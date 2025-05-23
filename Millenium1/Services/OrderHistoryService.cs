using Microsoft.EntityFrameworkCore;
using Millenium1.DTOs;
using Millenium1.Models;

namespace Millenium1.Services
{
    public class OrderHistoryService : IOrderHistoryService
    {
        private readonly MilleniumContext _context;

        public OrderHistoryService(MilleniumContext context)
        {
            _context = context;
        }

        public async Task<List<OrderHistoryDto>> GetAllAsync()
        {
            return await _context.OrderHistories
                .Select(h => new OrderHistoryDto
                {
                    Histid = h.Histid,
                    Clientid = h.Clientid,
                    Orderid = h.Orderid,
                    Date = h.Date
                })
                .ToListAsync();
        }

        public async Task<OrderHistoryDto?> GetByIdAsync(int id)
        {
            var h = await _context.OrderHistories.FindAsync(id);
            if (h == null) return null;

            return new OrderHistoryDto
            {
                Histid = h.Histid,
                Clientid = h.Clientid,
                Orderid = h.Orderid,
                Date = h.Date
            };
        }
    }
}