using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSC.SmartMarket.BusinessLogic.IoC;
using DSC.SmartMarket.BusinessLogic.Repository;
using DSC.SmartMarket.BusinessLogic.Validation;
using DSC.SmartMarket.Model;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal class ProdutoProcess : ProcessBase, IProdutoProcess
    {
        #region Propriedade(s)
        private IProdutoValidation ProdutoValidation
        {
            get
            {
                var resultado = Resolve<IProdutoValidation>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IProdutoValidation>(resultado);
            }
        }

        private IProdutoRepository ProdutoRepository
        {
            get
            {
                var resultado = Resolve<IProdutoRepository>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IProdutoRepository>(resultado);
            }
        }
        #endregion Propriedade(s)

        #region Método(s)
        public Resultado<IList<Produto>> ListarTodos(int pagina, int tamanhoPagina, string orderBy)
        {
            var resultado = new Resultado<IList<Produto>>(false);
            try
            {
                int skip = (pagina - 1) * tamanhoPagina;
                int take = tamanhoPagina;
                resultado = ProdutoRepository.Selecionar(skip, take, orderBy);
            }
            catch (Exception ex)
            {
                resultado = new Resultado<IList<Produto>>(ex);
            }
            return resultado;
        }

        public Resultado<int> ContarTodos()
        {
            var resultado = new Resultado<int>(false);
            try
            {
                resultado = ProdutoRepository.Contar();
            }
            catch (Exception ex)
            {
                resultado = new Resultado<int>(ex);
            }
            return resultado;
        }

        public Resultado Incluir(Produto produto)
        {
            var resultado = new Resultado(false);
            try
            {
                resultado = ProdutoValidation.Validate(produto, ProdutoOperation.Incluir);
                if (resultado.Sucesso)
                {
                    resultado = ProdutoRepository.Inserir(produto);
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }

        public Resultado Alterar(Produto produto)
        {
            var resultado = new Resultado(false);
            try
            {
                resultado = ProdutoValidation.Validate(produto, ProdutoOperation.Alterar);
                if (resultado.Sucesso)
                {
                    var resultadoConsultar = ProdutoRepository.SelecionarPorId(produto);
                    if (resultadoConsultar.Sucesso)
                    {
                        var produtoAlterar = resultadoConsultar.Retorno;
                        produtoAlterar.Nome = produto.Nome;
                        produtoAlterar.PesoMaximo = produto.PesoMaximo;
                        produtoAlterar.PesoMedio = produto.PesoMedio;
                        produtoAlterar.PesoMinimo = produto.PesoMinimo;
                        resultado = ProdutoRepository.Atualizar(produtoAlterar);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }

        public Resultado Excluir(Produto produto)
        {
            var resultado = new Resultado(false);
            try
            {
                resultado = ProdutoValidation.Validate(produto, ProdutoOperation.Excluir);
                if (resultado.Sucesso)
                {
                    var resultadoConsultar = ProdutoRepository.SelecionarPorId(produto);
                    if (resultadoConsultar.Sucesso)
                    {
                        var produtoExcluir= resultadoConsultar.Retorno;
                        resultado = ProdutoRepository.Remover(produtoExcluir);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }

        public Resultado<Produto> ConsultarPorId(Produto produtoFiltro)
        {
            var resultado = new Resultado<Produto>(true);
            try
            {
                var resultadoValidar = ProdutoValidation.Validate(produtoFiltro, ProdutoOperation.Consultar);
                resultado += resultadoValidar;
                if (resultado.Sucesso)
                {
                    resultado = ProdutoRepository.SelecionarPorId(produtoFiltro);
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado<Produto>(ex);
            }
            return resultado;
        }
        #endregion Método(s)

    }
}