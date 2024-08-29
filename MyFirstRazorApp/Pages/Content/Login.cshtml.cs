using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFirstRazorApp.Model;

namespace MyFirstRazorApp.Pages.Content
{
    public class LoginModel : PageModel
    {
        public string Msg { get; set; } = "";
        public void OnGet()
        {
        }

        public IActionResult OnPost(User NewUser)
        {
            string SQLStr = $"SELECT * FROM Users WHERE Username LIKE '{NewUser.Username}' AND Password LIKE '{NewUser.Password}'";
            Helper helper = new Helper();
            DataTable dt = helper.RetrieveTable(SQLStr, "Users");

            if (dt.Rows.Count > 0)
            {
                HttpContext.Session.SetString("Login", NewUser.Username);
                HttpContext.Session.SetString("Admin", dt.Rows[0]["Admin"].ToString());
                return RedirectToPage("/Index");
            }
            Msg = "Wrong username or password.";
            return Page();
        }
    }
}
