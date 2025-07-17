using Twitter.BlazorApp.Infrastructure.Models.Dvos;

namespace Twitter.BlazorApp.Infrastructure.Services.Interfaces;

public interface IUserService
{
    Task<UserDetailsDvo> GetUserDetails(Guid? id);
    Task<UserDetailsDvo> GetUserDetails(string userName);
    Task<UserFollowersDvo> GetUserFollowers(string userName);
    Task<UserFollowingDvo> GetUserFollowings(string userName);

    Task<bool> UpdateUser(UserDetailsDvo user);
    Task<bool> ChangeUserPassword(string oldPassword, string newPassword);

    Task<FollowSuggestionDvo> FollowSuggestions(Guid UserId);
}