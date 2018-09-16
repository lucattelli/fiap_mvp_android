using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace DSC.SmartMarket.Model
{
    [MetadataType(typeof(SupermercadoProduto.SupermercadoProdutoMD))]
    partial class SupermercadoProduto
    {

        private class SupermercadoProdutoMD
        {
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Excluir")]
            public int IdMercado { get; set; }

            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Excluir")]
            public int IdProduto { get; set; }

            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Valor do Produto.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Valor do Produto.", Ruleset = "Excluir")]
            public double ValorProduto { get; set; }

            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Quantidade Estoque.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Quantidade Estoque.", Ruleset = "Excluir")]
            public double QuantidadeEstoque { get; set; }
        }

    }
}
