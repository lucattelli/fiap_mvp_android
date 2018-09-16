using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal interface ISupermercadoProcess : IProcessBase
    {
        Resultado<IList<Supermercado>> ListarTodos(int pagina, int tamanhoPagina, string orderBy);

        Resultado<int> ContarTodos();

        Resultado Incluir(Supermercado supermercado);

        Resultado Alterar(Supermercado supermercado);

        Resultado Excluir(Supermercado supermercado);

        Resultado<Supermercado> Consultar(Supermercado supermercado);
    }
}
