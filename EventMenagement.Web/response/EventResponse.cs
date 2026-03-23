namespace EventMenagement.Web.response;

public record EventResponse(
    string Title,
    string Description,
    DateTime StartDate,
    DateTime EndDate,
    string? Status,
    string ? BanneeUrl,
    string? VenueName,
    string? VenueCity,
    string? VenueCountry
    );