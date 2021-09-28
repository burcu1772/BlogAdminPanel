using AutoMapper;
using AutoMapper.Configuration;
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
{  /// <summary>
   ///
   /// </summary>
   /// <returns></returns>
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        #region Dependency Description
        private readonly IPublicationRepository _publicationRepository;
        private readonly IMapper _mapper;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public PublicationController(

             IMapper mapper,
             IPublicationRepository  publicationRepository

)
        {
            _mapper = mapper;
            _publicationRepository = publicationRepository;

        }
        #endregion

        /// <summary>
        /// Get All Publications
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Publication> Get()
        {
            IEnumerable<Publication> publication = _publicationRepository.GetAll();

            return publication;
        }
        /// <summary>
        /// Get Publication By Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Publication Get(int ID)
        {
            return _publicationRepository.GetById(ID);
        }

        /// <summary>
        /// Create Publication
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Publication Post([FromBody]PublicationDTO publicationDTO)
        {
            var publication = publicationDTO.ToEntity(_mapper);

            var addingID = _publicationRepository.InsertAndGetId(publication);
            return _publicationRepository.GetById(addingID);
        }
        /// <summary>
        /// Update Publication
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public Publication Put([FromBody] PublicationDTO publicationDTO)
        {
            var publication = publicationDTO.ToEntity(_mapper);

            return _publicationRepository.UpdateAndGet(publication);
        }
        /// <summary>
        /// delete Publication by Id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var publication = _publicationRepository.GetById(id);
            _publicationRepository.Delete(publication);
        }
    }
}
