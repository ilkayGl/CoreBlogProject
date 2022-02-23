using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class CommentExcelDTO
    {
        public int CommentId { get; set; }

        public string CommentUser { get; set; }

        public string BlogName { get; set; }

        public string CommentTitle { get; set; }

        public string CommentContent { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
