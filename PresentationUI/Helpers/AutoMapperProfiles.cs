using AutoMapper;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationUI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Writer, AddProfileImageDTO>();
            CreateMap<AddProfileImageDTO, Writer>();

            CreateMap<Blog, BlogPostDTO>();
            CreateMap<BlogPostDTO, Blog>();

            CreateMap<About, AboutImageFileDTO>();
            CreateMap<AboutImageFileDTO, About>();

            CreateMap<LogoTitle, LogoImageFileDTO>();
            CreateMap<LogoImageFileDTO, LogoTitle>();
        }
    }
}
