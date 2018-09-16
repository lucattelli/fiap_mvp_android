using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal interface IConsultaListaCompraItemProcess : IProcessBase
    {
        Resultado<IList<ConsultaListaCompraItem>> ListarPorConsultaListaCompra(ConsultaListaCompra consultaListaCompra);

        Resultado<ConsultaListaCompraItem> Consultar(ConsultaListaCompraItem consultaListaCompraItem);

        Resultado<ConsultaListaCompraItem> Incluir(ConsultaListaCompraItem consultaListaCompraItem);
    }
}
