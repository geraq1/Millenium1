using Microsoft.EntityFrameworkCore;
using Millenium1.DTOs;
using Millenium1.Models;

namespace Millenium1.Services
{
    public class StatusOrderService : IStatusOrderService
    {
        private readonly MilleniumContext _context;

        public StatusOrderService(MilleniumContext context)
        {
            _context = context;
        }

        public async Task<List<StatusOrderDto>> GetAllAsync()
        {
            return await _context.StatusOrders
                .Select(s => new StatusOrderDto
                {
                    StatusOrderId = s.StatusOrderId,
                    StatusOrderNm = s.StatusOrderNm
                }).ToListAsync();
        }

        public async Task<StatusOrderDto?> GetByIdAsync(int id)
        {
            var status = await _context.StatusOrders.FindAsync(id);
            if (status == null) return null;

            return new StatusOrderDto
            {
                StatusOrderId = status.StatusOrderId,
                StatusOrderNm = status.StatusOrderNm
            };
        }

        public async Task<StatusOrderDto> CreateAsync(StatusOrderDto dto)
        {
            var entity = new StatusOrder
            {
                StatusOrderNm = dto.StatusOrderNm
            };
            _context.StatusOrders.Add(entity);
            await _context.SaveChangesAsync();

            dto.StatusOrderId = entity.StatusOrderId;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, StatusOrderDto dto)
        {
            var entity = await _context.StatusOrders.FindAsync(id);
            if (entity == null) return false;

            entity.StatusOrderNm = dto.StatusOrderNm;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.StatusOrders.FindAsync(id);
            if (entity == null) return false;

            _context.StatusOrders.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}