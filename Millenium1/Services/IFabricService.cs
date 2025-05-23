using Millenium1.DTOs;

namespace Millenium1.Services
{
    public interface IFabricService
    {
        Task<List<FabricDto>> GetAllAsync();
        Task<FabricDto?> GetByIdAsync(int id);
        Task<FabricDto> CreateAsync(FabricDto dto);
        Task<bool> UpdateAsync(int id, FabricDto dto);
        Task<bool> DeleteAsync(int id);
    }
}