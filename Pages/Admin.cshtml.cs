using Datamatiker2SemExam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Datamatiker2SemExam.Pages
{ 
public class AdminModel : PageModel
{
    private readonly MassageDBContext _context;

    public List<OpeningHour> OpeningHours { get; set; }

    public AdminModel(MassageDBContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        OpeningHours = _context.OpeningHours
            .OrderBy(o => o.Id)
            .ToList();
    }

        public IActionResult OnPostToggleOpen(int Id)
        {
            var item = _context.OpeningHours.FirstOrDefault(o => o.Id == Id);

            if (item == null)
            {
                TempData["Error"] = "Kunne ikke finde åbningstiden.";
                return RedirectToPage();
            }

            // Skift mellem åben og lukket
            item.ErOpen = !item.ErOpen;

            _context.SaveChanges();

            TempData["Success"] = item.ErOpen
                ? $"{item.Day} er nu åbnet."
                : $"{item.Day} er nu lukket.";

            return RedirectToPage();
        }
    }
}