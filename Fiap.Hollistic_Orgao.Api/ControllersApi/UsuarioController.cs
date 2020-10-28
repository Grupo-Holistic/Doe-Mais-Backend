using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Hollistic.Web.Model;
using Fiap.Hollistic_Orgao.Api.Models;
using Fiap.Hollistic_Orgao.Web.Persistencia;
using Fiap.Hollistic_Orgao.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Hollistic_Orgao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private DoacaoContext _context;
        private IUsuarioRepository _usuarioRepository;
        private IHospitalRepository _hospitalRepository;

        public UsuarioController(DoacaoContext context, IUsuarioRepository usuarioRepository, IHospitalRepository hospitalRepository)
        {
            _context = context;
            _usuarioRepository = usuarioRepository;
            _hospitalRepository = hospitalRepository;
        }


        //Localhost:1233/api/produto/buscar?nome=teste -> buscar um produto por nome
        [HttpPost("login")]
        public ActionResult<Usuario> Post(Teste teste)
        {
            var login = _usuarioRepository.PesquisarLogin(teste.Email, teste.Senha);
            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }
        [HttpGet]
        public IList<Usuario> Get()
        {
            return _usuarioRepository.Listar();
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = _usuarioRepository.Pesquisar(id);


            if (usuario == null)
            {
                return NotFound();
            }


            return usuario;
        }

        //localhost:1233/api/produto (POST) -> cadastrar um produto
        [HttpPost]
        public ActionResult<Usuario> Post(Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);
            _usuarioRepository.Salvar();
            //Rretorna o status 201 Created, Link para acessar o produto registrado
            //e o produto registrado
            return CreatedAtAction("Get", new { id = usuario.UsuarioId }, usuario);
        }

        //localhost:1233/api/produto/1 (PUT) -> atualizar um produto
        [HttpPut("{id}")]
        public ActionResult<Usuario> Put(int id, Usuario usuario)
        {
            var p = _usuarioRepository.Pesquisar(id);
            if (p == null)
                return NotFound();

            usuario.UsuarioId = id;
            _usuarioRepository.Atualizar(usuario);
            _usuarioRepository.Salvar();

            return Ok(usuario);  //Status 200 ok
        }

        //localhost:1233/api/produto/1 (DELETE) -> remover um produto
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var p = _usuarioRepository.Pesquisar(id);
            if (p == null)
                return NotFound();

            _usuarioRepository.Remover(id);
            _usuarioRepository.Salvar();

            return NoContent(); //Status 204 No Content
        }

    }
}
