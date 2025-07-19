using System.Text.RegularExpressions;
using AutoMapper;
using MediatR;
using Twitter.Backend.Domain.Entities;
using Twitter.Backend.Domain.Repositories;

namespace Twitter.Backend.Application.Features.Commands.Tweet.Create;

public class CreateTweetHandler : IRequestHandler<CreateTweetRequest, CreateTweetResponse>
{
    private readonly ITweetRepository _tweetRepository;
    private readonly IMapper _mapper;
    private ITweetHashTagRepository _tweetHashTagRepository;
    private IHashtagRepository _hashtagRepository;


    public CreateTweetHandler(ITweetRepository tweetRepository, IMapper mapper,
        IHashtagRepository hashtagRepository, ITweetHashTagRepository tweetHashTagRepository)
    {
        _tweetRepository = tweetRepository;
        _mapper = mapper;
        _hashtagRepository = hashtagRepository;
        _tweetHashTagRepository = tweetHashTagRepository;
    }

    public async Task<CreateTweetResponse> Handle(CreateTweetRequest request, CancellationToken cancellationToken)
    {
        // Extract hashtags
        MatchCollection matches = Regex.Matches(request.Content, @"#\w+");
        List<string> hashtags = matches.Cast<Match>().Select(m => m.Value.ToLower()).Distinct().ToList();


        // Create tweet
        var dbTweet = new Domain.Entities.Tweet()
        {
            Content = request.Content,
            IsDeleted = false,
            IsRetweet = request.IsRetweet ?? false,
            UserId = request.UserId,
            MediaUrl = request.MediaUrl,
            RetweetParentId = request.RetweetParentId,
            ParentTweetId = request.ParentTweetId,
        };

        await _tweetRepository.AddAsync(dbTweet);

        // Save hashtags and link to tweet
        foreach (var tag in hashtags)
        {
            // Check if hashtag already exists
            var existingHashtag = await _hashtagRepository.FirstOrDefaultAsync(i=>i.Tag==tag);
            
            Domain.Entities.Hashtag hashtagEntity;

            if (existingHashtag != null)
            {
                hashtagEntity = existingHashtag;
            }
            else
            {
                hashtagEntity = new Domain.Entities.Hashtag { Tag = tag };
                await _hashtagRepository.AddAsync(hashtagEntity);
            }

            var tweetHashtag = new TweetHashtag
            {
                TweetId = dbTweet.Id,
                HashtagId = hashtagEntity.Id
            };

            await _tweetHashTagRepository.AddAsync(tweetHashtag);
        }

        return new CreateTweetResponse { Id = dbTweet.Id };
    }

}