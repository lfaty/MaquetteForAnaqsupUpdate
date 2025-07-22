using AutoMapper;
using MaquetteForAnaqsup.API.Models.Domain;
using MaquetteForAnaqsup.API.Models.DTO;
using MaquetteForAnaqsup.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MaquetteForAnaqsup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUnivUserRolesController : ControllerBase
    {
        private readonly IUniversiteUsersService _serviceUnivUser;
        private readonly IMapper _mapper;

        public AdminUnivUserRolesController(IUniversiteUsersService serviceUnivUser, IMapper mapper)
        {
            _serviceUnivUser = serviceUnivUser;
            _mapper = mapper;
        }

        // GET: api/Structures
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll(string? codeUniv, string? codeAnnee)
        {
            var lstDatas = await _serviceUnivUser.GetAllAsync(codeUniv, codeAnnee);
            // Create an exception
            //throw new Exception("This is a new exception");

            return Ok(_mapper.Map<List<UniversiteUserDto>>(lstDatas));
        }

        // GET: api/Structures/5
        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var data = await _serviceUnivUser.GetByIdAsync(id);
            if (data == null) { return NotFound(); }
            // Create an exception
            //throw new Exception("This is a new exception");

            return Ok(_mapper.Map<UniversiteUserDto>(data));
        }


        // GET: api/Structures/5
        [HttpGet]
        [Route("GetByIdDetail")]
        public async Task<ActionResult> GetByIdDetail([FromRoute] Guid id)
        {
            var data = await _serviceUnivUser.GetByIdDetail(id);
            if (data == null) { return NotFound(); }
            // Create an exception
            //throw new Exception("This is a new exception");

            return Ok(_mapper.Map<UniversiteUserDto>(data));
        }

        // GET: api/Structures/5
        [HttpGet]
        [Route("GetByIdStructure")]
        public async Task<ActionResult> GetByIdStructure([FromRoute] string idStruct)
        {
            var data = await _serviceUnivUser.GetByIdStructure(idStruct);
            if (data == null) { return NotFound(); }
            // Create an exception
            //throw new Exception("This is a new exception");

            return Ok(_mapper.Map<UniversiteUserDto>(data));
        }


        // GET: api/Structures/5
        [HttpGet]
        [Route("GetByIdUser")]
        public async Task<ActionResult> GetByIdUser([FromRoute] string idUser)
        {
            var data = await _serviceUnivUser.GetByIdUser(idUser);
            if (data == null) { return NotFound(); }
            // Create an exception
            //throw new Exception("This is a new exception");

            return Ok(_mapper.Map<UniversiteUserDto>(data));
        }

        // GET: api/Structures/5
        [HttpGet]
        [Route("GetByIdRole")]
        public async Task<ActionResult> GetByIdRole([FromRoute] string idRole)
        {
            var data = await _serviceUnivUser.GetByIdRole(idRole);
            if (data == null) { return NotFound(); }
            // Create an exception
            //throw new Exception("This is a new exception");

            return Ok(_mapper.Map<UniversiteUserDto>(data));
        }

        // POST: api/Structures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Add-Structure-User")]
        public async Task<ActionResult> Create([FromBody] AddUniversiteUserDto addModel)
        {
            var model = _mapper.Map<UniversiteUser>(addModel);
            model = await _serviceUnivUser.AddAsync(model);
            var modelDto = _mapper.Map<UniversiteUserDto>(model);

            return CreatedAtAction(nameof(GetById), new { id = modelDto.Id }, modelDto);
        }

        // PUT: api/Structures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut]
        [Route("Update-Structure-User")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUniversiteUserDto updateModel)
        {
            if (id != updateModel.Id) return BadRequest("Id not match");
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            // Check if the entity exists
            var existingEntity = await _serviceUnivUser.GetByIdAsync(id);
            if (existingEntity == null) return NotFound();

            existingEntity.UserId = updateModel.UserId;
            existingEntity.UniversiteId = updateModel.UniversiteId;
            existingEntity.RoleId = updateModel.RoleId;
            existingEntity.UpdateDate = DateTime.UtcNow;

            var model = _mapper.Map<UniversiteUser>(existingEntity);
            model = await _serviceUnivUser.UpdateAsync(model);

            return Ok(_mapper.Map<UniversiteUserDto>(model));
        }

        // DELETE: api/Structures/5
        [HttpDelete]
        [Route("Delete-Structure-User")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var data = await _serviceUnivUser.GetByIdAsync(id);
            if (data == null) return NotFound();

            await _serviceUnivUser.DeleteAsync(id);

            return Ok();
        }

        //// PATCH: api/Structures/5
        [HttpPatch]
        [Route("Statut")]
        public async Task<IActionResult> Statut([FromRoute] Guid id, StatutDto statutDto)
        {
            var model = _mapper.Map<UniversiteUser>(statutDto);
            await _serviceUnivUser.StatutAsync(id, model);

            return Ok(_mapper.Map<UniversiteUserDto>(model));
        }
    }
}
