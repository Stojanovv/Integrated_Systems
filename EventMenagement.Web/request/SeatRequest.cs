using System.ComponentModel.DataAnnotations;

namespace EventMenagement.Web.request;

public record SeatRequest
(
    [Required] int Row,
    [Required] int RowNumber,
    [Required] string? Label,
    [Required] bool IsAccessible,
    [Required] Guid SectionId
    );