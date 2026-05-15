using Datamatiker2SemExam.Interfaces;
using Datamatiker2SemExam.Models;

namespace Datamatiker2SemExam.UnitTests
{
    //unittest TC-20-C
    public class DeleteBookingUnitTest
    {
        private IBookingRepository repo;
        public DeleteBookingUnitTest(IBookingRepository repo)
        {
            this.repo = repo;
        }
        public bool Run()
        {
            //step 1
            List<Booking> startList = repo.GetAll();
            //step 2
            Booking booking = testBooking();
            int bookingId = repo.Create(booking);
            //step 3
            List<Booking> secondList = repo.GetAll();
            if (secondList.Count <= startList.Count) return false;
            if (!containsBooking(secondList,bookingId)) return false;
            //step 4
            bool wasDeleted = repo.Delete(bookingId);
            if (!wasDeleted) return false;
            //step 5
            List<Booking> thirdList = repo.GetAll();
            if(thirdList.Count >= secondList.Count ) return false;
            if (containsBooking(thirdList, bookingId)) return false;
            return true;

           
           

        }
        public bool containsBooking(List<Booking> bookingList, int givenId)
        {
            return bookingList.Select<Booking, int>(b => b.Id).Contains(givenId);
        }
        public Booking testBooking()
        {
            Booking booking = new Booking();
            booking.StartTime = DateTime.Now;
            booking.Duration = 30;
            booking.WorkerId = 1;
            booking.TreatmentId = 1;
            booking.CustomerId = 1;
            return booking;
        }
    }
}
