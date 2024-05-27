using Microsoft.AspNetCore.Identity;
using Uncos.WebAPI.Models.AuthModels;

namespace Uncos.WebAPI.Services
{
    public interface IUserService
    {
        Task<RegisterResponseModel> RegisterAsync(RegisterModel model);
        Task<LoginResponseModel> LoginAsync(LoginModel model);
        Task<string> LogoutAsync();
    }
}
