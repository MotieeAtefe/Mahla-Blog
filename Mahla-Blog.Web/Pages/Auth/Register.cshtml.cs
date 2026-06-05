using Mahla_Blog.CoreLayer.DTOs.Users;
using Mahla_Blog.CoreLayer.Services.Users;
using Mahla_Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Mahla_Blog.Web.Pages.Auth
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;
        #region Property
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = " {0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = " {0} را وارد کنید")]
        public string FullName { get; set; }

        [Required(ErrorMessage = " {0} را وارد کنید")]
        [Display(Name = "رمزعبور")]
        public string Password { get; set; }
        #endregion
        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var result = _userService.RegisterUser(new UserRegisterDto()
            {
                UserName = UserName,
                FullName = FullName,
                Password = Password
            });
            if (result.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError("UserName", result.Message);
                return Page();
            }
            return RedirectToPage("Login");
        }
    }
}
