using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Areas.Admin.Models
{
    public class LogoImageFilesAdd
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IFormFile Logo { get; set; }
    }
}
