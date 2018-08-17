using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentitySample.Models
{
    public class ViewModelParticular
    {
        [Required(ErrorMessage = "O nome é campo obrigatório!")]
        [Display(Name = "Nome: ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Identificação obrigatório!")]
        [Display(Name = "Identificação(BI): ")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "O BI tem de conter 8 algarismos!")]
        public int Bi { get; set; }

        [Required(ErrorMessage = "O campo Morada obrigatório!")]
        [Display(Name = "Morada: ")]
        public string Morada { get; set; }

        [Display(Name = "Data de Nascimento: ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //falta custom validator
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo Carta de Condução é obrigatório")]
        [Display(Name = "Carta de Condução: ")]
        [RegularExpression(@"^[A-Z] - \d{6} \d{1}$",ErrorMessage = "Insira o seu numero da carta de condução no formato Letra(Maiúscula) - (6 algarismos) (1 algarismo)!")]
        public string Cconducao { get; set; }

        

        [Required]
        [Display(Name = "Email: ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira o seu contacto!")]
        [Display(Name = "Contacto: ")]
        [DataType(DataType.PhoneNumber)]
        public int Tel { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracters.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar password")]
        [Compare("Password", ErrorMessage = "As passwords não coincidem")]
        public string ConfirmPassword { get; set; }


    }
}