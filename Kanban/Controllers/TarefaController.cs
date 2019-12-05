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
        private readonly StatusDAO _statusDAO;
        private readonly IHostingEnvironment _hosting;
        //private int JobId;

        public TarefaController(ProjetoDAO projetoDAO, JobDAO jobDAO, TarefaDAO tarefaDAO, FuncionarioDAO funcionarioDAO, StatusDAO statusDAO, IHostingEnvironment hosting)
        {
            _projetoDAO = projetoDAO;
            _jobDAO = jobDAO;
            _tarefaDAO = tarefaDAO;
            _funcionarioDAO = funcionarioDAO;
            _statusDAO = statusDAO;
            _hosting = hosting;
        }

        public IActionResult Index(int id)
        {
            ViewBag.DataHora = DateTime.Now;
            ViewBag.JobId = id;
            //return View(_tarefaDAO.ListarTarefas());
            return View(_jobDAO.ListaTarefasJobID(id));

        }

        public IActionResult Cadastrar(int id)
        {
            ViewBag.Responsavel = new SelectList(_funcionarioDAO.ListarFuncionarios(), "FuncionarioId", "NomeFuncionario");
            ViewBag.NomeStatus = new SelectList(_statusDAO.ListarStatusPorNome(), "TipoStatusId", "NomeStatus");
            ViewBag.Jobid = id;
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Tarefa t, int dprResponsavel, int dprNomeStatus, int hdnJobId)
        {
            t.JobId = hdnJobId;
            ViewBag.Responsavel = new SelectList(_funcionarioDAO.ListarFuncionarios(), "FuncionarioId", "NomeFuncionario");
            ViewBag.NomeStatus = new SelectList(_statusDAO.ListarStatusPorNome(), "TipoStatusId", "NomeStatus");

            if (ModelState.IsValid)
            {
                t.Responsavel = _funcionarioDAO.ListarFuncionariosPorId(dprResponsavel);
                t.StatusTarefa = _statusDAO.ListarStatusPorId(dprNomeStatus);
                _tarefaDAO.CadastrarNovaTarefa(t);
                return View(t);
            }
            return View(t);
        }

        public IActionResult Alterar(int id)
        {
            ViewBag.Responsavel = new SelectList(_funcionarioDAO.ListarFuncionarios(), "FuncionarioId", "NomeFuncionario");
            ViewBag.NomeStatus = new SelectList(_statusDAO.ListarStatusPorNome(), "TipoStatusId", "NomeStatus");
            return View(_tarefaDAO.BuscarTarefaoPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Tarefa t)
        {
            
            _tarefaDAO.EditarTarefa(t);
            return RedirectToAction("Index");
        }

        public IActionResult Remover(int id)
        {
            if (id != null)
            {
                _tarefaDAO.ExluirTarefa(id);
            }
            else
            {
                //Redirecionar para uma página de erro
            }
            return RedirectToAction("Index");
        }
    }
}