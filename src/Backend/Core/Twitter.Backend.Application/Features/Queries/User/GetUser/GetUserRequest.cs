using MediatR;

namespace Twitter.Backend.Application.Features.Queries.User.GetUser;

public class GetUserRequest : IRequest<GetUserResponse>
{
    public Guid Id { get; set; }
}