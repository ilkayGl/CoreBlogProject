using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class LogoTitle
    {
        [Key]
        public int LogoTitleId { get; set; }

        public string Logo { get; set; }

        public string Title { get; set; }

        public bool Status { get; set; }


    }
}
