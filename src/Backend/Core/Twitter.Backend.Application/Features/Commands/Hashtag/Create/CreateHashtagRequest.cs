using MediatR;

namespace Twitter.Backend.Application.Features.Commands.Hashtag.Create;

public class CreateHashtagRequest : IRequest<CreateHashtagResponse>
{
    public string Tag { get; set; }
}