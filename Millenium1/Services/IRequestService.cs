using Millenium1.DTOs;

namespace Millenium1.Services
{
    public interface IRequestService
    {
        Task<List<RequestDto>> GetAllAsync();
        Task<RequestDto?> GetByIdAsync(int id);
        Task<RequestDto> CreateAsync(RequestDto dto);
        Task<bool> UpdateAsync(int id, RequestDto dto);
        Task<bool> DeleteAsync(int id);
    }
}