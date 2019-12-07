using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Enderecos")]
    public class Endereco
    {
        public Endereco()
        {
            
        }
        [Key]
        public int EnderecoId { get; set; }

        [Display(Name = "Cidade:")]
        public string cidade { get; set; }

        [Display(Name = "CEP:")]
        public string cep { get; set; }

        [Display(Name = "Bairro:")]
        public string bairro { get; set; }
    }
}

