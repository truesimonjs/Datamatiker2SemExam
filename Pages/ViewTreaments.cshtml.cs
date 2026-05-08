using Datamatiker2SemExam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Datamatiker2SemExam.Interfaces;

namespace Datamatiker2SemExam.Pages
{
    public class ViewTreamentsModel : PageModel
    {
        private ITreatmentRepository _treatmentRepository;
        public List<Treatment> Data { get; private set; }

        public ViewTreamentsModel(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }
        public void OnGet()
        {
            Data = _treatmentRepository.GetAll();
        }

       
    }
}
