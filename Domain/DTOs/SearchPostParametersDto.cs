namespace Domain.DTOs;

public class SearchPostParametersDto
{
    public SearchPostParametersDto(string? username, int? userId, bool? postedStatus, string? titleContains)
    {
        Username = username;
        UserId = userId;
        PostedStatus = postedStatus;
        TitleContains = titleContains;
    }

    public string? Username { get; }
    public int? UserId { get; }
    public bool? PostedStatus { get; }
    public string? TitleContains { get; }
}