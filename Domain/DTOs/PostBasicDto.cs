namespace Domain.DTOs;

public class PostBasicDto
{
    public int Id { get; }
    public string AuthorName { get; }
    public string Title { get; }
    public bool IsCompleted { get;  }

    public PostBasicDto(int id, string authorName, string title, bool isCompleted)
    {
        Id = id;
        AuthorName = authorName;
        Title = title;
        IsCompleted = isCompleted;
    }
}