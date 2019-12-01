using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Departamentos")]
    public class Departamento
    {
        public Departamento()
        {

        }
        [Key]
        public int DepartamentoId { get; set; }

        public string NomeDepartamento { get; set; }
    }
}
