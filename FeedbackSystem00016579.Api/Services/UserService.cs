using AutoMapper;
using FeedbackSystem00016579.Api.Data.IRepositories;
using FeedbackSystem00016579.Api.DTOs;
using FeedbackSystem00016579.Api.Interfaces;
using FeedbackSystem00016579.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem00016579.Api.Services;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<bool> AddAsync(UserForCreationDto dto)
    {
        var user = await this.userRepository.GetAll()
            .Where(u => u.Username == dto.Username)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (user is not null)
            throw new Exception("User already exists");

        var mappedUser = this.mapper.Map<User>(dto);
        mappedUser.CreatedAt = DateTime.UtcNow;

        return await this.userRepository.InsertAsync(mappedUser);
    }

    public async Task<bool> RemoveByIdAsync(long id)
    {
        var user = await this.userRepository.GetAll()
            .Where(u => u.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (user is null)
            throw new Exception("User not found");

        return await this.userRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync()
    {
        var users = await this.userRepository.GetAll()
            .Include(u => u.Feedbacks)
            .ToListAsync();

        return this.mapper.Map<IEnumerable<UserForResultDto>>(users);
    }

    public async Task<UserForResultDto> RetrieveByIdAsync(long id)
    {
        var user = await this.userRepository.GetAll()
            .Include(u => u.Feedbacks)
            .Where(u => u.Id == id)
            .FirstOrDefaultAsync();
        if (user is null)
            throw new Exception("User not found");

        return this.mapper.Map<UserForResultDto>(user);
    }

    public async Task<bool> UpdateAsync(long id, UserForUpdateDto dto)
    {
        var user = await this.userRepository.GetByIdAsync(id);
        if (user is null)
            throw new Exception("User not found");

        var mappedUser = this.mapper.Map(dto, user);
        return await this.userRepository.UpdateAsync(mappedUser);
    }
}
