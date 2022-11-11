using System.Reflection;
using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);

    Task<Post> ViewAsync(int id);
    Task<PostBasicDto> GetByIdAsync(int id);
}
