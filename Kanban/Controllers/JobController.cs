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
    public class JobController : Controller
    {
        private readonly ProjetoDAO _projetoDAO;
        private readonly JobDAO _jobDAO;
        private readonly TarefaDAO _tarefaDAO;
        private readonly DepartamentoDAO _departamentoDAO;
        private readonly StatusDAO _statusDAO;
        private readonly IHostingEnvironment _hosting;
        //private int ProjetoId;

        public JobController(JobDAO jobDAO, TarefaDAO tarefaDAO, DepartamentoDAO departamentoDAO, ProjetoDAO projetoDAO, StatusDAO statusDAO, IHostingEnvironment hosting)
        {
            _projetoDAO = projetoDAO;
            _jobDAO = jobDAO;
            _tarefaDAO = tarefaDAO;
            _departamentoDAO = departamentoDAO;
            _statusDAO = statusDAO;
            _hosting = hosting;
        }

        public IActionResult Index(int id)
        {
            ViewBag.DataHora = DateTime.Now;
            ViewBag.ProjetoId = id;
           // return View(_jobDAO.BuscarJobPorId(id));
            return View(_projetoDAO.ListaJobsProjetoID(id));
        }

        public IActionResult Cadastrar(int id)
        {
            ViewBag.DptoResponsavel = new SelectList(_departamentoDAO.ListarDepartamentos(), "DepartamentoId", "NomeDepartamento");
            ViewBag.NomeStatus = new SelectList(_statusDAO.ListarStatusPorNome(), "TipoStatusId", "NomeStatus");
            ViewBag.ProjetoId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Job j, int dprDptoResponsavel, int dprNomeStatus, int hdnProjetoId)
        {
            j.ProjetoId = hdnProjetoId;
            ViewBag.DptoResponsavel = new SelectList(_departamentoDAO.ListarDepartamentos(), "DepartamentoId", "NomeDepartamento");
            ViewBag.NomeStatus = new SelectList(_statusDAO.ListarStatusPorNome(), "TipoStatusId", "NomeStatus");

            if (ModelState.IsValid)
            {
                j.DptoResponsavel = _departamentoDAO.ListarDepartamentosPorId(dprDptoResponsavel);
                j.StatusJob = _statusDAO.ListarStatusPorId(dprNomeStatus);
                _jobDAO.CadastrarNovoJob(j);
                return View(j);
            }

            return View(j);
        }

        public IActionResult Alterar(int id)
        {
            ViewBag.DptoResponsavel = new SelectList(_departamentoDAO.ListarDepartamentos(), "DepartamentoId", "NomeDepartamento");
            ViewBag.NomeStatus = new SelectList(_statusDAO.ListarStatusPorNome(), "TipoStatusId", "NomeStatus");
            return View(_jobDAO.BuscarJobPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Job j)
        {
            _jobDAO.EditarJob(j);
            return RedirectToAction("Index");
        }

        public IActionResult Remover(int id)
        {
            if (id != null)
            {
                _jobDAO.ExluirJob(id);
            }
            else
            {
                //Redirecionar para uma página de erro
            }
            return RedirectToAction("Index");
        }

    }
}