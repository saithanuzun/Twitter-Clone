using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Commands.Hashtag.Create;

public class CreateHashtagHandler : IRequestHandler<CreateHashtagRequest,CreateHashtagResponse>
{
    private readonly IHashtagRepository _hashtagRepository;
    private readonly IMapper _mapper;

    public CreateHashtagHandler(IHashtagRepository hashtagRepository, IMapper mapper)
    {
        _hashtagRepository = hashtagRepository;
        _mapper = mapper;
    }

    public async Task<CreateHashtagResponse> Handle(CreateHashtagRequest request, CancellationToken cancellationToken)
    {
        var dbTag = _mapper.Map<Domain.Entities.Hashtag>(request);

        await _hashtagRepository.AddAsync(dbTag);

        return new CreateHashtagResponse() { Id = dbTag.Id };
    }
}