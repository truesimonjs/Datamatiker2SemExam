using Datamatiker2SemExam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Datamatiker2SemExam.Services
{
    public class TreatmentRepository : EFCRepositoryBase<Treatment, MassageDBContext>, IViewTreatment
    {

    }
}
