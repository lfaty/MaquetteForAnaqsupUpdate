using AutoMapper;
using MaquetteForAnaqsup.API.Identity.DTO;
using MaquetteForAnaqsup.API.Identity.Repositories;
using MaquetteForAnaqsup.API.Models.Domain;
using MaquetteForAnaqsup.API.Models.DTO;
using MaquetteForAnaqsup.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MaquetteForAnaqsup.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ITokenRepository tokenRepository;
        private readonly IUniversiteUsersService serviceStructureUser;
        private readonly IMapper mapper;
        private readonly IEmailSender sender;

        public AccountsController(UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            ITokenRepository tokenRepository, 
            IMapper mapper,
            IEmailSender sender,
            IUniversiteUsersService serviceStructureUser)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.tokenRepository = tokenRepository;
            this.mapper = mapper;
            this.sender = sender;
            this.serviceStructureUser = serviceStructureUser;
        }

        // POST : /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var existingUser = await userManager.FindByEmailAsync(registerDto.Username);
            if (existingUser != null) { return BadRequest("Email already exists"); }

            IdentityUser identityUser = new IdentityUser();

            identityUser.UserName = registerDto.Username;
            identityUser.Email = registerDto.Username;
            identityUser.PasswordHash = registerDto.Password;

            if (registerDto.PhoneNumber is not null)
            {
                identityUser.PhoneNumber = registerDto.PhoneNumber;
                identityUser.PhoneNumberConfirmed = true;
            }

            var identityResult = await userManager.CreateAsync(identityUser, registerDto.Password);
            if (!identityResult.Succeeded) { BadRequest(identityResult.Errors); }

            // Add roles to this User
            if (registerDto.Roles != null & registerDto.Roles.Any())
            {
                identityResult = await userManager.AddToRolesAsync(identityUser, registerDto.Roles);
                if (identityResult.Succeeded)
                {
                    foreach (var item in registerDto.Roles)
                    {
                        AddUniversiteUserDto addStructureUserDto = new AddUniversiteUserDto();
                        addStructureUserDto.UniversiteId = registerDto.UniversiteId;
                        addStructureUserDto.UserId = identityUser.UserName;
                        addStructureUserDto.RoleId = item;

                        var model = mapper.Map<UniversiteUser>(addStructureUserDto);
                        await serviceStructureUser.AddAsync(model);
                    }
                }
            }

            //Send Email Confirmation
            var user = await userManager.FindByEmailAsync(identityUser.Email);

            var emailCode = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(emailCode));

            //EmailConfirmation(user.Email, code);
            var confirmationLink = Url.Action("EmailConfirmation", "Accounts", new { email = user.Email, code = code }, Request.Scheme);
            //var confirmationLink = $"https://localhost:44326/api/Auth/EmailConfirmation?email={user.Email}&code={code}";

            string email = user.Email;
            string subject = "Mail de confirmation";
            string message = "Merci de trouver le lien d'activation : " + confirmationLink;

            await sender.SendEmailAsync(email, subject, message);

            return Ok("Un mail vous a été envoyé pour l'activation du compte !");

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


        // POST : /api/auth/login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            if (loginRequestDto == null) { return BadRequest("Login request is null");}

            var user = await userManager.FindByEmailAsync(loginRequestDto.UserName);
            if (user == null || !await userManager.CheckPasswordAsync(user, loginRequestDto.Password))
            {
                return BadRequest("Username or password incorrect");
            }

            LoginResponseDto response = new LoginResponseDto();
            // Get Roles for this user
            var roles = await userManager.GetRolesAsync(user);
            if (roles != null)
            {
                // Create Token
                var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());
                response.JwtToken = jwtToken;
                response.Username = user.UserName;
                response.UserId = user.Id;
                response.Roles = roles.ToList();
            }
            return Ok(response);
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user is null) { return BadRequest("Mail introuvable !"); }

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var forgotPasswordLink = Url.Action("ResetPassword", "Accounts", new { email = user.Email, code = token }, Request.Scheme);

            //string email = user.Email;
            string subject = "Forgot Password Link";
            string message = "Cliquer pour initialiser le password : " + forgotPasswordLink;

            sender.SendEmailAsync(email, subject, message);

            return StatusCode(StatusCodes.Status200OK, $"Un mail vous a été envoyé à {user.Email} pour l'initialisation du mot de passe !");
        }
    }
}
