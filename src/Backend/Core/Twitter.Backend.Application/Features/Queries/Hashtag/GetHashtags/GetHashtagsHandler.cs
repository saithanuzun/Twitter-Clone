using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.Hashtag.GetHashtags;

public class GetHashtagsHandler : IRequestHandler<GetHashtagsRequest,GetHashTagsResponse>
{
    private readonly IHashtagRepository _hashtagRepository;
    private readonly ITweetHashTagRepository _tweetHashTagRepository;
    private IMapper _mapper;

    public GetHashtagsHandler(IHashtagRepository hashtagRepository, IMapper mapper, ITweetHashTagRepository tweetHashTagRepository)
    {
        _hashtagRepository = hashtagRepository;
        _mapper = mapper;
        _tweetHashTagRepository = tweetHashTagRepository;
    }

    public async Task<GetHashTagsResponse> Handle(GetHashtagsRequest request, CancellationToken cancellationToken)
    {
        var dic = new Dictionary<string, int>();
        var hashtags = await _hashtagRepository.GetAll(default);

        foreach (var item in hashtags)
        {
            var count = _tweetHashTagRepository.Get(i => i.HashtagId == item.Id).Count();
            dic.Add(item.Tag,count);
        }

        return new GetHashTagsResponse() {Hashtags = dic};
    }
}