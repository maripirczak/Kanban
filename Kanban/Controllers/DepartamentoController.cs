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
    public class DepartamentoController : Controller
    {
        private readonly DepartamentoDAO _departamentoDAO;
        private readonly JobDAO _jobDAO;
        private readonly IHostingEnvironment _hosting;

        public DepartamentoController(DepartamentoDAO departamentoDAO, JobDAO jobDAO, IHostingEnvironment hosting)
        {
            _jobDAO = jobDAO;
            _departamentoDAO = departamentoDAO;
            _hosting = hosting;
        }


        public IActionResult Index()
        {
            ViewBag.DataHora = DateTime.Now;
            return View(_departamentoDAO.ListarDepartamentos());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Departamento d)
        {            
            if (ModelState.IsValid)
            {
                _departamentoDAO.CadastrarDepartamento(d);
                return View(d);
            }
            return View(d);
        }
    }
}