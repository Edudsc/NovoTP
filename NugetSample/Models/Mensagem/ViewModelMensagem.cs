using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentitySample.Models
{
    public class ViewModelMensagem
    {
        [Required]
        [Display(Name = "Mensagem")]
        public string Data { get; set; }

    }
}