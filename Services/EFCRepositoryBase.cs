using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Datamatiker2SemExam.Services
{
    public abstract class EFCRepositoryBase<T, TContext> : IRepository<T>
    where T : class, IHasId
    where TContext : DbContext, new()
    {
        public int Create(T entity)
        {
            using DbContext context = new TContext();
            int id = NextId();
            entity.Id = id;
            context.Set<T>().Add(entity);
            int changes = context.SaveChanges();
            if (changes == 0) throw new Exception($"failed to create new {nameof(T)}", null);
            return entity.Id;
            
        }
        public T? Read(int id)
        {
            using DbContext context = new TContext();

            IQueryable<T> query = GetAllWithIncludes(context);
            return  query.FirstOrDefault(t => t.Id == id);

            //mere udskrevet version
            /*
            foreach (T item in query)
            {
                if (item.Id == id) return item;
            }
            return query.ElementAt(0);
            */
        }
        public List<T> GetAll()
        {
            using DbContext context = new TContext();
            return GetAllWithIncludes(context).ToList();

        }
        public bool Delete(int id)
        {
            using DbContext context = new TContext();
            T? item = Read(id);
            if (item == null) return false;
            context.Set<T>().Remove(item);
            return (context.SaveChanges() > 0);
           
        }

        //returner en datatype som kan bruges til at query databasen
        protected virtual IQueryable<T> GetAllWithIncludes(DbContext context)
        {
            return context.Set<T>();
        }
        private int NextId()
        {
            IEnumerable<int> usedIds = GetAll().Select(t => t.Id);
            int newId = usedIds.DefaultIfEmpty(0).Max();
            return newId;
        }


    }
}
