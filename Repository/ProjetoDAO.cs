using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class ProjetoDAO
    {
        private readonly Context _context;

        public ProjetoDAO(Context context)
        {
            _context = context;
        }

        public void CadastrarNovoProjeto(Projeto p)
        {
            _context.Projetos.Add(p);
            _context.SaveChanges();
        }

        public List<Projeto> ListarProjetos() => _context.Projetos.ToList();


        //metodo que localiza o campo da chave primaria e busca
        public Projeto BuscarProjetoPorId(int id)
        {
            return _context.Projetos.Find(id);
        }


        public void EditarProjeto(Projeto pAlterado)
        {
            var result = _context.Projetos.SingleOrDefault(p => p.ProjetoId == pAlterado.ProjetoId);
            if (result != null)
            {
                result.NomeProjeto = pAlterado.NomeProjeto;
                result.DescricaoProjeto = pAlterado.DescricaoProjeto;
                result.NomeEmpresa = pAlterado.NomeEmpresa;
                result.StatusProjeto = pAlterado.StatusProjeto;
                _context.SaveChanges();
            }

        }

        public List<Job> ListaJobsProjetoID(int pID)
        {
            var result = _context.Jobs.Include("DptoResponsavel").Where(jl => jl.ProjetoId == pID).ToList();

            return result;
        }

        public void ExluirProjeto(Projeto p)
        {
            _context.Projetos.Remove(p);
            _context.SaveChanges();

        }
    }
}
