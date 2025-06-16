using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.BLL.DTOs.EmployeeSpecialty;
using VeterinaryClinic.BLL.Services.Interfaces;

namespace VeterinaryClinic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeSpecialtiesController : ControllerBase
    {
        private readonly IEmployeeSpecialtyService _service;
        public EmployeeSpecialtiesController(IEmployeeSpecialtyService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeSpecialtyDto>>> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeSpecialtyDto>> GetById(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            return dto != null ? Ok(dto) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeSpecialtyDto>> Create(CreateEmployeeSpecialtyDto dto)
        {
            var newId = await _service.CreateAsync(dto);
            var created = await _service.GetByIdAsync(newId);
            return CreatedAtAction(nameof(GetById), new { id = newId }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, EmployeeSpecialtyDto dto)
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
