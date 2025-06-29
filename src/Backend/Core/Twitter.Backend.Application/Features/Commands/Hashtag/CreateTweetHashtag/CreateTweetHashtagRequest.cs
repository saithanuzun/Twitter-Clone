using MediatR;
using Twitter.Backend.Application.Features.Commands.Hashtag.Create;

namespace Twitter.Backend.Application.Features.Commands.Hashtag.CreateTweetHashtag;

public class CreateTweetHashtagRequest : IRequest<CreateTweetHashtagResponse>, IRequest<CreateHashtagResponse>
{
    public Guid TweetId { get; set; }
    public Guid HashtagId { get; set; }
}