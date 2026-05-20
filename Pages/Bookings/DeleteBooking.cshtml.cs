using Datamatiker2SemExam.Interfaces;
using Datamatiker2SemExam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Datamatiker2SemExam.Pages
{
    public class DeleteBookingModel : PageModel
    {
        private readonly IBookingRepository _bookingRepository;
        public Booking? Booking { get; set; }

        public DeleteBookingModel(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public IActionResult OnGet(int id)
        {
            Booking = _bookingRepository.Read(id);
            if (Booking == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPostDelete(int id)
        {
            _bookingRepository.Delete(id);
            return RedirectToPage("/Bookings/ViewBooking");
        }
    }
}