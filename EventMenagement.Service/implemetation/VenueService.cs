using EventMenagement.Repository.Interface;
using EventsManagement.Domain;
using EventsManagement.Repository.Implementation;

namespace EventMenagement.Service.implemetation;

public class VenueService : IVenueService
{
    private readonly IRepository<Venue> _repository;

    public VenueService(IRepository<Venue> repository)
    {
        _repository = repository;
    }

    public async Task<List<Venue>> GetAllAsync()
    {
        var result = await _repository.GetAllAsync(
            selector: x => x
        );
        return result.ToList();
    }

    public async Task<Venue> GetByIdAsync(Guid id)
    {
        var result = await _repository.GetAsync(
            selector: x => x,
            predicate: x => x.Id == id);
        return result;
    }

    public Task<Venue> GetAllNyIdNotNullAsync(Guid id)
    {
        var result = GetByIdAsync(id);
        if (result == null)
        {
            throw new NullReferenceException("Venue not fount!");
        }

        return result;
    }

    public async Task<Venue> InsertAsync(string name, string address, string city, string country, string? zipCode)
    {
        var venue = new Venue
        {
            Name = name,
            Address = address,
            City = city,
            Country = country,
            ZipCode = zipCode
        };
        return await _repository.InsertAsync(venue);
    }

    public async Task<Venue> UpdateAsync(Guid id, string name, string adress, string city, string country, string? zipCode)
    {
        var venue = GetAllNyIdNotNullAsync(id);
        venue.Result.Name = name;
        venue.Result.Address = adress;
        venue.Result.City = city;
        venue.Result.Country = country;
        venue.Result.ZipCode = zipCode;

        return await _repository.UpdateAsync(await venue);
    }

    public async Task<Venue> DeleteAsync(Guid id)
    {
        var venue = GetAllNyIdNotNullAsync(id);
        return await _repository.DeleteAsync(await venue);
    }
}