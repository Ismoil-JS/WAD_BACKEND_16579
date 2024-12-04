using AutoMapper;
using FeedbackSystem00016579.Api.DTOs;
using FeedbackSystem00016579.Api.Models;

namespace FeedbackSystem00016579.Api.Mappers;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<User, UserForCreationDto>().ReverseMap();

        CreateMap<Feedback,FeedbackForCreationDto>().ReverseMap();
        CreateMap<Feedback, FeedbackForResultDto>().ReverseMap();
        CreateMap<Feedback, FeedbackForUpdateDto>().ReverseMap();


    }
}
