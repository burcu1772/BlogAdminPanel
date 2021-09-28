using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Data.Models
{
    [Table("Category")]
    public class Category:BaseEntity

    {
        [StringLength(100)]
        public string Name { get; set; }

        public int CategoryNo { get; set; }
        public virtual IList<Publication>  Publications { get; set; }
    }
}
