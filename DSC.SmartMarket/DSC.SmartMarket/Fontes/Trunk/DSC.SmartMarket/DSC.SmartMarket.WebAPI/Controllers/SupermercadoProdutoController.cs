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
    public class SupermercadoProdutoController : ApiController
    {
        #region Propriedade(s)
        private IOperacionalFacade OperacionalFacade
        {
            get
            {
                return (IOperacionalFacade)this.Configuration.DependencyResolver.GetService(typeof(IOperacionalFacade));
            }
        }
        #endregion Propriedade(s)

        #region Método(s)
        [HttpGet]
        public IHttpActionResult Get(int? idMercado = null, int? idProduto = null)
        {
            if (idMercado.HasValue)
            {
                if (idProduto.HasValue)
                {
                    var supermercadoProduto = new SupermercadoProduto()
                    {
                        IdMercado = idMercado.Value,
                        IdProduto = idProduto.Value
                    };
                    var resultado = OperacionalFacade.ConsultarSupermercadoProduto(supermercadoProduto);
                    if (resultado)
                    {
                        supermercadoProduto = resultado.Retorno;
                        var retornoJson = SupermercadoProdutoToJson(supermercadoProduto);
                        return Ok(retornoJson);
                    }
                    else
                    {
                        return BadRequest(resultado.ConsolidaMensagens("\n"));
                    }
                }
                else
                {
                    var supermercado = new Supermercado()
                    {
                        Id = idMercado.Value
                    };
                    var resultado = OperacionalFacade.ListarSupermercadoProdutoPorSupermercado(supermercado);
                    if (resultado)
                    {
                        var retornoJson = resultado.Retorno.Select(sup =>
                            SupermercadoProdutoToJson(sup)).ToArray();
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
        public IHttpActionResult Put([FromBody] SupermercadoProduto supermercadoProduto)
        {
            if (supermercadoProduto != null)
            {
                var resultado = OperacionalFacade.IncluirSupermercadoProduto(supermercadoProduto);
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

        [HttpPost]
        public IHttpActionResult Post([FromBody] SupermercadoProduto supermercadoProduto)
        {
            if (supermercadoProduto != null)
            {
                var resultado = OperacionalFacade.AlterarSupermercadoProduto(supermercadoProduto);
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
        public IHttpActionResult Delete(int? idMercado = null, int? idProduto = null)
        {
            if (idMercado.HasValue && idProduto.HasValue)
            {
                var supermercadoProduto = new SupermercadoProduto()
                {
                    IdMercado = idMercado.Value,
                    IdProduto = idProduto.Value
                };
                var resultado = OperacionalFacade.ExcluirSupermercadoProduto(supermercadoProduto);
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

        [NonAction]
        private object SupermercadoProdutoToJson(SupermercadoProduto supermercadoProduto)
        {
            if (supermercadoProduto == null)
                return null;
            else
                return new
                {
                    IdMercado = supermercadoProduto.IdMercado,
                    IdProduto = supermercadoProduto.IdProduto,
                    QuantidadeEstoque = supermercadoProduto.QuantidadeEstoque,
                    ValorProduto = supermercadoProduto.ValorProduto,
                    Produto = new
                    {
                        Id = supermercadoProduto.Produto.Id,
                        Nome = supermercadoProduto.Produto.Nome,
                        PesoMaximo = supermercadoProduto.Produto.PesoMaximo,
                        PesoMedio = supermercadoProduto.Produto.PesoMedio,
                        PesoMinimo = supermercadoProduto.Produto.PesoMinimo
                    }
                };
        }
        #endregion Método(s)
    }
}
