using FeedbackSystem00016579.Api.DTOs;
using FeedbackSystem00016579.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystem00016579.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService userService;

    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var users = await this.userService.RetrieveAllAsync();
        return Ok(users);
        
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var user = await this.userService.RetrieveByIdAsync(id);
        return Ok(user);
        
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserForCreationDto dto)
    {
        return Ok(await this.userService.AddAsync(dto));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] UserForUpdateDto dto)
    {
        return Ok(await this.userService.UpdateAsync(id, dto));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(await this.userService.RemoveByIdAsync(id));
    }
}
