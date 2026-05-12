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

    public IActionResult OnPostDelete(int Id)
    {
        var item = _context.OpeningHours.FirstOrDefault(o => o.Id == Id);

        if (item == null)
        {
            TempData["Error"] = "Kunne ikke finde åbningstiden.";
            return RedirectToPage();
        }

        _context.OpeningHours.Remove(item);
        _context.SaveChanges();

        TempData["Success"] = "Åbningstid slettet!";
        return RedirectToPage();
    }
}
}