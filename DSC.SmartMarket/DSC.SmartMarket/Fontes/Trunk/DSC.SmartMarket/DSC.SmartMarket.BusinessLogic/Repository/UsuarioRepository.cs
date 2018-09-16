using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    internal class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public Resultado<Usuario> Selecionar(Usuario usuarioFiltro)
        {
            var resultado = new Resultado<Usuario>();
            try
            {
                var resultadoSelect = Select();
                if (resultadoSelect)
                {
                    var query = resultadoSelect.Retorno
                        .Include("Cliente")
                        .Where(usu => usu.Id == usuarioFiltro.Id);
                    resultado = new Resultado<Usuario>(query.SingleOrDefault());
                }
                else
                {
                    resultado += resultadoSelect;
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<Usuario> SelecionarPorClienteId(Usuario usuarioFiltro)
        {
            var resultado = new Resultado<Usuario>();
            try
            {
                var resultadoSelect = Select();
                if (resultadoSelect)
                {
                    var query = resultadoSelect.Retorno
                        .Where(usu => usu.IdCliente == usuarioFiltro.IdCliente);
                    resultado = new Resultado<Usuario>(query.SingleOrDefault());
                }
                else
                {
                    resultado += resultadoSelect;
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<Usuario> SelecionarPorEmail(Usuario usuarioFiltro)
        {
            var resultado = new Resultado<Usuario>();
            try
            {
                var resultadoSelect = Select();
                if (resultadoSelect)
                {
                    var query = resultadoSelect.Retorno
                        .Include("Cliente")
                        .Where(usu => usu.Email == usuarioFiltro.Email);
                    resultado = new Resultado<Usuario>(query.SingleOrDefault());
                }
                else
                {
                    resultado += resultadoSelect;
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }
    }
}