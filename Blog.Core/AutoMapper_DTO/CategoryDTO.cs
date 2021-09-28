using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.AutoMapper_DTO
{
   public class CategoryDTO:BaseEntityDTO
    {
       
        public string Name { get; set; }
        public int CategoryNo { get; set; }

    }
}
