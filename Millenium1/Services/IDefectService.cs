using Millenium1.DTOs;

namespace Millenium1.Services
{
    public interface IDefectService
    {
        Task<List<DefectDto>> GetAllAsync();
        Task<DefectDto?> GetByIdAsync(int id);
        Task<DefectDto> CreateAsync(DefectDto dto);
        Task<bool> UpdateAsync(int id, DefectDto dto);
        Task<bool> DeleteAsync(int id);
    }
}