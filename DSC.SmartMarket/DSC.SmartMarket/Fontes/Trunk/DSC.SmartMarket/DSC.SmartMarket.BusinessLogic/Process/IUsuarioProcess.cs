using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal interface IUsuarioProcess : IProcessBase
    {
        Resultado<IList<Usuario>> ListarTodos(int pagina, int tamanhoPagina);

        Resultado<Usuario> Cadastrar(Usuario usuario);

        Resultado ValidarLogin(Usuario usuario);

        Resultado<Usuario> ConsultarPorEmail(Usuario usuarioFiltro);

        Resultado RedefinirSenha(Usuario usuario);
    }
}
