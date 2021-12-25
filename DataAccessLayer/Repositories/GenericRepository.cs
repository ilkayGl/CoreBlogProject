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
        private readonly Context c = new();
        private readonly DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public void Delete(T p)
        {
            using (Context c = new())
            {
                var deleteentity = c.Entry(p);
                deleteentity.State = EntityState.Deleted;
                c.SaveChanges();
            }

        }

        public List<T> FilterList(Expression<Func<T, bool>> filter)
        {
            using (Context c = new())
            {
                return _object.Where(filter).ToList();
            }

        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (Context c = new())
            {
                return _object.SingleOrDefault(filter);
            }

        }

        public void Insert(T p)
        {
            using (Context c = new())
            {
                var addentity = c.Entry(p);
                addentity.State = EntityState.Added;
                c.SaveChanges();
            }

        }

        public List<T> List()
        {
            using (Context c = new())
            {
                return _object.ToList();
            }
        }

        public void Update(T p)
        {
            using (Context c = new())
            {
                var updatedEntity = c.Entry(p);
                updatedEntity.State = EntityState.Modified;
                c.SaveChanges();
            }

        }


    }
}
