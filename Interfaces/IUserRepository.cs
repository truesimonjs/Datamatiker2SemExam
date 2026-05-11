using Datamatiker2SemExam.Models;

namespace Datamatiker2SemExam.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        public User? GetUserByUsernameAndPassword(string username, string password);
    }
}
