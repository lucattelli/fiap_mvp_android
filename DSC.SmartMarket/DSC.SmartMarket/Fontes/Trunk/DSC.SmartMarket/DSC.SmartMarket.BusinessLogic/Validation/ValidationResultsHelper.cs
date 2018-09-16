using DSC.SmartMarket.Model;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System.Collections.Generic;
using System.Linq;

namespace DSC.SmartMarket.BusinessLogic.Validation
{
    public static class ValidationResultsHelper
    {
        public static Resultado AsResultado(this ValidationResults validationResults)
        {
            var resultado = new Resultado(validationResults.IsValid);
            if (!validationResults.IsValid)
            {
                validationResults.ConsolidarResultadosValidacao(resultado);
            }
            return resultado;
        }

        public static void ConsolidarResultadosValidacao(this IEnumerable<ValidationResult> validationResults, Resultado resultado)
        {
            if (validationResults.Any())
            {
                resultado.Sucesso = false;
                foreach (ValidationResult validationResult in validationResults)
                {
                    resultado.Mensagens.Add(validationResult.AsMensagem());
                    validationResult.NestedValidationResults.ConsolidarResultadosValidacao(resultado);
                }
            }
        }

        public static Mensagem AsMensagem(this ValidationResult validationResult)
        {
            var mensagem = new Mensagem();
            mensagem.Entidade = validationResult.Target.GetType().Name;
            mensagem.Campo = validationResult.Key;
            mensagem.Tag = validationResult.Tag;
            mensagem.Informacoes.Add(validationResult.Message);
            return mensagem;
        }
    }
}
