using AutoMapper;
using MediatR;
using Twitter.Backend.Application.Features.Queries.Hashtag.GetHashtags;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.Hashtag.GetHashtagTweets;

public class GetHashtagTweetHandler : IRequestHandler<GetHashtagsRequest,GetHashTagsResponse>
{
    private IHashtagRepository _hashtagRepository;
    private IMapper _mapper;
    

    public GetHashtagTweetHandler(IHashtagRepository hashtagRepository, IMapper mapper)
    {
        _hashtagRepository = hashtagRepository;
        _mapper = mapper;
    }

    public Task<GetHashTagsResponse> Handle(GetHashtagsRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}