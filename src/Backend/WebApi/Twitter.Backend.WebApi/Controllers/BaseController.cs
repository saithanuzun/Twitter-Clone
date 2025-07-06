using System.Security.Claims;
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

    public Guid? UserId
    {
        get
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity is not null)
            {
                var userClaims = identity.Claims;
                var id = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value;

                if (!string.IsNullOrEmpty(id))
                    return new Guid(id);
            }

            return null;
        }
    }
}
