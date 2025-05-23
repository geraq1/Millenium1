using Microsoft.AspNetCore.Mvc;
using Millenium1.DTOs;
using Millenium1.Services;

namespace Millenium1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusEquipmentController : ControllerBase
    {
        private readonly IStatusEquipmentService _service;

        public StatusEquipmentController(IStatusEquipmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<StatusEquipmentDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusEquipmentDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<StatusEquipmentDto>> Create(StatusEquipmentDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.StatusEquipmentId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StatusEquipmentDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}