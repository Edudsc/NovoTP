﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentitySample.Models
{
    public class ViewModelFotos
    {
        [Required(ErrorMessage = "Insira o url da foto que deseja")]
        [Display(Name = "Fotos: ")]
        public string Url { get; set; }
    }
}