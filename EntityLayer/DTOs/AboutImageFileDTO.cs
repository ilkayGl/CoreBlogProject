using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class AboutImageFileDTO
    {
        public int AboutId { get; set; }

        public string AboutDetails1 { get; set; }

        public string AboutDetails2 { get; set; }

        public IFormFile AboutImage1 { get; set; }

        public string AboutImage2 { get; set; }

        public string AboutMapLocation { get; set; }

        public bool AboutStatus { get; set; }
    }
}
