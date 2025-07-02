using MediatR;

namespace Twitter.Backend.Application.Features.Queries.Hashtag.GetHashtagTweets;

public class GetHashtagTweetRequest : IRequest<GetHashtagTweetResponse>
{
    public Guid HashtagId { get; set; }
}