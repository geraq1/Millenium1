using Microsoft.EntityFrameworkCore;
using Millenium1.DTOs;
using Millenium1.Models;

namespace Millenium1.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly MilleniumContext _context;

        public EquipmentService(MilleniumContext context)
        {
            _context = context;
        }

        public async Task<List<EquipmentDto>> GetAllAsync()
        {
            return await _context.Equipment
                .Select(e => new EquipmentDto
                {
                    EquipmentId = e.EquipmentId,
                    EquipmentName = e.EquipmentName,
                    Type = e.Type,
                    Model = e.Model,
                    StatusEquipmentId = e.StatusEquipmentId
                }).ToListAsync();
        }

        public async Task<EquipmentDto?> GetByIdAsync(int id)
        {
            var entity = await _context.Equipment.FindAsync(id);
            if (entity == null) return null;

            return new EquipmentDto
            {
                EquipmentId = entity.EquipmentId,
                EquipmentName = entity.EquipmentName,
                Type = entity.Type,
                Model = entity.Model,
                StatusEquipmentId = entity.StatusEquipmentId
            };
        }

        public async Task<EquipmentDto> CreateAsync(EquipmentDto dto)
        {
            var entity = new Equipment
            {
                EquipmentName = dto.EquipmentName,
                Type = dto.Type,
                Model = dto.Model,
                StatusEquipmentId = dto.StatusEquipmentId
            };

            _context.Equipment.Add(entity);
            await _context.SaveChangesAsync();

            dto.EquipmentId = entity.EquipmentId;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, EquipmentDto dto)
        {
            var entity = await _context.Equipment.FindAsync(id);
            if (entity == null) return false;

            entity.EquipmentName = dto.EquipmentName;
            entity.Type = dto.Type;
            entity.Model = dto.Model;
            entity.StatusEquipmentId = dto.StatusEquipmentId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Equipment.FindAsync(id);
            if (entity == null) return false;

            _context.Equipment.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}