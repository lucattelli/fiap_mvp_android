//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DSC.SmartMarket.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemVenda
    {
        public int IdVenda { get; set; }
        public int NumeroItem { get; set; }
        public int IdMercado { get; set; }
        public int IdProduto { get; set; }
        public double ValorProduto { get; set; }
        public Nullable<long> RFIDSerial { get; set; }
    
        public virtual RFIDProduto RFIDProduto { get; set; }
        public virtual SupermercadoProduto SupermercadoProduto { get; set; }
        public virtual Venda Venda { get; set; }
    }
}
