namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public User Author { get; }
    public string Title { get; }
    
    public string Content { get; }

    public bool IsPosted { get; set; }

    public Post(User author, string title, string content)
    {
        Author = author;
        Title = title;
        Content = content;
    }
}