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
    public class ProdutoController : Controller
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

        // GET: Produto
        [HttpGet]
        public ActionResult Index(int? pagina)
        {
            var resultado = CarregarModel(pagina, IndexProdutoViewModel.TipoOperacao.Listar);
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
            var resultado = CarregarModel(pagina, IndexProdutoViewModel.TipoOperacao.Inserir);
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
            var resultado = CarregarModel(pagina, IndexProdutoViewModel.TipoOperacao.Editar);
            if (resultado.Sucesso)
            {
                var model = resultado.Retorno;
                var resultadoConsultar = OperacionalFacade.ConsultarProduto(new Produto() { Id = id });
                resultado += resultadoConsultar;
                if (resultadoConsultar.Sucesso)
                {
                    model.ProdutoEditar = resultadoConsultar.Retorno;
                    return View("Index", model);
                }
            }

            
            return View("Index");
        }

        [HttpGet]
        public ActionResult Remover(int id, int? pagina)
        {
            var resultadoRemover = OperacionalFacade.ExcluirProduto(new Produto() { Id = id });
            if (resultadoRemover.Sucesso)
            {
                var resultado = CarregarModel(pagina, IndexProdutoViewModel.TipoOperacao.Listar);
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
        public ActionResult Salvar(IndexProdutoViewModel model)
        {
            var resultado = new Resultado(true);
            var produto = model.ProdutoEditar;
            if (model.Operacao == IndexProdutoViewModel.TipoOperacao.Inserir)
            {
                resultado = OperacionalFacade.IncluirProduto(produto);
            }
            else
            {
                resultado = OperacionalFacade.AlterarProduto(produto);
            }


            IndexProdutoViewModel.TipoOperacao operacao;
            if (resultado.Sucesso)
            {
                operacao = IndexProdutoViewModel.TipoOperacao.Listar;
            }
            else
            {
                operacao = model.Operacao;
            }

            var resultadoCarregar = CarregarModel(model.Pagina, operacao);
            var newModel = resultadoCarregar.Retorno;
            if (!resultado.Sucesso)
            {
                ModelState.AddModelResultoErro(resultado, "ProdutoEditar");
                newModel.ProdutoEditar = model.ProdutoEditar;
                newModel.IsValid = resultado.Sucesso;
                return View("Index", newModel);
            }
            else
            {
                return View("Index");
            }
        }

        [NonAction]
        private Resultado<IndexProdutoViewModel> CarregarModel(int? pagina, IndexProdutoViewModel.TipoOperacao operacao)
        {
            var resultado = new Resultado<IndexProdutoViewModel>(true);
            try
            {
                pagina = pagina ?? 1;
                var resultadoListar = OperacionalFacade.ListarTodosProduto(pagina.Value, c_tamanhoPagina);
                resultado += resultadoListar;
                if (resultado.Sucesso)
                {
                    var lista = resultadoListar.Retorno.Item1;
                    var total = resultadoListar.Retorno.Item2;
                    var totalPagina = (int)Math.Ceiling((float)total / c_tamanhoPagina);

                    var model = new IndexProdutoViewModel()
                    {
                        Pagina = pagina.Value,
                        TotalPagina = totalPagina,
                        ListaProduto = lista,
                        Operacao = operacao,
                        ProdutoEditar = new Produto(),
                        TamanhoPagina = c_tamanhoPagina
                    };
                    resultado.Retorno = model;
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado<IndexProdutoViewModel>(ex);
            }
            return resultado;
        }
    }
}