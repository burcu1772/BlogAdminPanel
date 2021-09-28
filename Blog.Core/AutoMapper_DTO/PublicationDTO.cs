using Blog.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.AutoMapper_DTO
{
    public class PublicationDTO:BaseEntityDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategortId { get; set; }
    }
}
