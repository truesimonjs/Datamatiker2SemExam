using Datamatiker2SemExam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Datamatiker2SemExam.Pages
{
    public class ViewBookingModel : PageModel
    {
        private readonly MassageDBContext _context;

        public ViewBookingModel(MassageDBContext context)
        {
            _context = context;
        }

        public List<Booking> Bookings { get; set; } = new List<Booking>();
        public void OnGet()
        {
            Bookings = _context.Bookings.ToList();
        }
    }
}
