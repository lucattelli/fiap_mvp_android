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
    
    public partial class ListaCompra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ListaCompra()
        {
            this.ListaConsulta = new HashSet<ConsultaListaCompra>();
            this.ListaItem = new HashSet<ListaCompraItem>();
        }
    
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int IdCliente { get; set; }
        public int QuantidadeItem { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public System.DateTime DataAlteracao { get; set; }
        public Nullable<System.DateTime> DataUltimaConsulta { get; set; }
        public Nullable<System.DateTime> DataExclusao { get; set; }
        public bool Excluido { get; set; }
        public string IdGeocode { get; set; }
        public int DistanciaMaxima { get; set; }
        public bool SomenteDentroMunicipio { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsultaListaCompra> ListaConsulta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListaCompraItem> ListaItem { get; set; }
    }
}
