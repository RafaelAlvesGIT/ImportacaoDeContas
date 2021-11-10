using ControleDeContas.Dao;
using ControleDeContas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContas.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        // POST api/<ContasController>
        [HttpPost]
        public void Post([FromBody] List<Conta> contas)
        {
            ContaDao conta = new ContaDao();
            conta.InserirListaConta(contas);
        }
    }
}
