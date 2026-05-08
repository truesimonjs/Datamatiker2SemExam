using Datamatiker2SemExam.Interfaces;
using Datamatiker2SemExam.Models;

namespace Datamatiker2SemExam.Services
{
    public class UserRepository : EFCRepositoryBase<User, MassageDBContext>, IUserRepository
    {

    }
}