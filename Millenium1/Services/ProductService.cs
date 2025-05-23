using Microsoft.EntityFrameworkCore;
using Millenium1.DTOs;
using Millenium1.Models;

namespace Millenium1.Services
{
    public class ProductService : IProductService
    {
        private readonly MilleniumContext _context;

        public ProductService(MilleniumContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            return await _context.Products
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Description = p.Description,
                    EquipmentId = p.EquipmentId,
                    CategoryId = p.CategoryId,
                    FabricId = p.FabricId
                })
                .ToListAsync();
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var p = await _context.Products.FindAsync(id);
            if (p == null) return null;

            return new ProductDto
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Price = p.Price,
                Description = p.Description,
                EquipmentId = p.EquipmentId,
                CategoryId = p.CategoryId,
                FabricId = p.FabricId
            };
        }

        public async Task<ProductDto> CreateAsync(ProductDto dto)
        {
            var entity = new Product
            {
                ProductName = dto.ProductName,
                Price = dto.Price,
                Description = dto.Description,
                EquipmentId = dto.EquipmentId,
                CategoryId = dto.CategoryId,
                FabricId = dto.FabricId
            };

            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            dto.ProductId = entity.ProductId;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, ProductDto dto)
        {
            var entity = await _context.Products.FindAsync(id);
            if (entity == null) return false;

            entity.ProductName = dto.ProductName;
            entity.Price = dto.Price;
            entity.Description = dto.Description;
            entity.EquipmentId = dto.EquipmentId;
            entity.CategoryId = dto.CategoryId;
            entity.FabricId = dto.FabricId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            if (entity == null) return false;

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}