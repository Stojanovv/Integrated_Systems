using EventMenagement.Web.mapper;
using EventMenagement.Web.request;
using EventsManagement.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EventMenagement.Web.Controllers;

[Route("api/seats/[controller]")]
[ApiController]
public class SeatController : ControllerBase
{
    private readonly SeatMapper _mapper;

    public SeatController(SeatMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mapper.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await _mapper.GetByIdNotNUllAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] SeatRequest seat)
    {
        var result = await _mapper.InsertAsync(seat);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SeatRequest seat)
    {
        var result = await _mapper.UpdateAsync(id, seat);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _mapper.DeleteAsync(id);
        return Ok(result);
    }
}