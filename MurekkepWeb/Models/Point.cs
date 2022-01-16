using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MurekkepWeb.Models
{

    [Table("Point")]
    public class Point
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public virtual User user { get; set; }
        public virtual Question Question { get; set; }



    }
}