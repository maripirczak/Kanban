using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Context : DbContext
    {
        //Nomear o arquivo do BD
        public Context(DbContextOptions<Context> options) : base(options) { }

        //Definir as classes que vão virar tabelas no BD
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

    }


}
