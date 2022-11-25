namespace Domain.DTOs;

public class PostCreationDto
{
    public PostCreationDto(string title, string content)
    {
        Title = title;
        Content = content;
    }

    public int AuthorId { get; }
    public string Title { get; }

    public string Content { get; }
}