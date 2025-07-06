using MediatR;

namespace Twitter.Backend.Application.Features.Commands.Tweet.DeleteLike;

public class DeleteLikeRequest : IRequest<DeleteLikeResponse>
{
    public Guid TweetId { get; set; }
    public Guid UserId { get; set; }
}