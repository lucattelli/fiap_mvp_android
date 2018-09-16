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
    internal class ListaCompraItemProcess : ProcessBase, IListaCompraItemProcess
    {
        #region Propriedade(s)
        private IListaCompraValidation ListaCompraValidation
        {
            get
            {
                var resultado = Resolve<IListaCompraValidation>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IListaCompraValidation>(resultado);
            }
        }

        private IListaCompraItemValidation ListaCompraItemValidation
        {
            get
            {
                var resultado = Resolve<IListaCompraItemValidation>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IListaCompraItemValidation>(resultado);
            }
        }

        private IListaCompraItemRepository ListaCompraItemRepository
        {
            get
            {
                var resultado = Resolve<IListaCompraItemRepository>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IListaCompraItemRepository>(resultado);
            }
        }
        #endregion Propriedade(s)

        #region Método(s)
        public Resultado<IList<ListaCompraItem>> ListarPorListaCompra(ListaCompra listaCompra)
        {
            var resultado = new Resultado<IList<ListaCompraItem>>();
            try
            {
                resultado += ListaCompraValidation.Validate(listaCompra, ListaCompraOperation.Consultar);
                if (resultado)
                {
                    resultado = ListaCompraItemRepository.SelecionarPorListaCompra(listaCompra);
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ListaCompraItem> Consultar(ListaCompraItem listaCompraItem)
        {
            var resultado = new Resultado<ListaCompraItem>();
            try
            {
                resultado += ListaCompraItemValidation.Validate(listaCompraItem, ListaCompraItemOperation.Consultar);
                if (resultado)
                {
                    resultado = ListaCompraItemRepository.Selecionar(listaCompraItem);
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ListaCompraItem> Incluir(ListaCompraItem listaCompraItem)
        {
            var resultado = new Resultado<ListaCompraItem>();
            try
            {
                resultado += ListaCompraItemValidation.Validate(listaCompraItem, ListaCompraItemOperation.Incluir);
                if (resultado)
                {
                    resultado += ListaCompraItemRepository.Inserir(listaCompraItem);
                    if(resultado)
                    {
                        resultado = ListaCompraItemRepository.Selecionar(listaCompraItem);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ListaCompraItem> Alterar(ListaCompraItem listaCompraItem)
        {
            var resultado = new Resultado<ListaCompraItem>();
            try
            {
                resultado += ListaCompraItemValidation.Validate(listaCompraItem, ListaCompraItemOperation.Alterar);
                if (resultado)
                {
                    resultado += ListaCompraItemRepository.Atualizar(listaCompraItem);
                    if (resultado)
                    {
                        resultado = ListaCompraItemRepository.Selecionar(listaCompraItem);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ListaCompraItem> Excluir(ListaCompraItem listaCompraItem)
        {
            var resultado = new Resultado<ListaCompraItem>();
            try
            {
                resultado += ListaCompraItemValidation.Validate(listaCompraItem, ListaCompraItemOperation.Excluir);
                if (resultado)
                {
                    resultado += ListaCompraItemRepository.Atualizar(listaCompraItem);
                    if(resultado)
                    {
                        resultado = ListaCompraItemRepository.Selecionar(listaCompraItem);
                    }
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
