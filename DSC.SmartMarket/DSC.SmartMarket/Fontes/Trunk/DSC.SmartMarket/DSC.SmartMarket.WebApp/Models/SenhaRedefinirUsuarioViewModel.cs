using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSC.SmartMarket.WebApp.Models
{
    public class SenhaRedefinirUsuarioViewModel
    {
        public String Email
        { get; set; }

        public String EmailConfirmacao
        { get; set; }

        public String Senha
        { get; set; }

        public String SenhaConfirmacao
        { get; set; }
    }
}