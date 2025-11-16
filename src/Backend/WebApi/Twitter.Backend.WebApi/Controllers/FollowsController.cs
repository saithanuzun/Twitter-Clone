using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twitter.Backend.Application.Features.Commands.User.CreateFollow;
using Twitter.Backend.Application.Features.Commands.User.DeleteFollow;

namespace Twitter.Backend.WebApi.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class FollowsController : BaseController
{
    public FollowsController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPost("/users/{id}/follow")]
    public async Task<IActionResult> CreateFollow(Guid id)
    {
        var request = new CreateFollowRequest() { FollowerId = UserId.Value, FollowingId = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [HttpDelete("/users/{id}/follow")]
    public async Task<IActionResult> DeleteFollow(Guid id)
    {
        var request = new DeleteFollowRequest() { FollowerId = UserId.Value, FollowingId = id };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
}