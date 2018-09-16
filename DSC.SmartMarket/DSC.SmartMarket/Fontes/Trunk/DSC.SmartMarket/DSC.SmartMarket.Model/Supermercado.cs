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
    
    public partial class Supermercado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supermercado()
        {
            this.ListaSecao = new HashSet<Secao>();
            this.ListaSupermercadoProduto = new HashSet<SupermercadoProduto>();
            this.ListaVenda = new HashSet<Venda>();
            this.ListaConsulta = new HashSet<ConsultaListaCompra>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public string IdGeocode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Secao> ListaSecao { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupermercadoProduto> ListaSupermercadoProduto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venda> ListaVenda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsultaListaCompra> ListaConsulta { get; set; }
    }
}
