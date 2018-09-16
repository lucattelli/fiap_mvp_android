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
    public class ConsultaListaCompraItemController : ApiController
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
        public IHttpActionResult Get(int? idListaCompra = null, int? idMercado = null, DateTime? dataCriacao = null, int? idProduto = null)
        {
            if (idListaCompra.HasValue && idMercado.HasValue && dataCriacao.HasValue)
            {
                if (idProduto.HasValue)
                {
                    var consultaListaCompraItem = new ConsultaListaCompraItem()
                    {
                        IdListaCompra = idListaCompra.Value,
                        IdMercado = idMercado.Value,
                        DataCriacao = dataCriacao.Value,
                        IdProduto = idProduto.Value
                    };
                    var resultado = ComercialFacade.ConsultarConsultaListaCompraItem(consultaListaCompraItem);
                    if (resultado)
                    {
                        consultaListaCompraItem = resultado.Retorno;
                        var resultadoJson = ConsultaListaCompraItemToJson(consultaListaCompraItem);
                        return Ok(resultadoJson);
                    }
                    else
                    {
                        return BadRequest(resultado.ConsolidaMensagens("\n"));
                    }
                }
                else
                {
                    var consultaListaCompra = new ConsultaListaCompra()
                    {
                        IdListaCompra = idListaCompra.Value,
                        IdMercado = idMercado.Value,
                        DataCriacao = dataCriacao.Value
                    };
                    var resultado = ComercialFacade.ListarConsultaListaCompraItemPorConsultaListaCompra(consultaListaCompra);
                    if (resultado)
                    {
                        var resultadoJson = resultado.Retorno.Select(clci =>
                            ConsultaListaCompraItemToJson(clci)).ToArray();
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
        private object ConsultaListaCompraItemToJson(ConsultaListaCompraItem consultaListaCompraItem)
        {
            if (consultaListaCompraItem == null)
                return null;
            else
                return new
                {
                    IdListaCompra = consultaListaCompraItem.IdListaCompra,
                    IdMercado = consultaListaCompraItem.IdMercado,
                    DataCriacao = consultaListaCompraItem.DataCriacao,
                    IdProduto = consultaListaCompraItem.IdProduto,
                    ValorProduto = consultaListaCompraItem.ValorProduto,
                    Quantidade = consultaListaCompraItem.Quantidade,
                    Disponivel = consultaListaCompraItem.Disponivel,
                    ListaCompraItem = new
                    {
                        IdListaCompra = consultaListaCompraItem.ListaCompraItem.IdListaCompra,
                        IdProduto = consultaListaCompraItem.ListaCompraItem.IdProduto,
                        Quantidade = consultaListaCompraItem.ListaCompraItem.Quantidade
                    }
                };
        }
        #endregion Método(s)
    }
}
