using EventsManagement.Domain;
using EventsManagement.Domain.dto;

namespace EventMenagement.Service;

public interface ISeatService
{
    public Task<List<Seat>> GetAllAsync();
    public Task<Seat>GetByIdAsync(Guid id);
    public Task<Seat> GetByIdNotNullAsync(Guid id);
    public Task<Seat> InsertAsync(SeatDto dto);
    public Task<Seat> UpdateAsync(Guid id,SeatDto dto);
    public Task<Seat> DeleteAsync(Guid id);
}