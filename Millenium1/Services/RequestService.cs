using Microsoft.EntityFrameworkCore;
using Millenium1.DTOs;
using Millenium1.Models;

namespace Millenium1.Services
{
    public class RequestService : IRequestService
    {
        private readonly MilleniumContext _context;

        public RequestService(MilleniumContext context)
        {
            _context = context;
        }

        public async Task<List<RequestDto>> GetAllAsync()
        {
            return await _context.Requests
                .Select(r => new RequestDto
                {
                    Requestid = r.Requestid,
                    FabricId = r.FabricId,
                    Supplierid = r.Supplierid,
                    Quantity = r.Quantity,
                    Price = r.Price,
                    Startdate = r.Startdate,
                    Enddate = r.Enddate,
                    Isdone = r.Isdone
                }).ToListAsync();
        }

        public async Task<RequestDto?> GetByIdAsync(int id)
        {
            var r = await _context.Requests.FindAsync(id);
            if (r == null) return null;

            return new RequestDto
            {
                Requestid = r.Requestid,
                FabricId = r.FabricId,
                Supplierid = r.Supplierid,
                Quantity = r.Quantity,
                Price = r.Price,
                Startdate = r.Startdate,
                Enddate = r.Enddate,
                Isdone = r.Isdone
            };
        }

        public async Task<RequestDto> CreateAsync(RequestDto dto)
        {
            var r = new Request
            {
                FabricId = dto.FabricId,
                Supplierid = dto.Supplierid,
                Quantity = dto.Quantity,
                Price = dto.Price,
                Startdate = dto.Startdate,
                Enddate = dto.Enddate,
                Isdone = dto.Isdone
            };

            _context.Requests.Add(r);
            await _context.SaveChangesAsync();

            dto.Requestid = r.Requestid;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, RequestDto dto)
        {
            var r = await _context.Requests.FindAsync(id);
            if (r == null) return false;

            r.FabricId = dto.FabricId;
            r.Supplierid = dto.Supplierid;
            r.Quantity = dto.Quantity;
            r.Price = dto.Price;
            r.Startdate = dto.Startdate;
            r.Enddate = dto.Enddate;
            r.Isdone = dto.Isdone;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var r = await _context.Requests.FindAsync(id);
            if (r == null) return false;

            _context.Requests.Remove(r);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}