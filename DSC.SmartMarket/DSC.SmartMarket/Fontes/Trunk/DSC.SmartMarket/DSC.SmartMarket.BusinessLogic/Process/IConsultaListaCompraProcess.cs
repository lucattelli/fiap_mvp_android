using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal interface IConsultaListaCompraProcess : IProcessBase
    {
        Resultado<IList<ConsultaListaCompra>> ListarPorListaCompra(ListaCompra listaCompra);

        Resultado<ConsultaListaCompra> Consultar(ConsultaListaCompra consultaListaCompra);

        Resultado<ConsultaListaCompra> Incluir(ConsultaListaCompra consultaListaCompra);
    }
}
