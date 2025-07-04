using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Twitter.Backend.Application.Features.Commands.User.Create;
using Twitter.Backend.Application.Features.Commands.User.Update;
using Twitter.Backend.Application.Features.Queries.Tweet.GetTweet;
using Twitter.Backend.Application.Features.Queries.User.GetUser;
using Twitter.Backend.Application.Features.Queries.User.GetUserFollowers;
using Twitter.Backend.Application.Features.Queries.User.GetUserFollowings;

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
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    
    [HttpPost] // TODO: Implement the auth func JWT.

    [Route("Login")] // TODO: Implement the login functionality.
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
    
    [HttpGet("{Username}")]
    public async Task<IActionResult> GetByUsername(string Username)
    {
        var response = await _mediator.Send(new GetUserRequest() { Username = Username });
        return Ok(response);
    }

    [HttpGet("{UserId:guid}/Followers")]
    public async Task<IActionResult> GetUserFollowers(Guid UserId)
    {
        var response = await _mediator.Send(new GetUserFollowersRequest { UserId = UserId});
        return Ok(response);
    }
    
    [HttpGet("{UserId:guid}/Following")]
    public async Task<IActionResult> GetUserFollowing(Guid UserId)
    {
        var response = await _mediator.Send(new GetUserFollowingsRequest() { FollowerUserId = UserId});
        return Ok(response);
    }
    
   
}