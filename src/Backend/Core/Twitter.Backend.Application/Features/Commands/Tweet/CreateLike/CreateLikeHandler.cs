using AutoMapper;
using MediatR;
using Twitter.Backend.Application.Features.Commands.Tweet.Create;
using Twitter.Backend.Domain.Entities;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Commands.Tweet.CreateLike;

public class CreateLikeHandler : IRequestHandler<CreateLikeRequest,CreateLikeResponse>
{
    private ITweetLikeRepository _tweetLikeRepository;
    private IMapper _mapper;

    public CreateLikeHandler(IMapper mapper, ITweetLikeRepository tweetLikeRepository)
    {
        _mapper = mapper;
        _tweetLikeRepository = tweetLikeRepository;
    }

    public async Task<CreateLikeResponse> Handle(CreateLikeRequest request, CancellationToken cancellationToken)
    {
        var dbLike = _mapper.Map<TweetLike>(request);

        await _tweetLikeRepository.AddAsync(dbLike);

        return new CreateLikeResponse() { Id = dbLike.Id };
        
    }
}