using Microsoft.EntityFrameworkCore;
using Millenium1.DTOs;
using Millenium1.Models;

namespace Millenium1.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly MilleniumContext _context;

        public AdministratorService(MilleniumContext context)
        {
            _context = context;
        }

        public async Task<List<AdministratorDto>> GetAllAsync()
        {
            return await _context.Administrators
                .Select(a => new AdministratorDto
                {
                    AdministratorId = a.AdministratorId,
                    AdministratorFio = a.AdministratorFio,
                    AdministratorEmail = a.AdministratorEmail,
                    AdministratorPhone = a.AdministratorPhone,
                    CreatedAt = a.CreatedAt,
                    IsActive = a.IsActive
                }).ToListAsync();
        }

        public async Task<AdministratorDto?> GetByIdAsync(int id)
        {
            var admin = await _context.Administrators.FindAsync(id);
            if (admin == null) return null;

            return new AdministratorDto
            {
                AdministratorId = admin.AdministratorId,
                AdministratorFio = admin.AdministratorFio,
                AdministratorEmail = admin.AdministratorEmail,
                AdministratorPhone = admin.AdministratorPhone,
                CreatedAt = admin.CreatedAt,
                IsActive = admin.IsActive
            };
        }

        public async Task<AdministratorDto> CreateAsync(AdministratorDto dto)
        {
            var entity = new Administrator
            {
                AdministratorFio = dto.AdministratorFio,
                AdministratorEmail = dto.AdministratorEmail,
                AdministratorPhone = dto.AdministratorPhone,
                CreatedAt = dto.CreatedAt,
                IsActive = dto.IsActive
            };

            _context.Administrators.Add(entity);
            await _context.SaveChangesAsync();

            dto.AdministratorId = entity.AdministratorId;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, AdministratorDto dto)
        {
            var entity = await _context.Administrators.FindAsync(id);
            if (entity == null) return false;

            entity.AdministratorFio = dto.AdministratorFio;
            entity.AdministratorEmail = dto.AdministratorEmail;
            entity.AdministratorPhone = dto.AdministratorPhone;
            entity.CreatedAt = dto.CreatedAt;
            entity.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Administrators.FindAsync(id);
            if (entity == null) return false;

            _context.Administrators.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}