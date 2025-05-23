using Microsoft.AspNetCore.Mvc;
using Millenium1.DTOs;
using Millenium1.Services;

namespace Millenium1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderHistoryController : ControllerBase
    {
        private readonly IOrderHistoryService _service;

        public OrderHistoryController(IOrderHistoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderHistoryDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderHistoryDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
    }
}