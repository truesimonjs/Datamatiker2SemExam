using Datamatiker2SemExam.Models;
using Datamatiker2SemExam.Services;

namespace Datamatiker2SemExam
{
    public interface IRepository<T> where T : IHasId
    {
        List<T> GetAll();
        int Create(T entity);

        T? Read (int id);

        /// <summary>
        /// Return true if element was deleted
        /// </summary>
      
        bool Delete (int id);
    }
    public interface IViewTreatment : IRepository<Treatment>
    {
    }
}
