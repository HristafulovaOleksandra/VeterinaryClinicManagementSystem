using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.BLL.DTOs.AnimalDisease;
using VeterinaryClinic.BLL.Services.Interfaces;

namespace VeterinaryClinic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalDiseasesController : ControllerBase
    {
        private readonly IAnimalDiseaseService _service;

        public AnimalDiseasesController(IAnimalDiseaseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalDiseaseDto>>> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AnimalDiseaseDto>> GetById(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            return dto != null ? Ok(dto) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<AnimalDiseaseDto>> Create(CreateAnimalDiseaseDto dto)
        {
            var newId = await _service.CreateAsync(dto);
            var created = await _service.GetByIdAsync(newId);
            return CreatedAtAction(nameof(GetById), new { id = newId }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, AnimalDiseaseDto dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch");
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
