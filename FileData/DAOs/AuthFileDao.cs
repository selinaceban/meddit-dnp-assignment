using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace FileData.DAOs;

public class AuthFileDao : IUserService
{
    
    private readonly HttpClient _client;

    public AuthFileDao(HttpClient client)
    {
        _client = client;
    }

    public async Task<User> LoginAsync(UserLoginDto dto)
    {
        var response = await _client.PostAsJsonAsync("/login", dto);
        var result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        var existing = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return existing;
    }

    public async Task<User> CreateAsync(User user)
    {
        var response = await _client.PostAsJsonAsync("/users", user);
        var result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        var created = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return created;
    }

    public async Task<User> Create(UserCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetUsers(string? usernameContains = null)
    {
        throw new NotImplementedException();
    }
}
