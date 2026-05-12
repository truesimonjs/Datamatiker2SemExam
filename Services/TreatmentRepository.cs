using Datamatiker2SemExam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Datamatiker2SemExam.Interfaces;

namespace Datamatiker2SemExam.Services
{
    public class TreatmentRepository : EFCRepositoryBase<Treatment, MassageDBContext>, ITreatmentRepository
    {

    }
}
