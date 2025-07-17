using MediatR;
using Twitter.Backend.Application.Pagination;

namespace Twitter.Backend.Application.Features.Queries.Tweet.GetMainPageTweets;

public class GetMainPageTweetsRequest : PagedQuery, IRequest<PaginationResponse<GetMainPageTweetsResponse>> 
{
    
}