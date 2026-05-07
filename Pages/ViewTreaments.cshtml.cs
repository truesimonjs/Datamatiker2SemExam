using Datamatiker2SemExam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Datamatiker2SemExam.Pages
{
    public class ViewTreamentsModel : PageModel
    {
        public List<Treatment> Data { get; private set; }

        //public Treatment();
        public void OnGet()
        {
        }
    }
}
