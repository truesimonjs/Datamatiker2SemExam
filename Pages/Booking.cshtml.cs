using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Datamatiker2SemExam.Pages
{
    public class BookingModel : PageModel
    {

        public int Id { get; set; }
        public void OnGet(int id)
        {
            Id = id;
        }
    }
}