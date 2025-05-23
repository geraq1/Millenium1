using Microsoft.EntityFrameworkCore;
using Millenium1.DTOs;
using Millenium1.Models;

namespace Millenium1.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly MilleniumContext _context;

        public WarehouseService(MilleniumContext context)
        {
            _context = context;
        }

        public async Task<List<WarehouseDto>> GetAllAsync()
        {
            return await _context.Warehouses
                .Select(w => new WarehouseDto
                {
                    WarehouseId = w.WarehouseId,
                    FabricId = w.FabricId,
                    QuantityInStock = w.QuantityInStock
                }).ToListAsync();
        }

        public async Task<WarehouseDto?> GetByIdAsync(int id)
        {
            var w = await _context.Warehouses.FindAsync(id);
            if (w == null) return null;

            return new WarehouseDto
            {
                WarehouseId = w.WarehouseId,
                FabricId = w.FabricId,
                QuantityInStock = w.QuantityInStock
            };
        }

        public async Task<WarehouseDto> CreateAsync(WarehouseDto dto)
        {
            var w = new Warehouse
            {
                FabricId = dto.FabricId,
                QuantityInStock = dto.QuantityInStock
            };

            _context.Warehouses.Add(w);
            await _context.SaveChangesAsync();

            dto.WarehouseId = w.WarehouseId;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, WarehouseDto dto)
        {
            var w = await _context.Warehouses.FindAsync(id);
            if (w == null) return false;

            w.FabricId = dto.FabricId;
            w.QuantityInStock = dto.QuantityInStock;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var w = await _context.Warehouses.FindAsync(id);
            if (w == null) return false;

            _context.Warehouses.Remove(w);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}