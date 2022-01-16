using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MurekkepWeb.Models
{

    [Table("User")]
    public class User
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(200)]
        public string username { get; set; }
        [MaxLength(200)]
        public string name { get; set; }
        [MaxLength(200)]
        public string surname { get; set; }

        [MaxLength(200)]
        public string mailadres { get; set; }


        [MaxLength(200)]
        public string sifre { get; set; }

    }
}