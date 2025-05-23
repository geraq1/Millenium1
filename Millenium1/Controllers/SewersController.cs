using Microsoft.AspNetCore.Mvc;
using Millenium1.DTOs;
using Millenium1.Services;

namespace Millenium1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SewersController : ControllerBase
    {
        private readonly ISewerService _sewerService;

        public SewersController(ISewerService sewerService)
        {
            _sewerService = sewerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SewerDto>>> GetAll() =>
            Ok(await _sewerService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<SewerDto>> GetById(int id)
        {
            var sewer = await _sewerService.GetByIdAsync(id);
            if (sewer == null) return NotFound();
            return Ok(sewer);
        }

        [HttpPost]
        public async Task<ActionResult<SewerDto>> Create(SewerDto dto)
        {
            var created = await _sewerService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.SewerId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SewerDto dto)
        {
            var updated = await _sewerService.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _sewerService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}