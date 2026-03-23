using EventsManagement.Domain;
using EventsManagement.Domain.dto;

namespace EventMenagement.Service;

public interface IEventService
{
    public Task<List<Event>> GetAllAsync();
    public Task<Event> GetByIdAsync(Guid id);
    public Task<Event> GetByIdNotNullAsync(Guid id);
    public Task<Event> InsertAsync(EventDto dto);
    public Task<Event> UpdateAsync(Guid id, EventDto eventDto);
    public Task<Event> DeleteAsync(Guid id);
    // public Task<PaginatedResult<Event>> GetAllPaginatedAsync(int pageNumber, int pageSize);
}