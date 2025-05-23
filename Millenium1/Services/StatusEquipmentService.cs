using Microsoft.EntityFrameworkCore;
using Millenium1.DTOs;
using Millenium1.Models;

namespace Millenium1.Services
{
    public class StatusEquipmentService : IStatusEquipmentService
    {
        private readonly MilleniumContext _context;

        public StatusEquipmentService(MilleniumContext context)
        {
            _context = context;
        }

        public async Task<List<StatusEquipmentDto>> GetAllAsync()
        {
            return await _context.StatusEquipments
                .Select(e => new StatusEquipmentDto
                {
                    StatusEquipmentId = e.StatusEquipmentId,
                    StatusEquipmentNm = e.StatusEquipmentNm
                }).ToListAsync();
        }

        public async Task<StatusEquipmentDto?> GetByIdAsync(int id)
        {
            var entity = await _context.StatusEquipments.FindAsync(id);
            if (entity == null) return null;

            return new StatusEquipmentDto
            {
                StatusEquipmentId = entity.StatusEquipmentId,
                StatusEquipmentNm = entity.StatusEquipmentNm
            };
        }

        public async Task<StatusEquipmentDto> CreateAsync(StatusEquipmentDto dto)
        {
            var entity = new StatusEquipment
            {
                StatusEquipmentNm = dto.StatusEquipmentNm
            };
            _context.StatusEquipments.Add(entity);
            await _context.SaveChangesAsync();

            dto.StatusEquipmentId = entity.StatusEquipmentId;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, StatusEquipmentDto dto)
        {
            var entity = await _context.StatusEquipments.FindAsync(id);
            if (entity == null) return false;

            entity.StatusEquipmentNm = dto.StatusEquipmentNm;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.StatusEquipments.FindAsync(id);
            if (entity == null) return false;

            _context.StatusEquipments.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}