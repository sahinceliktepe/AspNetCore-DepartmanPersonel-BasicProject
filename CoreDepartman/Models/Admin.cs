using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDepartman.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Column(TypeName ="nvarchar(20)")]
        public string Kullanici { get; set; }

        [Column(TypeName ="nvarchar(10)")]
        public string Sifre { get; set; }
    }
}
