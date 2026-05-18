using Datamatiker2SemExam.Interfaces;
using Datamatiker2SemExam.Models;
using Datamatiker2SemExam.Services;
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

        private IUserRepository _userRepository;


        [BindProperty]
        public string Username { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public LoginModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> OnPost()
        {
            User? user = _userRepository.GetUserByUsernameAndPassword(Username, Password);

            if (user == null)
            {
                ErrorMessage = "Kunne ikke logge ind";
                return Page();
            }

            await _userRepository.LogIn(HttpContext, user);

            return RedirectToPage("/Index");
        }


    }
}
