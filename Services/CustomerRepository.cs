using Datamatiker2SemExam.Interfaces;
using Datamatiker2SemExam.Models;
using Datamatiker2SemExam;

namespace Datamatiker2SemExam.Services
{
    public class CustomerRepository : EFCRepositoryBase<Customer, MassageDBContext> , ICustomerRepository
    {
        
    }
}
