using Platform.Core.Entities;
using Platform.Core.Requests.Auth;

namespace Platform.Core.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<UserLoginResponseDto>> Login(string username, string password);
        ServiceResponse<int> Logout(); 
    }
}
