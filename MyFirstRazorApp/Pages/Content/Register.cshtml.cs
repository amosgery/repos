using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFirstRazorApp.Model;

namespace MyFirstRazorApp.Pages.Content
{
    public class RegisterModel : PageModel
    {
        public string Msg { get; set; } = "";
        public string SuccessMsg { get; set; } = "";
        public User NewUser { get; set; } 
        public void OnGet()
        {
            Msg = "";
            SuccessMsg = "";
        }
        public void OnPost(User NewUser)
        {
            Helper helper = new Helper();
            int n = helper.Insert(NewUser, "Users");
            if (n == -1)
            {
                Msg = "Username already taken.";
                //return Page();
            }
            else
            {
                SuccessMsg = "User " + NewUser.Username + " registered successfully";
            }
            //return Page();
        }
    }
}
