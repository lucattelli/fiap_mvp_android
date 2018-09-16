using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
//using Microsoft.Practices.EnterpriseLibrary.Common;
//using Microsoft.Practices.EnterpriseLibrary.Validation;
//using Ext.Net.MVC;

namespace DSC.SmartMarket.Model
{
    [DataContract, Serializable]
    public class Mensagem
    {
        #region Propriedade(s)
        [DataMember]
        public string Entidade
        { get; set; }

        [DataMember]
        public string Campo
        { get; set; }

        [DataMember]
        public List<string> Informacoes
        { get; set; }

        [DataMember]
        public object Tag
        { get; set; }
        #endregion Propriedade(s)

        #region Construtor(es)
        public Mensagem()
        {
            Informacoes = new List<string>();
        }
 
        public Mensagem(Exception ex)
            : this()
        {
            AddExcecaoMensagem(ex);
        }

        public Mensagem(string informacao)
            : this()
        {
            Informacoes.Add(informacao);
        }

        public Mensagem(string campo, string informacao)
            :this(informacao)
        {
            Campo = campo;
        }
        #endregion Construtor(es)

        #region Método(s)
        public void AddExcecaoMensagem(Exception ex)
        {
            Informacoes.Add(ex.Message);
            if (ex.InnerException != null)
            {
                AddExcecaoMensagem(ex.InnerException);
            }
        }

        public string ConsolidaMensagem(string separador)
        {
            if (Informacoes.Any())
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < Informacoes.Count; ++i)
                {
                    if (Informacoes[i].Length > 0)
                    {
                        sb.Append(Informacoes[i]);
                        if (i < (Informacoes.Count - 1))
                        {
                            sb.Append(separador);
                        }
                    }
                }
                return sb.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion Método(s)
    }
}
