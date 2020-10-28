using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Hollistic.Web.Model;
using Fiap.Hollistic_Orgao.Web.Persistencia;
using Fiap.Hollistic_Orgao.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Hollistic_Orgao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {

        private DoacaoContext _context;
        private IExameRepository _exameRepository;

        public ExameController(DoacaoContext context, IExameRepository exameRepository)
        {
            _context = context;
            _exameRepository = exameRepository;
        }

        //Localhost:1233/api/produto/buscar?nome=teste
        public IList<Exame> Get(string tipo)
        {

            return _exameRepository.BuscarPor(e => e.Tipo.Contains(tipo));
        }
        [HttpGet]
        public IList<Exame> Get()
        {
            return _exameRepository.Listar();
        }

        [HttpGet("{id}")]
        public ActionResult<Exame> Get(int id)
        {
            var Exame = _exameRepository.Pesquisar(id);


            if (Exame == null)
            {
                return NotFound();
            }


            return Exame;
        }

        //localhost:1233/api/produto (POST)
        [HttpPost]
        public ActionResult<Exame> Post(Exame exame)
        {
            _exameRepository.Cadastrar(exame);
            _exameRepository.Salvar();
            //Rretorna o status 201 Created, Link para acessar o produto registrado
            //e o produto registrado
            return CreatedAtAction("Get", new { id = exame.ExameId }, exame);
        }

        //localhost:1233/api/produto/1 (PUT) 
        [HttpPut("{id}")]
        public ActionResult<Exame> Put(int id, Exame exame)
        {
            var p = _exameRepository.Pesquisar(id);
            if (p == null)
                return NotFound();

            exame.ExameId = id;
            _exameRepository.Atualizar(exame);
            _exameRepository.Salvar();

            return Ok(exame);  //Status 200 ok
        }

        //localhost:1233/api/produto/1 (DELETE) 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var p = _exameRepository.Pesquisar(id);
            if (p == null)
                return NotFound();

            _exameRepository.Remover(id);
            _exameRepository.Salvar();

            return NoContent(); //Status 204 No Content
        }
    }
}
