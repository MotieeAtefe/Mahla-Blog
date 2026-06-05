using Mahla_Blog.CoreLayer.DTOs.Users;
using Mahla_Blog.CoreLayer.Utilities;

namespace Mahla_Blog.CoreLayer.Services.Users
{
    public interface IUserService
    {
        OperationResult RegisterUser(UserRegisterDto userRegisterDto);
        UserDto LoginUser(UserLoginDto userLoginDto);
    }
}
