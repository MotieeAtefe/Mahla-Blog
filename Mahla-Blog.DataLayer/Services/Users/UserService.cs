using System;
using System.Linq;
using Mahla_Blog.CoreLayer.DTOs.Users;
using Mahla_Blog.CoreLayer.Utilities;
using Mahla_Blog_DataLayer.Context;
using Mahla_Blog_DataLayer.Entities;


namespace Mahla_Blog.CoreLayer.Services.Users
{
    public class UserService : IUserService
    {
        readonly BlogContext _Context;
        public UserService(BlogContext Context)
        {
            _Context = Context;
        }

        public UserDto LoginUser(UserLoginDto userLoginDto)
        {
            var PasswordHash = userLoginDto.Password.EncodeToMd5();
            var User = _Context.Users.FirstOrDefault(u => u.UserName == userLoginDto.UserName && u.Password == PasswordHash);

            if (User == null) 
                return null;

            var UserDto = new UserDto()
            {
                UserId = User.Id,
                FullName = User.FullName,
                Password = User.Password,
                UserName = User.UserName,
                Role = User.Role,
                RegisterData = User.CreationDate

            };
            return UserDto;
        }

        public OperationResult RegisterUser(UserRegisterDto userRegisterDto)
        {
            var isUserExists = _Context.Users.Any(u => u.UserName == userRegisterDto.UserName);
            if (isUserExists)
                return OperationResult.Error("نام تکراری است");
            var HashPassword = userRegisterDto.Password.EncodeToMd5();

            _Context.Users.Add(new User()
            {
                UserName = userRegisterDto.UserName,
                IsDeleted = false,
                FullName = userRegisterDto.FullName,
                Role = UserRole.User,
                CreationDate = DateTime.Now,
                Password = HashPassword

            });
            _Context.SaveChanges();
            return OperationResult.Success();
        }
    }
}
