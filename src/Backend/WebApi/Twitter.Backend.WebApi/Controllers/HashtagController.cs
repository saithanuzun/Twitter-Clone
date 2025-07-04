using MediatR;
using Microsoft.AspNetCore.Mvc;
using Twitter.Backend.Application.Features.Queries.Hashtag.GetHashtags;
using Twitter.Backend.Application.Features.Queries.Hashtag.GetHashtagTweets;
using Twitter.Backend.Application.Features.Queries.Tweet.GetTweet;

namespace Twitter.Backend.WebApi.Controllers;

public class HashtagController : BaseController
{
    public HashtagController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetHashtagsTweetsById(Guid id)
    {
        var response = await _mediator.Send(new GetHashtagTweetRequest(){HashtagId = id});
        return Ok(response);
    }
    
    [HttpGet("{tag}")]
    public async Task<IActionResult> GetHashtagsTweetsByTag(string tag)
    {
        var response = await _mediator.Send(new GetHashtagTweetRequest(){Tag = tag});
        return Ok(response);
    }
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetHashtags()
    {
        var response = await _mediator.Send(new GetHashtagsRequest());
        return Ok(response);
    }
}