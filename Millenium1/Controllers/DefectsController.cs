using Microsoft.AspNetCore.Mvc;
using Millenium1.DTOs;
using Millenium1.Services;

namespace Millenium1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DefectsController : ControllerBase
    {
        private readonly IDefectService _defectService;

        public DefectsController(IDefectService defectService)
        {
            _defectService = defectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DefectDto>>> GetAll() =>
            Ok(await _defectService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<DefectDto>> GetById(int id)
        {
            var defect = await _defectService.GetByIdAsync(id);
            if (defect == null) return NotFound();
            return Ok(defect);
        }

        [HttpPost]
        public async Task<ActionResult<DefectDto>> Create(DefectDto dto)
        {
            var created = await _defectService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.DefectId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DefectDto dto)
        {
            var updated = await _defectService.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _defectService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}