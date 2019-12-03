using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;


namespace Kanban.Controllers
{
    public class TarefaController : Controller
    {

        private readonly ProjetoDAO _projetoDAO;
        private readonly JobDAO _jobDAO;
        private readonly TarefaDAO _tarefaDAO;
        private readonly FuncionarioDAO _funcionarioDAO;
        private readonly IHostingEnvironment _hosting;

        public TarefaController(ProjetoDAO projetoDAO, JobDAO jobDAO, TarefaDAO tarefaDAO, FuncionarioDAO funcionarioDAO, IHostingEnvironment hosting)
        {
            _projetoDAO = projetoDAO;
            _jobDAO = jobDAO;
            _tarefaDAO = tarefaDAO;
            _funcionarioDAO = funcionarioDAO;
            _hosting = hosting;
        }

        public IActionResult Index()
        {
            ViewBag.DataHora = DateTime.Now;
            return View(_tarefaDAO.ListarTarefas());
         
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Responsavel = new SelectList(_funcionarioDAO.ListarFuncionarios(), "FuncionarioId", "NomeFuncionario");
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Tarefa t, int dprResponsavel)
        {
            ViewBag.Responsavel = new SelectList(_funcionarioDAO.ListarFuncionarios(), "FuncionarioId", "NomeFuncionario");

            if (ModelState.IsValid)
            {
                _tarefaDAO.CadastrarNovaTarefa(t);
                return View(t);
            }
            return View(t);
        }
    }
}