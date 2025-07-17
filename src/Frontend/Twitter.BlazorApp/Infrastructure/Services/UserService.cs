using System.Text.Json;
using Twitter.BlazorApp.Infrastructure.Models.Dvos;
using Twitter.BlazorApp.Infrastructure.Services.Interfaces;

namespace Twitter.BlazorApp.Infrastructure.Services;

public class UserService : IUserService
{
    private HttpClient _client;

    public UserService(HttpClient client)
    {
        _client = client;
    }

    public async Task<UserDetailsDvo> GetUserDetails(Guid? id)
    {
        var response = await _client.GetAsync($"/api/user/{id}");
        
        var json = await response.Content.ReadAsStringAsync();
        
        var result = JsonSerializer.Deserialize<UserDetailsDvo>(json);
        
        return result;
    }

    public async Task<UserDetailsDvo> GetUserDetails(string userName)
    {
        var response = await _client.GetAsync($"/api/user/{userName}");
        
        var json = await response.Content.ReadAsStringAsync();
        
        var result = JsonSerializer.Deserialize<UserDetailsDvo>(json);
        
        return result;
    }

    public async Task<UserFollowersDvo> GetUserFollowers(string userName)
    {
        var response = await _client.GetAsync($"/api/user/{userName}/followers");
        
        var json = await response.Content.ReadAsStringAsync();
        
        var result = JsonSerializer.Deserialize<UserFollowersDvo>(json);
        
        return result;
    }

    public async Task<UserFollowingDvo> GetUserFollowings(string userName)
    {
        var response = await _client.GetAsync($"/api/user/{userName}/following");
        
        var json = await response.Content.ReadAsStringAsync();
        
        var result = JsonSerializer.Deserialize<UserFollowingDvo>(json);
        
        return result;
    }

    public Task<bool> UpdateUser(UserDetailsDvo user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeUserPassword(string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }

    public async Task<FollowSuggestionDvo> FollowSuggestions(Guid UserId)
    {
        Console.WriteLine("Starting GetHashtags...");

        var response = await _client.GetAsync($"/api/user/suggestions/{UserId}");
        Console.WriteLine($"Response received. Status code: {response.StatusCode}");

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Raw JSON: {json}");

        var result = JsonSerializer.Deserialize<FollowSuggestionDvo>(json);

        if (result == null)
        {
            Console.WriteLine("Deserialization failed: dvo is null.");
        }
        else
        {
            Console.WriteLine($"Deserialization succeeded. Hashtags count: {result.UserIds.Count().ToString()}");
        }

        return result;
    }
}