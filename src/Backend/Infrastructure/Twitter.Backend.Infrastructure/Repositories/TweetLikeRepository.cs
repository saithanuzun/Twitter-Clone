using Microsoft.EntityFrameworkCore;
using Twitter.Backend.Domain.Entities;
using Twitter.Backend.Domain.Repositories;
using Twitter.Backend.Infrastructure.Context;

namespace EksiSozluk.Api.Infrastructure.Persistence.Repositories;

public class TweetLikeRepository : GenericRepository<TweetLike>,ITweetLikeRepository
{
    public TweetLikeRepository(TwitterContext dbContext) : base(dbContext)
    {
    }
}