using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.BLL.DTOs.AnimalType;
using VeterinaryClinic.BLL.Services.Interfaces;
using VeterinaryClinic.BLL.Exceptions;
using Microsoft.IdentityModel.SecurityTokenService;

namespace VeterinaryClinic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalTypesController : ControllerBase
    {
        private readonly IAnimalTypeService _service;

        public AnimalTypesController(IAnimalTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalTypeDto>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AnimalTypeDto>> GetById(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            return dto != null ? Ok(dto) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<AnimalTypeDto>> Create(CreateAnimalTypeDto dto)
        {
            try
            {
                var id = await _service.CreateAsync(dto);
                var created = await _service.GetByIdAsync(id);
                return CreatedAtAction(nameof(GetById), new { id }, created);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, AnimalTypeDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            try
            {
                await _service.UpdateAsync(dto);
                return NoContent();
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (NotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }
    }
}
