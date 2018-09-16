using DSC.SmartMarket.BusinessLogic.Repository;
using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Validation
{
    internal class UsuarioValidation : ValidationBase<Usuario, UsuarioOperation>, IUsuarioValidation
    {
        #region Propriedade(s)
        private IUsuarioRepository UsuarioRepository
        {
            get
            {
                var resultado = Resolve<IUsuarioRepository>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IUsuarioRepository>(resultado);
            }
        }
        private IClienteRepository ClienteRepository
        {
            get
            {
                var resultado = Resolve<IClienteRepository>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IClienteRepository>(resultado);
            }
        }
        #endregion Propriedade(s)

        #region Método(s)
        protected override Resultado ValidateFieldsRules()
        {
            var resultado = base.ValidateFieldsRules();
            switch (Operation)
            {
                case UsuarioOperation.Incluir:
                    resultado += ValidateTipoUsuarioCliente();
                    break;

                case UsuarioOperation.Alterar:
                    resultado += ValidateTipoUsuarioCliente();
                    break;
            }
            return resultado;
        }

        protected override Resultado ValidateRules()
        {
            var resultado = base.ValidateRules();
            switch (Operation)
            {
                case UsuarioOperation.Incluir:
                    resultado += ValidateEmailUnico();
                    resultado += ValidateClienteExistente();
                    resultado += ValidateClienteUnico();
                    break;

                case UsuarioOperation.Alterar:
                    resultado += ValidateEmailUnico();
                    resultado += ValidateClienteExistente();
                    resultado += ValidateClienteUnico();
                    break;
            }
            return resultado;
        }

        private Resultado ValidateTipoUsuarioCliente()
        {
            var resultado = new Resultado();
            try
            {
                if ((Target.IdTipoUsuario == CodigoTipoUsuario.UsuarioFinal) && (!Target.IdCliente.HasValue))
                {
                    resultado.Sucesso = false;
                    resultado.Mensagens.Add(new Mensagem("IdCliente, Identificador do Cliente não informado para usuário de Tipo Usuario Final."));
                }
                else if ((Target.IdTipoUsuario != CodigoTipoUsuario.UsuarioFinal) && (Target.IdCliente.HasValue))
                {
                    resultado.Sucesso = false;
                    resultado.Mensagens.Add(new Mensagem("IdCliente, Identificador do Cliente não pode ser informado para usuário de Tipo Administrador."));
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        private Resultado ValidateClienteExistente()
        {
            var resultado = new Resultado();
            try
            {
                var cliente = Target.Cliente;
                if (cliente != null)
                {
                    var resultadoSelect = ClienteRepository.SelecionarPorId(cliente);
                    resultado += resultadoSelect;
                    if (resultado)
                    {
                        if (resultadoSelect.Retorno == null)
                        {
                            resultado += "Cliente informado não está cadastrado para associação com usuário.";
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

        private Resultado ValidateEmailUnico()
        {
            var resultado = new Resultado();
            try
            {
                var email = Target.Email;
                if (!string.IsNullOrEmpty(email))
                {
                    var resultadoSelect = UsuarioRepository.SelecionarPorEmail(new Usuario() { Email = email });
                    resultado += resultadoSelect;
                    if (resultado)
                    {
                        if (resultadoSelect.Retorno != null)
                        {
                            if ((Operation == UsuarioOperation.Incluir) ||
                                ((Operation == UsuarioOperation.Alterar) && (resultadoSelect.Retorno.Id != Target.Id)))
                            {
                                resultado += "O E-mail informado já está cadastrado.";
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

        private Resultado ValidateClienteUnico()
        {
            var resultado = new Resultado();
            try
            {
                var idCliente = Target.IdCliente;
                if (idCliente.HasValue)
                {
                    var resultadoSelect = UsuarioRepository.SelecionarPorClienteId(new Usuario() { IdCliente = idCliente });
                    resultado += resultadoSelect;
                    if (resultado)
                    {
                        if (resultadoSelect.Retorno != null)
                        {
                            if ((Operation == UsuarioOperation.Incluir) ||
                                ((Operation == UsuarioOperation.Alterar) && (resultadoSelect.Retorno.Id != Target.Id)))
                            {
                                resultado += "Cliente informado está cadastrado para associação com mais de um usuário.";
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
        #endregion Método(s)
    }
}
