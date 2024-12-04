using FeedbackSystem00016579.Api.DTOs;

namespace FeedbackSystem00016579.Api.Interfaces;

public interface IFeedbackService
{
    public Task<bool> AddAsync(FeedbackForCreationDto dto);
    public Task<bool> RemoveByIdAsync(long id);
    public Task<bool> UpdateAsync(long id, FeedbackForUpdateDto dto);
    public Task<FeedbackForResultDto> RetrieveByIdAsync(long id);
    public Task<IEnumerable<FeedbackForResultDto>> RetrieveAllAsync();

}
