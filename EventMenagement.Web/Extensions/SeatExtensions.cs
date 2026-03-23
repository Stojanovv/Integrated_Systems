using EventMenagement.Web.request;
using EventMenagement.Web.response;
using EventsManagement.Domain;
using EventsManagement.Domain.dto;

namespace EventMenagement.Web.Extensions;

public static class SeatExtensions
{
    public static SeatResponse? ToResponse(this Seat seat)
    {
        return new SeatResponse(
            Row: seat.Row,
            RowNumber: seat.RowNumber,
            Label: seat.Label,
            IsAccessible: seat.IsAccessible,
            SectionId: seat.SectionId);
    }

    public static List<SeatResponse> ToResponse(this IEnumerable<Seat> seats)
    {
        return seats.Select(x=>x.ToResponse()).ToList();
    }

    public static SeatDto ToDto(this SeatRequest request)
    {
        return new SeatDto
        {
            Row = request.Row,
            RowNumber = request.RowNumber,
            Label = request.Label,
            IsAccessible = request.IsAccessible,
            SectionId = request.SectionId
        };
    }
}