using Twitter.Frontend.BlazorApp.Infrastructure.Models.Dvos;
using Twitter.Frontend.BlazorApp.Infrastructure.Services.Interfaces;

namespace Twitter.Frontend.BlazorApp.Infrastructure.Services;

public class HashtagService : IHashtagService
{
    public Task<List<HashtagDvo>> GetHashtags()
    {
        throw new NotImplementedException();
    }
}