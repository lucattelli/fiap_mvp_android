using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    interface IConsultaListaCompraItemRepository : IRepositoryBase<ConsultaListaCompraItem>
    {
        Resultado<IList<ConsultaListaCompraItem>> SelecionarPorConsultaListaCompra(ConsultaListaCompra consultaListaCompra);

        Resultado<ConsultaListaCompraItem> Selecionar(ConsultaListaCompraItem consultaListaCompraItem);
    }
}
