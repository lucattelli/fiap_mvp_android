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
    public class ListaCompraItemController : ApiController
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
        public IHttpActionResult Get(int? idListaCompra = null, int? idProduto = null)
        {
            if (idListaCompra.HasValue)
            {
                if (idProduto.HasValue)
                {
                    var filtro = new ListaCompraItem()
                    {
                        IdListaCompra = idListaCompra.Value,
                        IdProduto = idProduto.Value
                    };
                    var resultado = ComercialFacade.ConsultarListaCompraItem(filtro);
                    if (resultado)
                    {
                        var listaCompraItem = resultado.Retorno;
                        var retornoJson = ListaCompraItemToJson(listaCompraItem);
                        return Ok(retornoJson);
                    }
                    else
                    {
                        return BadRequest(resultado.ConsolidaMensagens("\n"));
                    }
                }
                else
                {
                    var filtro = new ListaCompra()
                    {
                        Id = idListaCompra.Value
                    };
                    var resultado = ComercialFacade.ListarListaCompraItemPorListaCompra(filtro);
                    if (resultado)
                    {
                        var retornoJson = resultado.Retorno.Select(lci =>
                            ListaCompraItemToJson(lci)).ToArray();
                        return Ok(retornoJson);
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

        [HttpPut]
        public IHttpActionResult Put([FromBody] ListaCompraItem listaCompraItem)
        {
            if (listaCompraItem != null)
            {
                var resultado = ComercialFacade.IncluirListaCompraItem(listaCompraItem);
                if (resultado)
                {
                    var resultadoJson = ListaCompraItemToJson(resultado.Retorno);
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
        public IHttpActionResult Post([FromBody] ListaCompraItem listaCompraItem)
        {
            if (listaCompraItem != null)
            {
                var resultado = ComercialFacade.AlterarListaCompraItem(listaCompraItem);
                if (resultado)
                {
                    var resultadoJson = ListaCompraItemToJson(resultado.Retorno);
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
        public IHttpActionResult Delete(int? idListaCompra = null, int? idProduto = null)
        {
            if (idListaCompra.HasValue && idProduto.HasValue)
            {
                var listaCompraItem = new ListaCompraItem()
                {
                    IdListaCompra = idListaCompra.Value,
                    IdProduto = idProduto.Value
                };
                var resultado = ComercialFacade.AlterarListaCompraItem(listaCompraItem);
                if (resultado)
                {
                    var resultadoJson = ListaCompraItemToJson(resultado.Retorno);
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

        [NonAction]
        private object ListaCompraItemToJson(ListaCompraItem listaCompraItem)
        {
            if (listaCompraItem == null)
                return null;
            else
                return new
                {
                    IdListaCompra = listaCompraItem.IdListaCompra,
                    IdProduto = listaCompraItem.IdProduto,
                    Quantidade = listaCompraItem.Quantidade,
                    Produto = new
                    {
                        Id = listaCompraItem.Produto.Id,
                        Nome = listaCompraItem.Produto.Nome 
                    }
                };
        }
        #endregion Método(s)
    }
}
