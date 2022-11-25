using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Post
{
    public Post(User author, string title, string content)
    {
        Author = author;
        Title = title;
        Content = content;
    }

    private Post()
    {
    }

    [Key] public int Id { get; set; }

    public User Author { get; }

    [MaxLength(255)] public string Title { get; }

    [MaxLength(2000)] public string Content { get; }

    public bool IsPosted { get; set; }
}