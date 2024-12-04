using FeedbackSystem00016579.Api.DTOs;
using FeedbackSystem00016579.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystem00016579.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedbacksController : ControllerBase
{
    private readonly IFeedbackService feedbackService;

    public FeedbacksController(IFeedbackService feedbackService)
    {
        this.feedbackService = feedbackService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var feedbacks = await this.feedbackService.RetrieveAllAsync();
        return Ok(feedbacks);

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var feedback = await this.feedbackService.RetrieveByIdAsync(id);
        return Ok(feedback);

    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] FeedbackForCreationDto dto)
    {
        return Ok(await this.feedbackService.AddAsync(dto));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] FeedbackForUpdateDto dto)
    {
        return Ok(await this.feedbackService.UpdateAsync(id, dto));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(await this.feedbackService.RemoveByIdAsync(id));
    }
}
