using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T> where T : class, new()
    {
        List<T> List();

        void Insert(T p);

        T Get(Expression<Func<T, bool>> filter);

        void Delete(T p);

        void Update(T p);

        List<T> FilterList(Expression<Func<T, bool>> filter);
    }
}
