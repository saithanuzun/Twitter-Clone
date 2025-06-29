using Microsoft.EntityFrameworkCore;
using Twitter.Backend.Domain.Entities;
using Twitter.Backend.Domain.Repositories;
using Twitter.Backend.Infrastructure.Context;

namespace EksiSozluk.Api.Infrastructure.Persistence.Repositories;

public class TweetHashtagRepository: GenericRepository<TweetHashtag>,ITweetHashTagRepository
{
    public TweetHashtagRepository(TwitterContext dbContext) : base(dbContext)
    {
    }
}