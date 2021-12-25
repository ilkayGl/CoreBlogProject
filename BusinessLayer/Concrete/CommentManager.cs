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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }


        public Comment GetByID(int id)
        {
            return _commentDal.Get(x => x.CommentId == id);
        }

        public List<Comment> GetCommentBlogList()
        {
            return _commentDal.GetCommentBlogList();
        }

        public List<Comment> GetFilterList(int id)
        {
            return _commentDal.FilterList(x => x.BlogId == id);
        }

        public List<Comment> GetList()
        {
            return _commentDal.List();
        }

        public void TAddBL(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void TDeleteBL(Comment t)
        {
            _commentDal.Delete(t);
        }

        public void TUpdateBL(Comment t)
        {
            _commentDal.Update(t);
        }
    }
}
