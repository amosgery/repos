using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFirstRazorApp.Model;

namespace MyFirstRazorApp.Pages.Content
{
    public class UsersModel : PageModel
    {
        public DataTable dt { get; set; }

        public string filter { get; set; } = string.Empty;
        public string column { get; set; } = string.Empty;
        public string order { get; set; } = string.Empty ;


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

        public IActionResult OnPostFilter(string filter)
        {
            Helper helper = new Helper();
            string SQL;
            if (filter == string.Empty)
            {
                SQL = "SELECT * FROM Users";
            }
            else
            {
                SQL = $"SELECT * FROM Users WHERE Firstname LIKE '%{filter}%' OR Lastname Like '%{filter}%'";
            }
            dt = helper.RetrieveTable(SQL, "Users");
            return Page();
        }

        public IActionResult OnPostSort(string column, string order)
        {
            Helper helper = new Helper();
            string SQL = $"SELECT * FROM Users ORDER BY {column} {order}";
            dt = helper.RetrieveTable(SQL, "Users");
            return Page();
        }
    }

}
