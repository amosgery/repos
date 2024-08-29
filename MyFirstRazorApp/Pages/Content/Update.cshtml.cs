using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using MyFirstRazorApp.Model;

namespace MyFirstRazorApp.Pages.Content
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public User User { get; set; } = new User();
        public string Msg { get; set; } = string.Empty;

        public string SuccessMsg { get; set; } = string.Empty;

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
            User.FirstName = dr["Firstname"].ToString();
            User.LastName = dr["Lastname"].ToString();
            User.Email = dr["Email"].ToString();
            User.Phone = dr["Phone"].ToString();
            if (dr["Admin"].ToString().IsNullOrEmpty() ||
                dr["Admin"].ToString().Contains("false") ||
                dr["Admin"].ToString().Contains("False"))
                User.Admin = false;
            else 
                User.Admin = true;
            User.Birthday = DateTime.Parse(dr["Birthdate"].ToString());
            User.Gender = dr["Gender"].ToString();
            User.Occupation = dr["Occupation"].ToString();

            return Page();

        }

        public IActionResult OnPost()
        {
            Helper helper = new Helper();
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
