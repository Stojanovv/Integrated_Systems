using EventsManagement.Domain;

namespace EventMenagement.Service;

public interface IVenueService
{
    public Task<List<Venue>> GetAllAsync();
    public Task<Venue> GetByIdAsync(Guid id);
    public Task<Venue> GetAllNyIdNotNullAsync(Guid id);
    public Task<Venue> InsertAsync(string name, 
        string address, string city, string country, string? zipCode);
    public Task<Venue> UpdateAsync(Guid id,string name,string adress,string city,
        string country, string? zipCode);
    public Task<Venue> DeleteAsync(Guid id);
}