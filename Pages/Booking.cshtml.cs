using Datamatiker2SemExam.Interfaces;
using Datamatiker2SemExam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Datamatiker2SemExam.Pages
{
    public class BookingModel : PageModel
    {
        private readonly IBookingRepository _bookingRepository;

        public int Id { get; set; }
        public string Name { get; set; }
        public Booking? Booking { get; set; }

        public BookingModel(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public IActionResult OnGet(int id)
        {
            Id = id;
            Booking = _bookingRepository.Read(id);
            if (Booking == null)
            {
                return NotFound();
            }
            return Page();
        }
   
    }
}