using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ContactLocation
    {
        [Key]
        public int ContactLocationId { get; set; }

        public string ContactTitle { get; set; }

        public string ContactTitle2 { get; set; }

        public string ContactMapLocation { get; set; }

        public string ContactAdress { get; set; }

        public string ContactEMail { get; set; }

        public string ContactPhone { get; set; }

        public bool ContactStatus { get; set; }

    }
}
