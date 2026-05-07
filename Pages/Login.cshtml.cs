
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
            User? user = getUser();
            Console.WriteLine(user?.Username);

            if (user == null)
            {
                ErrorMessage = "Kunne ikke logge ind";
                return Page();
            }

            Console.WriteLine("logging in");

            // Log ind
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                BuildClaimsPrincipal(user));


            return RedirectToPage("/Index");
        }

        private ClaimsPrincipal BuildClaimsPrincipal(User user)
        {
            // Opbyg Claims-liste
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            claims.Add(new Claim(ClaimTypes.Role, user.Role));

            // Opret ClaimsIdentity (claims plus Authentication-strategi)
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Opret endeligt ClaimsPrincipal-objekt
            return new ClaimsPrincipal(claimsIdentity);
        }

        public User? getUser()
        {
            List<User> users = new List<User>();

            using MassageDBContext context = new MassageDBContext();

            users = context.Users.ToList();

            User? user = users.FirstOrDefault(u => u.Username == "lucas");

            return user;
        }
    }
}
