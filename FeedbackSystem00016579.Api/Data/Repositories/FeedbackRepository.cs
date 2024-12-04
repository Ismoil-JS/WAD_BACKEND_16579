using FeedbackSystem00016579.Api.Data.DbContexts;
using FeedbackSystem00016579.Api.Data.IRepositories;
using FeedbackSystem00016579.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem00016579.Api.Data.Repositories;

public class FeedbackRepository : IFeedbackRepository
{
    private readonly AppDbContext dbContext;

    public FeedbackRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<bool> DeleteAsync(long id)
    {

        var feedback = await dbContext.Feedbacks.FirstOrDefaultAsync(u => u.Id == id);
        dbContext.Feedbacks.Remove(feedback);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public  IQueryable<Feedback> GetAll()
    {
        var feedbacks = dbContext.Feedbacks;
        return feedbacks;
    }

    public  async Task<Feedback> GetByIdAsync(long id)
    {
        var feedback = await dbContext.Feedbacks.FirstOrDefaultAsync(r => r.Id == id);
        return feedback;
    }

    public async Task<bool> InsertAsync(Feedback feedback)
    {
        await this.dbContext.Feedbacks.AddAsync(feedback);
        return await this.dbContext.SaveChangesAsync() > 0;
    }

    public  async Task<bool> UpdateAsync(Feedback feedback)
    {
        dbContext.Feedbacks.Update(feedback);
        return await dbContext.SaveChangesAsync() > 0;
    }
}
