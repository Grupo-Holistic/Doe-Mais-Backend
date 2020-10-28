using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class PacienteController : Controller
    {
        private DoacaoContext _context;
        private IPacienteRepository _pacienteRepository;
        private IExameRepository _exameRepository;
        private IOrgaoRepository _orgaoRepository;

        public PacienteController(DoacaoContext context, IPacienteRepository pacienteRepository,
            IExameRepository exameRepository, IOrgaoRepository orgaoRepository)
        {
            _context = context;
            _pacienteRepository = pacienteRepository;
            _exameRepository = exameRepository;
            _orgaoRepository = orgaoRepository;
        }

        [HttpPost]
        public IActionResult AdicionarOrgao(Orgao orgao)
        {
            _orgaoRepository.Cadastrar(orgao);
            _orgaoRepository.Salvar();
            TempData["msg"] = "Orgao cadastrado";

            return RedirectToAction("AdicionarOrgao");
        }
        [HttpGet]
        public IActionResult AdicionarOrgao(int id)
        {
            var orgaos = _orgaoRepository.BuscarPor(p => p.PacienteId == id).ToList();
            ViewBag.lista = orgaos;
            var pp = _pacienteRepository.Pesquisar(id);
            var lista = _orgaoRepository.Listar();


            var model = new IndexPacienteViewModel
            {
                Orgaos = new SelectList(lista, "OrgaoId", "TipoOrgao"),
                Paciente = pp,
                PacienteId = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Adicionar(Exame exame)
        {
            _exameRepository.Cadastrar(exame);
            _exameRepository.Salvar();
            TempData["msg"] = "Exame cadastrado";
            
            return RedirectToAction("Adicionar");
        }
        [HttpGet]
        public IActionResult Adicionar(int id)
        {
            var exames = _exameRepository.BuscarPor(p => p.PacienteId == id).ToList();
            ViewBag.lista = exames;
            var pp = _pacienteRepository.Pesquisar(id);
            var lista = _exameRepository.Listar();
            
            
            var model = new IndexPacienteViewModel
            {
                Exames = new SelectList(lista, "ExameId", "Tipo"),
                Paciente = pp,
                PacienteId = id
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Paciente paciente)
        {
            _pacienteRepository.Cadastrar(paciente);
            _pacienteRepository.Salvar();

            TempData["msg"] = "Paciente Cadastrado";

            return RedirectToAction("Cadastrar");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _pacienteRepository.Remover(id);
            _pacienteRepository.Salvar();
            TempData["msg"] = "Paciente Removido";

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var paciente = _pacienteRepository.PesquisarDetalhes(id);

            return View(paciente);
        }

        [HttpPost]
        public IActionResult Editar(Paciente paciente)
        {
            _pacienteRepository.Atualizar(paciente);
            _pacienteRepository.Salvar();
            TempData["msg"] = "Paciente Atualizado";

            return RedirectToAction("index");

        }
        public IActionResult Index(bool doador, bool receptor)
        {

            List<string> opcoes = new List<string>();
            opcoes.Add("Doador");
            opcoes.Add("Receptor");

            var lista = _pacienteRepository.Listar();

            if (doador == true)
            {
                lista = _pacienteRepository.BuscarPor(p => p.Doador.Equals(doador));
            }
            else if (receptor == true)
            {
                lista = _pacienteRepository.BuscarPor(p => p.Receptor.Equals(receptor));
            }

            var model = new IndexPacienteViewModel
            {
                Pacientes = lista
            };

            return View(model);
        }
    }
}
