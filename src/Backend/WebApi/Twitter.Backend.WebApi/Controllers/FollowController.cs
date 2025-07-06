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
    
    [HttpPost("{BeingFollowedId:guid}")]
    public async Task<IActionResult> CreateFollow(Guid BeingFollowedId)
    {
        var request = new CreateFollowRequest() { FollowerId = UserId.Value, FollowingId = BeingFollowedId };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [HttpDelete("{BeingFollowedId:guid}")]
    public async Task<IActionResult> DeleteFollow(Guid BeingFollowedId)
    {
        var request = new DeleteFollowRequest() { FollowerId = UserId.Value, FollowingId = BeingFollowedId };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}