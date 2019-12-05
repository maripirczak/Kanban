using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Projetos")]
    public class Projeto
    {
        public Projeto() { DataCriacaoProjeto = DateTime.Now;}

        [Key]
        public int ProjetoId { get; set; }

        [Display(Name = "Nome do projeto:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string NomeProjeto { get; set; }

        [Display(Name = "Descrição do projeto:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(10, ErrorMessage = "No mínimo 10 caracteres")]
        [MaxLength(200, ErrorMessage = "No máximo 200 caracteres")]
        public string DescricaoProjeto { get; set; }

        [Display(Name = "Nome da Empresa:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string NomeEmpresa { get; set; }

        public DateTime DataCriacaoProjeto { get; set; }

        public TipoStatus StatusProjeto { get; set; }

        public List<Job> Jobs { get; set; }


    }
}
