using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;


namespace DSC.SmartMarket.Model
{
    [MetadataType(typeof(Cliente.ClienteMD))]
    partial class Cliente
    {
        private class ClienteMD
        { 
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, 
                ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, 
                ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Excluir")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Consultar")]
            public int Id { get; set; }

            [NotNullValidator(ErrorMessage = "Por favor preencha o campo Nome.", Ruleset = "Incluir")]
            [NotNullValidator(ErrorMessage = "Por favor preencha o campo Nome.", Ruleset = "Alterar")]
            public string Nome { get; set; }

            [NotNullValidator(ErrorMessage = "Por favor preencha o campo CPF.", Ruleset = "Incluir")]
            [NotNullValidator(ErrorMessage = "Por favor preencha o campo CPF.", Ruleset = "Alterar")]
            public string CPF { get; set; }

            [NotNullValidator(ErrorMessage = "Por favor preencha o campo RG.", Ruleset = "Incluir")]
            [NotNullValidator(ErrorMessage = "Por favor preencha o campo RG.", Ruleset = "Alterar")]
            public string RG { get; set; }

            [NotNullValidator(ErrorMessage = "Por favor preencha o campo Email.", Ruleset = "Incluir")]
            [NotNullValidator(ErrorMessage = "Por favor preencha o campo Email.", Ruleset = "Alterar")]
            [RegexValidator(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$",
                ErrorMessage ="Favor preencher o campo Email no formato aaa@dominio.com", Ruleset ="Incluir")]
            [RegexValidator(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$",
                ErrorMessage = "Favor preencher o campo Email no formato aaa@dominio.com", Ruleset = "Alterar")]
            public string Email { get; set; }

            [NotNullValidator(ErrorMessage = "Por favor preencha o campo Telefone.", Ruleset = "Incluir")]
            [NotNullValidator(ErrorMessage = "Por favor preencha o campo Telefone.", Ruleset = "Alterar")]
            public string Telefone { get; set; }
        }
    }
}
