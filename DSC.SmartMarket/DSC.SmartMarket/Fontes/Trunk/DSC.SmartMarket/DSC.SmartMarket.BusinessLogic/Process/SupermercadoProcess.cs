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
    internal class SupermercadoProcess : ProcessBase, ISupermercadoProcess
    {
        #region Propriedade(s)
        private ISupermercadoRepository SupermercadoRepository
        {
            get
            {
                var resultado = Resolve<ISupermercadoRepository>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return null;
            }
        }

        private ISupermercadoValidation SupermercadoValidation
        {
            get
            {
                var resultado = Resolve<ISupermercadoValidation>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return null;
            }
        }

        public Resultado Alterar(Supermercado supermercado)
        {
            var resultado = new Resultado(true);
            try
            {
                resultado = SupermercadoValidation.Validate(supermercado, SupermercadoOperation.Alterar);
                if (resultado.Sucesso)
                {
                    var resultadoConsultar = SupermercadoRepository.Selecionar(supermercado);
                    if (resultadoConsultar.Sucesso)
                    {
                        var produtoAlterar = resultadoConsultar.Retorno;
                        produtoAlterar.Nome = supermercado.Nome;
                        resultado = SupermercadoRepository.Atualizar(produtoAlterar);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }

        public Resultado<Supermercado> Consultar(Supermercado supermercado)
        {
            var resultado = new Resultado<Supermercado>(true);
            try
            {
                var resultadoValidar = SupermercadoValidation.Validate(supermercado, SupermercadoOperation.Consultar);
                resultado += resultadoValidar;
                if (resultado.Sucesso)
                {
                    resultado = SupermercadoRepository.Selecionar(supermercado);
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado<Supermercado>(ex);
            }
            return resultado;
        }

        public Resultado<int> ContarTodos()
        {
            var resultado = new Resultado<int>(true);
            try
            {
                resultado = SupermercadoRepository.Contar();
            }
            catch (Exception ex)
            {
                resultado = new Resultado<int>(ex);
            }
            return resultado;
        }

        public Resultado Incluir(Supermercado supermercado)
        {
            var resultado = new Resultado(true);
            try
            {
                resultado = SupermercadoValidation.Validate(supermercado, SupermercadoOperation.Incluir);
                if (resultado.Sucesso)
                {
                    resultado = SupermercadoRepository.Inserir(supermercado);
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }

        public Resultado<IList<Supermercado>> ListarTodos(int pagina, int tamanhoPagina, string orderBy)
        {
            var resultado = new Resultado<IList<Supermercado>>(false);
            try
            {
                int skip = (pagina - 1) * tamanhoPagina;
                int take = tamanhoPagina;
                resultado = SupermercadoRepository.Selecionar(skip, take, orderBy);
            }
            catch (Exception ex)
            {
                resultado = new Resultado<IList<Supermercado>>(ex);
            }
            return resultado;
        }

        public Resultado Excluir(Supermercado supermercado)
        {
            var resultado = new Resultado(false);
            try
            {
                resultado = SupermercadoValidation.Validate(supermercado, SupermercadoOperation.Excluir);
                if (resultado.Sucesso)
                {
                    var resultadoConsultar = SupermercadoRepository.Selecionar(supermercado);
                    if (resultadoConsultar.Sucesso)
                    {
                        var supermercadoExcluir = resultadoConsultar.Retorno;
                        resultado = SupermercadoRepository.Remover(supermercadoExcluir);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }
        #endregion Propriedade(s)
    }
}
