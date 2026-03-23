using EventMenagement.Repository.Interface;
using EventsManagement.Domain;
using EventsManagement.Domain.dto;

namespace EventMenagement.Service.implemetation;

public class SeatService: ISeatService
{
    private readonly IRepository<Seat> _repository;

    public SeatService(IRepository<Seat> repository)
    {
        _repository = repository;
    }

    public async Task<List<Seat>> GetAllAsync()
    {
        var result = await _repository.GetAllAsync(selector: x => x);
        return result.ToList();
    }

    public async Task<Seat> GetByIdAsync(Guid id)
    {
        var result = await _repository.GetAsync(selector: x => x, predicate: x => x.Id == id);
        return result;
    }

    public Task<Seat> GetByIdNotNullAsync(Guid id)
    {
        var result = GetByIdAsync(id);
        if (result == null)
        {
            throw new InvalidOperationException("Seat not found!");
        }

        return result;
    }

    public async Task<Seat> InsertAsync(SeatDto dto)
    {
        var seat = new Seat
        {
            Row = dto.Row,
            RowNumber = dto.RowNumber,
            Label = dto.Label,
            IsAccessible = dto.IsAccessible
        };
        return await _repository.InsertAsync(seat);
    }

    public async Task<Seat> UpdateAsync(Guid id,SeatDto dto)
    {
        var seat = GetByIdNotNullAsync(id);
        
        seat.Result.Row=dto.Row;
        seat.Result.RowNumber=dto.RowNumber;
        seat.Result.Label=dto.Label;
        seat.Result.IsAccessible=dto.IsAccessible;

        return await _repository.UpdateAsync(await seat);
    }

    public async Task<Seat> DeleteAsync(Guid id)
    {
        var seat = GetByIdNotNullAsync(id);
        return await _repository.DeleteAsync(await seat);
    }
}