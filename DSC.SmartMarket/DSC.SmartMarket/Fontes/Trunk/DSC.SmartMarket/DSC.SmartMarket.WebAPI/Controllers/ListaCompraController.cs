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
    public class ListaCompraController : ApiController
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
        public IHttpActionResult Get(int? idCliente = null, int? idListaCompra = null)
        {
            if (idCliente.HasValue)
            {
                var filtro = new Cliente() { Id = idCliente.Value };
                var resultado = ComercialFacade.ListarListaCompraPorCliente(filtro);
                if (resultado)
                {
                    var retornoJson = resultado.Retorno.Select(lic =>
                        ListaCompraToJson(lic)).ToArray();
                    return Ok(retornoJson);
                }
                else
                {
                    return BadRequest(resultado.ConsolidaMensagens("\n"));
                }
            }
            else if (idListaCompra.HasValue)
            {
                var filtro = new ListaCompra() { Id = idListaCompra.Value };
                var resultado = ComercialFacade.ConsultarListaCompra(filtro);
                if (resultado)
                {
                    var listaCompra = resultado.Retorno;
                    var retornoJson = ListaCompraToJson(listaCompra);
                    return Ok(retornoJson);
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
        public IHttpActionResult Put([FromBody] ListaCompra listaCompra)
        {
            if (listaCompra != null)
            {
                var resultado = ComercialFacade.IncluirListaCompra(listaCompra);
                if (resultado)
                {
                    var resultadoJson = ListaCompraToJson(resultado.Retorno);
                    return Ok(resultadoJson);
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

        [HttpPost]
        public IHttpActionResult Post([FromBody] ListaCompra listaCompra)
        {
            if (listaCompra != null)
            {
                var resultado = ComercialFacade.AlterarListaCompra(listaCompra);
                if (resultado)
                {
                    var resultadoJson = ListaCompraToJson(resultado.Retorno);
                    return Ok(resultadoJson);
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
                var listaCompra = new ListaCompra() { Id = id.Value };
                var resultado = ComercialFacade.ExcluirListaCompra(listaCompra);
                if (resultado)
                {
                    var resultadoJson = ListaCompraToJson(resultado.Retorno);
                    return Ok(resultadoJson);
                }
                else
                {
                    return BadRequest(resultado.ConsolidaMensagens("\n"));
                }
            }
            else
            {
                return BadRequest();
            };
        }

        [NonAction]
        private object ListaCompraToJson(ListaCompra listaCompra)
        {
            if (listaCompra == null)
                return null;
            else
                return new
                {
                    Id = listaCompra.Id,
                    Descricao = listaCompra.Descricao,
                    DataCriacao = listaCompra.DataCriacao,
                    DataUltimaConsulta = listaCompra.DataUltimaConsulta,
                    QuantidadeItem = listaCompra.QuantidadeItem
                };
        }
        #endregion Método(s)
    }
}
