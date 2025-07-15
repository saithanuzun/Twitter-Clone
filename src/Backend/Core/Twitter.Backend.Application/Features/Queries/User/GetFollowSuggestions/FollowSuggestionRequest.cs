using MediatR;

namespace Twitter.Backend.Application.Features.Queries.User.GetFollowSuggestions;

public class FollowSuggestionRequest : IRequest<FollowSuggestionResponse>
{
    public Guid UserId { get; set; }
}