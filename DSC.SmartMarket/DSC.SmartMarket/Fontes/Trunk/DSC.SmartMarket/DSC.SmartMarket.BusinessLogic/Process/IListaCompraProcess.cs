using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal interface IListaCompraProcess : IProcessBase
    {
        Resultado<IList<ListaCompra>> ListarPorCliente(Cliente cliente);

        Resultado<ListaCompra> Consultar(ListaCompra listaCompra);

        Resultado<ListaCompra> Incluir(ListaCompra listaCompra);

        Resultado<ListaCompra> Alterar(ListaCompra listaCompra);

        Resultado<ListaCompra> Excluir(ListaCompra listaCompra);
    }
}
