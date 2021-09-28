using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Data.Models
{
    [Table("Publication")]
    public class Publication:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public Category Category { get; set; }
        public virtual IList<Tags> Tags { get; set; }

    }
}
