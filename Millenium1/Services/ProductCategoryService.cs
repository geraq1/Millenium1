using Microsoft.EntityFrameworkCore;
using Millenium1.DTOs;
using Millenium1.Models;

namespace Millenium1.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly MilleniumContext _context;

        public ProductCategoryService(MilleniumContext context)
        {
            _context = context;
        }

        public async Task<List<ProductCategoryDto>> GetAllAsync()
        {
            return await _context.ProductCategories
                .Select(c => new ProductCategoryDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description
                })
                .ToListAsync();
        }

        public async Task<ProductCategoryDto?> GetByIdAsync(int id)
        {
            var c = await _context.ProductCategories.FindAsync(id);
            if (c == null) return null;

            return new ProductCategoryDto
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Description = c.Description
            };
        }

        public async Task<ProductCategoryDto> CreateAsync(ProductCategoryDto dto)
        {
            var c = new ProductCategory
            {
                CategoryName = dto.CategoryName,
                Description = dto.Description
            };

            _context.ProductCategories.Add(c);
            await _context.SaveChangesAsync();

            dto.CategoryId = c.CategoryId;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, ProductCategoryDto dto)
        {
            var c = await _context.ProductCategories.FindAsync(id);
            if (c == null) return false;

            c.CategoryName = dto.CategoryName;
            c.Description = dto.Description;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var c = await _context.ProductCategories.FindAsync(id);
            if (c == null) return false;

            _context.ProductCategories.Remove(c);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}