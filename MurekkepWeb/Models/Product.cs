using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MurekkepWeb.Models
{
    [Table("Product")]

    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }

        public string ImageAdres { get; set; }

        public string CategoryID { get; set; }

        public string Aciklama { get; set; }

        public DateTime addDate { get; set; }

        public List<Comment> YorumList { get; set; }
        public string ortalamaPuan { get; set; }
    }
}