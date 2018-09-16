using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal interface ISupermercadoProdutoProcess : IProcessBase
    {
        Resultado Incluir(SupermercadoProduto supermercadoProduto);

        Resultado Alterar(SupermercadoProduto supermercadoProduto);

        Resultado Excluir(SupermercadoProduto supermercadoProduto);

        Resultado<SupermercadoProduto> Consultar(SupermercadoProduto supermercadoProduto);

        Resultado<IList<SupermercadoProduto>> ListarPorSupermercado(Supermercado supermercado);
    }
}
