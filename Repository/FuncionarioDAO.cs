
using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FuncionarioDAO
    {

        private readonly Context _context;

        public FuncionarioDAO(Context context)
        {
            _context = context;
        }

        public bool CadastrarFuncionario(Funcionario f)
        {
            if (BuscarFuncionarioPorCpf(f) == null)
            {
                _context.Funcionarios.Add(f);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public Funcionario BuscarFuncionarioPorCpf(Funcionario f)
        {
            return _context.Funcionarios.FirstOrDefault(x => x.SenhaFuncionario.Equals(f.SenhaFuncionario));
        }

        public List<Funcionario> ListarFuncionarios() => _context.Funcionarios.ToList();


        public bool ValidarLogin(Funcionario f)
        {
            //pego o cpf e senha do funcionario        
            var result = _context.Funcionarios.FirstOrDefault(x => x.SenhaFuncionario.Equals(f.SenhaFuncionario) && x.SenhaFuncionario.Equals(f.SenhaFuncionario));

            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
