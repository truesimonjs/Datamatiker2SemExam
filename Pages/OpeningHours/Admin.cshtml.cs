using Datamatiker2SemExam.Interfaces;
using Datamatiker2SemExam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Datamatiker2SemExam.Pages
{
    public class AdminModel : PageModel
    {

        public List<OpeningHour> OpeningHours { get; set; }
        public IOpeningHourRepository _openingHoursRepository { get; set; }

        public AdminModel(IOpeningHourRepository openingHourRepository)
        {
            _openingHoursRepository = openingHourRepository;
        }

        public void OnGet()
        {
            OpeningHours = _openingHoursRepository.GetAll();
        }

        public async Task<IActionResult> OnPost()
        {
            return Page();
        }
        }
}