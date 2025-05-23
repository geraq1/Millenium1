using Microsoft.EntityFrameworkCore;
using Millenium1.DTOs;
using Millenium1.Models;

namespace Millenium1.Services
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly MilleniumContext _context;

        public MaintenanceService(MilleniumContext context)
        {
            _context = context;
        }

        public async Task<List<MaintenanceDto>> GetAllAsync()
        {
            return await _context.Maintenances
                .Select(m => new MaintenanceDto
                {
                    MaintenanceId = m.MaintenanceId,
                    EquipmentId = m.EquipmentId,
                    MaintenanceDate = m.MaintenanceDate,
                    MaintenanceType = m.MaintenanceType,
                    MaintenanceDescription = m.MaintenanceDescription,
                    NextMaintenanceDate = m.NextMaintenanceDate
                }).ToListAsync();
        }

        public async Task<MaintenanceDto?> GetByIdAsync(int id)
        {
            var entity = await _context.Maintenances.FindAsync(id);
            if (entity == null) return null;

            return new MaintenanceDto
            {
                MaintenanceId = entity.MaintenanceId,
                EquipmentId = entity.EquipmentId,
                MaintenanceDate = entity.MaintenanceDate,
                MaintenanceType = entity.MaintenanceType,
                MaintenanceDescription = entity.MaintenanceDescription,
                NextMaintenanceDate = entity.NextMaintenanceDate
            };
        }

        public async Task<MaintenanceDto> CreateAsync(MaintenanceDto dto)
        {
            var entity = new Maintenance
            {
                EquipmentId = dto.EquipmentId,
                MaintenanceDate = dto.MaintenanceDate,
                MaintenanceType = dto.MaintenanceType,
                MaintenanceDescription = dto.MaintenanceDescription,
                NextMaintenanceDate = dto.NextMaintenanceDate
            };

            _context.Maintenances.Add(entity);
            await _context.SaveChangesAsync();

            dto.MaintenanceId = entity.MaintenanceId;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, MaintenanceDto dto)
        {
            var entity = await _context.Maintenances.FindAsync(id);
            if (entity == null) return false;

            entity.EquipmentId = dto.EquipmentId;
            entity.MaintenanceDate = dto.MaintenanceDate;
            entity.MaintenanceType = dto.MaintenanceType;
            entity.MaintenanceDescription = dto.MaintenanceDescription;
            entity.NextMaintenanceDate = dto.NextMaintenanceDate;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Maintenances.FindAsync(id);
            if (entity == null) return false;

            _context.Maintenances.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}