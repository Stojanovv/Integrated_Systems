using EventMenagement.Web.mapper;
using EventMenagement.Web.request;
using EventMenagement.Web.response;
using Microsoft.AspNetCore.Mvc;

namespace EventMenagement.Web.Controller;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly EventMapper _mapper;

    public EventController(EventMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<EventResponse>>> GetAllAsync()
    {
        return await _mapper.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        var result = await _mapper.GetById(id);
        if (result == null)
        {
            return NotFound();
        }
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromBody] EventRequest request)
    {
        var result = await _mapper.InsertAsync(request);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] EventRequest request)
    {
        var result = await _mapper.UpdateAsync(id, request);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mapper.DeleteAsync(id);
        return Ok(result);
    }
}