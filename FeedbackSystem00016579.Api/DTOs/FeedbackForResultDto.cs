namespace FeedbackSystem00016579.Api.DTOs;

public class FeedbackForResultDto
{
    public long Id { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public long UserId { get; set; }
}
