using AutoMapper;
using Twitter.Backend.Application.Features.Commands.Tweet.CreateLike;
using Twitter.Backend.Application.Features.Commands.User.Create;
using Twitter.Backend.Application.Features.Commands.User.CreateFollow;
using Twitter.Backend.Application.Features.Commands.User.Login;
using Twitter.Backend.Application.Features.Queries.Tweet.GetTweet;
using Twitter.Backend.Application.Features.Queries.User.GetUser;
using Twitter.Backend.Domain.Entities;

namespace Twitter.Backend.Application.Mapping;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<CreateUserRequest, User>();

        CreateMap<User, GetUserResponse>()
            .ForMember(i => i.Username, k => k.MapFrom(k => k.Username))
            .ForMember(i => i.Email, k => k.MapFrom(k => k.Email))
            .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Profile.DisplayName))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Profile.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Profile.LastName))
            .ForMember(dest => dest.Bio, opt => opt.MapFrom(src => src.Profile.Bio))
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Profile.Location))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Profile.ImageUrl))
            .ReverseMap();
        
        /*CreateMap<GetTweetResponse, Tweet>()
            .ForMember(i => i.UserId, k => k.MapFrom(k => k.UserId))
            .ForMember(i => i.Content, k => k.MapFrom(k => k.Content))
            .ForMember(i => i.Id, k => k.MapFrom(k => k.Id))
            .ForMember(i => i.IsDeleted, k => k.MapFrom(k => k.IsDeleted))
            .ForMember(i => i.IsRetweet, k => k.MapFrom(k => k.IsRetweet))
            .ForMember(i => i.CreatedDate, k => k.MapFrom(k => k.CreatedDate))
            .ForMember(i => i.DeletedDate, k => k.MapFrom(k => k.DeletedDate))
            .ForMember(i => i.ParentTweetId, k => k.MapFrom(k => k.ParentTweetId))
            .ForMember(i => i.RetweetParentId, k => k.MapFrom(k => k.RetweetParentId))
            .ForMember(i => i.MediaUrl, k => k.MapFrom(k => k.MediaUrl))
            .ReverseMap(); */
        
        CreateMap<CreateFollowRequest, UserFollow>()
            .ForMember(i => i.FollowerId, k => k.MapFrom(k => k.FollowerId))
            .ForMember(i => i.FollowingId, k => k.MapFrom(k => k.FollowingId))
            .ReverseMap();
        
        CreateMap<CreateLikeRequest, TweetLike>()
            .ForMember(i => i.TweetId, k => k.MapFrom(k => k.TweetId))
            .ForMember(i => i.UserId, k => k.MapFrom(k => k.UserId))
            .ReverseMap();
        
        CreateMap<LoginResponse, User>()
            .ForMember(i => i.Id, k => k.MapFrom(k => k.Id))
            .ForMember(i => i.Username, k => k.MapFrom(k => k.Username))
            .ReverseMap();

    }
}

    
        
