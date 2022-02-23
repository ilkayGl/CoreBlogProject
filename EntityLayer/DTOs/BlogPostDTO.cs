using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class BlogPostDTO
    {
        public int BlogId { get; set; }

        public string BlogTitle { get; set; }

        public string BlogContent { get; set; }

        public string BlogThumbnailImage { get; set; }

        public IFormFile BlogImage { get; set; }

        public DateTime BlogCreateDate { get; set; }

        public bool BlogStatus { get; set; }
    }
}
