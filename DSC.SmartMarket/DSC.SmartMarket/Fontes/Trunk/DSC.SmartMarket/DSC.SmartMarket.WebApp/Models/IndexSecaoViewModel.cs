using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSC.SmartMarket.WebApp.Models
{
    public class IndexSecaoViewModel
    {
        public TipoOperacao Operacao
        { get; set; }

        public enum TipoOperacao
        {
            Listar,
            Inserir,
            Editar
        }
    }
}