using Millenium1.Models;
using Millenium1.DTOs;
using Microsoft.EntityFrameworkCore;
using Millenium1.Services;
namespace Millenium1.Services
{
    public class OrderService : IOrderService
    {
        private readonly MilleniumContext _context;

        public OrderService(MilleniumContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            return await _context.Orders
                .Select(o => new OrderDto
                {
                    Orderid = o.Orderid,
                    AdministratorId = o.AdministratorId,
                    SewerId = o.SewerId,
                    FabricId = o.FabricId,
                    ClientId = o.Clientid,
                    TotalAmount = o.TotalAmount,
                    OrderDate = o.OrderDate,
                    DueDate = o.DueDate,
                    StatusOrderId = o.StatusOrderId
                })
                .ToListAsync();
        }

        public async Task<OrderDto?> GetByIdAsync(int id)
        {
            var o = await _context.Orders.FindAsync(id);
            if (o == null) return null;

            return new OrderDto
            {
                Orderid = o.Orderid,
                AdministratorId = o.AdministratorId,
                SewerId = o.SewerId,
                FabricId = o.FabricId,
                ClientId = o.Clientid,
                TotalAmount = o.TotalAmount,
                OrderDate = o.OrderDate,
                DueDate = o.DueDate,
                StatusOrderId = o.StatusOrderId
            };
        }

        public async Task<OrderDto> CreateAsync(OrderDto dto)
        {
            var o = new Order
            {
                AdministratorId = dto.AdministratorId,
                SewerId = dto.SewerId,
                FabricId = dto.FabricId,
                Clientid = dto.ClientId,
                TotalAmount = dto.TotalAmount,
                OrderDate = dto.OrderDate,
                DueDate = dto.DueDate,
                StatusOrderId = dto.StatusOrderId
            };

            _context.Orders.Add(o);
            await _context.SaveChangesAsync();

            dto.Orderid = o.Orderid;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, OrderDto dto)
        {
            var o = await _context.Orders.FindAsync(id);
            if (o == null) return false;

            o.AdministratorId = dto.AdministratorId;
            o.SewerId = dto.SewerId;
            o.FabricId = dto.FabricId;
            o.Clientid = dto.ClientId;
            o.TotalAmount = dto.TotalAmount;
            o.OrderDate = dto.OrderDate;
            o.DueDate = dto.DueDate;
            o.StatusOrderId = dto.StatusOrderId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var o = await _context.Orders.FindAsync(id);
            if (o == null) return false;

            _context.Orders.Remove(o);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
