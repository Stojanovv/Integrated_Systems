using System.Security.Claims;
using Microsoft.AspNetCore.Http;
namespace EventMenagement.Service.implemetation;

public class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? GetUserId()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }

    public string? GetUserName()
    {
        return _httpContextAccessor.HttpContext?.User?.Identity?.Name;
    }
}