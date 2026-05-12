using Datamatiker2SemExam.Interfaces;
using Datamatiker2SemExam.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Datamatiker2SemExam.Services
{
    public class UserRepository : EFCRepositoryBase<User, MassageDBContext>, IUserRepository
    {
        public User? GetUserByUsernameAndPassword(string username, string password)
        {
            List<User> users = new List<User>();

            using MassageDBContext context = new MassageDBContext();

            users = context.Users.ToList();

            User? user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            return user;
        }

        public async Task LogIn(HttpContext httpContext, User user)
        {
            // Opbyg ClaimsPrincipal
            ClaimsPrincipal claimsPrincipal = BuildClaimsPrincipal(user);

            // Log ind
            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal);
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

    }
}