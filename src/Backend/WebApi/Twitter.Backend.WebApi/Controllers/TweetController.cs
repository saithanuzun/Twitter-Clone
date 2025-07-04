using MediatR;
using Microsoft.AspNetCore.Mvc;
using Twitter.Backend.Application.Features.Queries.Tweet.GetMainPageTweets;
using Twitter.Backend.Application.Features.Queries.Tweet.GetReplies;
using Twitter.Backend.Application.Features.Queries.Tweet.GetTweet;
using Twitter.Backend.Application.Features.Queries.Tweet.GetTweetLikes;

namespace Twitter.Backend.WebApi.Controllers;

public class TweetController : BaseController
{
    public TweetController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _mediator.Send(new GetTweetRequest() { Id = id });
        return Ok(response);
    }
    
    [HttpGet("{id}/Likes")]
    public async Task<IActionResult> LikedByUsers(Guid TweetId)
    {
        var response = await _mediator.Send(new GetTweetLikesRequest(){TweetId = TweetId});
        return Ok(response);
    }
    
    [HttpGet("{id}/Replies")]
    public async Task<IActionResult> GetReplies(Guid TweetId)
    {
        var response = await _mediator.Send(new GetRepliesRequest() { TweetId = TweetId });
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetMainPageTweets([FromQuery] Guid userId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var response = await _mediator.Send(new GetMainPageTweetsRequest()
        {
            UserId = userId,
            Page = page,
            PageSize = pageSize
        });

        return Ok(response);
    }


    
}