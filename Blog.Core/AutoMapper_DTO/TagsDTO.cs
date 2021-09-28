using Blog.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.AutoMapper_DTO
{
  public  class TagsDTO:BaseEntityDTO
    {
      
        public string Descriptions { get; set; }
        public int PublicationID { get; set; }
        public Publication Publication { get; set; }
    }
}
