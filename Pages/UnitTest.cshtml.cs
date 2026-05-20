using Datamatiker2SemExam.Interfaces;
using Datamatiker2SemExam.Services;
using Datamatiker2SemExam.UnitTests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Datamatiker2SemExam.Pages
{
    public class UnitTest_bookingModel : PageModel
    {
        private IBookingRepository repo;
        
        public bool DeleteBookingUnitTestResponse
        {
            get
            {
                DeleteBookingUnitTest unitTest = new DeleteBookingUnitTest(repo);
                return unitTest.Run();
            }
        }
        public UnitTest_bookingModel(IBookingRepository repo) 
        { 
            this.repo = repo;
        }
        public void OnGet()
        {

        }
    
        
    }
}
