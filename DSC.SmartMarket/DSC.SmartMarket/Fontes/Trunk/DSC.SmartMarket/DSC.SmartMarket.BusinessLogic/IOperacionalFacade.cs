using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic
{
    public interface IOperacionalFacade : IFacadeBase
    {
        Resultado<Tuple<IList<Produto>, int>> ListarTodosProduto(int pagina = 1, int tamanhoPagina = int.MaxValue, string orderBy = null);

        Resultado IncluirProduto(Produto produto);

        Resultado AlterarProduto(Produto produto);

        Resultado ExcluirProduto(Produto produto);

        Resultado<Produto> ConsultarProduto(Produto produtoFiltro);

        Resultado<Supermercado> ConsultarSupermercado(Supermercado supermercado);

        Resultado IncluirSupermercado(Supermercado supermercado);

        Resultado AlterarSupermercado(Supermercado supermercado);

        Resultado ExcluirSupermercado(Supermercado supermercado);

        Resultado<IList<SupermercadoProduto>> ListarSupermercadoProdutoPorSupermercado(Supermercado supermercado);

        Resultado<SupermercadoProduto> ConsultarSupermercadoProduto(SupermercadoProduto supermercadoProduto);

        Resultado IncluirSupermercadoProduto(SupermercadoProduto supermercadoProduto);

        Resultado AlterarSupermercadoProduto(SupermercadoProduto supermercadoProduto);

        Resultado ExcluirSupermercadoProduto(SupermercadoProduto supermercadoProduto);

        Resultado<Tuple<IList<Supermercado>, int>> ListarTodosSupermercados(int pagina = 1, int tamanhoPagina = int.MaxValue, string orderBy = null);
    }
}
