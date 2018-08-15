using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using IdentitySample.Models;

namespace IdentitySample.Models
{
    [Table("Fotos")]
    [MetadataType(typeof(ViewModelFotos))]
    public partial class FotosdoCarro
    {
        [Key]
        public int FotosdoCarroId { get; set; }

        //[ForeignKey("Carro")]
        //public int CarroId { get; set; }
        
        //public virtual Carro Carro { get; set; }

        public string Url { get; set; }
    }
}