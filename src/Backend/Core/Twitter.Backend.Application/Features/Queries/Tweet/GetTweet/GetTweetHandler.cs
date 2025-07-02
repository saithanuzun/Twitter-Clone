using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.Tweet.GetTweet;

public class GetTweetHandler : IRequestHandler<GetTweetRequest,GetTweetResponse>
{
    private readonly ITweetRepository _tweetRepository;
    private readonly IMapper _mapper;

    public GetTweetHandler(ITweetRepository tweetRepository, IMapper mapper)
    {
        _tweetRepository = tweetRepository;
        _mapper = mapper;
    }

    public async Task<GetTweetResponse> Handle(GetTweetRequest request, CancellationToken cancellationToken)
    {
        var tweet = await _tweetRepository.GetByIdAsync(request.Id);

        return _mapper.Map<GetTweetResponse>(tweet);
    }
}