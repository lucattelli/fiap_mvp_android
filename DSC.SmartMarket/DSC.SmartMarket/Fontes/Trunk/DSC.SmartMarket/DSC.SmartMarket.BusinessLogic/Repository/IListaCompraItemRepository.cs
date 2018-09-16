using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    internal interface IListaCompraItemRepository : IRepositoryBase<ListaCompraItem>
    {
        Resultado<IList<ListaCompraItem>> SelecionarPorListaCompra(ListaCompra listaCompra);

        Resultado<ListaCompraItem> Selecionar(ListaCompraItem listaCompraItem);
    }
}
