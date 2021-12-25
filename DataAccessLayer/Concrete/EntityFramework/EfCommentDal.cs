using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {

        public List<Comment> GetCommentBlogList()
        {
            using var c = new Context();
            return c.Comments.Include(x => x.Blog).OrderByDescending(d => d.CommentDate).ToList();
        }
    }
}
