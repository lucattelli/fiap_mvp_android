using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace DSC.SmartMarket.Model
{
    [MetadataType(typeof(Produto.ProdutoMD))]
    partial class Produto
    {
        private class ProdutoMD
        {
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Excluir")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Consultar")]
            int Id { get; set; }

            [NotNullValidator(ErrorMessage = "Por favor preencha o campo Nome.", Ruleset = "Incluir")]
            [NotNullValidator(ErrorMessage = "Por favor preencha o campo Nome.", Ruleset = "Alterar")]
            [StringLengthValidator(3, RangeBoundaryType.Inclusive, 100, RangeBoundaryType.Inclusive,
                ErrorMessage = "Por favor preencha o campo Nome com no mínimo 3 caracteres e no máximo 100 carecteres.", Ruleset = "Incluir")]
            [StringLengthValidator(3, RangeBoundaryType.Inclusive, 100, RangeBoundaryType.Inclusive,
                ErrorMessage = "Por favor preencha o campo Nome com no mínimo 3 caracteres e no máximo 100 carecteres.", Ruleset = "Alterar")]
            string Nome { get; set; }

            [RangeValidator(0d, RangeBoundaryType.Exclusive, 0d, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Peso Médio com valor maior que zero.", Ruleset = "Incluir")]
            [RangeValidator(0d, RangeBoundaryType.Exclusive, 0d, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Peso Médio com valor maior que zero.", Ruleset = "Alterar")]
            [PropertyComparisonValidator("PesoMinimo", ComparisonOperator.GreaterThanEqual,
                ErrorMessage = "Favor preencher o campo Peso Médio com valor igual ou superior ao preenchido no campo Peso Mínimo.", Ruleset = "Incluir")]
            [PropertyComparisonValidator("PesoMinimo", ComparisonOperator.GreaterThanEqual,
                ErrorMessage = "Favor preencher o campo Peso Médio com valor igual ou superior ao preenchido no campo Peso Mínimo.", Ruleset = "Alterar")]
            double PesoMedio { get; set; }

            [RangeValidator(0d, RangeBoundaryType.Exclusive, 0d, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Peso Máximo com valor maior que zero.", Ruleset = "Incluir")]
            [RangeValidator(0d, RangeBoundaryType.Exclusive, 0d, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Peso Máximo com valor maior que zero.", Ruleset = "Alterar")]
            [PropertyComparisonValidator("PesoMedio", ComparisonOperator.GreaterThanEqual,
                ErrorMessage = "Favor preencher o campo Peso Máximo com valor igual ou superior ao preenchido no campo Peso Médio.", Ruleset = "Incluir")]
            [PropertyComparisonValidator("PesoMedio", ComparisonOperator.GreaterThanEqual,
                ErrorMessage = "Favor preencher o campo Peso Máximo com valor igual ou superior ao preenchido no campo Peso Médio.", Ruleset = "Alterar")]
            double PesoMaximo { get; set; }

            [RangeValidator(0d, RangeBoundaryType.Exclusive, 0d, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Peso Mínimo com valor maior que zero.", Ruleset = "Incluir")]
            [RangeValidator(0d, RangeBoundaryType.Exclusive, 0d, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Peso Mínimo com valor maior que zero.", Ruleset = "Alterar")]
           double PesoMinimo { get; set; }

        }
    }
}
