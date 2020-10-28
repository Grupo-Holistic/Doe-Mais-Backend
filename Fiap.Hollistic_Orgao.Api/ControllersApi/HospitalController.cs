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
    public class HospitalController : ControllerBase
    {

        private DoacaoContext _context;
        private IHospitalRepository _hospitalRepository;

        public HospitalController(DoacaoContext context, IHospitalRepository hospitalRepository)
        {
            _context = context;
            _hospitalRepository = hospitalRepository;
        }

        //Localhost:1233/api/produto/buscar?nome=teste
        public IList<Hospital> Get(string nome)
        {

            return _hospitalRepository.BuscarPor(h => h.Nome.Contains(nome));
        }
        [HttpGet]
        public IList<Hospital> Get()
        {
            return _hospitalRepository.Listar();
        }

        [HttpGet("{id}")]
        public ActionResult<Hospital> Get(int id)
        {
            var Hospital = _hospitalRepository.Pesquisar(id);


            if (Hospital == null)
            {
                return NotFound();
            }


            return Hospital;
        }

        //localhost:1233/api/produto (POST)
        [HttpPost]
        public ActionResult<Hospital> Post(Hospital hospital)
        {
            _hospitalRepository.Cadastrar(hospital);
            _hospitalRepository.Salvar();
            //Rretorna o status 201 Created, Link para acessar o produto registrado
            //e o produto registrado
            return CreatedAtAction("Get", new { id = hospital.HospitalId }, hospital);
        }

        //localhost:1233/api/produto/1 (PUT) 
        [HttpPut("{id}")]
        public ActionResult<Hospital> Put(int id, Hospital hospital)
        {
            var p = _hospitalRepository.Pesquisar(id);
            if (p == null)
                return NotFound();

            hospital.HospitalId = id;
            _hospitalRepository.Atualizar(hospital);
            _hospitalRepository.Salvar();

            return Ok(hospital);  //Status 200 ok
        }

        //localhost:1233/api/produto/1 (DELETE) 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var p = _hospitalRepository.Pesquisar(id);
            if (p == null)
                return NotFound();

            _hospitalRepository.Remover(id);
            _hospitalRepository.Salvar();

            return NoContent(); //Status 204 No Content
        }
    }
}
