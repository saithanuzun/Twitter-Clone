using Twitter.Frontend.BlazorApp.Infrastructure.Models.Dvos;

namespace Twitter.Frontend.BlazorApp.Infrastructure.Services.Interfaces;

public interface IUserService
{
    Task<UserDetailsDvo> GetUserDetails(Guid? id);
    Task<UserDetailsDvo> GetUserDetails(string userName);
    Task<bool> UpdateUser(UserDetailsDvo user);
    Task<bool> ChangeUserPassword(string oldPassword, string newPassword);

    Task<FollowSuggestionDvo> FollowSuggestions(Guid UserId);
}