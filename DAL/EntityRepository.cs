using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ModelLib;

namespace DAL
{
    public class EntityRepository<T> : IRepository<T> where T : class
    {
        private readonly Context context = new Context();

        public void Add(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        public void Delete(T obj)
        {
            context.Set<T>().Remove(obj);
            context.SaveChanges();
        }

        public IEnumerable<T> ReadAll()
        {
            return context.Set<T>().ToList();
        }

        public T ReadById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void UpdateRating(int id, int rating)
        {
            var entity = context.Set<T>().Find(id);
            if (entity is Wine wine)
            {
                wine.Rating = rating;
                context.SaveChanges();
            }
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}
