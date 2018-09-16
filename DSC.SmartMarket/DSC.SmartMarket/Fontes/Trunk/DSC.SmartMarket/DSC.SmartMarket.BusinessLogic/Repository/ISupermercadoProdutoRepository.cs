using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    internal interface ISupermercadoProdutoRepository : IRepositoryBase<SupermercadoProduto>
    {
        Resultado<SupermercadoProduto> Selecionar(SupermercadoProduto supermercadoProduto);

        Resultado<IList<SupermercadoProduto>> SelecionarPorSupermercado(Supermercado supermercado);
    }
}
