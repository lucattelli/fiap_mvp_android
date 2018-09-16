using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic
{
    public interface IComercialFacade : IFacadeBase
    {

        Resultado<Cliente> ConsultarCliente(Cliente clienteFiltro);

        Resultado ExcluirCliente(Cliente cliente);

        Resultado IncluirCliente(Cliente cliente);

        Resultado AlterarCliente(Cliente cliente);
        
        Resultado<Tuple<IList<Cliente>, int>> ListarTodosCliente(int pagina = 1, int tamanhoPagina = int.MaxValue, string orderBy = null);

        Resultado<IList<ListaCompra>> ListarListaCompraPorCliente(Cliente cliente);

        Resultado<ListaCompra> ConsultarListaCompra(ListaCompra listaCompra);

        Resultado<ListaCompra> IncluirListaCompra(ListaCompra listaCompra);

        Resultado<ListaCompra> AlterarListaCompra(ListaCompra listaCompra);

        Resultado<ListaCompra> ExcluirListaCompra(ListaCompra listaCompra);

        Resultado<IList<ListaCompraItem>> ListarListaCompraItemPorListaCompra(ListaCompra listaCompra);

        Resultado<ListaCompraItem> ConsultarListaCompraItem(ListaCompraItem listaCompraItem);

        Resultado<ListaCompraItem> IncluirListaCompraItem(ListaCompraItem listaCompraItem);

        Resultado<ListaCompraItem> AlterarListaCompraItem(ListaCompraItem listaCompraItem);

        Resultado<ListaCompraItem> ExcluirListaCompraItem(ListaCompraItem listaCompraItem);

        Resultado<IList<ConsultaListaCompra>> ListarConsultaListaCompraPorListaCompra(ListaCompra listaCompra);

        Resultado<ConsultaListaCompra> ConsultarConsultaListaCompra(ConsultaListaCompra consultaListaCompra);

        Resultado<IList<ConsultaListaCompraItem>> ListarConsultaListaCompraItemPorConsultaListaCompra(ConsultaListaCompra consultaListaCompra);

        Resultado<ConsultaListaCompraItem> ConsultarConsultaListaCompraItem(ConsultaListaCompraItem consultaListaCompraItem);

        Resultado GerarConsultaListaCompra(ListaCompra listaCompra);
    }
}
