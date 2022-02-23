using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class LogoImageFileDTO
    {
        public int LogoTitleId { get; set; }

        public IFormFile Logo { get; set; }

        public string Title { get; set; }

        public bool Status { get; set; }
    }
}
