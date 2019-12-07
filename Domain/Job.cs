 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Jobs")]
    public class Job
    {
        public Job()
        {
            DataCriacaoJob = DateTime.Now;
        }

        [Key]
        public int JobId { get; set; }

        public int ProjetoId { get; set; }

        public string TituloJob { get; set; }

        public string DescricaoJob { get; set; }

        public string NomeResponsavel { get; set; }

        public DateTime DataCriacaoJob { get; set; }

        public DateTime DataEntregaJob { get; set; }

        public TipoStatus StatusJob { get; set; }

        public Departamento DptoResponsavel { get; set; }

        public List<Tarefa> Tarefas { get; set; }
    }
}
