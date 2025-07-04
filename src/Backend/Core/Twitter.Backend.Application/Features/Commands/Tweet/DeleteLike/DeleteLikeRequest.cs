using MediatR;

namespace Twitter.Backend.Application.Features.Commands.Tweet.DeleteLike;

public class DeleteLikeRequest : IRequest<DeleteLikeResponse>
{
    public Guid Id { get; set; }
}