using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MurekkepWeb.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(1000)]
        public string baslik { get; set; }
        public string icerik { get; set; }
        public virtual User owner { get; set; }
        //public DateTime CreateDateTime { get; set; }
        public int? productId { get; set; }

        public int begeniSayi { get; set; }

        public int yildiz { get; set; }

        public string username { get; set; }

    }
}