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
    public class DepartamentoDAO 
    {
        private readonly Context _context;

        public DepartamentoDAO(Context context)
        {
            _context = context;
        }

        public void CadastrarDepartamento(Departamento d)
        {
            _context.Departamentos.Add(d);
            _context.SaveChanges();
        }

        //Where: metodo que retorna todas as ocorrências em uma busca
        public List<Departamento> ListarDepartamentos()
        {
            return _context.Departamentos.ToList();
        }

        public Departamento ListarDepartamentosPorId(int id)
        {
            Departamento departamento = _context.Departamentos.FirstOrDefault(d => d.DepartamentoId == id);
            return departamento;
        }

  
    }
}