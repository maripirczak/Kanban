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
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioDAO _funcionarioDAO;
        private readonly DepartamentoDAO _departamentoDAO;
        private readonly IHostingEnvironment _hosting;

        public FuncionarioController(FuncionarioDAO funcionarioDAO, DepartamentoDAO departamentoDAO, IHostingEnvironment hosting)
        {
            _funcionarioDAO = funcionarioDAO;
            _departamentoDAO = departamentoDAO;
            _hosting = hosting;
        }

        public IActionResult Index()
        {
            ViewBag.DataHora = DateTime.Now;
            return View(_funcionarioDAO.ListarFuncionarios());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Funcionario f)
        {
            if (ModelState.IsValid)
            {
                _funcionarioDAO.CadastrarFuncionario(f);
                return View(f);
            }
            return View(f);
        }
    }
}