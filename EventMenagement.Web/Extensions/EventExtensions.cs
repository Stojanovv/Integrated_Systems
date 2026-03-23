using EventMenagement.Web.request;
using EventMenagement.Web.response;
using EventsManagement.Domain;
using EventsManagement.Domain.dto;

namespace EventMenagement.Web.Extensions;

public static class EventExtensions
{
    public static EventResponse? ToResponse(this Event e)
    {
        return new EventResponse(
            Title: e.Title,
            Description:e.Description,
            StartDate:e.StartDate,
            EndDate:e.EndDate,
            Status:e.Status,
            BanneeUrl:e.BannerUrl,
            VenueName:e.Venue?.Name,
            VenueCity:e.Venue?.City,
            VenueCountry:e.Venue?.Country);
    }

    public static List<EventResponse> ToResponse(this IEnumerable<Event> events)
    {
        return events.Select(x => x.ToResponse()).ToList();
    }


    public static EventDto ToDto(this EventRequest request)
    {
        return new EventDto
        {
            Title = request.Title,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Status = request.Status,
            BannerUrl = request.BanneeUrl,
            VenueId = request.VenueId,
            UserId = request.UserId,
        };
    }

    public static EventDto ToDto(this Event eventDto)
    {
        return new EventDto
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
    }
}