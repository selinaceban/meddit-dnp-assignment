using System.Security.Claims;
using Domain.DTOs;

namespace BlazorWasm.Services;

public interface IAuthService
{
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    public Task LoginAsync(string username, string password);
    public Task LogoutAsync();
    public Task RegisterAsync(UserCreationDto dto);
    public Task<ClaimsPrincipal> GetAuthAsync();
}