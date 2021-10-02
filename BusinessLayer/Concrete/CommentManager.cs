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



        public void CommentAddBL(Comment comment)
        {
            _commentDal.Insert(comment);
        }

        public void CommentDeleteBL(Comment comment)
        {
            _commentDal.Delete(comment);
        }

        public void CommentUpdateBL(Comment comment)
        {
            _commentDal.Update(comment);
        }

        public Comment GetByID(int id)
        {
            return _commentDal.Get(x => x.CommentId == id);
        }

        public List<Comment> GetFilterList(int id)
        {
            return _commentDal.FilterList(x => x.BlogId == id);
        }

        public List<Comment> GetList()
        {
            return _commentDal.List();
        }
    }
}
