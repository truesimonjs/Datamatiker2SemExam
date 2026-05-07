
using Datamatiker2SemExam.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Datamatiker2SemExam.Pages
{
    public class LoginModel : PageModel
    {
        public static User? CurrentUser { get; set; }

        [BindProperty]
        public string Navn { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public LoginModel()
        {
        }

        public async Task<IActionResult> OnPost()
        {

 

            return RedirectToPage("/Index");
        }


        public void OnGet()
        {
            List<User> users = new List<User>();

            using MassageDBContext context = new MassageDBContext();

            users = context.Users.ToList();

            User? user = users.FirstOrDefault(u => u.Navn == "lucas");

            Console.WriteLine(user.Navn);
        }
    }
}
