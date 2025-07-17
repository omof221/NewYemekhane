using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YemekhaneDataAccesLayer.Abstract;
using YemekhaneDataAccesLayer.Context;

namespace YemekhaneDataAccesLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T entity)
        {
            using var context = new YemekhaneContext();
            context.Remove(entity);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var context = new YemekhaneContext();
            return context.Set<T>().ToList();
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            using var context = new YemekhaneContext();
            return context.Set<T>().Where(filter).ToList();
        }

        public T GetById(int id)
        {
            using var context = new YemekhaneContext();
            return context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            using var context = new YemekhaneContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            using var context = new YemekhaneContext();
            context.Update(entity);
            context.SaveChanges();
        }
    }
 
}
