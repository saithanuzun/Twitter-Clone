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
        // Create tweet
        Domain.Entities.Tweet dbTweet;

        if (request.IsRetweet == true && request.RetweetParentId.HasValue)
        {
            dbTweet = Domain.Entities.Tweet.CreateRetweet(request.UserId, request.RetweetParentId.Value);
        }
        else if (request.ParentTweetId.HasValue)
        {
            dbTweet = Domain.Entities.Tweet.CreateReply(request.UserId, request.ParentTweetId.Value, request.Content, request.MediaUrl);
        }
        else
        {
            dbTweet = Domain.Entities.Tweet.Create(request.UserId, request.Content, request.MediaUrl);
        }

        await _tweetRepository.AddAsync(dbTweet);

        // Save hashtags and link to tweet
        foreach (var tag in hashtags)
        {
            // Check if hashtag already exists
            var existingHashtag = await _hashtagRepository.FirstOrDefaultAsync(i => i.Tag == tag);

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