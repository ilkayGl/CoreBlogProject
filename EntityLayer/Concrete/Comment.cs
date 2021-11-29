using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string CommentUserName { get; set; }

        public string CommentTitle { get; set; }

        public string CommentContent { get; set; }

        public DateTime CommentDate { get; set; } = DateTime.Now;

        public int BlogScore { get; set; }

        public bool CommentStatus { get; set; }


        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
