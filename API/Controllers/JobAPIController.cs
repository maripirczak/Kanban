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
    [Route("api/[controller]")]
    [ApiController]
    public class JobAPIController : ControllerBase
    {
        private readonly JobDAO _jobDAO;
        public JobAPIController(JobDAO jobDAO)
        {
            _jobDAO = jobDAO;
        }

        //GET: /api/Job/ListarTarefasPorJobIdApi/id
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