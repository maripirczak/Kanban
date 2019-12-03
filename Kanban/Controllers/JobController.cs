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
        private readonly IHostingEnvironment _hosting;
        private int ProjetoId;

        public JobController(JobDAO jobDAO, TarefaDAO tarefaDAO, DepartamentoDAO departamentoDAO, ProjetoDAO projetoDAO, IHostingEnvironment hosting)
        {
            _projetoDAO = projetoDAO;
            _jobDAO = jobDAO;
            _tarefaDAO = tarefaDAO;
            _departamentoDAO = departamentoDAO;
            _hosting = hosting;
        }

        public IActionResult Index(int id)
        {
            ViewBag.DataHora = DateTime.Now;
            ProjetoId = id;
            return View(_jobDAO.ListarJobs());
        }

        public IActionResult Cadastrar()
        {
            ViewBag.DptoResponsavel = new SelectList(_departamentoDAO.ListarDepartamentos(), "DepartamentoId", "NomeDepartamento");
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Job j, int dprDptoResponsavel)
        {
            ViewBag.DptoResponsavel = new SelectList(_departamentoDAO.ListarDepartamentos(), "DepartamentoId", "NomeDepartamento");

            j.ProjetoId = ProjetoId;
            if (ModelState.IsValid)
            {               
                _jobDAO.CadastrarNovoJob(j);
                return View(j);
            }
            return View(j);
        }

    }
}