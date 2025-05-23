using Millenium1.DTOs;

namespace Millenium1.Services
{
    public interface IMaintenanceService
    {
        Task<List<MaintenanceDto>> GetAllAsync();
        Task<MaintenanceDto?> GetByIdAsync(int id);
        Task<MaintenanceDto> CreateAsync(MaintenanceDto dto);
        Task<bool> UpdateAsync(int id, MaintenanceDto dto);
        Task<bool> DeleteAsync(int id);
    }
}