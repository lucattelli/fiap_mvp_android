using DSC.SmartMarket.BusinessLogic.Common;
using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    internal class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public Resultado<Cliente> SelecionarPorId(Cliente clienteFiltro)
        {
            var resultado = new Resultado<Cliente>(true);
            try
            {
                var resultadoSelect = Select();
                if (resultadoSelect.Sucesso)
                {
                    var query = resultadoSelect.Retorno
                        .Where(cli => cli.Id == clienteFiltro.Id);
                    resultado.Retorno = query.Single();
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<Cliente> SelecionarPorNome(Cliente clienteFiltro)
        {
            var resultado = new Resultado<Cliente>(true);
            try
            {
                var resultadoSelect = Select();
                if (resultadoSelect.Sucesso)
                {
                    var query = resultadoSelect.Retorno
                        .Where(cli => cli.Nome == clienteFiltro.Nome);
                    resultado.Retorno = query.SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<Cliente> SelecionarPorCPF(Cliente clienteFiltro)
        {
            var resultado = new Resultado<Cliente>(true);
            try
            {
                var resultadoSelect = Select();
                if (resultadoSelect)
                {
                    var query = resultadoSelect.Retorno
                        .Where(cli => cli.CPF == clienteFiltro.CPF);
                    resultado.Retorno = query.SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }


        public Resultado<Cliente> SelecionarPorRG(Cliente clienteFiltro)
        {
            var resultado = new Resultado<Cliente>(true);
            try
            {
                var resultadoSelect = Select();
                if (resultadoSelect.Sucesso)
                {
                    var query = resultadoSelect.Retorno
                        .Where(cli => cli.RG == clienteFiltro.RG);
                    resultado.Retorno = query.SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }


        public Resultado<Cliente> SelecionarPorEmail(Cliente clienteFiltro)
        {
            var resultado = new Resultado<Cliente>(true);
            try
            {
                var resultadoSelect = Select();
                if (resultadoSelect.Sucesso)
                {
                    var query = resultadoSelect.Retorno
                        .Where(cli => cli.Email == clienteFiltro.Email);
                    resultado.Retorno = query.SingleOrDefault();
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
