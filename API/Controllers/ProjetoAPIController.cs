using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controllers
{
    [Route("api/Projeto")]
    [ApiController]
    public class ProjetoAPIController : ControllerBase
    {
        private readonly ProjetoDAO _projetoDAO;
        public ProjetoAPIController(ProjetoDAO projetoDAO)
        {
            _projetoDAO = projetoDAO;
        }

        //GET: /api/Projeto/ListarJobsPorProjetoIdApi/id
        [HttpGet]
        [Route("ListarJobsPorProjetoIdApi/{id}")]
        public IActionResult ListarJobsPorProjetoIdApi(int id)
        {
            List<Job> j = _projetoDAO.ListarJobsPorProjetoIdApi(id);
            if (j != null)
            {
                return Ok(j);
            }
            return NotFound(new { msg = "Projeto não encontrado!" });


            //return Ok(_projetoDAO.ListarJobsPorProjetoIdApi(id));
    

        }

    }
}