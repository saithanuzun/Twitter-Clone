using MediatR;
using Microsoft.AspNetCore.Mvc;
using Twitter.Backend.Application.Features.Commands.User.CreateFollow;
using Twitter.Backend.Application.Features.Commands.User.DeleteFollow;

namespace Twitter.Backend.WebApi.Controllers;

public class FollowController : BaseController
{
    public FollowController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateFollow([FromBody] CreateFollowRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteFollow([FromBody] DeleteFollowRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}