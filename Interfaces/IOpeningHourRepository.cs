using Datamatiker2SemExam.Models;

namespace Datamatiker2SemExam.Interfaces
{
    public interface IOpeningHourRepository : IRepository<OpeningHour>
    {
        void UpdateOpeningHour(int id, string newTime, bool changeOpeningState);
    }
}
