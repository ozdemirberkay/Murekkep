using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MurekkepWeb.Models
{
    [Table("SubSite")]
    public class SubSite
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(120)]
        public string siteName { get; set; }
        public string description { get; set; }
        [MaxLength(1000)]
        public string LogoPath { get; set; }
        [MaxLength(1000)]
        public string miniLogoPath { get; set; }
        public DateTime openDate { get; set; }
        public Boolean inUse { get; set; }

        public virtual List<Question> questions { get; set; }



    }
}