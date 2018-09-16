using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    internal interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Resultado<Produto> SelecionarPorId(Produto produtoFiltro);
        Resultado<Produto> SelecionarPorNome(Produto produtoFiltro);
    }
}
