using Microsoft.AspNetCore.Mvc;
using Millenium1.DTOs;
using Millenium1.Services;

namespace Millenium1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministratorsController : ControllerBase
    {
        private readonly IAdministratorService _adminService;

        public AdministratorsController(IAdministratorService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdministratorDto>>> GetAll() =>
            Ok(await _adminService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<AdministratorDto>> GetById(int id)
        {
            var admin = await _adminService.GetByIdAsync(id);
            if (admin == null) return NotFound();
            return Ok(admin);
        }

        [HttpPost]
        public async Task<ActionResult<AdministratorDto>> Create(AdministratorDto dto)
        {
            var created = await _adminService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.AdministratorId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AdministratorDto dto)
        {
            var updated = await _adminService.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _adminService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}