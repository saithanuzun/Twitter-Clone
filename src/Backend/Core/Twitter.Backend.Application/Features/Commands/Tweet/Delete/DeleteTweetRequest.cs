using MediatR;

namespace Twitter.Backend.Application.Features.Commands.Tweet.Delete;

public class DeleteTweetRequest : IRequest<DeleteTweetResponse>
{
    public Guid TweetId { get; set; }
}