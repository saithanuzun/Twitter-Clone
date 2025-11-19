using MediatR;

namespace Twitter.Backend.Application.Features.Queries.User.GetUserLikes;

public class GetUserLikesRequest : IRequest<GetUserLikesResponse>
{
    public Guid? UserId { get; set; }
    public string? username { get; set; }
}