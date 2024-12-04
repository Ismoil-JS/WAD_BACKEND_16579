namespace FeedbackSystem00016579.Api.Models;

public class Feedback
{
    public long Id { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
