using Datamatiker2SemExam.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Datamatiker2SemExam.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Datamatiker2SemExam.Interfaces;
namespace Datamatiker2SemExam.Pages.Bookings
{
    public class CreateBookingModel : PageModel
    {
        private IBookingRepository repo;
        [BindProperty]
        public Booking Element { get; set; } = new();

        public SelectList CustomerList { get; set; }
        public SelectList WorkerList { get; set; }
        public SelectList TreatmentList { get; set; }
        public CreateBookingModel(IBookingRepository repo, ICustomerRepository customerRepo, IWorkerRepository workerRepo, ITreatmentRepository treatmentRepo)
        {
            this.repo = repo;
            CustomerList = new SelectList(customerRepo.GetAll(),nameof(Customer.Id),nameof(Customer.Name));
            WorkerList = new SelectList(workerRepo.GetAll(),nameof(Worker.Id),nameof(Worker.Name));
            TreatmentList = new SelectList(treatmentRepo.GetAll(), nameof(Treatment.Id), nameof(Treatment.Name));


        }
        public IActionResult OnPost()
        {
           
            if (!ModelState.IsValid)
            {
                return Page();


            }
            
            repo.Create(Element);
            return RedirectToPage("/Bookings/ViewBooking");
               
        }
    }
}
