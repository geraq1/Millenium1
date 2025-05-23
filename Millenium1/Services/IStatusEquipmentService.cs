using Millenium1.DTOs;

namespace Millenium1.Services
{
    public interface IStatusEquipmentService
    {
        Task<List<StatusEquipmentDto>> GetAllAsync();
        Task<StatusEquipmentDto?> GetByIdAsync(int id);
        Task<StatusEquipmentDto> CreateAsync(StatusEquipmentDto dto);
        Task<bool> UpdateAsync(int id, StatusEquipmentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}