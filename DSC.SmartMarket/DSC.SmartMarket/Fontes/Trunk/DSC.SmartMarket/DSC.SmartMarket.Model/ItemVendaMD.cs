using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace DSC.SmartMarket.Model
{
    [MetadataType(typeof(ItemVenda.ItemVendaMD))]
    partial class ItemVenda
    {
        private class ItemVendaMD
        {
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Identificador da Venda.", Ruleset = "Incluir")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Identificador da Venda.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Identificador da Venda.", Ruleset = "Excluir")]
            public int IdVenda { get; set; }

            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Numero do Item.", Ruleset = "Incluir")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Numero do Item.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Numero do Item.", Ruleset = "Excluir")]
            public int NumeroItem { get; set; }

            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Identificador do Mercado.", Ruleset = "Incluir")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Identificador do Mercado.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Identificador do Mercado.", Ruleset = "Excluir")]
            public int IdMercado { get; set; }

            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Incluir")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Alterar")]
            public int IdProduto { get; set; }
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Valor do Produto.", Ruleset = "Incluir")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Valor do Produto.", Ruleset = "Alterar")]
            public double ValorProduto { get; set; }

            public Nullable<long> RFIDSerial { get; set; }

        }
        
    }
    
}
