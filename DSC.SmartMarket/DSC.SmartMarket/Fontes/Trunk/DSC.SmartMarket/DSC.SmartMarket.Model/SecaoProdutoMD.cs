using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace DSC.SmartMarket.Model
{
    [MetadataType(typeof(SecaoProduto.SecaoProdutoMD))]
    partial class SecaoProduto
    {
        private class SecaoProdutoMD
        {
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Excluir")]
            public int IdSecao { get; set; }

            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Excluir")]
            public int IdMercado { get; set; }

            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Excluir")]
            public int IdProduto { get; set; }
            
            public bool Ativo { get; set; }
        }
    }   
}
