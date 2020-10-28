using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Hollistic.Web.Model;
using Fiap.Hollistic_Orgao.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Fiap.Hollistic_Orgao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository;

        public PacienteController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        //Localhost:1233/api/paciente/buscar?nome=teste -> buscar um paciente por nome
        [HttpGet("buscar")]
        public IList<Paciente> Get(string nome)
        {

            return _pacienteRepository.BuscarPor(p => p.Nome.Contains(nome));
        }
        [HttpGet]
        public IList<Paciente> Get()
        {
            return _pacienteRepository.Listar();
        }

        [HttpGet("{id}")]
        public ActionResult<Paciente> Get(int id)
        {
            var paciente = _pacienteRepository.Pesquisar(id);
            

            if (paciente == null)
            {
                return NotFound();
            }
            

            return paciente;
        }

        //localhost:1233/api/paciente (POST) -> cadastrar um paciente
        [HttpPost]
        public ActionResult<Paciente> Post(Paciente paciente)
        {
            _pacienteRepository.Cadastrar(paciente);
            _pacienteRepository.Salvar();
            //Rretorna o status 201 Created, Link para acessar o produto registrado
            //e o produto registrado
            return CreatedAtAction("Get", new { id = paciente.PacienteId }, paciente);
        }

        //localhost:1233/api/paciente/1 (PUT) -> atualizar um paciente
        [HttpPut("{id}")]
        public ActionResult<Paciente> Put(int id, Paciente paciente)
        {
            var p = _pacienteRepository.Pesquisar(id);
            if (p == null)
                return NotFound();

            paciente.PacienteId = id;
            _pacienteRepository.Atualizar(paciente);
            _pacienteRepository.Salvar();

            return Ok(paciente);  //Status 200 ok
        }

        //localhost:1233/api/paciente/1 (DELETE) -> remover um paciente
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var p = _pacienteRepository.Pesquisar(id);
            if (p == null)
                return NotFound();

            _pacienteRepository.Remover(id);
            _pacienteRepository.Salvar();

            return NoContent(); //Status 204 No Content
        }
    }
}
