using FeedbackSystem00016579.Api.DTOs;

namespace FeedbackSystem00016579.Api.Interfaces;

public interface IUserService
{
    public Task<bool> AddAsync(UserForCreationDto dto);
    public Task<bool> RemoveByIdAsync(long id);
    public Task<bool> UpdateAsync(long id, UserForUpdateDto dto);
    public Task<UserForResultDto> RetrieveByIdAsync(long id);
    public Task<IEnumerable<UserForResultDto>> RetrieveAllAsync();
}
