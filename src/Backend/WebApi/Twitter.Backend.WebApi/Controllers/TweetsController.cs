using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twitter.Backend.Application.Features.Commands.Tweet.Create;
using Twitter.Backend.Application.Features.Commands.Tweet.CreateLike;
using Twitter.Backend.Application.Features.Commands.Tweet.Delete;
using Twitter.Backend.Application.Features.Commands.Tweet.DeleteLike;
using Twitter.Backend.Application.Features.Queries.Tweet.GetMainPageTweets;
using Twitter.Backend.Application.Features.Queries.Tweet.GetReplies;
using Twitter.Backend.Application.Features.Queries.Tweet.GetTweet;
using Twitter.Backend.Application.Features.Queries.Tweet.GetTweetLikes;
using Twitter.Backend.Application.Features.Queries.User.GetUserLikes;
using Twitter.Backend.Application.Features.Queries.User.GetUserReplies;
using Twitter.Backend.Application.Features.Queries.User.GetUserTweets;

namespace Twitter.Backend.WebApi.Controllers;

public class TweetsController : BaseController
{
    public TweetsController(IMediator mediator) : base(mediator)
    {
        
    }
    
    [HttpDelete("{Id:guid}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        
        if (response == null)
            return NotFound();
        
        return Ok(response);
    }
    
    [HttpGet("{TweetId:guid}/likes")]
    public async Task<IActionResult> LikedByUsers(Guid TweetId)
    {
        var response = await _mediator.Send(new GetTweetLikesRequest(){TweetId = TweetId});
        return Ok(response);
    }
    
    [HttpGet("{TweetId:guid}/replies")]
    public async Task<IActionResult> GetReplies(Guid TweetId)
    {
        var response = await _mediator.Send(new GetRepliesRequest() { TweetId = TweetId });
        return Ok(response);
    }
    
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("by-user/feed")] 
    public async Task<IActionResult> FeedByUser([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var response = await _mediator.Send(new GetMainPageTweetsRequest()
        {
            //UserId = UserId.Value,
            Page = page,
            PageSize = pageSize
        });

        return Ok(response);
    }
    
    [HttpGet("feed")] 
    public async Task<IActionResult> Feed( [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var response = await _mediator.Send(new GetMainPageTweetsRequest()
        {
            Page = page,
            PageSize = pageSize
        });

        return Ok(response);
    }

    [HttpGet("/api/tweets/by-user/{username}")]
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
    
    [HttpGet("/api/tweets/by-user/{username}/likes")]
    public async Task<IActionResult> GetTweetsLikesByUsername(
        [FromRoute] string username)
    {
        var response = await _mediator.Send(new GetUserLikesRequest
        {
            username = username,
        });

        return Ok(response);
    }
    
    [HttpGet("/api/tweets/by-user/{username}/replies")]
    public async Task<IActionResult> GetTweetsRepliesByUsername(
        [FromRoute] string username)
    {
        var response = await _mediator.Send(new GetUserRepliesRequest
        {
            username = username,
        });

        return Ok(response);
    }
    
      
    [HttpPost]
    [Route("/api/tweets/{tweetId}/like")]
    public async Task<IActionResult> CreateLike(Guid tweetId)
    {
        var request = new CreateLikeRequest() { TweetId = tweetId, UserId = UserId.Value };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("/api/tweets/{tweetId}/like")]
    public async Task<IActionResult> DeleteLike(Guid tweetId)
    {
        var request = new DeleteLikeRequest(){ TweetId = tweetId, UserId = UserId.Value};

        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    /*
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
   */
    
}