using MediatR;

namespace Twitter.Backend.Application.Features.Commands.User.DeleteFollow;

public class DeleteFollowRequest : IRequest<DeleteFollowResponse>
{
    public Guid Id { get; set; }
}