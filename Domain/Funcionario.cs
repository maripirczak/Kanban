using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Funcionarios")]
    public class Funcionario
    {
        public Funcionario()
        {

        }

        [Key]
        public int FuncionarioId { get; set; }

        public string NomeFuncionario { get; set; }

        public string CpfFuncionario { get; set; }

        public string SenhaFuncionario { get; set; }
    }
}
