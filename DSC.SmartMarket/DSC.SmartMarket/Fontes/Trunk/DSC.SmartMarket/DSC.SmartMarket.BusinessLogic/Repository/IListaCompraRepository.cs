using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    internal interface IListaCompraRepository : IRepositoryBase<ListaCompra>
    {
        Resultado<ListaCompra> Selecionar(ListaCompra listaCompra);

        Resultado<IList<ListaCompra>> SelecionarPorCliente(Cliente cliente);
    }
}
