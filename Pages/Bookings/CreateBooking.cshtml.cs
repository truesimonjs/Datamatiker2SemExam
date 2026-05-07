using Datamatiker2SemExam.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Datamatiker2SemExam.Models;
namespace Datamatiker2SemExam.Pages.Bookings
{
    public class CreateBookingModel : PageModel
    {
        private IBookingRepository repo;
        public Booking Element { get; set; } = new();
        public CreateBookingModel(IBookingRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();

            }
            repo.Create(Element);
            return RedirectToPage();
               
        }
    }
}
