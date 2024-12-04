using FeedbackSystem00016579.Api.Models;

namespace FeedbackSystem00016579.Api.Data.IRepositories;

public interface IUserRepository
{
    public Task<bool> InsertAsync(User user);
    public Task<bool> UpdateAsync(User user);
    public Task<bool> DeleteAsync(long id);
    public Task<User> GetByIdAsync(long id);
    public IQueryable<User> GetAll();
}
