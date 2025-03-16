using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewWebApp.Model;

namespace NewWebApp.Pages
{
    public class usersModel : PageModel
    {

        public DataTable dt { get; set; }

        public string filter { get; set; } = string.Empty;
        public string column { get; set; } = string.Empty;
        public string order { get; set; } = string.Empty;


        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Admin")))
                return Redirect("/Error");
            // This is just a placeholder. Replace with actual data fetching logic.
            Helper helper = new Helper();
            string SQL = "SELECT * FROM Users";
            dt = helper.RetrieveTable(SQL, "Users");
            return Page();
        }
    }
}
