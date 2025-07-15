using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Twitter.Backend.Application.Features.Commands.User.Create;
using Twitter.Backend.Application.Features.Commands.User.Update;
using Twitter.Backend.Application.Features.Queries.Tweet.GetTweet;
using Twitter.Backend.Application.Features.Queries.User.GetFollowSuggestions;
using Twitter.Backend.Application.Features.Queries.User.GetUser;
using Twitter.Backend.Application.Features.Queries.User.GetUserFollowers;
using Twitter.Backend.Application.Features.Queries.User.GetUserFollowings;
using LoginRequest = Twitter.Backend.Application.Features.Commands.User.Login.LoginRequest;

namespace Twitter.Backend.WebApi.Controllers;

public class UserController : BaseController
{
    public UserController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [HttpPut]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _mediator.Send(request);

        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _mediator.Send(new GetUserRequest() { Id = id });
        return Ok(response);
    }
    
    [HttpGet("{username}")]
    public async Task<IActionResult> GetByUsername(string username)
    {
        var response = await _mediator.Send(new GetUserRequest() { Username = username });
        return Ok(response);
    }

    [HttpGet("{username}/followers")]
    public async Task<IActionResult> GetUserFollowersByUsername(string username)
    {
        var user = await _mediator.Send(new GetUserRequest { Username = username });
        if (user == null) return NotFound($"User '{username}' not found.");

        var response = await _mediator.Send(new GetUserFollowersRequest { FollowingId = user.Id });
        return Ok(response);
    }

    [HttpGet("{username}/following")]
    public async Task<IActionResult> GetUserFollowingByUsername(string username)
    {
        var user = await _mediator.Send(new GetUserRequest { Username = username });
        if (user == null) return NotFound($"User '{username}' not found.");

        var response = await _mediator.Send(new GetUserFollowingsRequest { FollowerUserId = user.Id });
        return Ok(response);
    }
    
    [HttpGet("suggestions/{userId:guid}")]
    public async Task<IActionResult> GetUserFollowSuggestion(Guid userId)
    {
        var response = await _mediator.Send(new FollowSuggestionRequest(){UserId = userId});
        
        return Ok(response);
    }

    
}