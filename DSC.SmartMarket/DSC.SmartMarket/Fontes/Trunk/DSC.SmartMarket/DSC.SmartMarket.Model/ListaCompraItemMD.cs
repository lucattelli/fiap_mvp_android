using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.Model
{
    [MetadataType(typeof(ListaCompraItem.ListaCompraItemMD))]
    partial class ListaCompraItem
    {
        private class ListaCompraItemMD
        {
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                           ErrorMessage = "Favor preencher o campo Identificador da Lista de Compra.", Ruleset = "Incluir")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                           ErrorMessage = "Favor preencher o campo Identificador da Lista de Compra.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                           ErrorMessage = "Favor preencher o campo Identificador da Lista de Compra.", Ruleset = "Excluir")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                           ErrorMessage = "Favor preencher o campo Identificador da Lista de Compra.", Ruleset = "Consultar")]
            public int IdListaCompra { get; set; }

            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                           ErrorMessage = "Favor preencher o campo Identificador de Produto.", Ruleset = "Incluir")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                           ErrorMessage = "Favor preencher o campo Identificador de Produto.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                           ErrorMessage = "Favor preencher o campo Identificador de Produto.", Ruleset = "Excluir")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                           ErrorMessage = "Favor preencher o campo Identificador de Produto.", Ruleset = "Consultar")]
            public int IdProduto { get; set; }
        }
    }
}
