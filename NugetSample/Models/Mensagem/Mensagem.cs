using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using IdentitySample.Models;

namespace IdentitySample.Models
{
    [Table("Mensagens")]
    public class Mensagem
    {
        [Key]
        public int MensagemId { get; set; }

        //Pode ser de um particular para um Particular (Lista para guardar dois)
        //public IList<Particular> Particulars { get; set; }

        ////pode ser nullable quando a mensagem é entre dois Particulares
        //[ForeignKey("Profissional")]
        //public int? ProfissionalId { get; set; }
        
        //public virtual Profissional Profissional { get; set; }

        [Column("Mensagem")]
        public string Data { get; set; }

        [Column("Vista")]
        public bool Lida { get; set; }

        public Mensagem()
        {

        }
    }
}