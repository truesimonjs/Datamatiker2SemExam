using Datamatiker2SemExam.Interfaces;
using Datamatiker2SemExam.Models;
using Datamatiker2SemExam.Pages;


namespace Datamatiker2SemExam.Services
{
    public class OpeningHourRepository : EFCRepositoryBase<OpeningHour, MassageDBContext>, IOpeningHourRepository
    {
    }
}
