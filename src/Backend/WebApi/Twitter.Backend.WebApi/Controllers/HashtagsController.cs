using MediatR;
using Microsoft.AspNetCore.Mvc;
using Twitter.Backend.Application.Features.Queries.Hashtag.GetHashtags;
using Twitter.Backend.Application.Features.Queries.Hashtag.GetHashtagTweets;
using Twitter.Backend.Application.Features.Queries.Tweet.GetTweet;

namespace Twitter.Backend.WebApi.Controllers;

public class HashtagsController : BaseController
{
    
    public HashtagsController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetHashtagsTweetsById(Guid id)
    {
        var response = await _mediator.Send(new GetHashtagTweetRequest(){HashtagId = id});
        return Ok(response);
    }
    
    [HttpGet("by-tag/{tag}")]
    public async Task<IActionResult> GetHashtagsTweetsByTag(string tag)
    {
        if (string.IsNullOrEmpty(tag))
            return BadRequest();
        
        var response = await _mediator.Send(new GetHashtagTweetRequest(){Tag = tag});
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetHashtags()
    {
        var response = await _mediator.Send(new GetHashtagsRequest());
        return Ok(response);
    }
}