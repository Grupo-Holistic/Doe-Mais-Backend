using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Hollistic.Web.Model;
using Fiap.Hollistic_Orgao.Web.Persistencia;
using Fiap.Hollistic_Orgao.Web.Repositories;
using Fiap.Hollistic_Orgao.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Hollistic_Orgao.Web.Controllers
{
    public class UsuarioController : Controller
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

        public IActionResult Remover(int id)
        {
            _usuarioRepository.Remover(id);
            _usuarioRepository.Salvar();
            TempData["msg"] = "Usuario Removido";

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarHospitais();

            var usuario = _usuarioRepository.Pesquisar(id);

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            _usuarioRepository.Atualizar(usuario);
            _usuarioRepository.Salvar();
            TempData["msg"] = "Usuario Atualizado";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarHospitais();
            return View();
        }

        private void CarregarHospitais()
        {
            var lista = _hospitalRepository.Listar();
            ViewBag.Hospitais = new SelectList(lista, "HospitalId", "Nome");
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);
            _usuarioRepository.Salvar();
            TempData["msg"] = "Usuario Cadastrado";

            return RedirectToAction("Cadastrar", new { id = usuario.UsuarioId});

        }

        public IActionResult Login(string email, string senha)
        {
            var login = _usuarioRepository.PesquisarLogin(email, senha);
            

            if (login != null)
            {
                var hospital = _usuarioRepository.PesquisarDetalhes(login.UsuarioId).Hospital.Nome;

                ViewBag.hospital = hospital;
                return RedirectToAction("Index", "Paciente" ) ;
                
            }
            else
            {
                TempData["msg"] = "Usuario ou senha inválido";
            }
            return View();
        }

        public IActionResult Index()
        {

            var lista = _usuarioRepository.Listar();

            var model = new IndexUsuarioViewModel
            {
                Usuarios = lista
            };

            return View(model);
        }
    }
}
