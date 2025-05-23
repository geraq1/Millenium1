using Microsoft.AspNetCore.Mvc;
using Millenium1.DTOs;
using Millenium1.Services;

namespace Millenium1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FabricsController : ControllerBase
    {
        private readonly IFabricService _fabricService;

        public FabricsController(IFabricService fabricService)
        {
            _fabricService = fabricService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FabricDto>>> GetAll() =>
            Ok(await _fabricService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<FabricDto>> GetById(int id)
        {
            var fabric = await _fabricService.GetByIdAsync(id);
            if (fabric == null) return NotFound();
            return Ok(fabric);
        }

        [HttpPost]
        public async Task<ActionResult<FabricDto>> Create(FabricDto dto)
        {
            var created = await _fabricService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.FabricId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FabricDto dto)
        {
            var updated = await _fabricService.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _fabricService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}