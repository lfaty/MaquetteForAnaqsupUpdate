using AutoMapper;
using MaquetteForAnaqsup.API.Models.Domain;
using MaquetteForAnaqsup.API.Models.DTO;
using MaquetteForAnaqsup.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaquetteForAnaqsup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AdminAnneesController : ControllerBase
    {
        private readonly IAnneeMaquettesService _serviceAnne;
        private readonly IMapper _mapper;

        public AdminAnneesController(IMapper mapper, IAnneeMaquettesService serviceAnne)
        {
            _serviceAnne = serviceAnne;
            _mapper = mapper;
        }

        // GET: api/AnneeExercices
        [HttpGet]
        [Route("Liste-Annees")]
        public async Task<ActionResult> GetAll(string? codeUniv, string? annee)
        {
            // Create an exception
            //throw new Exception("This is a new exception");
            return Ok(_mapper.Map<List<AnneeMaquetteDto>>(await _serviceAnne.GetAllAsync(codeUniv, annee)));
        }

        // GET: api/AnneeExercices/5
        [HttpGet]
        [Route("Details-Annee")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var data = await _serviceAnne.GetByIdAsync(id);
            if (data == null) { return NotFound(); }

            // Create an exception
            //throw new Exception("This is a new exception");
            return Ok(_mapper.Map<AnneeMaquetteDto>(data));
        }

        // POST: api/AnneeExercices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Ajout-Annee")]
        public async Task<ActionResult> Create([FromBody] AddAnneeMaquetteDto addModel)
        {
            var model = _mapper.Map<AnneeMaquette>(addModel);

            model = await _serviceAnne.AddAsync(model);

            var modelDto = _mapper.Map<AnneeMaquetteDto>(model);

            return CreatedAtAction(nameof(GetById), new { id = modelDto.Id }, modelDto);
        }

        // PUT: api/AnneeExercices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("Modif-Annee")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAnneeMaquetteDto updateModel)
        {
            if (id != updateModel.Id) return BadRequest("Id not match");
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            // Check if the entity exists
            var existingEntity = await _serviceAnne.GetByIdAsync(id);
            if (existingEntity == null) return NotFound();

            existingEntity.Libelle = updateModel.Libelle;
            existingEntity.UpdateDate = DateTime.UtcNow;

            var model = _mapper.Map<AnneeMaquette>(existingEntity);
            model = await _serviceAnne.UpdateAsync(model);
            return Ok(_mapper.Map<AnneeMaquetteDto>(model));
        }

        // DELETE: api/AnneeExercices/5
        [HttpDelete]
        [Route("Supprime-Annee")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var data = await _serviceAnne.GetByIdAsync(id);
            if (data == null) return NotFound();
            await _serviceAnne.DeleteAsync(id);
            return Ok();
        }

        // PATCH: api/AnneeExercices/5
        [HttpPatch]
        [Route("Statut-Annee")]
        public async Task<IActionResult> Statut(Guid id, StatutDto statutDto)
        {
            var model = _mapper.Map<AnneeMaquette>(statutDto);
            await _serviceAnne.StatutAsync(id, model);
            return Ok(_mapper.Map<AnneeMaquetteDto>(model));
        }
    }
}
