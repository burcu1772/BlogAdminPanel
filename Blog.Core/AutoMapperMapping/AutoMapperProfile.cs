using AutoMapper;
using Blog.Core.AutoMapper_DTO;
using Blog.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.AutoMapperMapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Category

            CreateMap<CategoryDTO, Category>()

          
                .ForMember(dest => dest.CategoryNo, no => no.Ignore());



            CreateMap<Category, CategoryDTO>();




            #endregion
            #region Publication

            CreateMap<PublicationDTO, Publication>()


                .ForMember(dest => dest.CreatedDate, no => no.Ignore());



            CreateMap<Publication, PublicationDTO>();




            #endregion
            #region Tags

            CreateMap<TagsDTO, Tags>();





            CreateMap<Tags, TagsDTO>();




            #endregion

        }
    }
}