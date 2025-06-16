using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.BLL.DTOs.HospitalDepartment;
using VeterinaryClinic.BLL.Services.Interfaces;

namespace VeterinaryClinic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalDepartmentsController : ControllerBase
    {
        private readonly IHospitalDepartmentService _service;
        public HospitalDepartmentsController(IHospitalDepartmentService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalDepartmentDto>>> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<HospitalDepartmentDto>> GetById(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            return dto != null ? Ok(dto) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<HospitalDepartmentDto>> Create(CreateHospitalDepartmentDto dto)
        {
            var newId = await _service.CreateAsync(dto);
            var created = await _service.GetByIdAsync(newId);
            return CreatedAtAction(nameof(GetById), new { id = newId }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, HospitalDepartmentDto dto)
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
