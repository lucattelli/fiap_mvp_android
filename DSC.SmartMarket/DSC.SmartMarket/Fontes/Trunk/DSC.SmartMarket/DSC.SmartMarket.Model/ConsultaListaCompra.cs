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
    
    public partial class ConsultaListaCompra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConsultaListaCompra()
        {
            this.ListaItem = new HashSet<ConsultaListaCompraItem>();
        }
    
        public int IdListaCompra { get; set; }
        public int IdMercado { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public double ValorTotal { get; set; }
        public int DistanciaMaxima { get; set; }
        public bool SomenteDentroMunicipio { get; set; }
        public string IdGeocode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsultaListaCompraItem> ListaItem { get; set; }
        public virtual ListaCompra ListaCompra { get; set; }
        public virtual Supermercado Supermercado { get; set; }
    }
}
