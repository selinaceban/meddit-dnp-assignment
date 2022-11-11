using Domain.Models;

namespace Domain.DTOs;

public class UserCreationDto
{
    public string UserName { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }

    public UserCreationDto(string userName, string email, string password)
    {
        UserName = userName;
        Email = email;
        Password = password;
    }

    
}