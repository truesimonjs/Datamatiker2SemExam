using Datamatiker2SemExam.Interfaces;
using Datamatiker2SemExam.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Datamatiker2SemExam.Pages
{
    public class IndexModel : PageModel
    {
        private IOpeningHourRepository _openingHour;

        public List<OpeningHour> OpeningHours { get; set; }

        public IndexModel(IOpeningHourRepository openingHourRepository)
        {
            _openingHour = openingHourRepository;
        }
        public void OnGet()
        {
            OpeningHours = _openingHour.GetAll();
           
        }
    }
}