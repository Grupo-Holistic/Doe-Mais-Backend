using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Hollistic_Orgao.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Hollistic_Orgao.Api.ControllersMvc
{
    public class OrgaoController : Controller
    {
        private IOrgaoRepository _orgaoRepository;
        public OrgaoController(IOrgaoRepository orgaoRepository)
        {
            _orgaoRepository = orgaoRepository;

        }
        public IActionResult Index()
        {
            var lista = _orgaoRepository.Listar();
            ViewBag.orgaos = lista;
            return View();
        }
    }
}
