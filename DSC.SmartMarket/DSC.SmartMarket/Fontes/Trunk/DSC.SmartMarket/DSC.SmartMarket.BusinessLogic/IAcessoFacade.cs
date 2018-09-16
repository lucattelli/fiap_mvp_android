using DSC.SmartMarket.Model;

namespace DSC.SmartMarket.BusinessLogic
{
    public interface IAcessoFacade : IFacadeBase
    {
        Resultado<Usuario> ValidarLoginUsuario(Usuario usuario);

        Resultado<Usuario> CadastrarUsuario(Usuario usuario);

        Resultado SenhaRedefinir(Usuario usuario);

    }
}