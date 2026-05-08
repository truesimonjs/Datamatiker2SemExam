using Datamatiker2SemExam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Datamatiker2SemExam.Pages
{
    public class IndexModel : PageModel
    {

        public List<OpeningHour> OpeningHours { get; set; }

    
        public void OnGet()
        {
            using MassageDBContext context = new MassageDBContext();
            OpeningHours = context.OpeningHours.ToList();
            //Console.WriteLine(OpeningHours[0].Day); 
        }
    }
}