using MediatR;

namespace Twitter.Backend.Application.Features.Commands.Tweet.CreateLike;

public class CreateLikeRequest : IRequest<CreateLikeResponse>
{
    public Guid TweetId { get; set; }
    public Guid UserId { get; set; }
}