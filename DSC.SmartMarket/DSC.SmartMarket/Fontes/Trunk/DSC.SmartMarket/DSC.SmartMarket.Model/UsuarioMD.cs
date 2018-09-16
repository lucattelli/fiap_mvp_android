using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.Model
{
    [MetadataType(typeof(Usuario.UsuarioMD))]
    partial class Usuario
    {
        private class UsuarioMD
        {
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, ErrorMessage = "Favor preencher o campo Identificador.", Ruleset = "Excluir")]

            public int Id { get; set; }

            [NotNullValidator(ErrorMessage = "Por favor preencha o campo Nome.", Ruleset = "Incluir")]
            [NotNullValidator(ErrorMessage = "Por favor preencha o campo Nome.", Ruleset = "Alterar")]
            public string Nome { get; set; }

            [NotNullValidator(ErrorMessage = "Por favor preencha o campo Email.", Ruleset = "Incluir")]
            [NotNullValidator(ErrorMessage = "Por favor preencha o campo Email.", Ruleset = "Alterar")]
            public string Email { get; set; }

            [NotNullValidator(ErrorMessage = "Por favor preencha o campo Indicador de Cadastro Ativo.", Ruleset = "Incluir")]
            [NotNullValidator(ErrorMessage = "Por favor preencha o campo Indicador de Cadastro Ativo.", Ruleset = "Alterar")]
            public Nullable<bool> Ativo { get; set; }

            public Nullable<System.DateTime> DataCadastro { get; set; }

            public Nullable<System.DateTime> DataAlteracao { get; set; }

            public Nullable<bool> Deletado { get; set; }

            [NotNullValidator(ErrorMessage = "Por favor preencha o campo Senha.", Ruleset = "Incluir")]
            [NotNullValidator(ErrorMessage = "Por favor preencha o campo Senha.", Ruleset = "Alterar")]
            public string Senha { get; set; }

            public CodigoTipoUsuario IdTipoUsuario { get; set; }
        }
    }
}
