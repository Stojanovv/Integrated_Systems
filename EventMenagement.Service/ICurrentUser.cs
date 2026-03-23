namespace EventMenagement.Service;

public interface ICurrentUser
{
    string? GetUserId();
    string? GetUserName();
}