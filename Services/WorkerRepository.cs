using Datamatiker2SemExam.Models;
using Datamatiker2SemExam.Interfaces;
namespace Datamatiker2SemExam.Services
{
    public class WorkerRepository : EFCRepositoryBase<Worker, MassageDBContext> , IWorkerRepository
    {
    }
}
