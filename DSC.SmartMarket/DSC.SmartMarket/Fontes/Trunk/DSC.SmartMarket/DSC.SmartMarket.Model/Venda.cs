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
    
    public partial class Venda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Venda()
        {
            this.ListaItemVenda = new HashSet<ItemVenda>();
        }
    
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public Nullable<System.DateTime> DataVenda { get; set; }
        public int IdMercado { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemVenda> ListaItemVenda { get; set; }
        public virtual Supermercado Supermercado { get; set; }
    }
}