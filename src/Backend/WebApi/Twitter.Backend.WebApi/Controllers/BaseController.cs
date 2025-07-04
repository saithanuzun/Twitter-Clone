using MediatR;
using Microsoft.AspNetCore.Mvc;using MediatR;
using Microsoft.AspNetCore.Mvc;
using Twitter.Backend.Application.Features.Queries.Tweet.GetTweet;

namespace Twitter.Backend.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
