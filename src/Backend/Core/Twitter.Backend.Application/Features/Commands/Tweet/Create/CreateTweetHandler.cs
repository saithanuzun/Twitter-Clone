using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Commands.Tweet.Create;

public class CreateTweetHandler : IRequestHandler<CreateTweetRequest, CreateTweetResponse>
{
    private readonly ITweetRepository _tweetRepository;
    private readonly IMapper _mapper;


    public CreateTweetHandler(ITweetRepository tweetRepository, IMapper mapper)
    {
        _tweetRepository = tweetRepository;
        _mapper = mapper;
    }

    public async Task<CreateTweetResponse> Handle(CreateTweetRequest request,
        CancellationToken cancellationToken)
    {
        var dbEntry = _mapper.Map<Domain.Entities.Tweet>(request);
        await _tweetRepository.AddAsync(dbEntry);

        return new CreateTweetResponse() { Id = dbEntry.Id };
    }

}
    
