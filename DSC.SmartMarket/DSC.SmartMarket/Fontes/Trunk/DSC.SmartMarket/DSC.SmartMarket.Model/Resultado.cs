//using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DSC.SmartMarket.Model
{
    [DataContract(Name = "Resultado{0}"), Serializable]
    public class Resultado<T> : Resultado
    {
        #region Propriedade(s)
        [DataMember]
        public T Retorno
        { get; set; }

        public bool PossuiRetorno
        {
            get
            {
                return Retorno != null;
            }
        }
        #endregion Propriedade(s)

        #region Construtor(es)
        public Resultado()
            : base() { }

        public Resultado(Resultado resultado)
            : base(resultado) { }

        public Resultado(T retorno)
            : base()
        {
            Sucesso = true;
            Retorno = retorno;
        }

        public Resultado(bool sucesso)
            : base(sucesso) { }

        public Resultado(T retorno, bool sucesso)
            : base(sucesso)
        {
            Retorno = retorno;
        }

        public Resultado(Exception ex)
            : base(ex) { }

        public Resultado(string mensagemErro)
            : base(mensagemErro) { }
        #endregion Construtor(es)

        #region Método(s)
        public new Resultado<T> Adicionar(Resultado resultado)
        {
            return (Resultado<T>)base.Adicionar(resultado);
        }
        #endregion Método(s)

        #region Operador(es)
        public static Resultado<T> operator +(Resultado<T> r1, Resultado r2)
        {
            return new Resultado<T>(resultado: r1).Adicionar(r2);
        }

        public static Resultado<T> operator +(Resultado<T> r1, string mensagemErro)
        {
            return new Resultado<T>(resultado: r1).Adicionar(new Resultado<T>(mensagemErro: mensagemErro));
        }

        public static implicit operator bool(Resultado<T> r)
        {
            return r.Sucesso;
        }

        public static implicit operator Resultado<T>(Exception ex)
        {
            return new Resultado<T>(ex);
        }

        public static implicit operator Resultado<T>(bool sucesso)
        {
            return new Resultado<T>(sucesso: sucesso);
        }
        #endregion Operador(es)
    }

    [DataContract, Serializable]
    public class Resultado
    {
        #region Propriedade(s)
        [DataMember]
        public bool Sucesso
        { get; set; }

        [DataMember]
        public List<Mensagem> Mensagens
        { get; set; }

        public bool ResultadoExcecao
        { get; set; }
        #endregion Propriedade(s)

        #region Construtor(es)
        public Resultado() :
            this(true)
        { }

        public Resultado(bool sucesso)
        {
            ResultadoExcecao = false;
            Sucesso = sucesso;
            Mensagens = new List<Mensagem>();
        }

        public Resultado(Exception ex)
        {
            ResultadoExcecao = true;
            Mensagens = new List<Mensagem>();
            CarregarExcecao(ex);
        }

        public Resultado(Resultado resultado)
            : this(resultado.Sucesso)
        {
            if (!Sucesso)
            {
                if (resultado.ResultadoExcecao)
                {
                    ResultadoExcecao = resultado.ResultadoExcecao;
                }
            }
            Mensagens.AddRange(resultado.Mensagens);
        }

        public Resultado(string mensagemErro)
            : this(false)
        {
            var mensagem = new Mensagem();
            mensagem.Informacoes.Add(mensagemErro);
            Mensagens.Add(mensagem);
        }
        #endregion Construtor(es)

        #region Método(s)
        public string ConsolidaMensagens(string separador)
        {
            if (Mensagens.Any())
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < Mensagens.Count; ++i)
                {
                    if (Mensagens[i].Informacoes.Any())
                    {
                        sb.Append(Mensagens[i].ConsolidaMensagem(separador));
                        if (i < (Mensagens.Count - 1))
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

        public void CarregarExcecao(Exception ex)
        {
            Sucesso = false;
            Mensagem mensagem = new Mensagem(ex);
            mensagem.Informacoes.Add(ex.Message);
            Mensagens.Add(mensagem);
        }

        public virtual Resultado Adicionar(Resultado resultado)
        {
            if (Sucesso != (Sucesso && resultado.Sucesso))
            {
                Sucesso = resultado.Sucesso;
                AdicionarMensagens(resultado);
            }
            return this;
        }

        public virtual void AdicionarMensagens(Resultado resultado)
        {
            Mensagens.AddRange(resultado.Mensagens);
        }
        #endregion Método(s)

        #region Operador(es)
        public static Resultado operator +(Resultado r1, Resultado r2)
        {
            return new Resultado(resultado: r1).Adicionar(r2);
        }

        public static Resultado operator +(Resultado r1, string mensagemErro)
        {
            return new Resultado(resultado: r1).Adicionar(new Resultado(mensagemErro: mensagemErro));
        }

        public static implicit operator bool(Resultado r)
        {
            return r.Sucesso;
        }

        public static implicit operator Resultado(Exception ex)
        {
            return new Resultado(ex);
        }

        public static implicit operator Resultado(bool sucesso)
        {
            return new Resultado(sucesso: sucesso);
        }
        #endregion Operador(es)
    }
}
