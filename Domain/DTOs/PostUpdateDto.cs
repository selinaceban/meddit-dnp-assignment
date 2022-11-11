namespace Domain.DTOs;

public class PostUpdateDto
{
    public int Id { get; }
    public int? AuthorId { get; set; }
    public string? Title { get; set; }
    public bool? IsPosted { get; set; }

    public PostUpdateDto(int id)
    {
        Id = id;
    }
}