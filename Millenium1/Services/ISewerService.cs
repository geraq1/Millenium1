using Millenium1.DTOs;

namespace Millenium1.Services
{
    public interface ISewerService
    {
        Task<List<SewerDto>> GetAllAsync();
        Task<SewerDto?> GetByIdAsync(int id);
        Task<SewerDto> CreateAsync(SewerDto dto);
        Task<bool> UpdateAsync(int id, SewerDto dto);
        Task<bool> DeleteAsync(int id);
    }
}