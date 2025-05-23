using Millenium1.Models;
using Microsoft.EntityFrameworkCore;
public class ClientService : IClientService
{
    private readonly MilleniumContext _context;

    public ClientService(MilleniumContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ClientDto>> GetAllAsync()
    {
        return await _context.Clients
            .Select(c => new ClientDto
            {
                Clientid = c.Clientid,
                ClientFio = c.ClientFio,
                ClientEmail = c.ClientEmail
            }).ToListAsync();
    }

    public async Task<ClientDto?> GetByIdAsync(long id)
    {
        var c = await _context.Clients.FindAsync(id);
        return c == null ? null : new ClientDto
        {
            Clientid = c.Clientid,
            ClientFio = c.ClientFio,
            ClientEmail = c.ClientEmail
        };
    }

    public async Task<ClientDto> CreateAsync(ClientDto dto)
    {
        var entity = new Client
        {
            Clientid = dto.Clientid,
            ClientFio = dto.ClientFio,
            ClientEmail = dto.ClientEmail
        };

        _context.Clients.Add(entity);
        await _context.SaveChangesAsync();
        return dto;
    }

    public async Task<ClientDto?> UpdateAsync(long id, ClientDto dto)
    {
        var entity = await _context.Clients.FindAsync(id);
        if (entity == null) return null;

        entity.ClientFio = dto.ClientFio;
        entity.ClientEmail = dto.ClientEmail;

        await _context.SaveChangesAsync();
        return dto;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await _context.Clients.FindAsync(id);
        if (entity == null) return false;

        _context.Clients.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}