using DSC.SmartMarket.BusinessLogic.Repository;
using DSC.SmartMarket.BusinessLogic.Validation;
using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal class SupermercadoProdutoProcess : ProcessBase, ISupermercadoProdutoProcess
    {
        #region Propriedade(s)
        private ISupermercadoProdutoValidation SupermercadoProdutoValidation
        {
            get
            {
                var resultado = Resolve<ISupermercadoProdutoValidation>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<ISupermercadoProdutoValidation>(resultado);
            }
        }

        private ISupermercadoValidation SupermercadoValidation
        {
            get
            {
                var resultado = Resolve<ISupermercadoValidation>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<ISupermercadoValidation>(resultado);
            }
        }

        private ISupermercadoProdutoRepository SupermercadoProdutoRepository
        {
            get
            {
                var resultado = Resolve<ISupermercadoProdutoRepository>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<ISupermercadoProdutoRepository>(resultado);
            }
        }
        #endregion Propriedade(s)

        #region Método(s)
        public Resultado Incluir(SupermercadoProduto supermercadoProduto)
        {
            var resultado = new Resultado();
            try
            {
                resultado += SupermercadoProdutoValidation.Validate(supermercadoProduto, SupermercadoProdutoOperation.Incluir);
                if (resultado)
                {
                    resultado = SupermercadoProdutoRepository.Inserir(supermercadoProduto);
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado Alterar(SupermercadoProduto supermercadoProduto)
        {
            var resultado = new Resultado();
            try
            {
                resultado += SupermercadoProdutoValidation.Validate(supermercadoProduto, SupermercadoProdutoOperation.Alterar);
                if (resultado)
                {
                    resultado = SupermercadoProdutoRepository.Atualizar(supermercadoProduto);
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado Excluir(SupermercadoProduto supermercadoProduto)
        {
            var resultado = new Resultado();
            try
            {
                resultado += SupermercadoProdutoValidation.Validate(supermercadoProduto, SupermercadoProdutoOperation.Excluir);
                if (resultado)
                {
                    resultado = SupermercadoProdutoRepository.Remover(supermercadoProduto);
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<SupermercadoProduto> Consultar(SupermercadoProduto supermercadoProduto)
        {
            var resultado = new Resultado<SupermercadoProduto>();
            try
            {
                resultado += SupermercadoProdutoValidation.Validate(supermercadoProduto, SupermercadoProdutoOperation.Consultar);
                if (resultado)
                {
                    resultado = SupermercadoProdutoRepository.Selecionar(supermercadoProduto);
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<IList<SupermercadoProduto>> ListarPorSupermercado(Supermercado supermercado)
        {
            var resultado = new Resultado<IList<SupermercadoProduto>>();
            try
            {
                resultado += SupermercadoValidation.Validate(supermercado, SupermercadoOperation.Consultar);
                if (resultado)
                {
                    resultado = SupermercadoProdutoRepository.SelecionarPorSupermercado(supermercado);
                }
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
