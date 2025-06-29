using MediatR;

namespace Twitter.Backend.Application.Features.Commands.User.CreateFollow;

public class CreateFollowRequest : IRequest<CreateFollowResponse>
{
    public Guid FollowerId { get; set; } //who follows
    public Guid FollowingId { get; set; } //who is being followed
}