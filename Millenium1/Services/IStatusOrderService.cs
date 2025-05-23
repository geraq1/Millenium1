using Millenium1.DTOs;

namespace Millenium1.Services
{
    public interface IStatusOrderService
    {
        Task<List<StatusOrderDto>> GetAllAsync();
        Task<StatusOrderDto?> GetByIdAsync(int id);
        Task<StatusOrderDto> CreateAsync(StatusOrderDto dto);
        Task<bool> UpdateAsync(int id, StatusOrderDto dto);
        Task<bool> DeleteAsync(int id);
    }
}