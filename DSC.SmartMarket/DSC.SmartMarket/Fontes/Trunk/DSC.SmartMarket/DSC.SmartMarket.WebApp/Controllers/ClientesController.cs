using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DSC.SmartMarket.BusinessLogic;
using DSC.SmartMarket.BusinessLogic.Common;
using DSC.SmartMarket.Model;
using DSC.SmartMarket.WebApp.Models;

namespace DSC.SmartMarket.WebApp.Controllers
{
    public class ClientesController : ApiController
    {

        #region Constante(s)
        private const int c_tamanhoPagina = 1000;
        #endregion Constante(s)

        #region Propriedade(s)
        private IOperacionalFacade OperacionalFacade
        {
            get
            {
                // return (IOperacionalFacade) this.Configuration.DependencyResolver.GetService(typeof(IOperacionalFacade));
                return new OperacionalFacade();
            }
        }
        #endregion Propriedade(s)

        public IHttpActionResult Get()
        {
            var resultado = CarregarModel(null, IndexClienteViewModel.TipoOperacao.Listar);
            if (resultado.Sucesso)
            {
                return Ok(new { entries = resultado.Retorno.ListaCliente });
            }
            else
            {
                return Ok();
            }
        }

        public IHttpActionResult Get(int id)
        {
            if (id == 0)
            {
                return BadRequest("ID is mandatory");
            }
            var resultadoSelecionar = OperacionalFacade.ConsultarCliente(new Cliente() { Id = id });
            if (resultadoSelecionar.Sucesso)
            {
                return Ok(resultadoSelecionar.Retorno);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Post([FromBody] Cliente c)
        {
            if (c == null)
            {
                return BadRequest("Invalid Cliente");
            }
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = new Resultado(true);
            c.Id = 0;
            c.CPF = Formata.RemoveFormatoCPF(c.CPF);
            c.RG = Formata.RemoveFormatoCPF(c.RG);
            c.Telefone = Formata.RemoveFormatoTelefone(c.Telefone);
            resultado = OperacionalFacade.IncluirCliente(c);
            if (resultado.Sucesso)
            {
                var location = Url.Link("DefaultApi", new { controller = "Clientes", id = c.Id });
                return Created(new Uri(location), c);
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put([FromBody] Cliente c)
        {
            if (c == null)
            {
                return BadRequest("Invalid Cliente");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = new Resultado(true);
            c.CPF = Formata.RemoveFormatoCPF(c.CPF);
            c.RG = Formata.RemoveFormatoCPF(c.RG);
            c.Telefone = Formata.RemoveFormatoTelefone(c.Telefone);
            resultado = OperacionalFacade.AlterarCliente(c);
            if (resultado.Sucesso)
            {
                return Ok(c);
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("ID is mandatory");
            }
            var resultadoRemover = OperacionalFacade.ExcluirCliente(new Cliente() { Id = id });
            if (!resultadoRemover.Sucesso)
            {
                return BadRequest();
            }
            var resultado = CarregarModel(null, IndexClienteViewModel.TipoOperacao.Listar);
            if (!resultado.Sucesso)
            {
                return BadRequest();
            }
            return Ok();
        }

        private Resultado<IndexClienteViewModel> CarregarModel(int? pagina, IndexClienteViewModel.TipoOperacao operacao)
        {
            var resultado = new Resultado<IndexClienteViewModel>(true);
            try
            {
                pagina = pagina ?? 1;
                var resultadoListar = OperacionalFacade.ListarTodosClientes(pagina.Value, c_tamanhoPagina);
                resultado += resultadoListar;
                if (resultado.Sucesso)
                {
                    var lista = resultadoListar.Retorno.Item1;
                    var total = resultadoListar.Retorno.Item2;
                    var totalPagina = (int)Math.Ceiling((float)total / c_tamanhoPagina);

                    var model = new IndexClienteViewModel()
                    {
                        Pagina = pagina.Value,
                        TotalPagina = totalPagina,
                        ListaCliente = lista,
                        Operacao = operacao,
                        ClienteAlterar = new Cliente(),
                        TamanhoPagina = c_tamanhoPagina
                    };
                    resultado.Retorno = model;
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado<IndexClienteViewModel>(ex);
            }
            return resultado;
        }
    }
}