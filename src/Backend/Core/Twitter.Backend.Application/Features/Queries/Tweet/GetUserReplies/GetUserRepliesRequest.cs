using MediatR;

namespace Twitter.Backend.Application.Features.Queries.User.GetUserReplies;

public class GetUserRepliesRequest : IRequest<GetUserRepliesResponse>
{
    public Guid? UserId { get; set; }
    public string? username { get; set; }
}