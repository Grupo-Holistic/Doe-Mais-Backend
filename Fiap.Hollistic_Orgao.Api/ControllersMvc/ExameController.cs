using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Hollistic.Web.Model;
using Fiap.Hollistic_Orgao.Web.Persistencia;
using Fiap.Hollistic_Orgao.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Hollistic_Orgao.Api.ControllersMvc
{
    public class ExameController : Controller
    {
        private DoacaoContext _context;

        private IExameRepository _exameRepository;

        public ExameController(DoacaoContext context, IExameRepository exameRepository)
        {
            _context = context;
            _exameRepository = exameRepository;

        }

        
        public IActionResult Index()
        {
            var lista = _exameRepository.Listar();
            ViewBag.exames = lista;


            return View();
        }

        public IActionResult Cadastrar(Exame exame)
        {
            _exameRepository.Cadastrar(exame);
            _exameRepository.Salvar();
            TempData["msg"] = "Exame Registrado";
            return RedirectToAction("Index");

        }
    }
}
