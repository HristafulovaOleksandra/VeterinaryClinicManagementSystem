using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.BLL.DTOs.AnimalMedicalRecord;
using VeterinaryClinic.BLL.Services.Interfaces;
using VeterinaryClinic.DAL.Entities.HelpModels;

namespace VeterinaryClinic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalMedicalRecordsController : ControllerBase
    {
        private readonly IAnimalMedicalRecordService _service;
        public AnimalMedicalRecordsController(IAnimalMedicalRecordService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] AnimalMedicalRecordParameters parameters)
        {
            var result = await _service.GetAllAsync(parameters);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AnimalMedicalRecordDto>> GetById(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            return dto != null ? Ok(dto) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<AnimalMedicalRecordDto>> Create(CreateAnimalMedicalRecordDto dto)
        {
            var newId = await _service.CreateAsync(dto);
            var created = await _service.GetByIdAsync(newId);
            return CreatedAtAction(nameof(GetById), new { id = newId }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, AnimalMedicalRecordDto dto)
        {
            if (id != dto.Id) return BadRequest();
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
