using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using IdentitySample.Models;

namespace IdentitySample.Models
{
    [Table("Zonas")]
    public class Zonas
    {
        [Key]
        public int ZonasId { get; set; }

        [Column("ZonadeAluger")]
        public string NomeZona { get; set; }

        public Zonas()
        {

        }
    }
}