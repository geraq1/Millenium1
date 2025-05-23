using Millenium1.DTOs;

namespace Millenium1.Services
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllAsync();
        Task<OrderDto?> GetByIdAsync(int id);
        Task<OrderDto> CreateAsync(OrderDto dto);
        Task<bool> UpdateAsync(int id, OrderDto dto);
        Task<bool> DeleteAsync(int id);
    }
}