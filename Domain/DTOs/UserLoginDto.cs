namespace Domain.DTOs;

public class UserLoginDto
{
    public UserLoginDto(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public string UserName { get; init; }
    public string Password { get; init; }
}