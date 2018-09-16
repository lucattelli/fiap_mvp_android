using DSC.SmartMarket.BusinessLogic.Process;
using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic
{
    public class OperacionalFacade : FacadeBase, IOperacionalFacade
    {
        #region Propriedade(s)
        private IProdutoProcess ProdutoProcess
        {
            get
            {
                var resultado = Resolve<IProdutoProcess>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IProdutoProcess>(resultado);
            }
        }

        private IClienteProcess ClienteProcess
        {
            get
            {
                var resultado = Resolve<IClienteProcess>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IClienteProcess>(resultado);
            }
        }

        private ISupermercadoProcess SupermercadoProcess
        {
            get
            {
                var resultado = Resolve<ISupermercadoProcess>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<ISupermercadoProcess>(resultado);
            }
        }

        private ISupermercadoProdutoProcess SupermercadoProdutoProcess
        {
            get
            {
                var resultado = Resolve<ISupermercadoProdutoProcess>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<ISupermercadoProdutoProcess>(resultado);
            }
        }
        #endregion Propriedade(s)

        #region Método(s)

        public Resultado IncluirProduto(Produto produto)
        {
            var resultado = new Resultado(false);
            try
            {
                resultado = ProdutoProcess.Incluir(produto);
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }

        public Resultado AlterarProduto(Produto produto)
        {
            var resultado = new Resultado(false);
            try
            {
                resultado = ProdutoProcess.Alterar(produto);
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }

        public Resultado ExcluirProduto(Produto produto)
        {
            var resultado = new Resultado(false);
            try
            {
                resultado = ProdutoProcess.Excluir(produto);
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }

        public Resultado<Produto> ConsultarProduto(Produto produtoFiltro)
        {
            var resultado = new Resultado<Produto>(true);
            try
            {
                resultado = ProdutoProcess.ConsultarPorId(produtoFiltro);
            }
            catch (Exception ex)
            {
                resultado = new Resultado<Produto>(ex);
            }
            return resultado;
        }

        public Resultado<Tuple<IList<Produto>, int>> ListarTodosProduto(int pagina = 1, int tamanhoPagina = int.MaxValue, string orderBy = null)
        {
            var resultado = new Resultado<Tuple<IList<Produto>, int>>(true);
            try
            {
                var resultadoContar = ProdutoProcess.ContarTodos();
                resultado += resultadoContar;
                if (resultado.Sucesso)
                {
                    int total = resultadoContar.Retorno;
                    var resultadoListar = ProdutoProcess.ListarTodos(pagina, tamanhoPagina, orderBy);
                    resultado += resultadoListar;
                    if (resultadoListar.Sucesso)
                    {
                        var lista = resultadoListar.Retorno;
                        resultado.Retorno = new Tuple<IList<Produto>, int>(lista, total);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado<Tuple<IList<Produto>, int>>(ex);
            }
            return resultado;
        }

        public Resultado IncluirSupermercado(Supermercado supermercado)
        {
            var resultado = new Resultado(false);
            try
            {
                resultado = SupermercadoProcess.Incluir(supermercado);
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }

        public Resultado AlterarSupermercado(Supermercado supermercado)
        {
            var resultado = new Resultado(false);
            try
            {
                resultado = SupermercadoProcess.Alterar(supermercado);
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }

        public Resultado ExcluirSupermercado(Supermercado supermercado)
        {
            var resultado = new Resultado(false);
            try
            {
                resultado = SupermercadoProcess.Excluir(supermercado);
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }

        public Resultado<Supermercado> ConsultarSupermercado(Supermercado supermercadoFiltro)
        {
            var resultado = new Resultado<Supermercado>(true);
            try
            {
                resultado = SupermercadoProcess.Consultar(supermercadoFiltro);
            }
            catch (Exception ex)
            {
                resultado = new Resultado<Supermercado>(ex);
            }
            return resultado;
        }

        public Resultado<Tuple<IList<Supermercado>, int>> ListarTodosSupermercados(int pagina = 1, int tamanhoPagina = int.MaxValue, string orderBy = null)
        {
            var resultado = new Resultado<Tuple<IList<Supermercado>, int>>(true);
            try
            {
                var resultadoContar = SupermercadoProcess.ContarTodos();
                resultado += resultadoContar;
                if (resultado.Sucesso)
                {
                    int total = resultadoContar.Retorno;
                    var resultadoListar = SupermercadoProcess.ListarTodos(pagina, tamanhoPagina, orderBy);
                    resultado += resultadoListar;
                    if (resultadoListar.Sucesso)
                    {
                        var lista = resultadoListar.Retorno;
                        resultado.Retorno = new Tuple<IList<Supermercado>, int>(lista, total);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado<Tuple<IList<Supermercado>, int>>(ex);
            }
            return resultado;
        }

        public Resultado<IList<SupermercadoProduto>> ListarSupermercadoProdutoPorSupermercado(Supermercado supermercado)
        {
            var resultado = new Resultado<IList<SupermercadoProduto>>();
            try
            {
                resultado = SupermercadoProdutoProcess.ListarPorSupermercado(supermercado);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<SupermercadoProduto> ConsultarSupermercadoProduto(SupermercadoProduto supermercadoProduto)
        {
            var resultado = new Resultado<SupermercadoProduto>();
            try
            {
                resultado = SupermercadoProdutoProcess.Consultar(supermercadoProduto);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado IncluirSupermercadoProduto(SupermercadoProduto supermercadoProduto)
        {
            var resultado = new Resultado();
            try
            {
                resultado = SupermercadoProdutoProcess.Incluir(supermercadoProduto);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado AlterarSupermercadoProduto(SupermercadoProduto supermercadoProduto)
        {
            var resultado = new Resultado();
            try
            {
                resultado = SupermercadoProdutoProcess.Alterar(supermercadoProduto);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado ExcluirSupermercadoProduto(SupermercadoProduto supermercadoProduto)
        {
            var resultado = new Resultado();
            try
            {
                resultado = SupermercadoProdutoProcess.Excluir(supermercadoProduto);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }
        #endregion Método(s)
    }
}