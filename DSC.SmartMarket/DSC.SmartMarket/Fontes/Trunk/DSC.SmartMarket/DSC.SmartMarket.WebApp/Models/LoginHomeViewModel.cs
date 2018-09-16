using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSC.SmartMarket.WebApp.Models
{
    public class LoginHomeViewModel
    {
        public string Email
        { get; set; }

        public string Senha
        { get; set; }
    }
}