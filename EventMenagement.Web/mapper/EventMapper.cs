using EventMenagement.Service;
using EventMenagement.Web.Extensions;
using EventMenagement.Web.request;
using EventMenagement.Web.response;
using EventsManagement.Domain.dto;

namespace EventMenagement.Web.mapper;

public class EventMapper
{
    private readonly IEventService _eventService;

    public EventMapper(IEventService eventService)
    {
        _eventService = eventService;
    }

    public async Task<EventResponse?> GetById(Guid id)
    {
        var result = await _eventService.GetByIdNotNullAsync(id);
        return result.ToResponse();
    }

    public async Task<List<EventResponse>> GetAllAsync()
    {
        var result = await _eventService.GetAllAsync();
        return result.ToResponse();
    }

    public async Task<EventResponse> GetByIdNotNullAsync(Guid id)
    {
        var result = await _eventService.GetByIdNotNullAsync(id);
        return result.ToResponse();
    }
    public async Task<EventResponse> InsertAsync(EventRequest request)
    {
        var dto = request.ToDto();
        var result = await _eventService.InsertAsync(dto);
        return result.ToResponse();
    }

    public async Task<EventResponse> UpdateAsync(Guid id, EventRequest request)
    {
        var dto = request.ToDto();
        var result = await _eventService.UpdateAsync(id, dto);
        return result.ToResponse();
    }

    public async Task<EventResponse> DeleteAsync(Guid id)
    {
        var result = await _eventService.DeleteAsync(id);
        return result.ToResponse();
    }

}
