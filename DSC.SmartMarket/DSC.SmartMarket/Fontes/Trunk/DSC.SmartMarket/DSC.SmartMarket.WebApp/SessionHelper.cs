using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSC.SmartMarket.WebApp
{
    public static class SessionHelper
    {
        #region Constante(s)
        private const string m_sesKeyUsuarioLogado = "Session_sesKeyUsuarioLogado";
        #endregion Constante(s)

        #region Método(s)
        public static Usuario GetUsuarioLogado(this HttpSessionStateBase session)
        {
            return session[m_sesKeyUsuarioLogado] as Usuario;
        }

        public static bool IsLogado(this HttpSessionStateBase session)
        {
            return session.GetUsuarioLogado() != null;
        }

        public static void SetUsuarioLogado(this HttpSessionStateBase session, Usuario usuario)
        {
            if (usuario != null)
            {
                session[m_sesKeyUsuarioLogado] = usuario;
            }
            else
            {
                session.Remove(m_sesKeyUsuarioLogado);
            }
        }
        #endregion Método(s)
    }
}