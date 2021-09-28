using AutoMapper;
using AutoMapper.Configuration;
using Blog.Core;
using Blog.Core.AutoMapper_DTO;
using Blog.Core.AutoMapperMapping;
using Blog.Core.Infastructure;
using Blog.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        #region Dependency Description
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;


        public CategoryController(

             IMapper mapper,
             ICategoryRepository categoryRepository

)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
         
        }
        #endregion

     
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            
            IEnumerable<Category> category = _categoryRepository.GetAll();

            return category;
        }
        [HttpGet("{id}")]
        public Category Get(int Id)
        {
            return _categoryRepository.GetById(Id);
        }

        [HttpPost]
        public Category Post(CategoryDTO categorydto)
        {
            var category = categorydto.ToEntity(_mapper);

            var addingID = _categoryRepository.InsertAndGetId(category);
            return _categoryRepository.GetById(addingID);
        }
      
        [HttpPut]
        public Category Put(CategoryDTO categorydto)
        {
            var category = categorydto.ToEntity(_mapper);
            return _categoryRepository.UpdateAndGet(category);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var category = _categoryRepository.GetById(id);
             _categoryRepository.Delete(category);
        }
    }
}
