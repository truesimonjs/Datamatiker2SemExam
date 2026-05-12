using Datamatiker2SemExam.Models;
using Datamatiker2SemExam.Interfaces;

namespace Datamatiker2SemExam.Services
{
    public class BookingRepository : EFCRepositoryBase<Booking, MassageDBContext>, IBookingRepository
    {

    }
}
