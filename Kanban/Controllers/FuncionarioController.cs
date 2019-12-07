using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
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
            Funcionario f = new Funcionario();
            if (TempData["Endereco"] != null)
            {
                string resultado = TempData["Endereco"].ToString();
                Endereco endereco = JsonConvert.DeserializeObject<Endereco>(resultado);
                f.Endereco = endereco;
            }
            return View(f);
        }

        [HttpPost]
        public IActionResult BuscarCep(Funcionario f)
        {
            string url = "https://api.postmon.com.br/v1/cep/" +
                f.Endereco.cep;
            WebClient client = new WebClient();
            TempData["Endereco"] = client.DownloadString(url);

            return RedirectToAction(nameof(Cadastrar));
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