using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Areas.Admin.Models
{
    public class BlogModel
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public string Writer { get; set; }
        public string BlogName { get; set; }
        public DateTime BlogDate { get; set; }
    }
}
