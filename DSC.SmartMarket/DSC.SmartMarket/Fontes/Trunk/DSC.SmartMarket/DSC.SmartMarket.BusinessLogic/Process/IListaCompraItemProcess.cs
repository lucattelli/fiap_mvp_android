using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal interface IListaCompraItemProcess : IProcessBase
    {
        Resultado<IList<ListaCompraItem>> ListarPorListaCompra(ListaCompra listaCompra);

        Resultado<ListaCompraItem> Consultar(ListaCompraItem listaCompraItem);

        Resultado<ListaCompraItem> Incluir(ListaCompraItem listaCompraItem);

        Resultado<ListaCompraItem> Alterar(ListaCompraItem listaCompraItem);

        Resultado<ListaCompraItem> Excluir(ListaCompraItem listaCompraItem);
    }
}
