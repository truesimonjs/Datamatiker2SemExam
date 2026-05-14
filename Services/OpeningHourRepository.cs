using Datamatiker2SemExam.Interfaces;
using Datamatiker2SemExam.Models;
using Microsoft.EntityFrameworkCore;


namespace Datamatiker2SemExam.Services
{
    public class OpeningHourRepository : EFCRepositoryBase<OpeningHour, MassageDBContext>, IOpeningHourRepository
    {
        public void UpdateOpeningHour(int id, string newTime, bool changeOpeningState)
        {
            using DbContext context = new MassageDBContext();
            OpeningHour? openingHour = context.Set<OpeningHour>().FirstOrDefault(o => o.Id == id);

            if (openingHour == null)
                throw new Exception($"OpeningHour with id {id} not found");

            openingHour.StartTime = newTime;
            openingHour.ErOpen = changeOpeningState;

            context.SaveChanges();
        }
    }
}
