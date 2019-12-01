using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class JobDAO
    {
        private readonly Context _context;

        public JobDAO(Context context)
        {
            _context = context;
        }

        public void CadastrarNovoJob(Job j)
        {
            _context.Jobs.Add(j);
            _context.SaveChanges();
        }

        public List<Job> ListarJobs()
        {
            List<Job> ListJobs = _context.Jobs.Include("DptoResponsavel").ToList();
            return ListJobs;
        }

        //metodo que localiza o campo da chave primaria e busca
        public Job BuscarJobPorId(int id)
        {
            Job job = _context.Jobs.Include("DptoResponsavel").FirstOrDefault(j => j.JobId == id);
            return job;
        }

        public void EditarJob(Job jAlterado)
        {
            var result = _context.Jobs.SingleOrDefault(j => j.JobId == jAlterado.JobId);
            if (result != null)
            {
                result.TituloJob = jAlterado.TituloJob;
                result.DescricaoJob = jAlterado.DescricaoJob;
                result.DataEntregaJob = jAlterado.DataEntregaJob;
                result.StatusJob = jAlterado.StatusJob;
                result.DptoResponsavel = jAlterado.DptoResponsavel;
                _context.SaveChanges();
            }
        }

        public List<Tarefa> ListaTarefasJobID(int jID)
        {
            var result = _context.Tarefas.Include("Responsavel").Where(tl => tl.JobId == jID).ToList();

            return result;
        }

        public void ExluirJob(Job j)
        {
            _context.Jobs.Remove(j);
            _context.SaveChanges();
        }
    }
}
