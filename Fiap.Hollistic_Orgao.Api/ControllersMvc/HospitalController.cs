using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Hollistic.Web.Model;
using Fiap.Hollistic_Orgao.Web.Persistencia;
using Fiap.Hollistic_Orgao.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Hollistic_Orgao.Web.Controllers
{
    public class HospitalController : Controller
    {
        private DoacaoContext _context;
        private IHospitalRepository _hospitalRepository;

        public HospitalController(DoacaoContext context, IHospitalRepository hospitalRepository)
        {
            _context = context;
            _hospitalRepository = hospitalRepository;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Hospital hospital)
        {
            _hospitalRepository.Cadastrar(hospital);
            _hospitalRepository.Salvar();
            TempData["msg"] = "Hospital Cadastrado";

            return RedirectToAction("Cadastrar");

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
