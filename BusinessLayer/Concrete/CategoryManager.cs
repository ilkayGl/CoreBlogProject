using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }


        public Category GetByID(int id)
        {
            return _categoryDal.Get(x => x.CategoryId == id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public void TAddBL(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TDeleteBL(Category t)
        {
            _categoryDal.Delete(t);
        }

        public void TUpdateBL(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
