using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Post
{
 [Key]
    public int Id { get; set; }
    public User Author { get; private set; }
    [MaxLength(255)]
    public string Title { get; private set; }
    
    [MaxLength(2000)]
    public string Content { get; }

    public bool IsPosted { get; set; }

    public Post(User author, string title, string content)
    {
        Author = author;
        Title = title;
        Content = content;
    }
    
    private Post(){}
}