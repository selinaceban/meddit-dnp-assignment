namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public User Author { get; }
    public string Title { get; }

    public bool IsPosted { get; set; }

    public Post(User author, string title)
    {
        Author = author;
        Title = title;
    }
}