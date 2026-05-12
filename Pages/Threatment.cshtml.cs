using Microsoft.AspNetCore.Mvc.RazorPages;
using Datamatiker2SemExam.Models;
using Datamatiker2SemExam.Services;
using Datamatiker2SemExam.Interfaces;

namespace Datamatiker2SemExam.Pages
{
    public class ThreatmentModel : PageModel
    {
        public Treatment? Treatment { get; set; }
        private ITreatmentRepository _treatmentRepository;

        public ThreatmentModel (ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        public void OnGet(int id)
        {
            // The id is captured from the route
            Treatment = _treatmentRepository.Read(id);
        }
    }
}
