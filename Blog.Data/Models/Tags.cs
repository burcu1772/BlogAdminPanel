using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Data.Models
{
    [Table("Tags")]
    public class Tags:BaseEntity
    {
        [StringLength(100)]
        public string Descriptions { get; set; }
        public int PublicationID { get; set; }
        public Publication Publication { get; set; }

    }
}
