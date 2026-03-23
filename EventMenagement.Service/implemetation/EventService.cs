using EventMenagement.Repository.Interface;
using EventsManagement.Domain;
using EventsManagement.Domain.dto;
using Microsoft.EntityFrameworkCore.Query;

namespace EventMenagement.Service.implemetation;

public class EventService : IEventService
{
    private readonly IRepository<Event> _repository;

    public EventService(IRepository<Event> repository)
    {
        _repository = repository;
    }

    public async Task<List<Event>> GetAllAsync()
    {
        var result = await _repository.GetAllAsync(
            selector: x => x);
        return result.ToList();
    }

    public async Task<Event> GetByIdAsync(Guid id)
    {
        return await _repository.GetAsync(
            selector: x => x,
            predicate: x => x.Id == id);
    }

    public Task<Event> GetByIdNotNullAsync(Guid id)
    {
        var result = GetByIdAsync(id);
        if (result == null)
        {
            throw new InvalidOperationException("Event not found");
        }

        return result;
    }

    public async Task<Event> InsertAsync(EventDto eventDto)
    {
        var eventToAdd = new Event
        {
            Title = eventDto.Title,
            Description = eventDto.Description,
            StartDate = eventDto.StartDate,
            EndDate = eventDto.EndDate,
            Status = eventDto.Status,
            BannerUrl = eventDto.BannerUrl,
            VenueId = eventDto.VenueId,
            UserId = eventDto.UserId,
        };

        return await _repository.InsertAsync(eventToAdd);
    }

    public async Task<Event> UpdateAsync(Guid id, EventDto eventDto)
    {
        var eventToEdit = await GetByIdNotNullAsync(id);
        
        eventToEdit.Title = eventDto.Title;
        eventToEdit.Description = eventDto.Description;
        eventToEdit.StartDate = eventDto.StartDate;
        eventToEdit.EndDate = eventDto.EndDate;
        eventToEdit.Status = eventDto.Status;
        eventToEdit.BannerUrl = eventDto.BannerUrl;
        eventToEdit.VenueId = eventDto.VenueId;
        eventToEdit.UserId = eventDto.UserId;
        
        return await _repository.UpdateAsync(eventToEdit);
    }

    public async Task<Event> DeleteAsync(Guid id)
    {
        var eventToDelete = await GetByIdNotNullAsync(id);
        return await _repository.DeleteAsync(eventToDelete);
    }
}