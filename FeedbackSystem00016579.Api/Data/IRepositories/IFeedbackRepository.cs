using FeedbackSystem00016579.Api.Models;

namespace FeedbackSystem00016579.Api.Data.IRepositories;

public interface IFeedbackRepository
{
    public Task<bool> InsertAsync(Feedback feedback);
    public Task<bool> UpdateAsync(Feedback feedback);
    public Task<bool> DeleteAsync(long id);
    public Task<Feedback> GetByIdAsync(long id);
    public IQueryable<Feedback> GetAll();
}
