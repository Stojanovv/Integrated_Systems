using System.ComponentModel.DataAnnotations;

namespace EventMenagement.Web.request;

public record EventRequest(
    [Required] string Title,
    [Required] string Description,
    [Required] DateTime StartDate,
    [Required] DateTime EndDate,
    [Required] string Status,
    [Required]string BanneeUrl,
    [Required] Guid UserId,
    [Required] Guid VenueId
    );