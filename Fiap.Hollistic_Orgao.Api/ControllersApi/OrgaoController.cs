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
    public class OrgaoController : ControllerBase
    {

        private DoacaoContext _context;
        private IOrgaoRepository _orgaoRepository;

        public OrgaoController(DoacaoContext context, IOrgaoRepository orgaoRepository)
        {
            _context = context;
            _orgaoRepository = orgaoRepository;
        }

        //Localhost:1233/api/produto/buscar?nome=teste
        public IList<Orgao> Get(string tipoOrgao)
        {

            return _orgaoRepository.BuscarPor(o => o.TipoOrgao.Equals(tipoOrgao));
        }
        [HttpGet]
        public IList<Orgao> Get()
        {
            return _orgaoRepository.Listar();
        }

        [HttpGet("{id}")]
        public ActionResult<Orgao> Get(int id)
        {
            var Orgao = _orgaoRepository.Pesquisar(id);


            if (Orgao == null)
            {
                return NotFound();
            }


            return Orgao;
        }

        //localhost:1233/api/produto (POST)
        [HttpPost]
        public ActionResult<Orgao> Post(Orgao orgao)
        {
            _orgaoRepository.Cadastrar(orgao);
            _orgaoRepository.Salvar();
            //Rretorna o status 201 Created, Link para acessar o produto registrado
            //e o produto registrado
            return CreatedAtAction("Get", new { id = orgao.OrgaoId }, orgao);
        }

        //localhost:1233/api/produto/1 (PUT) 
        [HttpPut("{id}")]
        public ActionResult<Orgao> Put(int id, Orgao orgao)
        {
            var p = _orgaoRepository.Pesquisar(id);
            if (p == null)
                return NotFound();

            orgao.OrgaoId = id;
            _orgaoRepository.Atualizar(orgao);
            _orgaoRepository.Salvar();

            return Ok(orgao);  //Status 200 ok
        }

        //localhost:1233/api/produto/1 (DELETE) 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var p = _orgaoRepository.Pesquisar(id);
            if (p == null)
                return NotFound();

            _orgaoRepository.Remover(id);
            _orgaoRepository.Salvar();

            return NoContent(); //Status 204 No Content
        }
    }
}
