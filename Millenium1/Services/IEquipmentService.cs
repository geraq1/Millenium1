using Millenium1.DTOs;

namespace Millenium1.Services
{
    public interface IEquipmentService
    {
        Task<List<EquipmentDto>> GetAllAsync();
        Task<EquipmentDto?> GetByIdAsync(int id);
        Task<EquipmentDto> CreateAsync(EquipmentDto dto);
        Task<bool> UpdateAsync(int id, EquipmentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}