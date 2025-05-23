using Millenium1.DTOs;

namespace Millenium1.Services
{
    public interface IStatusDefectService
    {
        Task<List<StatusDefectDto>> GetAllAsync();
        Task<StatusDefectDto?> GetByIdAsync(int id);
        Task<StatusDefectDto> CreateAsync(StatusDefectDto dto);
        Task<bool> UpdateAsync(int id, StatusDefectDto dto);
        Task<bool> DeleteAsync(int id);
    }
}