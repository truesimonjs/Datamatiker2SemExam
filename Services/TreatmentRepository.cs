using Datamatiker2SemExam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Datamatiker2SemExam.Services
{
    public class TreatmentRepository : EFCRepositoryBase<Treatment, MassageDBContext>
    {
        protected override IQueryable<Treatment> GetAllWithIncludes(DbContext context)
        {
            return base.GetAllWithIncludes(context)
                .Include(t => t.Price)
                .Include(t => t.Id)
                .Include(t => t.Duration);
        }
    }
}
