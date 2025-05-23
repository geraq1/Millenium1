using Microsoft.AspNetCore.Mvc;
using Millenium1.DTOs;
using Millenium1.Services;

namespace Millenium1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusOrderController : ControllerBase
    {
        private readonly IStatusOrderService _service;

        public StatusOrderController(IStatusOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<StatusOrderDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusOrderDto>> GetById(int id)
        {
            var status = await _service.GetByIdAsync(id);
            if (status == null) return NotFound();
            return Ok(status);
        }

        [HttpPost]
        public async Task<ActionResult<StatusOrderDto>> Create(StatusOrderDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.StatusOrderId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StatusOrderDto dto)
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