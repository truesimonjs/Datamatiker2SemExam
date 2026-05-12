using Datamatiker2SemExam.Models;
using Microsoft.AspNetCore.Http;

namespace Datamatiker2SemExam.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        public User? GetUserByUsernameAndPassword(string username, string password);
        public Task LogIn(HttpContext httpContext, User user);
    }
}
