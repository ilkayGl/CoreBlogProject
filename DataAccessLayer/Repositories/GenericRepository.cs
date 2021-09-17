using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class, new()
    {
        Context c = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public void Delete(T p)
        {
            var deleteentity = c.Entry(p);
            deleteentity.State = EntityState.Deleted;
            c.SaveChanges();
        }

        public List<T> FilterList(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            var addentity = c.Entry(p);
            addentity.State = EntityState.Added;
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public void Update(T p)
        {
            var updateenity = c.Entry(p);
            updateenity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
