using Datamatiker2SemExam.Interfaces;
using Datamatiker2SemExam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Datamatiker2SemExam.Pages
{
    public class OpeningHourModel : PageModel
    {
        public OpeningHour? OpeningHour { get; set; }
        public IOpeningHourRepository _openingHoursRepository { get; set; }

        [BindProperty]
        public bool ChangeOpeningState { get; set; }

        [BindProperty]
        public string NewTime { get; set; }

        public OpeningHourModel(IOpeningHourRepository openingHourRepository)
        {
            _openingHoursRepository = openingHourRepository;
        }
        public void OnGet(int id)
        {
            OpeningHour = _openingHoursRepository.Read(id);
        }

        public IActionResult OnPost(int id)
        {
            try
            {
                _openingHoursRepository.UpdateOpeningHour(id, NewTime, ChangeOpeningState);
                return RedirectToPage("index");
            }
            catch (Exception ex)
            {
                return Page();
            }
        }
    }
}
