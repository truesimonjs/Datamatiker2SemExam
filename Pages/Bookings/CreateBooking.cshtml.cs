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
        public Booking Element { get; set; } = new();

        public SelectList CustomerList { get; set; }
        public SelectList WorkerList { get; set; }
        public CreateBookingModel(IBookingRepository repo, ICustomerRepository customerRepo, IWorkerRepository workerRepo)
        {
            this.repo = repo;
            CustomerList = new SelectList(customerRepo.GetAll(),nameof(Customer.Id),nameof(Customer.Name));
            WorkerList = new SelectList(workerRepo.GetAll(),nameof(Worker.Id),nameof(Worker.Name));
            
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();


            }
            repo.Create(Element);
            return RedirectToPage();
               
        }
    }
}
