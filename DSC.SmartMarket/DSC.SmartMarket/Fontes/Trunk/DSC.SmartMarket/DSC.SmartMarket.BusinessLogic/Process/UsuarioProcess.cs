using DSC.SmartMarket.BusinessLogic.Repository;
using DSC.SmartMarket.BusinessLogic.Validation;
using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal class UsuarioProcess : ProcessBase, IUsuarioProcess
    {
        #region Propriedade(s)
        private IUsuarioRepository UsuarioRepository
        {
            get
            {
                var resultado = Resolve<IUsuarioRepository>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return null;
            }
        }

        private IUsuarioValidation UsuarioValidation
        {
            get
            {
                var resultado = Resolve<IUsuarioValidation>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return null;
            }
        }
        #endregion Propriedade(s)

        #region Método(s)
        public Resultado<IList<Usuario>> ListarTodos(int pagina, int tamanhoPagina)
        {
            var resultado = new Resultado<IList<Usuario>>();
            try
            {
                var skip = (pagina - 1) * tamanhoPagina;
                var take = tamanhoPagina;
                var orderBy = "Id DESC";
                resultado = UsuarioRepository.Selecionar(skip, take, orderBy);
            }
            catch (Exception ex)
            {
                resultado = new Resultado<IList<Usuario>>(ex);
            }
            return resultado;
        }

        public Resultado<Usuario> ConsultarPorEmail(Usuario usuarioFiltro)
        {
            var resultado = new Resultado<Usuario>();
            try
            {
                resultado += UsuarioValidation.Validate(usuarioFiltro, UsuarioOperation.ConsultarPorEmail);
                if (resultado)
                {
                    resultado = UsuarioRepository.SelecionarPorEmail(usuarioFiltro);
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<Usuario> Cadastrar(Usuario usuario)
        {
            var resultado = new Resultado<Usuario>();
            try
            {
                var resultadoCifrar = CifrarSenha(usuario.Senha);
                resultado += resultadoCifrar;
                if (resultado)
                {
                    var usuarioCifrado = usuario;
                    usuarioCifrado.Senha = resultadoCifrar.Retorno;
                    usuarioCifrado.Ativo = true;
                    usuarioCifrado.DataCadastro = DateTime.Now;
                    usuarioCifrado.DataAlteracao = DateTime.Now;
                    usuarioCifrado.Deletado = false;
                    usuarioCifrado.IdTipoUsuario = CodigoTipoUsuario.UsuarioFinal;
                    resultado += UsuarioValidation.Validate(usuario, UsuarioOperation.Incluir);
                    if (resultado)
                    {
                        resultado += UsuarioRepository.Inserir(usuarioCifrado);
                        if (resultado)
                        {
                            resultado = UsuarioRepository.Selecionar(usuarioCifrado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado ValidarLogin(Usuario usuario)
        {
            var resultado = new Resultado(true);
            try
            {
                var resultadoConsultar = ConsultarPorEmail(usuario);
                resultado += resultadoConsultar;
                if (resultado)
                {
                    var usuarioEncontrado = resultadoConsultar.Retorno;
                    if (usuarioEncontrado != null)
                    {
                        var resultadoCifrar = CifrarSenha(usuario.Senha);
                        resultado += resultadoCifrar;
                        if (resultado)
                        {
                            string senhaCifrada = resultadoCifrar.Retorno;
                            if (usuarioEncontrado.Senha == senhaCifrada)
                            {
                                resultado = new Resultado(true);
                            }
                            else
                            {
                                resultado = new Resultado(false);
                            }
                        }
                    }
                    else
                    {
                        resultado = new Resultado(false);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }

            if (!resultado.Sucesso)
            {
                resultado += "Usuário e/ou Senha inválido(s)";
            }
            return resultado;
        }

        public Resultado RedefinirSenha(Usuario usuario)
        {
            var resultado = new Resultado(true);
            try
            {
                var resultadoConsultar = ConsultarPorEmail(usuario);
                resultado += resultadoConsultar;
                if (resultado)
                {
                    var usuarioEncontrado = resultadoConsultar.Retorno;
                    if (usuarioEncontrado != null)
                    {
                        var resultadoCifrar = CifrarSenha(usuario.Senha);
                        resultado += resultadoCifrar;
                        if (resultado)
                        {
                            usuarioEncontrado.Senha = resultadoCifrar.Retorno;
                            usuarioEncontrado.DataAlteracao = DateTime.Now;
                            resultado += UsuarioValidation.Validate(usuarioEncontrado, UsuarioOperation.Incluir);
                            if (resultado)
                            {
                                resultado = UsuarioRepository.Atualizar(usuarioEncontrado);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        private Resultado<string> CifrarSenha(string senha)
        {
            var resultado = new Resultado<string>();
            try
            {
                var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(senha));
                resultado.Retorno = string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
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
