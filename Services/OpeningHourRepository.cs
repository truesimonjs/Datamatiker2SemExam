using Datamatiker2SemExam.Interfaces;
using Datamatiker2SemExam.Models;


namespace Datamatiker2SemExam.Services
{
    public class OpeningHourRepository : EFCRepositoryBase<OpeningHour, MassageDBContext>, IOpeningHourRepository
    {
    }
}
