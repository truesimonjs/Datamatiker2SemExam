using Datamatiker2SemExam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Datamatiker2SemExam.Pages
{
    public class ViewTreamentsModel : PageModel
    {
        private IViewTreatment _viewTreatment;
        public List<Treatment> Data { get; private set; }

        public ViewTreamentsModel(IViewTreatment viewTreatment)
        {
            _viewTreatment = viewTreatment;
        }
        public void OnGet()
        {
            Data = _viewTreatment.GetAll();
        }

       
    }
}
