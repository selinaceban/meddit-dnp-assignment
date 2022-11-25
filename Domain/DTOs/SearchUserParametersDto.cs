namespace Domain.DTOs;

public class SearchUserParametersDto
{
    public SearchUserParametersDto(string? usernameContains)
    {
        UsernameContains = usernameContains;
    }

    public string? UsernameContains { get; }
}