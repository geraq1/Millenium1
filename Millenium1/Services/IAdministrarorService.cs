using Millenium1.DTOs;

namespace Millenium1.Services
{
    public interface IAdministratorService
    {
        Task<List<AdministratorDto>> GetAllAsync();
        Task<AdministratorDto?> GetByIdAsync(int id);
        Task<AdministratorDto> CreateAsync(AdministratorDto dto);
        Task<bool> UpdateAsync(int id, AdministratorDto dto);
        Task<bool> DeleteAsync(int id);
    }
}