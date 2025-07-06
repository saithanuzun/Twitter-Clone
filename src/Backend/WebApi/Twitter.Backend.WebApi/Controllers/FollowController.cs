using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twitter.Backend.Application.Features.Commands.User.CreateFollow;
using Twitter.Backend.Application.Features.Commands.User.DeleteFollow;

namespace Twitter.Backend.WebApi.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class FollowController : BaseController
{
    public FollowController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPost("{beingFollowedId:guid}")]
    public async Task<IActionResult> CreateFollow(Guid beingFollowedId)
    {
        var request = new CreateFollowRequest() { FollowerId = UserId.Value, FollowingId = beingFollowedId };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [HttpDelete("{beingFollowedId:guid}")]
    public async Task<IActionResult> DeleteFollow(Guid beingFollowedId)
    {
        var request = new DeleteFollowRequest() { FollowerId = UserId.Value, FollowingId = beingFollowedId };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}