using Mahla_Blog.CoreLayer.Services.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mahla_Blog.Web.Pages.Auth
{
    [ValidateAntiForgeryToken]
    [BindProperties]
    public class LoginModel : PageModel
    {
        public readonly IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }
        #region Property
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = " {0} را وارد کنید")]
        public string UserName { get; set; }

        [Required(ErrorMessage = " {0} را وارد کنید")]
        [Display(Name = "رمزعبور")]
        public string Password { get; set; }
        #endregion

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var User = _userService.LoginUser(new CoreLayer.DTOs.Users.UserLoginDto()
            {
                UserName = UserName,
                Password = Password
            });

            if (User == null)
            {
                ModelState.AddModelError("UserName", "کاربری با این مشخصات یافت نشد");
                return Page();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim("Test","Test"),
                new Claim(ClaimTypes.NameIdentifier, User.UserId.ToString()),
                new Claim(ClaimTypes.Name,User.FullName)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var ClaimsPrincipal = new ClaimsPrincipal(identity);
           await HttpContext.SignInAsync(ClaimsPrincipal);

            return RedirectToPage("../Index");


        }





    }
}
