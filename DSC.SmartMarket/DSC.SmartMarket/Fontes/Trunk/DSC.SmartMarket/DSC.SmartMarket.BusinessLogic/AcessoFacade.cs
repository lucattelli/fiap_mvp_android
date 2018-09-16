using DSC.SmartMarket.BusinessLogic.Process;
using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DSC.SmartMarket.BusinessLogic
{
    public class AcessoFacade : FacadeBase, IAcessoFacade
    {
        #region Propriedade(s)
        private IUsuarioProcess UsuarioProcess
        {
            get
            {
                var resultado = Resolve<IUsuarioProcess>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IUsuarioProcess>(resultado);
            }
        }

        private IClienteProcess ClienteProcess
        {
            get
            {
                var resultado = Resolve<IClienteProcess>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IClienteProcess>(resultado);
            }
        }
        #endregion Propriedade(s)

        #region Método(s)
        public Resultado<IList<Usuario>> ListarTodosUsuario(int pagina = 1, int tamanhoPagina = int.MaxValue)
        {
            var resultado = new Resultado<IList<Usuario>>();
            try
            {
                resultado = UsuarioProcess.ListarTodos(pagina, tamanhoPagina);
            }
            catch (Exception ex)
            {
                resultado = new Resultado<IList<Usuario>>(ex);
            }
            return resultado;
        }

        public Resultado<Usuario> ValidarLoginUsuario(Usuario usuario)
        {
            var resultado = new Resultado<Usuario>(true);
            try
            {
                var resultadoLogin = UsuarioProcess.ValidarLogin(usuario);
                resultado += resultadoLogin;
                if (resultado.Sucesso)
                {
                    resultado = UsuarioProcess.ConsultarPorEmail(usuario);
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<Usuario> CadastrarUsuario(Usuario usuario)
        {
            var resultado = new Resultado<Usuario>();
            try
            {
                using (var scope = new TransactionScope())
                {
                    var cliente = usuario.Cliente;
                    if (cliente != null)
                    {
                        var resultadoCliente = ClienteProcess.Incluir(cliente);
                        resultado += resultadoCliente;
                        if (resultado)
                        {
                            usuario.IdCliente = resultadoCliente.Retorno.Id;
                            usuario.IdTipoUsuario = CodigoTipoUsuario.UsuarioFinal;
                            resultado = UsuarioProcess.Cadastrar(usuario);
                        }
                    }

                    if (resultado)
                        scope.Complete();
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado SenhaRedefinir(Usuario usuario)
        {
            var resultado = new Resultado();
            try
            {
                var resultadoConsulta = UsuarioProcess.ConsultarPorEmail(usuario);
                resultado += resultadoConsulta;
                if (resultado)
                {
                    resultado = UsuarioProcess.RedefinirSenha(usuario);
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;

        }
        #endregion Método(s)
    }
}
