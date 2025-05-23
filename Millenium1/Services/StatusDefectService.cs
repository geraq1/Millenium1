using Microsoft.EntityFrameworkCore;
using Millenium1.DTOs;
using Millenium1.Models;

namespace Millenium1.Services
{
    public class StatusDefectService : IStatusDefectService
    {
        private readonly MilleniumContext _context;

        public StatusDefectService(MilleniumContext context)
        {
            _context = context;
        }

        public async Task<List<StatusDefectDto>> GetAllAsync()
        {
            return await _context.StatusDefects
                .Select(s => new StatusDefectDto
                {
                    StatusDefectsId = s.StatusDefectsId,
                    StatusDefectsNm = s.StatusDefectsNm
                })
                .ToListAsync();
        }

        public async Task<StatusDefectDto?> GetByIdAsync(int id)
        {
            var entity = await _context.StatusDefects.FindAsync(id);
            if (entity == null) return null;

            return new StatusDefectDto
            {
                StatusDefectsId = entity.StatusDefectsId,
                StatusDefectsNm = entity.StatusDefectsNm
            };
        }

        public async Task<StatusDefectDto> CreateAsync(StatusDefectDto dto)
        {
            var entity = new StatusDefect
            {
                StatusDefectsNm = dto.StatusDefectsNm
            };

            _context.StatusDefects.Add(entity);
            await _context.SaveChangesAsync();

            dto.StatusDefectsId = entity.StatusDefectsId;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, StatusDefectDto dto)
        {
            var entity = await _context.StatusDefects.FindAsync(id);
            if (entity == null) return false;

            entity.StatusDefectsNm = dto.StatusDefectsNm;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.StatusDefects.FindAsync(id);
            if (entity == null) return false;

            _context.StatusDefects.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}