using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    internal interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Resultado<Usuario> Selecionar(Usuario usuario);

        Resultado<Usuario> SelecionarPorClienteId(Usuario usuario);

        Resultado<Usuario> SelecionarPorEmail(Usuario usuarioFiltro);
    }
}
