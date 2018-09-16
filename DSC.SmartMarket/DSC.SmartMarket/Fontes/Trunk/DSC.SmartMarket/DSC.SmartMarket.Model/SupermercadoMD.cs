using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace DSC.SmartMarket.Model
{
    [MetadataType(typeof(Supermercado.SupermercadoMD))]
    partial class Supermercado
    {

        private class SupermercadoMD
        {
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Excluir")]
            public int Id { get; set; }

            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Nome.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Nome.", Ruleset = "Excluir")]
            public string Nome { get; set; }
        }
    }
}
