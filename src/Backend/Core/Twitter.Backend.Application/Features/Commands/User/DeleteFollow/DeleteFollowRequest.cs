using MediatR;

namespace Twitter.Backend.Application.Features.Commands.User.DeleteFollow;

public class DeleteFollowRequest : IRequest<DeleteFollowResponse>
{
    public Guid FollowerId { get; set; } //who follows
    public Guid FollowingId { get; set; } //who is being followed
}