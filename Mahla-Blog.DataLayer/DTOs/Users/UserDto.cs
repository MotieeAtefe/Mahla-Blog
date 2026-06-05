
using Mahla_Blog_DataLayer.Entities;
using System;

namespace Mahla_Blog.CoreLayer.DTOs.Users
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public DateTime RegisterData { get; set; }


    }
}
