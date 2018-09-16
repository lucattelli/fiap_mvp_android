using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    internal interface IConsultaListaCompraRepository : IRepositoryBase<ConsultaListaCompra>
    {
        Resultado<IList<ConsultaListaCompra>> SelecionarPorListaCompra(ListaCompra listaCompra);

        Resultado<ConsultaListaCompra> Selecionar(ConsultaListaCompra consultaListaCompra);
    }
}
