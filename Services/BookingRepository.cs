using Datamatiker2SemExam.Interfaces;
using Datamatiker2SemExam.Models;
using Microsoft.EntityFrameworkCore;

namespace Datamatiker2SemExam.Services
{
    public class BookingRepository : EFCRepositoryBase<Booking, MassageDBContext>, IBookingRepository
    {
        protected override IQueryable<Booking> GetAllWithIncludes(DbContext context)
        {
            return base.GetAllWithIncludes(context)
                .Include(b => b.Customer)
                .Include(b => b.Treatment)
                .Include(b => b.Worker);
        }
     
    }
}