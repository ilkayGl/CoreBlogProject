using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class BlogExcelDTO
    {
        public int ID { get; set; }

        public string Category { get; set; }

        public string Writer { get; set; }

        public string BlogName { get; set; }

        public DateTime BlogDate { get; set; }
    }
}
