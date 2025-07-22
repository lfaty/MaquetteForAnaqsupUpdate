using AutoMapper;
using MaquetteForAnaqsup.API.Identity.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace MaquetteForAnaqsup.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminRolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;

        public AdminRolesController(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
        }

        // GET: RolesController
        [HttpGet]
        [Route("GetRoles")]
        public async Task<ActionResult> GetRoles()
        {
            return Ok(mapper.Map<List<RoleDto>>(roleManager.Roles));
        }

        // GET: RolesController/Details/5
        [HttpGet]
        [Route("GetRole")]
        public async Task<IActionResult> GetRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null) { return NotFound(); }

            return Ok(mapper.Map<RoleDto>(role));
        }

        // POST: RolesController/Create
        [HttpPost]
        [Route("AddRole")]
        public async Task<ActionResult> AddRole([FromBody] AddRoleDto addRoleDto)
        {
            if (!ModelState.IsValid){ return BadRequest(ModelState); }
            
            var model = mapper.Map<IdentityRole>(addRoleDto);

            await roleManager.CreateAsync(model);

            return Ok();
        }

        [HttpPut]
        [Route("UpdateRole")]
        public async Task<IActionResult> UpdateRole(string id, [FromBody] UpdateRoleDto updateRoleDto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var role = await roleManager.FindByIdAsync(id);
            if (role == null) { return NotFound(); }

            if (role.Name != updateRoleDto.Name)
            {
                role.Name = updateRoleDto.Name;
            }

            var model = mapper.Map<IdentityRole>(role);
            await roleManager.UpdateAsync(model);

            return Ok();
        }

        // POST: RolesController/Delete/5
        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();

            await roleManager.DeleteAsync(role);

            return Ok();
        }
    }
}
