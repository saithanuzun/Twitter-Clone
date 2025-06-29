using AutoMapper;
using MediatR;
using Twitter.Backend.Application.Features.Commands.Hashtag.Create;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Commands.Hashtag.CreateTweetHashtag;

public class CreateTweetHashtagHandler : IRequestHandler<CreateTweetHashtagRequest,CreateHashtagResponse>
{
    private ITweetHashTagRepository _hashTagRepository;
    private IMapper _mapper;

    public CreateTweetHashtagHandler(ITweetHashTagRepository hashTagRepository, IMapper mapper)
    {
        _hashTagRepository = hashTagRepository;
        _mapper = mapper;
    }

    public async Task<CreateHashtagResponse> Handle(CreateTweetHashtagRequest request, CancellationToken cancellationToken)
    {
        var dbTweetHashtag = _mapper.Map<Domain.Entities.TweetHashtag>(request);

        await _hashTagRepository.AddAsync(dbTweetHashtag);

        return new CreateHashtagResponse() { Id = dbTweetHashtag.Id };
    }
}