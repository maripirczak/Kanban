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
    public class ProjetoController : Controller
    {

        private readonly ProjetoDAO _projetoDAO;
        private readonly JobDAO _jobDAO;
        private readonly StatusDAO _statusDAO;
        private readonly IHostingEnvironment _hosting;

        public ProjetoController(ProjetoDAO projetoDAO, JobDAO jobDAO, StatusDAO statusDAO, IHostingEnvironment hosting)
        {
            _projetoDAO = projetoDAO;
            _jobDAO = jobDAO;
            _statusDAO = statusDAO;
            _hosting = hosting;
        }

        public IActionResult Index()
        {
            ViewBag.DataHora = DateTime.Now;
            return View(_projetoDAO.ListarProjetos());
        }

        public IActionResult Cadastrar()
        {
            ViewBag.NomeStatus = new SelectList(_statusDAO.ListarStatusPorNome(), "TipoStatusId", "NomeStatus");
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Projeto p, int dprNomeStatus)
        {
            ViewBag.NomeStatus = new SelectList(_statusDAO.ListarStatusPorNome(), "TipoStatusId", "NomeStatus");

            if (ModelState.IsValid)
            {
                p.StatusProjeto = _statusDAO.ListarStatusPorId(dprNomeStatus);
                _projetoDAO.CadastrarNovoProjeto(p);
                return View(p);
            }
            return View(p);
        }


        public IActionResult Remover(int id)
        {
            if (id != null)
            {
                _projetoDAO.ExluirProjeto(id);
            }
            else
            {
                //Redirecionar para uma página de erro
            }
            return RedirectToAction("Index");
        }


        public IActionResult Alterar(int id)
        {
            return View(_projetoDAO.BuscarProjetoPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Projeto p)
        {
            _projetoDAO.EditarProjeto(p);
            return RedirectToAction("Index");
        }

        public IActionResult VerJobs(int id)
        {
            return View(_jobDAO.BuscarJobPorId(id));
        }



    }
}