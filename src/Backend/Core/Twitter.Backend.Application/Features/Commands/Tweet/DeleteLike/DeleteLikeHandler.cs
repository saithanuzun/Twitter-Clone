using AutoMapper;
using MediatR;
using Twitter.Backend.Application.Features.Commands.Tweet.CreateLike;
using Twitter.Backend.Domain.Entities;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Commands.Tweet.DeleteLike;

public class DeleteLikeHandler : IRequestHandler<DeleteLikeRequest,DeleteLikeResponse>
{
    private ITweetLikeRepository _tweetLikeRepository;
    private IMapper _mapper;

    public DeleteLikeHandler(ITweetLikeRepository tweetLikeRepository, IMapper mapper)
    {
        _tweetLikeRepository = tweetLikeRepository;
        _mapper = mapper;
    }

    public async Task<DeleteLikeResponse> Handle(DeleteLikeRequest request, CancellationToken cancellationToken)
    {
        var dbLike = await _tweetLikeRepository
            .GetSingleAsync(i => i.Id == request.Id);
        
        await _tweetLikeRepository.DeleteAsync(dbLike);

        return new DeleteLikeResponse() { Id = dbLike.Id };
    }
}