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
    public class UsuarioController : Controller
    {
        private IAcessoFacade AcessoFacade
        {
            get
            {
                return (IAcessoFacade)this.Resolver.GetService<IAcessoFacade>();
            }
        }

        [HttpGet]
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastrarUsuarioViewModel u)
        {
            var usuario = new Usuario()
            {
                Nome = u.Nome,
                Email = u.Email,
                Senha = u.Senha

            };
            var resultado = AcessoFacade.CadastrarUsuario(usuario);
            if (resultado.Sucesso)
            {
                return RedirectToAction("Index", "Home");
            } else
            {
                ModelState.AddModelError("Email", resultado.ConsolidaMensagens("<br>"));
                return View("Cadastrar");
            }
        }

        [HttpGet]
        public ActionResult SenhaRedefinir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SenhaRedefinir(SenhaRedefinirUsuarioViewModel r)
        {
            var usuario = new Usuario()
            {
                Email = r.Email,
                Senha = r.Senha

            };
            var resultado = AcessoFacade.SenhaRedefinir(usuario);
            if (resultado.Sucesso)
            {
                return RedirectToAction("SenhaEnviada", "Usuario");
            }
            else
            {
                ModelState.AddModelError("Email", resultado.ConsolidaMensagens("<br>"));
                return View("SenhaRedefinir");
            }
        }

        [HttpGet]
        public ActionResult SenhaEnviada()
        {
            return View();
        }
    }
}