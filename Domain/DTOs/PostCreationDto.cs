namespace Domain.DTOs;

public class PostCreationDto
{
    public int AuthorId { get; }
    public string Title { get; }
    
    public string Content { get; }

    public PostCreationDto(int authorId, string title, string content)
    {
        AuthorId = authorId;
        Title = title;
        Content = content;
    }
}