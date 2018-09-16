using DSC.SmartMarket.BusinessLogic;
using DSC.SmartMarket.Model;
using DSC.SmartMarket.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSC.SmartMarket.WebApp.Controllers
{
    public class SupermercadoController : Controller
    {
        #region Constante(s)
        private const int c_tamanhoPagina = 5;
        #endregion Constante(s)

        #region Propriedade(s)
        private IOperacionalFacade OperacionalFacade
        {
            get
            {
                return Resolver.GetService<IOperacionalFacade>();
            }
        }
        #endregion Propriedade(s)


        // GET: Supermercado
        public ActionResult Index(int? pagina)
        {
            var resultado = CarregarModel(pagina, IndexSupermercadoViewModel.TipoOperacao.Listar);
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
            var resultado = CarregarModel(pagina, IndexSupermercadoViewModel.TipoOperacao.Incluir);
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
        public ActionResult Editar(int id, int? pagina)
        {
            var resultado = CarregarModel(pagina, IndexSupermercadoViewModel.TipoOperacao.Editar);
            if (resultado.Sucesso)
            {
                var model = resultado.Retorno;
                var resultadoConsultar = OperacionalFacade.ConsultarSupermercado(new Supermercado() { Id = id });
                resultado += resultadoConsultar;
                if (resultadoConsultar.Sucesso)
                {
                    model.SupermercadoEditar = resultadoConsultar.Retorno;
                    return View("Index", model);
                }
            }


            return View("Index");
        }

        [HttpGet]
        public ActionResult Remover(int id, int? pagina)
        {
            var resultadoRemover = OperacionalFacade.ExcluirSupermercado(new Supermercado() { Id = id });
            if (resultadoRemover.Sucesso)
            {
                var resultado = CarregarModel(pagina, IndexSupermercadoViewModel.TipoOperacao.Listar);
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
        public ActionResult Salvar(IndexSupermercadoViewModel model)
        {
            var resultado = new Resultado(true);
            var supermercado = model.SupermercadoEditar;
            if (model.Operacao == IndexSupermercadoViewModel.TipoOperacao.Incluir)
            {
                resultado = OperacionalFacade.IncluirSupermercado(supermercado);
            }
            else
            {
                resultado = OperacionalFacade.AlterarSupermercado(supermercado);
            }

            IndexSupermercadoViewModel.TipoOperacao operacao;
            if (resultado.Sucesso)
            {
                operacao = IndexSupermercadoViewModel.TipoOperacao.Listar;
            }
            else
            {
                operacao = model.Operacao;
            }

            var resultadoCarregar = CarregarModel(model.Pagina, operacao);
            var newModel = resultadoCarregar.Retorno;
            if (!resultado.Sucesso)
            {
                ModelState.AddModelResultoErro(resultado, "SupermercadoEditar");
                newModel.SupermercadoEditar = model.SupermercadoEditar;
                newModel.IsValid = resultado.Sucesso;
                return View("Index", newModel);

            }
            else
            {
                return View("Index");
            }

        }

        [NonAction]
        private Resultado<IndexSupermercadoViewModel> CarregarModel(int? pagina, IndexSupermercadoViewModel.TipoOperacao operacao)
        {
            var resultado = new Resultado<IndexSupermercadoViewModel>(true);
            try
            {
                pagina = pagina ?? 1;
                var resultadoListar = OperacionalFacade.ListarTodosSupermercados(pagina.Value, c_tamanhoPagina);
                resultado += resultadoListar;
                if (resultado.Sucesso)
                {
                    var lista = resultadoListar.Retorno.Item1;
                    var total = resultadoListar.Retorno.Item2;
                    var totalPagina = (int)Math.Ceiling((float)total / c_tamanhoPagina);

                    var model = new IndexSupermercadoViewModel()
                    {
                        Pagina = pagina.Value,
                        TotalPagina = totalPagina,
                        ListaSupermercado = lista,
                        Operacao = operacao,
                        SupermercadoEditar = new Supermercado(),
                        TamanhoPagina = c_tamanhoPagina
                    };
                    resultado.Retorno = model;
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado<IndexSupermercadoViewModel>(ex);
            }
            return resultado;
        }
    }
}