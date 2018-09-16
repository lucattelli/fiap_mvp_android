using DSC.SmartMarket.BusinessLogic.Common;
using DSC.SmartMarket.BusinessLogic.Repository;
using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Validation
{
    internal class ClienteValidation : ValidationBase<Cliente, ClienteOperation>, IClienteValidation
    {
        #region Propredade(s)
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
        #endregion Propriedade(s)

        protected override Resultado ValidateFieldsRules()
        {
            var resultado = base.ValidateRules();
            switch (Operation)
            {
                case ClienteOperation.Incluir:
                    resultado += ValidarCPFCalculo();
                    resultado += ValidarCPFUnico();
                    resultado += ValidarEmailUnico();
                    break;

                case ClienteOperation.Alterar:
                    resultado += ValidarCPFCalculo();
                    break;
            }
            return resultado;
        }

        //private Resultado ValidarNomeUnico()
        //{
        //    var resultado = new Resultado(true);
        //    try
        //    {
        //        var filtro = new Cliente() { Nome = Target.Nome };
        //        var resultadoSelecionar = ClienteRepository.SelecionarPorNome(filtro);
        //        resultado.Sucesso = !(resultadoSelecionar.Sucesso && resultadoSelecionar.Retorno != null);
        //        if (!resultado.Sucesso)
        //        {
        //            resultado.Mensagens.Add(new Mensagem("Nome", "Por favor preencha o campo Nome com um valor único."));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado += ex;
        //    }
        //    return resultado;
        //}

        private Resultado ValidarCPFCalculo()
        {
            var resultado = new Resultado(true);
            try
            {
                if (!Valida.ValidaCPF(Target.CPF))
                {
                    resultado = false;
                    resultado.Mensagens.Add(new Mensagem("CPF", "Por favor preencha o campo CPF com um valor válido."));
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        private Resultado ValidarCPFUnico()
        {
            var resultado = new Resultado(true);
            try
            {
                var filtro = new Cliente() { CPF = Target.CPF };
                var resultadoSelecionar = ClienteRepository.SelecionarPorCPF(filtro);
                resultado += resultadoSelecionar;
                if (resultado)
                {
                    if (resultadoSelecionar.PossuiRetorno)
                    {
                        resultado = false;
                        resultado.Mensagens.Add(new Mensagem("CPF", "Por favor preencha o campo CPF com um valor único."));
                    }
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        //private Resultado ValidarRGUnico()
        //{
        //    var resultado = new Resultado(true);
        //    try
        //    {
        //        var filtro = new Cliente() { RG = Target.RG };
        //        var resultadoSelecionar = ClienteRepository.SelecionarPorRG(filtro);
        //        resultado.Sucesso = !(resultadoSelecionar.Sucesso && resultadoSelecionar.Retorno != null);
        //        if (!resultado.Sucesso)
        //        {
        //            resultado.Mensagens.Add(new Mensagem("RG", "Por favor preencha o campo RG com um valor único."));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado += ex;
        //    }
        //    return resultado;
        //}

        private Resultado ValidarEmailUnico()
        {
            var resultado = new Resultado(true);
            try
            {
                var filtro = new Cliente() { RG = Target.RG };
                var resultadoSelecionar = ClienteRepository.SelecionarPorEmail(filtro);
                resultado += resultadoSelecionar;
                if (resultado)
                {
                    if (resultadoSelecionar.PossuiRetorno)
                    {
                        resultado = false;
                        resultado.Mensagens.Add(new Mensagem("Email", "Por favor preencha o campo Email com um valor único."));
                    }
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
