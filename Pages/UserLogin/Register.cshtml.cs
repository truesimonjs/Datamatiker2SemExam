using Datamatiker2SemExam.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Datamatiker2SemExam.Models;

namespace Datamatiker2SemExam.Pages
{
    public class RegisterModel : PageModel
    {
        public IUserRepository _userRepository { get; set; }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public RegisterModel (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> OnPost()
        {
            List<User> allUsers = _userRepository.GetAll();
            bool existingUser = allUsers.Any(u => u.Username == Username);
            if (existingUser)
            {
                ErrorMessage = "Username already exists. Please choose a different username.";
                return Page();
            }
            User newUser = new User
            {
                Username = Username,
                Password = Password,
                Role = "User"
            };
            _userRepository.Create(newUser);
            await _userRepository.LogIn(HttpContext, newUser);
            return RedirectToPage("/Index");

        }
        public void OnGet()
        {
        }
    }
}
