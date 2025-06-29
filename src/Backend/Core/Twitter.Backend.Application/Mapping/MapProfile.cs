using AutoMapper;
using Twitter.Backend.Application.Features.Commands.User.Create;
using Twitter.Backend.Domain.Entities;

namespace Twitter.Backend.Application.Mapping;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<CreateUserRequest, User>();

    }
        
}