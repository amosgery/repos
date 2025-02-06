using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewWebApp.Model;

namespace NewWebApp.Pages
{
    public class registerModel : PageModel
    {
        public string Msg { get; set; } = "";
        public User NewUser { get; set; }
        public void OnGet()
        {
            Msg = "";
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
                Msg = "User " + NewUser.Username + " registered successfully";
            }
            //return Page();
        }
    }
}
