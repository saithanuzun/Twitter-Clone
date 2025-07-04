using AutoMapper;
using MediatR;
using Twitter.Backend.Application.Features.Commands.Tweet.DeleteLike;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Commands.Tweet.Delete;

public class DeleteTweetHandler : IRequestHandler<DeleteTweetRequest,DeleteTweetResponse>
{
    private ITweetRepository _tweetRepository;
    private IMapper _mapper;

    public DeleteTweetHandler(ITweetRepository tweetRepository, IMapper mapper)
    {
        _tweetRepository = tweetRepository;
        _mapper = mapper;
    }


    public async Task<DeleteTweetResponse> Handle(DeleteTweetRequest request, CancellationToken cancellationToken)
    {
        var dbTweet = await _tweetRepository
            .GetSingleAsync(i => i.Id == request.TweetId);
        
        await _tweetRepository.DeleteAsync(dbTweet);

        return new DeleteTweetResponse() { TweetId =  dbTweet.Id };
    }
}