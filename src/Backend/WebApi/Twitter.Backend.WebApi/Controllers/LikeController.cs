using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twitter.Backend.Application.Features.Commands.Tweet.CreateLike;
using Twitter.Backend.Application.Features.Commands.Tweet.DeleteLike;

namespace Twitter.Backend.WebApi.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class LikeController : BaseController
{
    public LikeController(IMediator mediator) : base(mediator)
    {
    }
    
    
    [HttpPost]
    [Route("/api/{tweetId}/like")]
    public async Task<IActionResult> CreateLike(Guid tweetId)
    {
        var request = new CreateLikeRequest() { TweetId = tweetId, UserId = UserId.Value };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("/api/{tweetId}/like")]
    public async Task<IActionResult> DeleteLike(Guid tweetId)
    {
        var request = new DeleteLikeRequest(){ TweetId = tweetId, UserId = UserId.Value};

        var response = await _mediator.Send(request);
        return Ok(response);
    }
}