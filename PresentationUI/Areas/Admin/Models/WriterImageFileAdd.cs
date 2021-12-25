﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Areas.Admin.Models
{
    public class WriterImageFileAdd
    {
        public int WriterId { get; set; }

        public string WriterName { get; set; }

        public string WriterRole { get; set; }

        public string WriterTitle { get; set; }

        public string WriterAbout { get; set; }

        public IFormFile WriterImage { get; set; }

        public string WriterMail { get; set; }

        public string WriterPassword { get; set; }

        public bool WriterStatus { get; set; }
    }
}
