using Microsoft.EntityFrameworkCore;
using Millenium1.DTOs;
using Millenium1.Models;
using System.Diagnostics.Metrics;

namespace Millenium1.Services
{
    public class SewerService : ISewerService
    {
        private readonly MilleniumContext _context;

        public SewerService(MilleniumContext context)
        {
            _context = context;
        }

        public async Task<List<SewerDto>> GetAllAsync()
        {
            return await _context.Sewers
                .Select(s => new SewerDto
                {
                    SewerId = s.SewerId,
                    SewerFio = s.SewerFio,
                    SkillLevel = s.SkillLevel
                })
                .ToListAsync();
        }

        public async Task<SewerDto?> GetByIdAsync(int id)
        {
            var sewer = await _context.Sewers.FindAsync(id);
            if (sewer == null) return null;

            return new SewerDto
            {
                SewerId = sewer.SewerId,
                SewerFio = sewer.SewerFio,
                SkillLevel = sewer.SkillLevel
            };
        }

        public async Task<SewerDto> CreateAsync(SewerDto dto)
        {
            var entity = new Sewer
            {
                SewerFio = dto.SewerFio,
                SkillLevel = dto.SkillLevel
            };

            _context.Sewers.Add(entity);
            await _context.SaveChangesAsync();

            dto.SewerId = entity.SewerId;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, SewerDto dto)
        {
            var entity = await _context.Sewers.FindAsync(id);
            if (entity == null) return false;

            entity.SewerFio = dto.SewerFio;
            entity.SkillLevel = dto.SkillLevel;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Sewers.FindAsync(id);
            if (entity == null) return false;

            _context.Sewers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}