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

    public Task<GetHashTagsResponse> Handle(GetHashtagsRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}