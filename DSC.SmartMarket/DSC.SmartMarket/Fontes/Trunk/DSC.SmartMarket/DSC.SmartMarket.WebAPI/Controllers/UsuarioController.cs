using DSC.SmartMarket.BusinessLogic;
using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DSC.SmartMarket.WebAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        #region Propriedade(s)
        private IAcessoFacade AcessoFacade
        {
            get
            {
                return (IAcessoFacade)this.Configuration.DependencyResolver.GetService(typeof(IAcessoFacade));
            }
        }

        private IComercialFacade ComercialFacade
        {
            get
            {
                return (IComercialFacade)this.Configuration.DependencyResolver.GetService(typeof(IComercialFacade));
            }
        }
        #endregion Propriedade(s)

        #region Método(s)
        [HttpGet]
        public IHttpActionResult Get(string email = null, string senha = null)
        {
            var resultado = AcessoFacade.ValidarLoginUsuario(new Usuario() { Email = email, Senha = senha });
            if (resultado)
            {
                var usuario = resultado.Retorno;
                var retornoJson = new
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Cliente = new
                    {
                        Id = usuario.Cliente.Id,
                        Nome = usuario.Cliente.Nome,
                        RG = usuario.Cliente.RG,
                        CPF = usuario.Cliente.CPF,
                        Email = usuario.Cliente.Email,
                        Telefone = usuario.Cliente.Telefone
                    }
                };
                return Ok(retornoJson);
            }
            else
            {
                return BadRequest(resultado.ConsolidaMensagens("\n"));
            }
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] Usuario usuario)
        {
            var resultado = new Resultado();
            if (usuario != null)
            {
                resultado = AcessoFacade.CadastrarUsuario(usuario);
            }
            else
            {
                resultado += "Dados do usuário para cadastro não informado.";
            }

            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest(resultado.ConsolidaMensagens("\n"));
            }
        }
        #endregion Método(s)
    }
}
