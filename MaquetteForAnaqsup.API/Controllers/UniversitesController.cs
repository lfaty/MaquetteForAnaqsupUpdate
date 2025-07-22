using AutoMapper;
using MaquetteForAnaqsup.API.Models.Domain;
using MaquetteForAnaqsup.API.Models.DTO;
using MaquetteForAnaqsup.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaquetteForAnaqsup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitesController : ControllerBase
    {
        private readonly IUniversitesService _serviceUniversite;
        private readonly IMapper _mapper;

        public UniversitesController(IMapper mapper, IUniversitesService serviceUniversite)
        {
            _serviceUniversite = serviceUniversite;
            _mapper = mapper;
        }

        // GET: api/Universites
        [HttpGet]
        public async Task<ActionResult> GetAll(string? CodeUniv, string? CodeAnnee)
        {
            var lstDatas = await _serviceUniversite.GetAllAsync(CodeUniv, CodeAnnee);
            return Ok(_mapper.Map<List<UniversiteDto>>(lstDatas));
        }

        // GET: api/Universites/5
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetById([FromRoute] Guid id)
        {
            var data = await _serviceUniversite.GetByIdAsync(id);
            if (data == null) { return NotFound(); }
            return Ok(_mapper.Map<UniversiteDto>(data));
        }

        // POST: api/Universites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AddUniversiteDto addModel)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var model = _mapper.Map<Universite>(addModel);
            model = await _serviceUniversite.AddAsync(model);
            var modelDto = _mapper.Map<UniversiteDto>(model);

            return CreatedAtAction(nameof(GetById), new { id = modelDto.Id }, modelDto);
        }

        // PUT: api/Universites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUniversiteDto updateModel)
        {
            if (id != updateModel.Id) return BadRequest("Id not match");
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            // Check if the entity exists
            var existingEntity = await _serviceUniversite.GetByIdAsync(id);
            if (existingEntity == null) return NotFound();
            // Update the properties
            existingEntity.CodeUniv = updateModel.CodeUniv;
            existingEntity.NomUniversite = updateModel.NomUniversite;
            existingEntity.SloganUniversite = updateModel.SloganUniversite;
            existingEntity.AdresseUniversite = updateModel.AdresseUniversite;
            existingEntity.UrlLogo = updateModel.UrlLogo;
            existingEntity.DateUpdate = DateTime.Now;
            var model = _mapper.Map<Universite>(existingEntity);
            model = await _serviceUniversite.UpdateAsync(model);

            return Ok(_mapper.Map<UniversiteDto>(model));
        }

        // DELETE: api/Universites/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var data = await _serviceUniversite.GetByIdAsync(id);
            if (data == null) return NotFound();

            await _serviceUniversite.DeleteAsync(id);

            return Ok();
        }
    }
}
