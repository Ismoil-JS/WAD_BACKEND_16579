using Microsoft.EntityFrameworkCore;
using FeedbackSystem00016579.Api.Models;
using FeedbackSystem00016579.Api.Data.DbContexts;
using FeedbackSystem00016579.Api.Data.IRepositories;

namespace FeedbackSystem00016579.Api.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext dbContext;
    public UserRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<bool> DeleteAsync(long id)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        dbContext.Users.Remove(user);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public IQueryable<User> GetAll()
    {
        var users = dbContext.Users;
        return users;
    }

    public async Task<User> GetByIdAsync(long id)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(r => r.Id == id);
        return user;
    }

    public async Task<bool> InsertAsync(User user)
    {
        await this.dbContext.Users.AddAsync(user);
        return await this.dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(User user)
    {

        dbContext.Users.Update(user);
        return await dbContext.SaveChangesAsync() > 0;
    }
}
