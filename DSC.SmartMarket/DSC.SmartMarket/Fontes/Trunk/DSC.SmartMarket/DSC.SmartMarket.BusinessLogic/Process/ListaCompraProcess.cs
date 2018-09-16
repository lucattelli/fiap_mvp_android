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
    internal class ListaCompraProcess : ProcessBase, IListaCompraProcess
    {
        #region Propriedade(s)
        private IClienteValidation ClienteValidation
        {
            get
            {
                var resultado = Resolve<IClienteValidation>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IClienteValidation>(resultado);
            }
        }

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

        private IListaCompraRepository ListaCompraRepository
        {
            get
            {
                var resultado = Resolve<IListaCompraRepository>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IListaCompraRepository>(resultado);
            }
        }
        #endregion Propriedade(s)

        #region Método(s)
        public Resultado<IList<ListaCompra>> ListarPorCliente(Cliente cliente)
        {
            var resultado = new Resultado<IList<ListaCompra>>();
            try
            {
                var resultadoValidation = ClienteValidation.Validate(cliente, ClienteOperation.Consultar);
                resultado += resultadoValidation;
                if (resultado)
                {
                    resultado = ListaCompraRepository.SelecionarPorCliente(cliente);
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ListaCompra> Consultar(ListaCompra listaCompra)
        {
            var resultado = new Resultado<ListaCompra>();
            try
            {
                var resultadoValidation = ListaCompraValidation.Validate(listaCompra, ListaCompraOperation.Consultar);
                resultado += resultadoValidation;
                if (resultado)
                {
                    resultado = ListaCompraRepository.Selecionar(listaCompra);
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ListaCompra> Incluir(ListaCompra listaCompra)
        {
            var resultado = new Resultado<ListaCompra>();
            try
            {
                var resultadoValidation = ListaCompraValidation.Validate(listaCompra, ListaCompraOperation.Incluir);
                resultado += resultadoValidation;
                if (resultado)
                {
                    resultado += ListaCompraRepository.Inserir(listaCompra);
                    if (resultado)
                    {
                        resultado = ListaCompraRepository.Selecionar(listaCompra);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ListaCompra> Alterar(ListaCompra listaCompra)
        {
            var resultado = new Resultado<ListaCompra>();
            try
            {
                listaCompra.DataAlteracao = DateTime.Now;
                var resultadoValidation = ListaCompraValidation.Validate(listaCompra, ListaCompraOperation.Alterar);
                resultado += resultadoValidation;
                if (resultado)
                {
                    resultado += ListaCompraRepository.Atualizar(listaCompra);
                    if (resultado)
                    {
                        resultado = ListaCompraRepository.Selecionar(listaCompra);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ListaCompra> Excluir(ListaCompra listaCompra)
        {
            var resultado = new Resultado<ListaCompra>();
            try
            {
                listaCompra.DataAlteracao = DateTime.Now;
                var resultadoValidation = ListaCompraValidation.Validate(listaCompra, ListaCompraOperation.Excluir);
                resultado += resultadoValidation;
                if (resultado)
                {
                    resultado += ListaCompraRepository.Atualizar(listaCompra);
                    if (resultado)
                    {
                        resultado = ListaCompraRepository.Selecionar(listaCompra);
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
