namespace Domain.DTOs;

public class PostCreationDto
{
    public int AuthorId { get; }
    public string Title { get; }
    
    public string Content { get; }

    public PostCreationDto(string title, string content)
    {
        Title = title;
        Content = content;
    }
}