﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Areas.Admin.Models
{
    public class AboutImageFileAdd
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
