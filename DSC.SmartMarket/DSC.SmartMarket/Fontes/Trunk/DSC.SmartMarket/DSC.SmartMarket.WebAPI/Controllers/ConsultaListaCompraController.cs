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
    public class ConsultaListaCompraController : ApiController
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
        public IHttpActionResult Get(int? idListaCompra = null, int? idMercado = null, DateTime? dataCriacao = null)
        {
            if (idListaCompra.HasValue)
            {
                if (idMercado.HasValue && dataCriacao.HasValue)
                {
                    var consultaListaCompra = new ConsultaListaCompra()
                    {
                        IdListaCompra = idListaCompra.Value,
                        IdMercado = idMercado.Value,
                        DataCriacao = dataCriacao.Value
                    };
                    var resultado = ComercialFacade.ConsultarConsultaListaCompra(consultaListaCompra);
                    if (resultado)
                    {
                        consultaListaCompra = resultado.Retorno;
                        var resultadoJson = ConsultaListaCompraToJson(consultaListaCompra);
                        return Ok(resultadoJson);
                    }
                    else
                    {
                        return BadRequest(resultado.ConsolidaMensagens("\n"));
                    }
                }
                else
                {
                    var listaCompra = new ListaCompra() { Id = idListaCompra.Value };
                    var resultado = ComercialFacade.ListarConsultaListaCompraPorListaCompra(listaCompra);
                    if (resultado)
                    {
                        var resultadoJson = resultado.Retorno.Select(clc =>
                            ConsultaListaCompraToJson(clc)).ToArray();
                        return Ok(resultadoJson);
                    }
                    else
                    {
                        return BadRequest(resultado.ConsolidaMensagens("\n"));
                    }
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [NonAction]
        private object ConsultaListaCompraToJson(ConsultaListaCompra consultaListaCompra)
        {
            if (consultaListaCompra == null)
                return consultaListaCompra;
            else
                return new
                {
                    IdListaCompra = consultaListaCompra.IdListaCompra,
                    IdMercado = consultaListaCompra.IdMercado,
                    DataCriacao = consultaListaCompra.DataCriacao,
                    ValorTotal = consultaListaCompra.ValorTotal,
                    ListaCompra = new
                    {
                        Id = consultaListaCompra.ListaCompra.Id,
                        Descricao = consultaListaCompra.ListaCompra.Descricao,
                        DataUltimaConsulta = consultaListaCompra.ListaCompra.DataUltimaConsulta,
                        QuantidadeItem = consultaListaCompra.ListaCompra.QuantidadeItem
                    }
                };
        }
        #endregion Método(s)
    }
}
