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
            User user = helper.GetUser(NewUser, "Users");

            if (user != null)
            {
                HttpContext.Session.SetString("Login", user.Firstname);
                HttpContext.Session.SetString("Admin", user.Admin);
                return RedirectToPage("/Index");
            }
            Msg = "Wrong username or password.";
            return Page();
        }
    }
}
