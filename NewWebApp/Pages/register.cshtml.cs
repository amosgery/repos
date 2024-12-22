using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NewWebApp.Pages
{
    public class registerModel : PageModel
    {
        public string Msg { get; set; } = "";
        public void OnGet()
        {
        }

        public IActionResult OnPost(string Username, string Password)
        {
            if (Username == "Amos")
            {
                Msg = "User " + Username + " registered successfuly";
            }
            else
            {
                Msg = "Wrong username or password.";
            }
            return Page();
            
        }
    }
}
