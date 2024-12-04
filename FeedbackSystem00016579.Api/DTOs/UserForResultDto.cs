using FeedbackSystem00016579.Api.Models;

namespace FeedbackSystem00016579.Api.DTOs;

public class UserForResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<FeedbackForResultDto> Feedbacks { get; set; }
}
