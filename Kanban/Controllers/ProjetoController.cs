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
        private readonly IHostingEnvironment _hosting;

        public ProjetoController(ProjetoDAO projetoDAO, JobDAO jobDAO, IHostingEnvironment hosting)
        {
            _projetoDAO = projetoDAO;
            _jobDAO = jobDAO;
            _hosting = hosting;
        }

        public IActionResult Index()
        {
            ViewBag.DataHora = DateTime.Now;
            return View(_projetoDAO.ListarProjetos());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Projeto p)
        {
            ViewBag.Categorias = new SelectList(_projetoDAO.ListarProjetos(), "ProjetoId", "NomeProjeto");

            if (ModelState.IsValid)
            {
                _projetoDAO.CadastrarNovoProjeto(p);
                return View(p);
            }
            return View(p);
        }

    }
}