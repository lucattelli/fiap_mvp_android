using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSC.SmartMarket.BusinessLogic.IoC;
using DSC.SmartMarket.BusinessLogic.Repository;
using DSC.SmartMarket.BusinessLogic.Validation;
using DSC.SmartMarket.Model;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal class ClienteProcess : ProcessBase, IClienteProcess
    {
        #region Propriedade(s)
        private IClienteRepository ClienteRepository
        {
            get
            {
                var resultado = Resolve<IClienteRepository>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return null;
            }
        }

        private IClienteValidation ClienteValidation
        {
            get
            {
                var resultado = Resolve<IClienteValidation>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return null;
            }
        }

        public Resultado Alterar(Cliente cliente)
        {
            var resultado = new Resultado(false);
            try
            {
                resultado = ClienteValidation.Validate(cliente, ClienteOperation.Alterar);
                if (resultado.Sucesso)
                {
                    var resultadoConsultar = ClienteRepository.SelecionarPorId(cliente);
                    if (resultadoConsultar.Sucesso)
                    {
                        var clienteAlterar = resultadoConsultar.Retorno;
                        clienteAlterar.Nome = cliente.Nome;
                        clienteAlterar.CPF = cliente.CPF;
                        clienteAlterar.RG = cliente.RG;
                        clienteAlterar.Email = cliente.Email;
                        clienteAlterar.Telefone = cliente.Telefone;
                        resultado = ClienteRepository.Atualizar(clienteAlterar);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }

        public Resultado<Cliente> ConsultarPorId(Cliente clienteFiltro)
        {
            var resultado = new Resultado<Cliente>(true);
            try
            {
                var resultadoValidar = ClienteValidation.Validate(clienteFiltro, ClienteOperation.Consultar);
                resultado += resultadoValidar;
                if (resultado.Sucesso)
                {
                    resultado = ClienteRepository.SelecionarPorId(clienteFiltro);
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado<Cliente>(ex);
            }
            return resultado;
        }

        public Resultado<int> ContarTodos()
        {
            var resultado = new Resultado<int>(true);
            try
            {
                resultado = ClienteRepository.Contar();
            }
            catch (Exception ex)
            {
                resultado = new Resultado<int>(ex);
            }
            return resultado;
        }

        public Resultado<Cliente> Incluir(Cliente cliente)
        {
            var resultado = new Resultado<Cliente>();
            try
            {
                resultado += ClienteValidation.Validate(cliente, ClienteOperation.Incluir);
                if (resultado.Sucesso)
                {
                    resultado += ClienteRepository.Inserir(cliente);
                    if (resultado)
                    {
                        resultado = ConsultarPorId(cliente);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<IList<Cliente>> ListarTodos(int pagina, int tamanhoPagina, string orderBy)
        {
            var resultado = new Resultado<IList<Cliente>>(false);
            try
            {
                int skip = (pagina - 1) * tamanhoPagina;
                int take = tamanhoPagina;
                resultado = ClienteRepository.Selecionar(skip, take, orderBy);
            }
            catch (Exception ex)
            {
                resultado = new Resultado<IList<Cliente>>(ex);
            }
            return resultado;
        }

        public Resultado Excluir(Cliente cliente)
        {
            var resultado = new Resultado(false);
            try
            {
                resultado = ClienteValidation.Validate(cliente, ClienteOperation.Excluir);
                if (resultado.Sucesso)
                {
                    var resultadoConsultar = ClienteRepository.SelecionarPorId(cliente);
                    if (resultadoConsultar.Sucesso)
                    {
                        var clienteExcluir = resultadoConsultar.Retorno;
                        resultado = ClienteRepository.Remover(clienteExcluir);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado(ex);
            }
            return resultado;
        }
        #endregion Propriedade(s)

    }
}
