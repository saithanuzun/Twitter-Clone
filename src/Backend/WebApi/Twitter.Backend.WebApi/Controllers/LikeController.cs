using MediatR;
using Microsoft.AspNetCore.Mvc;
using Twitter.Backend.Application.Features.Commands.Tweet.CreateLike;
using Twitter.Backend.Application.Features.Commands.Tweet.DeleteLike;

namespace Twitter.Backend.WebApi.Controllers;

public class LikeController : BaseController
{
    public LikeController(IMediator mediator) : base(mediator)
    {
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateLike([FromBody] CreateLikeRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteLike([FromBody] DeleteLikeRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}