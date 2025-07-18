using Twitter.BlazorApp.Infrastructure.Models.Dvos;

namespace Twitter.BlazorApp.Infrastructure.Services.Interfaces;

public interface IHashtagService
{
    Task<HashtagsDvo> GetHashtags();

}