using AutoMapper;
using Azure.Core;
using MaquetteForAnaqsup.API.Identity.DTO;
using MaquetteForAnaqsup.API.Models.Domain;
using MaquetteForAnaqsup.API.Models.DTO;
using MaquetteForAnaqsup.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace MaquetteForAnaqsup.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUniversiteUsersService serviceUnivUser;
        private readonly IMapper mapper;

        public AdminUsersController(UserManager<IdentityUser> userManager, IMapper mapper, IUniversiteUsersService serviceUnivUser)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.serviceUnivUser = serviceUnivUser;
        }

        // GET: UsersController
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(mapper.Map<List<UserDto>>(userManager.Users));
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null) { return NotFound(); }

            return Ok(mapper.Map<UserDto>(user));
        }

        // POST : /api/Auth/Register
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] AddUserDto addUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await userManager.FindByEmailAsync(addUserDto.Username);
            if (existingUser != null)
            {
                return BadRequest("Email already exists");
            }

            IdentityUser identityUser = new IdentityUser();

            identityUser.UserName = addUserDto.Username;
            identityUser.Email = addUserDto.Username;
            identityUser.PasswordHash = addUserDto.Password;
                
            if(addUserDto.PhoneNumber is not null)
            {
                identityUser.PhoneNumber = addUserDto.PhoneNumber;
                identityUser.PhoneNumberConfirmed = true;
            }

            var identityResult = await userManager.CreateAsync(identityUser, addUserDto.Password);
            if (!identityResult.Succeeded) { return BadRequest("Something went wrong"); }

            // Add roles to this User
            if (addUserDto.Roles != null & addUserDto.Roles.Any())
            {
                //var roles = string.Join(",", registerDto.Roles);
                identityResult = await userManager.AddToRolesAsync(identityUser, addUserDto.Roles);
                if (identityResult.Succeeded)
                {
                    foreach (var item in addUserDto.Roles)
                    {
                        AddUniversiteUserDto addUnivUserDto = new AddUniversiteUserDto();
                        addUnivUserDto.UniversiteId = addUserDto.UniversiteId;
                        addUnivUserDto.UserId = identityUser.Id;
                        addUnivUserDto.RoleId = item;

                        var model = mapper.Map<UniversiteUser>(addUnivUserDto);
                        await serviceUnivUser.AddAsync(model);
                    }
                }
            }

            //Send Email Confirmation
            var user = await userManager.FindByEmailAsync(identityUser.Email);

            var emailCode = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(emailCode));

            // Pour Tester
            var confirmation = EmailConfirmation(user.Email, code);

            return Ok(confirmation);
        }


        [HttpPost]
        [Route("EmailConfirmation")]
        public async Task<IActionResult> EmailConfirmation([FromQuery] string email, string code)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user is null) { return BadRequest("Mail introuvable !"); }

            var codeSended = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await userManager.ConfirmEmailAsync(user, codeSended);

            if(!result.Succeeded) { return BadRequest(result.Errors); }

            return Ok("Confirmed Success !");
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var user = await userManager.FindByIdAsync(id);
            if (user == null) { return NotFound(); }

            if (user.UserName != updateUserDto.Username || user.PasswordHash != updateUserDto.Password)
            {
                user.UserName = updateUserDto.Username;
                user.PasswordHash = updateUserDto.Password;
            }

            var model = mapper.Map<IdentityUser>(user);
            await userManager.UpdateAsync(model);

            return Ok();
        }
    }
}
