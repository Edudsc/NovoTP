using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using IdentitySample.Models;

namespace IdentitySample.Models
{
    [Table("Particulares")]
    public class Particular
    {
        [Key]
        public int ParticularId { get; set; }

        [Column("Nome" )]
        public string Nome { get; set; }

        [Column("Identificacao")]
        public int Bi { get; set; }

        [Column("Morada")]
        public string Morada { get; set; }
        
        [Column("DatadeNascimento")]
        public DateTime DataNascimento { get; set; }

        [Column("CartadeConducao")]
        public string Cconducao { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Telefone")]
        public int Tel { get; set; }


        //tem avaliação como cliente(conjunto de criticas de cliente)
        public IList<Critcliente> Classificacli { get; set; }
        
        //tem avaliação como fornecedor(conjunto de criticas de fornecedor)
        public IList<CritFornecedor> Classificaforn { get; set; }
        
        //tem um ou mais carros para alugar
        public IList<Carro> Carros { get; set; }

        //pode alugar carros
        public IList<Carro> Carroalugados { get; set; }

        //presta serviços
        public IList<Servicos> Servicoses { get; set; }

        //tem uma ou mais zonas de atuacao
        public IList<Zonas> Zonases { get; set; }

        //adicionar aqui uma lista de mensagens?
        public IList<Mensagem> Mensagens { get; set; }

        public Particular()
        {

        }
    }//fim da classe Particular
}