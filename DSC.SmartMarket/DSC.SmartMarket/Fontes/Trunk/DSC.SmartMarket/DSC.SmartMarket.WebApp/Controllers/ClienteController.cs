using DSC.SmartMarket.BusinessLogic;
using DSC.SmartMarket.BusinessLogic.Common;
using DSC.SmartMarket.Model;
using DSC.SmartMarket.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSC.SmartMarket.WebApp.Controllers
{
    public class ClienteController : Controller
    {
        #region Constante(s)
        private const int c_tamanhoPagina = 5;
        #endregion Constante(s)

        #region Propriedade(s)
        private IComercialFacade ComercialFacade
        {
            get
            {
                return Resolver.GetService<IComercialFacade>();
            }
        }
        #endregion Propriedade(s)

        #region Método(s)
        [HttpGet]
        public ActionResult Index(int? pagina)
        {
            var resultado = CarregarModel(pagina, IndexClienteViewModel.TipoOperacao.Listar);
            if (resultado.Sucesso)
            {
                return View(resultado.Retorno);
            }
            else
            {
                //Todo: Tratar exceções com página especializada.
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Inserir(int? pagina)
        {
            var resultado = CarregarModel(pagina, IndexClienteViewModel.TipoOperacao.Incluir);
            if (resultado.Sucesso)
            {
                return View("Index", resultado.Retorno);
            }
            else
            {
                //Todo: Tratar exceções com página especializada.
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Alterar(int ClienteId, int? pagina)
        {
            var resultado = CarregarModel(pagina, IndexClienteViewModel.TipoOperacao.Alterar);
            if (resultado.Sucesso)
            {
                var model = resultado.Retorno;
                var resultadoConsultar = ComercialFacade.ConsultarCliente(new Cliente() { Id = ClienteId });
                resultado += resultadoConsultar;
                if (resultadoConsultar.Sucesso)
                {
                    model.ClienteAlterar = resultadoConsultar.Retorno;
                    return View("Index", model);
                }
            }

            //Todo: Tratar exceções com página especializada.
            return View("Index");
        }

        [HttpGet]
        public ActionResult Excluir(int ClienteId, int? pagina)
        {
            var resultadoRemover = ComercialFacade.ExcluirCliente(new Cliente() { Id = ClienteId });
            if (resultadoRemover.Sucesso)
            {
                var resultado = CarregarModel(pagina, IndexClienteViewModel.TipoOperacao.Listar);
                if (resultado.Sucesso)
                {
                    var model = resultado.Retorno;
                    return View("Index", model);
                }
            }
            //Todo: Tratar exceções com página especializada.
            return View("Index");
        }

        [HttpPost]
        public ActionResult Salvar(IndexClienteViewModel model)
        {
            var resultado = new Resultado(true);
            var cliente = model.ClienteAlterar;
            cliente.CPF = Formata.RemoveFormatoCPF(cliente.CPF);
            cliente.RG = Formata.RemoveFormatoCPF(cliente.RG);
            cliente.Telefone = Formata.RemoveFormatoTelefone(cliente.Telefone);

            if (model.Operacao == IndexClienteViewModel.TipoOperacao.Incluir)
            {
                resultado = ComercialFacade.IncluirCliente(cliente);
            }
            else
            {
                resultado = ComercialFacade.AlterarCliente(cliente);
            }

            IndexClienteViewModel.TipoOperacao operacao;
            if (resultado.Sucesso)
            {
                operacao = IndexClienteViewModel.TipoOperacao.Listar;
            }
            else
            {
                operacao = model.Operacao;
            }

            var resultadoCarregar = CarregarModel(model.Pagina, operacao);
            var newModel = resultadoCarregar.Retorno;
            if (!resultado.Sucesso)
            {
                ModelState.AddModelResultoErro(resultado, "ClienteAlterar");
                newModel.ClienteAlterar = model.ClienteAlterar;
                newModel.IsValid = resultado.Sucesso;
                return View("Index", newModel);

            }
            else
            {
                return View("Index");
            }

        }

        [NonAction]
        private Resultado<IndexClienteViewModel> CarregarModel(int? pagina, IndexClienteViewModel.TipoOperacao operacao)
        {
            var resultado = new Resultado<IndexClienteViewModel>(true);
            try
            {
                pagina = pagina ?? 1;
                var resultadoListar = ComercialFacade.ListarTodosCliente(pagina.Value, c_tamanhoPagina);
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
        #endregion Método(s)
    }
}