using System;
using System.Linq;
using System.Web.Http;
using DSC.SmartMarket.BusinessLogic;
using DSC.SmartMarket.Model;

namespace DSC.SmartMarket.WebAPI
{
    public class ProdutoController : ApiController
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
        public IHttpActionResult Get(int? id = null)
        {
            if (id.HasValue)
            {
                var produto = new Produto() { Id = id.Value };
                var resultado = OperacionalFacade.ConsultarProduto(produto);
                if (resultado)
                {
                    return Ok(resultado.Retorno);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                var resultado = OperacionalFacade.ListarTodosProduto();
                if (resultado)
                {
                    var lista = resultado.Retorno.Item1;
                    if (lista.Any())
                        return Ok(lista);
                    else
                        return NotFound();
                }
                else
                {
                    return BadRequest(resultado.ConsolidaMensagens("\n"));
                }
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Produto produto)
        {
            if (produto != null)
            {
                var resultado = OperacionalFacade.IncluirProduto(produto);
                if (resultado)
                {
                    var location = Url.Link("DefaultApi", new { controller = "Produto", id = produto.Id });
                    return Created(new Uri(location), produto);
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
        public IHttpActionResult Put([FromBody] Produto produto)
        {
            if (produto != null)
            {
                var resultado = OperacionalFacade.AlterarProduto(produto);
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
                var produto = new Produto() { Id = id.Value };
                var resultado = OperacionalFacade.ExcluirProduto(produto);
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