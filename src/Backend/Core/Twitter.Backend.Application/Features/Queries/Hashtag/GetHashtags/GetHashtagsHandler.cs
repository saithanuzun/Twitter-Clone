using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.Hashtag.GetHashtags;

public class GetHashtagsHandler : IRequestHandler<GetHashtagsRequest,GetHashTagsResponse>
{
    private IHashtagRepository _hashtagRepository;
    private IMapper _mapper;

    public GetHashtagsHandler(IHashtagRepository hashtagRepository, IMapper mapper)
    {
        _hashtagRepository = hashtagRepository;
        _mapper = mapper;
    }

    public async Task<GetHashTagsResponse> Handle(GetHashtagsRequest request, CancellationToken cancellationToken)
    {
        var hashtags =  _hashtagRepository.GetAll().Result.Select(i=>i.Tag).ToList();

        return new GetHashTagsResponse() {Hashtags = hashtags};
    }
}