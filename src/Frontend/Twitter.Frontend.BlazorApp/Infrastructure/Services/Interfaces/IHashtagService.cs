using Twitter.Frontend.BlazorApp.Infrastructure.Models.Dvos;

namespace Twitter.Frontend.BlazorApp.Infrastructure.Services.Interfaces;

public interface IHashtagService
{
    Task<List<HashtagDvo>> GetHashtags();
    
}