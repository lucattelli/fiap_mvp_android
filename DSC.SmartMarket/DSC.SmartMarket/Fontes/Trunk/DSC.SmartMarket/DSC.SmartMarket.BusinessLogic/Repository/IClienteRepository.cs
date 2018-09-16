using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    internal interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Resultado<Cliente> SelecionarPorId(Cliente clienteFiltro);
        Resultado<Cliente> SelecionarPorNome(Cliente clienteFiltro);
        Resultado<Cliente> SelecionarPorCPF(Cliente clienteFiltro);
        Resultado<Cliente> SelecionarPorRG(Cliente clienteFiltro);
        Resultado<Cliente> SelecionarPorEmail(Cliente clienteFiltro);
    }
}
