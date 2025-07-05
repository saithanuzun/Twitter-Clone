using Twitter.Frontend.BlazorApp.Infrastructure.Models.Dvos;

namespace Twitter.Frontend.BlazorApp.Infrastructure.Services.Interfaces;

public interface IUserService
{
    Task<UserDetailsDvo> GetUserDetail(Guid? id);
    Task<UserDetailsDvo> GetUserDetail(string userName);
    Task<bool> UpdateUser(UserDetailsDvo user);
    Task<bool> ChangeUserPassword(string oldPassword, string newPassword);
}