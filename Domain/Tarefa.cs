 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Tarefas")]
    public class Tarefa
    {
        public Tarefa()
        {
            DataCriacaoTarefa = DateTime.Now;
        }

        [Key]
        public int TarefaId { get; set; }

        public int JobId { get; set; }

        public string TituloTarefa { get; set; }

        public string DescricaoTarefa { get; set; }

        public DateTime DataCriacaoTarefa { get; set; }

        public DateTime DataEntregaTarefa { get; set; }

        public Funcionario Responsavel { get; set; }

        public string StatusTarefa { get; set; }


    }
}
