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
        }
    }
}

