using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal interface IProdutoProcess : IProcessBase
    {
        Resultado<IList<Produto>> ListarTodos(int pagina, int tamanhoPagina, string orderBy);

        Resultado<int> ContarTodos();

        Resultado Incluir(Produto produto);

        Resultado Alterar(Produto produto);

        Resultado Excluir(Produto produto);

        Resultado<Produto> ConsultarPorId(Produto produtoFiltro);
    }
}
