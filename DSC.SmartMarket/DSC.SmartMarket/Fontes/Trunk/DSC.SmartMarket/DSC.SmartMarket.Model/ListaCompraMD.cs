using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.Model
{
    [MetadataType(typeof(ListaCompra.ListaCompraMD))]
    partial class ListaCompra
    {
        private class ListaCompraMD
        {
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                           ErrorMessage = "Favor preencher o campo Identificador da Venda.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                           ErrorMessage = "Favor preencher o campo Identificador da Venda.", Ruleset = "Excluir")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                           ErrorMessage = "Favor preencher o campo Identificador da Venda.", Ruleset = "Consultar")]
            public int Id { get; set; }
        }
    }
}
