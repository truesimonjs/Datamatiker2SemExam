using Datamatiker2SemExam.Interfaces;
using Datamatiker2SemExam.Models;
using Datamatiker2SemExam.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Datamatiker2SemExam.Pages
{
    public class ViewBookingModel : PageModel
    {
        private IBookingRepository _bookingRepository;

        public List<Booking> Bookings { get; set; } = new List<Booking>();

        public ViewBookingModel(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public void OnGet()
        {
            Bookings = _bookingRepository.GetAll();
            Console.WriteLine(Bookings.ToString());
        }

        public IActionResult OnPostDelete(int id)
        {
            var booking = _bookingRepository.Read(id);

            if (booking == null)

            {
                return NotFound();
            }

            _bookingRepository.Delete(id);

            return RedirectToPage();
        }

    }
}

