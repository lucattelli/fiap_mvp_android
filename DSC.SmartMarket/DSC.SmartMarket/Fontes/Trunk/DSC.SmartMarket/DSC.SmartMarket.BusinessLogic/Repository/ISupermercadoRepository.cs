using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    internal interface ISupermercadoRepository : IRepositoryBase<Supermercado>
    {
        Resultado<Supermercado> Selecionar(Supermercado produtoFiltro);
        Resultado<Supermercado> SelecionarPorNome(Supermercado produtoFiltro);
    }
}
