public interface IClientService
{
    Task<IEnumerable<ClientDto>> GetAllAsync();
    Task<ClientDto?> GetByIdAsync(long id);
    Task<ClientDto> CreateAsync(ClientDto dto);
    Task<ClientDto?> UpdateAsync(long id, ClientDto dto);
    Task<bool> DeleteAsync(long id);
}