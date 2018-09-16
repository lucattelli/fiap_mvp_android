using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSC.SmartMarket.WebApp
{
    public static class ModelStateDictionaryHelper
    {
        public static ModelStateDictionary AddModelResultoErro(this ModelStateDictionary modelState, Resultado resultado, string prefixo = null)
        {
            if (!string.IsNullOrEmpty(prefixo) && !prefixo.EndsWith("."))
            {
                prefixo += ".";
            }

            foreach(var mensagem in resultado.Mensagens)
            {
                var chave = string.IsNullOrEmpty(prefixo) ? mensagem.Campo : prefixo + mensagem.Campo;
                foreach(var info in mensagem.Informacoes)
                {
                    modelState.AddModelError(chave, info);
                }
            }
            return modelState;
        }
    }
}