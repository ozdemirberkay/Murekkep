using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MurekkepWeb.Models
{
    [Table("Answer")]
    public class Answer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(1000)]
        public string body { get; set; }
        public virtual User owner { get; set; }
        public int vote { get; set; }

        public DateTime CreateDateTime { get; set; }
        public int? questionId { get; set; }



    }
}