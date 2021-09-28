using AutoMapper;
using Blog.Core.AutoMapper_DTO;
using Blog.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.AutoMapperMapping
{
    public static class MappingExtensions
    {
        #region Category
        public static CategoryDTO ToModel(this Category entity, IMapper _mapper)
        {
            return _mapper.Map<Category, CategoryDTO>(entity);

        }
        public static List<CategoryDTO> ToModel(this List<Category> entity, IMapper _mapper)
        {
            return _mapper.Map<List<CategoryDTO>>(entity);

        }


        public static Category ToEntity(this CategoryDTO model, IMapper _mapper)
        {
            return _mapper.Map<CategoryDTO, Category>(model);

        }

        public static Category ToEntity(this CategoryDTO model, Category destination, IMapper _mapper)
        {

            return _mapper.Map(model, destination);
        }



        #endregion
        #region Publication
        public static PublicationDTO ToModel(this Publication entity, IMapper _mapper)
        {
            return _mapper.Map<Publication, PublicationDTO>(entity);

        }
        public static List<PublicationDTO> ToModel(this List<Publication> entity, IMapper _mapper)
        {
            return _mapper.Map<List<PublicationDTO>>(entity);

        }


        public static Publication ToEntity(this PublicationDTO model, IMapper _mapper)
        {
            return _mapper.Map<PublicationDTO, Publication>(model);

        }

        public static Publication ToEntity(this PublicationDTO model, Publication destination, IMapper _mapper)
        {

            return _mapper.Map(model, destination);
        }



        #endregion
        #region Tags
        public static TagsDTO ToModel(this Tags entity, IMapper _mapper)
        {
            return _mapper.Map<Tags, TagsDTO>(entity);

        }
        public static List<TagsDTO> ToModel(this List<Tags> entity, IMapper _mapper)
        {
            return _mapper.Map<List<TagsDTO>>(entity);

        }


        public static Tags ToEntity(this TagsDTO model, IMapper _mapper)
        {
            return _mapper.Map<TagsDTO, Tags>(model);

        }

        public static Tags ToEntity(this TagsDTO model, Tags destination, IMapper _mapper)
        {

            return _mapper.Map(model, destination);
        }



        #endregion
    }
}
