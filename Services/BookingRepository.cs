using Datamatiker2SemExam.Interfaces;
using Datamatiker2SemExam.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Datamatiker2SemExam.Services
{
    public class BookingRepository : EFCRepositoryBase<Booking, MassageDBContext>, IBookingRepository
    {
        private ITreatmentRepository treatmentRepo;
        public BookingRepository(ITreatmentRepository treatmentrepo)
        {
            this.treatmentRepo = treatmentrepo;
        }
        protected override IQueryable<Booking> GetAllWithIncludes(DbContext context)
        {
            return base.GetAllWithIncludes(context)
                .Include(b => b.Customer)
                .Include(b => b.Treatment)
                .Include(b => b.Worker);
        }
        
        public override int Create(Booking entity)
        {
            
            entity.Duration = treatmentRepo.Read(entity.TreatmentId).Duration;
            return base.Create(entity);
        }
       
    }
}