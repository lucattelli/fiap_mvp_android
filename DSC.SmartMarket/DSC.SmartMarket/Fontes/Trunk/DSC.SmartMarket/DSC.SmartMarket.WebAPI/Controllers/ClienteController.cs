using System;
using System.Linq;
using System.Web.Http;
using DSC.SmartMarket.BusinessLogic;
using DSC.SmartMarket.BusinessLogic.Common;
using DSC.SmartMarket.Model;

namespace DSC.SmartMarket.WebAPI
{
    public class ClienteController : ApiController
    {
        #region Propriedade(s)
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
        public IHttpActionResult Get(int? id = null)
        {
            if (id.HasValue)
            {
                var cliente = new Cliente()
                {
                    Id = id.Value
                };
                var resultado = ComercialFacade.ConsultarCliente(cliente);
                if (resultado.Sucesso)
                {
                    return Ok(resultado.Retorno);
                }
                else
                {
                    return BadRequest(resultado.ConsolidaMensagens("\n"));
                }
            }
            else
            {
                var resultado = ComercialFacade.ListarTodosCliente();
                if (resultado.Sucesso)
                {
                    var lista = resultado.Retorno.Item1;
                    if (lista.Any())
                    {
                        return Ok(lista);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                    return BadRequest(resultado.ConsolidaMensagens("\n"));
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Cliente cliente)
        {
            if (cliente != null)
            {
                cliente.CPF = Formata.RemoveFormatoCPF(cliente.CPF);
                cliente.RG = Formata.RemoveFormatoCPF(cliente.RG);
                cliente.Telefone = Formata.RemoveFormatoTelefone(cliente.Telefone);
                var resultado = ComercialFacade.IncluirCliente(cliente);
                if (resultado)
                {
                    var location = Url.Link("DefaultApi", new { controller = "Cliente", id = cliente.Id });
                    return Created(new Uri(location), cliente);
                }
                else
                {
                    return BadRequest(resultado.ConsolidaMensagens("\n"));
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] Cliente cliente)
        {
            if (cliente != null)
            {
                cliente.CPF = Formata.RemoveFormatoCPF(cliente.CPF);
                cliente.CPF = Formata.RemoveFormatoCPF(cliente.CPF);
                cliente.RG = Formata.RemoveFormatoCPF(cliente.RG);
                cliente.Telefone = Formata.RemoveFormatoTelefone(cliente.Telefone);
                var resultado = ComercialFacade.AlterarCliente(cliente);
                if (resultado)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(resultado.ConsolidaMensagens("\n"));
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int? id = null)
        {
            if (id.HasValue)
            {
                var cliente = new Cliente() { Id = id.Value };
                var resultado = ComercialFacade.ExcluirCliente(cliente);
                if (resultado)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(resultado.ConsolidaMensagens("\n"));
                }
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion Método(s)
    }
}