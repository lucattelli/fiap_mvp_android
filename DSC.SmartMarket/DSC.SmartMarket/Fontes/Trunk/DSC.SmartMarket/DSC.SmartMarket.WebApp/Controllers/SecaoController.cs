using DSC.SmartMarket.Model;
using DSC.SmartMarket.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSC.SmartMarket.WebApp.Controllers
{
    public class SecaoController : Controller
    {
        // GET: Secao
        public ActionResult Index()
        {
            var model = new IndexSecaoViewModel()
            {
                Operacao = IndexSecaoViewModel.TipoOperacao.Listar
            };
            return View(model);
        }
    }
}