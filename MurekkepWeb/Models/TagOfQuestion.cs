using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MurekkepWeb.Models
{

    [Table("TagOfQuestion")]
    public class TagOfQuestion
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public virtual Tag tag { get; set; }

        public int questionId { get; set; }
        public Boolean checkedTag { get; set; }

    }
}