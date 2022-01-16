using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MurekkepWeb.Models
{

    [Table("Tag")]
    public class Tag
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(200)]
        public string tagName { get; set; }
        [MaxLength(1000)]
        public string description { get; set; }
        public int numberOfQuestions { get; set; }
        public virtual SubSite subSite { get; set; }

        //public Tag(string tagName, string description, int numberOfQuestions = 0)
        //{
        //    this.tagName = tagName;
        //    this.description = description;
        //    this.numberOfQuestions = numberOfQuestions;
        //}
    }
}