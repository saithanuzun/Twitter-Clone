using Twitter.Frontend.BlazorApp.Infrastructure.Models.Dvos;
using Twitter.Frontend.BlazorApp.Infrastructure.Services.Interfaces;

namespace Twitter.Frontend.BlazorApp.Infrastructure.Services;

public class UserService : IUserService
{
    public Task<UserDetailsDvo> GetUserDetail(Guid? id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDetailsDvo> GetUserDetail(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateUser(UserDetailsDvo user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeUserPassword(string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }
}