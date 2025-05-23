using Microsoft.EntityFrameworkCore;
using Millenium1.DTOs;
using Millenium1.Models;

namespace Millenium1.Services
{
    public class DefectService : IDefectService
    {
        private readonly MilleniumContext _context;

        public DefectService(MilleniumContext context)
        {
            _context = context;
        }

        public async Task<List<DefectDto>> GetAllAsync()
        {
            return await _context.Defects
                .Select(d => new DefectDto
                {
                    DefectId = d.DefectId,
                    OrderId = d.OrderId,
                    ProductId = d.ProductId,
                    Description = d.Description,
                    StatusDefectsId = d.StatusDefectsId
                }).ToListAsync();
        }

        public async Task<DefectDto?> GetByIdAsync(int id)
        {
            var defect = await _context.Defects.FindAsync(id);
            if (defect == null) return null;

            return new DefectDto
            {
                DefectId = defect.DefectId,
                OrderId = defect.OrderId,
                ProductId = defect.ProductId,
                Description = defect.Description,
                StatusDefectsId = defect.StatusDefectsId
            };
        }

        public async Task<DefectDto> CreateAsync(DefectDto dto)
        {
            var entity = new Defect
            {
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                Description = dto.Description,
                StatusDefectsId = dto.StatusDefectsId
            };

            _context.Defects.Add(entity);
            await _context.SaveChangesAsync();

            dto.DefectId = entity.DefectId;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, DefectDto dto)
        {
            var entity = await _context.Defects.FindAsync(id);
            if (entity == null) return false;

            entity.OrderId = dto.OrderId;
            entity.ProductId = dto.ProductId;
            entity.Description = dto.Description;
            entity.StatusDefectsId = dto.StatusDefectsId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Defects.FindAsync(id);
            if (entity == null) return false;

            _context.Defects.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}