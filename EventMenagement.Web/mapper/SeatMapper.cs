using EventMenagement.Service;
using EventMenagement.Web.Extensions;
using EventMenagement.Web.request;
using EventMenagement.Web.response;

namespace EventMenagement.Web.mapper;

public class SeatMapper
{
    private readonly ISeatService _seatService;

    public SeatMapper(ISeatService seatService)
    {
        _seatService = seatService;
    }

    public async Task<List<SeatResponse>> GetAllAsync()
    {
        var result = await _seatService.GetAllAsync();
        return result.ToResponse();
    }

    public async Task<SeatResponse> GetByIdAsync(Guid id)
    {
        var result = await _seatService.GetByIdAsync(id);
        return result.ToResponse();
    }
    
    public async Task<SeatResponse> GetByIdNotNUllAsync(Guid id)
    {
        var result = await _seatService.GetByIdNotNullAsync(id);
        return result.ToResponse();
    }

    public async Task<SeatResponse> InsertAsync(SeatRequest seatRequest)
    {
        var req = seatRequest.ToDto();
        var result = await _seatService.InsertAsync(req);
        return result.ToResponse();
    }

    public async Task<SeatResponse> UpdateAsync(Guid id,SeatRequest seatRequest)
    {
        var dto = seatRequest.ToDto();
        var result = await _seatService.UpdateAsync(id, dto);
        return result.ToResponse();
    }

    public async Task<SeatResponse> DeleteAsync(Guid id)
    {
        var result = await _seatService.DeleteAsync(id);
        return result.ToResponse();
    }
    
    
}