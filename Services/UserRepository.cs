using Datamatiker2SemExam.Interfaces;
using Datamatiker2SemExam.Models;

namespace Datamatiker2SemExam.Services
{
    public class UserRepository : EFCRepositoryBase<User, MassageDBContext>, IUserRepository
    {
        public User? GetUserByUsernameAndPassword(string username, string password)
        {
            List<User> users = new List<User>();

            using MassageDBContext context = new MassageDBContext();

            users = context.Users.ToList();

            User? user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            return user;
        }

    }
}