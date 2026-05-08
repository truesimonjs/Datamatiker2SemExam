using Datamatiker2SemExam.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

using Datamatiker2SemExam.Services;

namespace Datamatiker2SemExam.Pages
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public string Username { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public LoginModel()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            User? user = getUser(Username, Password);

            if (user == null)
            {
                ErrorMessage = "Kunne ikke logge ind";
                return Page();
            }


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

        public User? getUser(string username, string password)
        {
            List<User> users = new List<User>();

            using MassageDBContext context = new MassageDBContext();

            users = context.Users.ToList();

            User? user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            return user;
        }
    }
}
