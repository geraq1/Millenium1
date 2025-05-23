using Microsoft.EntityFrameworkCore;
using Millenium1.DTOs;
using Millenium1.Models;

namespace Millenium1.Services
{
    public class FabricService : IFabricService
    {
        private readonly MilleniumContext _context;

        public FabricService(MilleniumContext context)
        {
            _context = context;
        }

        public async Task<List<FabricDto>> GetAllAsync()
        {
            return await _context.Fabrics
                .Select(f => new FabricDto
                {
                    FabricId = f.FabricId,
                    FabName = f.FabName,
                    PricePerMeter = f.PricePerMeter,
                    Description = f.Description,
                    MaterialType = f.MaterialType,
                    SupplierId = f.SupplierId
                })
                .ToListAsync();
        }

        public async Task<FabricDto?> GetByIdAsync(int id)
        {
            var fabric = await _context.Fabrics.FindAsync(id);
            if (fabric == null) return null;

            return new FabricDto
            {
                FabricId = fabric.FabricId,
                FabName = fabric.FabName,
                PricePerMeter = fabric.PricePerMeter,
                Description = fabric.Description,
                MaterialType = fabric.MaterialType,
                SupplierId = fabric.SupplierId
            };
        }

        public async Task<FabricDto> CreateAsync(FabricDto dto)
        {
            var entity = new Fabric
            {
                FabName = dto.FabName,
                PricePerMeter = dto.PricePerMeter,
                Description = dto.Description,
                MaterialType = dto.MaterialType,
                SupplierId = dto.SupplierId
            };

            _context.Fabrics.Add(entity);
            await _context.SaveChangesAsync();

            dto.FabricId = entity.FabricId;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, FabricDto dto)
        {
            var entity = await _context.Fabrics.FindAsync(id);
            if (entity == null) return false;

            entity.FabName = dto.FabName;
            entity.PricePerMeter = dto.PricePerMeter;
            entity.Description = dto.Description;
            entity.MaterialType = dto.MaterialType;
            entity.SupplierId = dto.SupplierId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Fabrics.FindAsync(id);
            if (entity == null) return false;

            _context.Fabrics.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}