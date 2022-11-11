using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public interface IAuthLogic
{
    Task<User> ValidateUserAsync(string username, string password);
    Task<User> RegisterUserAsync(UserCreationDto user);
    Task<User> GetByIdAsync(int id);
}