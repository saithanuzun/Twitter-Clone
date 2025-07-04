using MediatR;
using Microsoft.AspNetCore.Mvc;
using Twitter.Backend.Application.Features.Commands.Tweet.Create;
using Twitter.Backend.Application.Features.Commands.Tweet.CreateLike;
using Twitter.Backend.Application.Features.Commands.Tweet.Delete;
using Twitter.Backend.Application.Features.Commands.Tweet.DeleteLike;
using Twitter.Backend.Application.Features.Queries.Tweet.GetMainPageTweets;
using Twitter.Backend.Application.Features.Queries.Tweet.GetReplies;
using Twitter.Backend.Application.Features.Queries.Tweet.GetTweet;
using Twitter.Backend.Application.Features.Queries.Tweet.GetTweetLikes;
using Twitter.Backend.Application.Features.Queries.User.GetUserTweets;

namespace Twitter.Backend.WebApi.Controllers;

public class TweetController : BaseController
{
    public TweetController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpDelete("{Id:guid}")]
    public async Task<IActionResult> DeleteTweet(Guid Id)
    {
        var request = new DeleteTweetRequest() { TweetId = Id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTweet([FromBody] CreateTweetRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
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
    
    [HttpGet("MainPage")] // TODO: Implement Main page tweets.

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
    
    [HttpGet("by-user/{userId:guid}")]
    public async Task<IActionResult> GetTweetsByUserId(
        [FromRoute] Guid userId,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var response = await _mediator.Send(new GetUserTweetsRequest
        {
            UserId = userId,
            Page = page,
            PageSize = pageSize
        });

        return Ok(response);
    }
    
    [HttpGet("by-user/{username}")]
    public async Task<IActionResult> GetTweetsByUsername(
        [FromRoute] string username,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var response = await _mediator.Send(new GetUserTweetsRequest
        {
            username = username,
            Page = page,
            PageSize = pageSize
        });

        return Ok(response);
    }
   
    
    
}