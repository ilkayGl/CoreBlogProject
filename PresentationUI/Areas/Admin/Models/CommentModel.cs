using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Areas.Admin.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }

        public string CommentUser { get; set; }

        public string BlogName { get; set; }

        public string CommentTitle { get; set; }

        public string CommentContent { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
