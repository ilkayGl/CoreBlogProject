using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetList();

        List<Comment> GetFilterList(int id);

        void CommentAddBL(Comment comment);

        void CommentDeleteBL(Comment comment);

        void CommentUpdateBL(Comment comment);

        Comment GetByID(int id);
    }
}
