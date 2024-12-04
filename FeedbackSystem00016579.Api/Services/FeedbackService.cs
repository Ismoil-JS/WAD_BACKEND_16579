using AutoMapper;
using FeedbackSystem00016579.Api.Data.IRepositories;
using FeedbackSystem00016579.Api.DTOs;
using FeedbackSystem00016579.Api.Interfaces;
using FeedbackSystem00016579.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem00016579.Api.Services;

public class FeedbackService : IFeedbackService
{
    private readonly IMapper mapper;
    private readonly IFeedbackRepository feedbackRepository;
    private readonly IUserRepository userRepository;
    public FeedbackService(IMapper mapper, IFeedbackRepository feedbackRepository, IUserRepository userRepository)
    {
        this.mapper = mapper;
        this.feedbackRepository = feedbackRepository;
        this.userRepository = userRepository;
    }

    public async Task<bool> AddAsync(FeedbackForCreationDto dto)
    {
        var user = await this.userRepository.GetAll()
            .Where(u => u.Id == dto.UserId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (user is null)
            throw new Exception("Feedback not found");

        var mappedFeedback = this.mapper.Map<Feedback>(dto);
        mappedFeedback.CreatedAt = DateTime.UtcNow;

        return await this.feedbackRepository.InsertAsync(mappedFeedback);
    }

    public async Task<bool> RemoveByIdAsync(long id)
    {
        var feedback = await this.feedbackRepository.GetByIdAsync(id);
        if (feedback is null)
            throw new Exception("Feedback not found");

        return await this.feedbackRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<FeedbackForResultDto>> RetrieveAllAsync()
    {
        var feedbacks = await this.feedbackRepository.GetAll()
            .AsNoTracking()
            .ToListAsync();

        return this.mapper.Map<IEnumerable<FeedbackForResultDto>>(feedbacks);
    }

    public async Task<FeedbackForResultDto> RetrieveByIdAsync(long id)
    {
        var feedback = await this.feedbackRepository.GetByIdAsync(id);
        if (feedback is null)
            throw new Exception("Feedback not found");

        return this.mapper.Map<FeedbackForResultDto>(feedback);
    }

    public async Task<bool> UpdateAsync(long id, FeedbackForUpdateDto dto)
    {
        var feedback = await this.feedbackRepository.GetByIdAsync(id);
        if (feedback is null)
            throw new Exception("Feedback not found");

        var mappedFeedback = this.mapper.Map(dto, feedback);
        return await this.feedbackRepository.UpdateAsync(mappedFeedback);
    }
}
