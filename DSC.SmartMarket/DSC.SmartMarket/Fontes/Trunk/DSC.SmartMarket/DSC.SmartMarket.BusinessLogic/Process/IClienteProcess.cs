using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSC.SmartMarket.Model;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal interface IClienteProcess : IProcessBase
    {
        Resultado<IList<Cliente>> ListarTodos(int pagina, int tamanhoPagina, string orderBy);

        Resultado<int> ContarTodos();

        Resultado<Cliente> Incluir(Cliente cliente);

        Resultado Alterar(Cliente cliente);

        Resultado Excluir(Cliente cliente);

        Resultado<Cliente> ConsultarPorId(Cliente clienteFiltro);
    }
}
