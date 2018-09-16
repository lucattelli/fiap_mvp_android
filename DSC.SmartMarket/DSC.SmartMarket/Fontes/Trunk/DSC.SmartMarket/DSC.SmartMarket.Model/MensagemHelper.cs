using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSC.SmartMarket.Model
{
    public static class MensagemHelper
    {
        public static string ConsolidarMensagens(this IEnumerable<Mensagem> mensagens, string separador)
        {
            if (mensagens.Any())
            {
                var sb = new StringBuilder();
                foreach(var mensagem in mensagens)
                {
                    var strMensagem = mensagem.ConsolidaMensagem(separador);
                    if (strMensagem.Length > 0)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(separador);
                        }
                        sb.Append(strMensagem);
                    }
                }
                return sb.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
