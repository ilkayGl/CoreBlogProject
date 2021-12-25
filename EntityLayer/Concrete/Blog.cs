using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        public string BlogTitle { get; set; }

        public string BlogContent { get; set; }

        public string BlogThumbnailImage { get; set; }

        public string BlogImage { get; set; }
        
        [NotMapped]
        public IFormFile Image { get; set; }

        public DateTime BlogCreateDate { get; set; }

        public bool BlogStatus { get; set; }



        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
