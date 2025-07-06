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
    [Route("{TweetId}")]
    public async Task<IActionResult> CreateLike(Guid TweetId)
    {
        var request = new CreateLikeRequest() { TweetId = TweetId, UserId = UserId.Value };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("{TweetId}")]
    public async Task<IActionResult> DeleteLike(Guid TweetId)
    {
        var request = new DeleteLikeRequest(){ TweetId = TweetId, UserId = UserId.Value};

        var response = await _mediator.Send(request);
        return Ok(response);
    }
}