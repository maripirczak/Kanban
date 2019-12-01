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
        private readonly JobDAO _jobDAO;
        private readonly TarefaDAO _tarefaDAO;
        private readonly DepartamentoDAO _departamentoDAO;
        private readonly IHostingEnvironment _hosting;

        public JobController(JobDAO jobDAO, TarefaDAO tarefaDAO, DepartamentoDAO departamentoDAO, IHostingEnvironment hosting)
        {
            _jobDAO = jobDAO;
            _tarefaDAO = tarefaDAO;
            _departamentoDAO = departamentoDAO;
            _hosting = hosting;
        }

        public IActionResult Index()
        {
            ViewBag.DataHora = DateTime.Now;
            return View(_jobDAO.ListarJobs());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Job j)
        {
            if(ModelState.IsValid)
            {
                _jobDAO.CadastrarNovoJob(j);
                return View(j);
            }
            return View(j);
        }
    }
}