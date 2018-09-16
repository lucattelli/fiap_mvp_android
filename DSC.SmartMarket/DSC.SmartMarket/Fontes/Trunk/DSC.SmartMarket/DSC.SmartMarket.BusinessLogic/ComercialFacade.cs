using DSC.SmartMarket.BusinessLogic.Process;
using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic
{
    public class ComercialFacade : FacadeBase, IComercialFacade
    {
        #region Propriedade(s)
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

        private IListaCompraProcess ListaCompraProcess
        {
            get
            {
                var resultado = Resolve<IListaCompraProcess>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IListaCompraProcess>(resultado);
            }
        }

        private IListaCompraItemProcess ListaCompraItemProcess
        {
            get
            {
                var resultado = Resolve<IListaCompraItemProcess>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IListaCompraItemProcess>(resultado);
            }
        }

        private IConsultaListaCompraProcess ConsultaListaCompraProcess
        {
            get
            {
                var resultado = Resolve<IConsultaListaCompraProcess>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IConsultaListaCompraProcess>(resultado);
            }
        }

        private IConsultaListaCompraItemProcess ConsultaListaCompraItemProcess
        {
            get
            {
                var resultado = Resolve<IConsultaListaCompraItemProcess>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IConsultaListaCompraItemProcess>(resultado);
            }
        }
        #endregion Propriedade(s)

        #region Método(s)
        public Resultado IncluirCliente(Cliente cliente)
        {
            var resultado = new Resultado(false);
            try
            {
                resultado = ClienteProcess.Incluir(cliente);
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }

        public Resultado AlterarCliente(Cliente cliente)
        {
            var resultado = new Resultado(false);
            try
            {
                resultado = ClienteProcess.Alterar(cliente);
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }

        public Resultado ExcluirCliente(Cliente cliente)
        {
            var resultado = new Resultado(false);
            try
            {
                resultado = ClienteProcess.Excluir(cliente);
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }

        public Resultado<Cliente> ConsultarCliente(Cliente clienteFiltro)
        {
            var resultado = new Resultado<Cliente>();
            try
            {
                resultado = ClienteProcess.ConsultarPorId(clienteFiltro);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<Tuple<IList<Cliente>, int>> ListarTodosCliente(int pagina = 1, int tamanhoPagina = int.MaxValue, string orderBy = null)
        {
            var resultado = new Resultado<Tuple<IList<Cliente>, int>>(true);
            try
            {
                var resultadoContar = ClienteProcess.ContarTodos();
                resultado += resultadoContar;
                if (resultado.Sucesso)
                {
                    int total = resultadoContar.Retorno;
                    var resultadoListar = ClienteProcess.ListarTodos(pagina, tamanhoPagina, orderBy);
                    resultado += resultadoListar;
                    if (resultadoListar.Sucesso)
                    {
                        var lista = resultadoListar.Retorno;
                        resultado.Retorno = new Tuple<IList<Cliente>, int>(lista, total);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado<Tuple<IList<Cliente>, int>>(ex);
            }
            return resultado;
        }

        public Resultado<IList<ListaCompra>> ListarListaCompraPorCliente(Cliente cliente)
        {
            var resultado = new Resultado<IList<ListaCompra>>();
            try
            {
                resultado = ListaCompraProcess.ListarPorCliente(cliente);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ListaCompra> ConsultarListaCompra(ListaCompra listaCompra)
        {
            var resultado = new Resultado<ListaCompra>();
            try
            {
                resultado = ListaCompraProcess.Consultar(listaCompra);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ListaCompra> IncluirListaCompra(ListaCompra listaCompra)
        {
            var resultado = new Resultado<ListaCompra>();
            try
            {
                listaCompra.Excluido = false;
                listaCompra.QuantidadeItem = 0;
                listaCompra.DataCriacao = DateTime.Now;
                listaCompra.DataAlteracao = listaCompra.DataCriacao;
                resultado = ListaCompraProcess.Incluir(listaCompra);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ListaCompra> AlterarListaCompra(ListaCompra listaCompra)
        {
            var resultado = new Resultado<ListaCompra>();
            try
            {
                resultado = ListaCompraProcess.Alterar(listaCompra);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ListaCompra> ExcluirListaCompra(ListaCompra listaCompra)
        {
            var resultado = new Resultado<ListaCompra>();
            try
            {
                resultado = ListaCompraProcess.Excluir(listaCompra);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<IList<ListaCompraItem>> ListarListaCompraItemPorListaCompra(ListaCompra listaCompra)
        {
            var resultado = new Resultado<IList<ListaCompraItem>>();
            try
            {
                resultado = ListaCompraItemProcess.ListarPorListaCompra(listaCompra);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ListaCompraItem> ConsultarListaCompraItem(ListaCompraItem listaCompraItem)
        {
            var resultado = new Resultado<ListaCompraItem>();
            try
            {
                resultado = ListaCompraItemProcess.Consultar(listaCompraItem);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ListaCompraItem> IncluirListaCompraItem(ListaCompraItem listaCompraItem)
        {
            var resultado = new Resultado<ListaCompraItem>();
            try
            {
                resultado = ListaCompraItemProcess.Incluir(listaCompraItem);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ListaCompraItem> AlterarListaCompraItem(ListaCompraItem listaCompraItem)
        {
            var resultado = new Resultado<ListaCompraItem>();
            try
            {
                resultado = ListaCompraItemProcess.Alterar(listaCompraItem);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ListaCompraItem> ExcluirListaCompraItem(ListaCompraItem listaCompraItem)
        {
            var resultado = new Resultado<ListaCompraItem>();
            try
            {
                resultado = ListaCompraItemProcess.Excluir(listaCompraItem);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<IList<ConsultaListaCompra>> ListarConsultaListaCompraPorListaCompra(ListaCompra listaCompra)
        {
            var resultado = new Resultado<IList<ConsultaListaCompra>>();
            try
            {
                resultado = ConsultaListaCompraProcess.ListarPorListaCompra(listaCompra);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ConsultaListaCompra> ConsultarConsultaListaCompra(ConsultaListaCompra consultaListaCompra)
        {
            var resultado = new Resultado<ConsultaListaCompra>();
            try
            {
                resultado = ConsultaListaCompraProcess.Consultar(consultaListaCompra);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<IList<ConsultaListaCompraItem>> ListarConsultaListaCompraItemPorConsultaListaCompra(ConsultaListaCompra consultaListaCompra)
        {
            var resultado = new Resultado<IList<ConsultaListaCompraItem>>();
            try
            {
                resultado = ConsultaListaCompraItemProcess.ListarPorConsultaListaCompra(consultaListaCompra);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ConsultaListaCompraItem> ConsultarConsultaListaCompraItem(ConsultaListaCompraItem consultaListaCompraItem)
        {
            var resultado = new Resultado<ConsultaListaCompraItem>();
            try
            {
                resultado = ConsultaListaCompraItemProcess.Consultar(consultaListaCompraItem);
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado GerarConsultaListaCompra(ListaCompra listaCompra)
        {
            var resultado = new Resultado();
            try
            {

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
