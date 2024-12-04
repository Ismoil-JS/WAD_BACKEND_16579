namespace FeedbackSystem00016579.Api.Models;

public class User
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Feedback> Feedbacks { get; set; }

}
