using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        List<T> GetList();

        void TAddBL(T t);

        void TDeleteBL(T t);

        void TUpdateBL(T t);

        T GetByID(int id);
    }
}
