using MediatR;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Queries.User.GetUserReplies;

public class GetUserRepliesHandler : IRequestHandler<GetUserRepliesRequest,GetUserRepliesResponse>
{
    private readonly ITweetRepository _tweetRepository;
    private readonly IUserRepository _userRepository;
    
    public async Task<GetUserRepliesResponse> Handle(GetUserRepliesRequest request, CancellationToken cancellationToken)
    {
        var tweets =  _tweetRepository
            .Get(i => i.UserId == request.UserId || request.username==i.User.Username,default,i=>i.User)
            .Select(i=>i.Id)
            .ToList();

        var RepliedTweetIds = new List<Guid>();
        
        foreach (var tweetId in tweets)
        {
            var hasParent = _tweetRepository.Get(i=>i.ParentTweetId==tweetId).Any();
            
            if (hasParent)
                RepliedTweetIds.Add(tweetId);
                
        }
        

        return new GetUserRepliesResponse() { UserId = request.UserId, Username=request.username, TweetIds = RepliedTweetIds };
        
    }
}