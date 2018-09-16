using DSC.SmartMarket.BusinessLogic;
using DSC.SmartMarket.Model;
using DSC.SmartMarket.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSC.SmartMarket.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IAcessoFacade AcessoFacade
        {
            get
            {
                return (IAcessoFacade)this.Resolver.GetService<IAcessoFacade>();
            }
        }

        [HttpGet]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginHomeViewModel login)
        {
            var usuario = new Usuario()
            {
                Email = login.Email,
                Senha = login.Senha
            };
            var resultado = AcessoFacade.ValidarLoginUsuario(usuario);
            if (resultado.Sucesso)
            {
                var usuarioValidado = resultado.Retorno;
                Session["Logado"] = true;
                Session.SetUsuarioLogado(usuarioValidado);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ModelState.AddModelError("Email", resultado.ConsolidaMensagens("<br>"));
                return View("Index");
            }
        }
    }
}