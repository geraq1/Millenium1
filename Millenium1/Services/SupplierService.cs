using Microsoft.EntityFrameworkCore;
using Millenium1.DTOs;
using Millenium1.Models;

namespace Millenium1.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly MilleniumContext _context;

        public SupplierService(MilleniumContext context)
        {
            _context = context;
        }

        public async Task<List<SupplierDto>> GetAllAsync()
        {
            return await _context.Suppliers
                .Select(s => new SupplierDto
                {
                    SupplierId = s.SupplierId,
                    SupplierName = s.SupplierName,
                    SupplierEmail = s.SupplierEmail,
                    SupplierPhone = s.SupplierPhone,
                    RegistrationDate = s.RegistrationDate
                }).ToListAsync();
        }

        public async Task<SupplierDto?> GetByIdAsync(int id)
        {
            var s = await _context.Suppliers.FindAsync(id);
            if (s == null) return null;

            return new SupplierDto
            {
                SupplierId = s.SupplierId,
                SupplierName = s.SupplierName,
                SupplierEmail = s.SupplierEmail,
                SupplierPhone = s.SupplierPhone,
                RegistrationDate = s.RegistrationDate
            };
        }

        public async Task<SupplierDto> CreateAsync(SupplierDto dto)
        {
            var s = new Supplier
            {
                SupplierName = dto.SupplierName,
                SupplierEmail = dto.SupplierEmail,
                SupplierPhone = dto.SupplierPhone,
                RegistrationDate = dto.RegistrationDate
            };

            _context.Suppliers.Add(s);
            await _context.SaveChangesAsync();

            dto.SupplierId = s.SupplierId;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, SupplierDto dto)
        {
            var s = await _context.Suppliers.FindAsync(id);
            if (s == null) return false;

            s.SupplierName = dto.SupplierName;
            s.SupplierEmail = dto.SupplierEmail;
            s.SupplierPhone = dto.SupplierPhone;
            s.RegistrationDate = dto.RegistrationDate;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var s = await _context.Suppliers.FindAsync(id);
            if (s == null) return false;

            _context.Suppliers.Remove(s);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}