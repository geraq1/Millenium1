using Millenium1.DTOs;

namespace Millenium1.Services
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategoryDto>> GetAllAsync();
        Task<ProductCategoryDto?> GetByIdAsync(int id);
        Task<ProductCategoryDto> CreateAsync(ProductCategoryDto dto);
        Task<bool> UpdateAsync(int id, ProductCategoryDto dto);
        Task<bool> DeleteAsync(int id);
    }
}