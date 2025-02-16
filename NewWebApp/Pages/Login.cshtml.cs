using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewWebApp.Model;

namespace NewWebApp.Pages
{
    public class LoginModel : PageModel
    {
        public string Msg { get; set; } = "";
        public void OnGet()
        {
        }

        public IActionResult OnPost(User NewUser)
        {
            Helper helper = new Helper();
            bool userExist = helper.UserExist(NewUser, "Users");

            if (userExist)
            {
                HttpContext.Session.SetString("Login", NewUser.Username);
                HttpContext.Session.SetString("Admin", NewUser.Admin.ToString());
                return RedirectToPage("/Index");
            }
            Msg = "Wrong username or password.";
            return Page();
        }
    }
}
