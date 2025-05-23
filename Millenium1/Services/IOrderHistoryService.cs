using Millenium1.DTOs;

namespace Millenium1.Services
{
    public interface IOrderHistoryService
    {
        Task<List<OrderHistoryDto>> GetAllAsync();
        Task<OrderHistoryDto?> GetByIdAsync(int id);
    }
}