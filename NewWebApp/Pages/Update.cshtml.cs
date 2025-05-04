using System.Data;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewWebApp.Model;

namespace NewWebApp.Pages
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public User User { get; set; } = new User();
        public string Msg { get; set; } = string.Empty;

        public string SuccessMsg { get; set; } = string.Empty;
        [BindProperty]
        public bool Admin { get; set; } = false;
        public IActionResult OnGet(string param)
        {
            int id = int.Parse(param);
            Helper helper = new Helper();
            string SQL = $"SELECT * FROM Users WHERE Id = {id}";
            DataTable dt = helper.RetrieveTable(SQL, "Users");
            DataRow dr = dt.Rows[0];
            //User user = new User();
            User.ID = id;
            User.Username = dr["Username"].ToString();
            User.Password = dr["Password"].ToString();
            User.Firstname = dr["First name"].ToString();
            User.Lastname = dr["Last name"].ToString();
            if (string.IsNullOrEmpty(dr["Admin"].ToString()))
                Admin = false;
            else
                Admin = true;
            User.Birthdate = dr["Birth date"].ToString();


            return Page();

        }

        public IActionResult OnPost()
        {
            Helper helper = new Helper();
            if (Admin)
                User.Admin = "true";
            else
                User.Admin = "";

            try
            {
             
                int n = helper.Update(User, "Users");
                SuccessMsg = "User " + User.Username + " updated successfully";
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
            }
            return Page();
        }
    }
}
