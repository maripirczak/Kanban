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

        //GET: /api/Projeto/ListarJobsPorProjetoIdApi/2
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


        [Route("api/[controller]")]
        [ApiController]
        public class JobAPIController : ControllerBase
        {
            private readonly JobDAO _jobDAO;
            public JobAPIController(JobDAO jobDAO)
            {
                _jobDAO = jobDAO;
            }

            //GET: /api/Job/ListarTarefasPorJobIdApi/8015
            [HttpGet]
            [Route("ListarTarefasPorJobIdApi/{id}")]
            public IActionResult ListarTarefasPorJobIdApi(int id)
            {
                List<Tarefa> t = _jobDAO.ListarTarefasPorJobIdApi(id);
                if (t != null)
                {
                    return Ok(t);
                }
                return NotFound(new { msg = "Job não encontrado!" });


            }


        }
    }
    }