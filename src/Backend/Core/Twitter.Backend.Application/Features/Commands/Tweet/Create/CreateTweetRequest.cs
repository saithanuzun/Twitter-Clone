using MediatR;

namespace Twitter.Backend.Application.Features.Commands.Tweet.Create;

public class CreateTweetRequest : IRequest<CreateTweetResponse>
{
    public string Content { get; set; }
    public string? MediaUrl { get; set; }
    
    public Guid? ParentTweetId { get; set; }
    
    public Guid UserId { get; set; }
    
    public bool? IsRetweet { get; set; }
    
    public Guid? RetweetParentId { get; set; }
    
}