namespace EventMenagement.Web.response;

public record SeatResponse(
     int Row, 
     int RowNumber, 
     string? Label, 
     bool IsAccessible, 
     Guid SectionId
);