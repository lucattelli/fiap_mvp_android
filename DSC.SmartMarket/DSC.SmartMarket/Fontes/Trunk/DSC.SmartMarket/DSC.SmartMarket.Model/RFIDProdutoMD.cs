using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace DSC.SmartMarket.Model
{
    [MetadataType(typeof(RFIDProduto.RFIDProdutoMD))]
    partial class RFIDProduto
    {
        private class RFIDProdutoMD
        {
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, 
                ErrorMessage = "Favor preencher o campo Identificador do Mercado.", Ruleset = "Incluir")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, 
                ErrorMessage = "Favor preencher o campo Identificador do Mercado.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, 
                ErrorMessage = "Favor preencher o campo Identificador do Mercado.", Ruleset = "Excluir")]
            public int IdMercado { get; set; }

            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, 
                ErrorMessage = "Favor preencher o campo Identificador do Produto.", Ruleset = "Incluir")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, 
                ErrorMessage = "Favor preencher o campo Identificador do Produto.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, 
                ErrorMessage = "Favor preencher o campo Identificador do Produto.", Ruleset = "Excluir")]
            public int IdProduto { get; set; }

            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, 
                ErrorMessage = "Favor preencher o campo Identificador Serial RFID.", Ruleset = "Incluir")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, 
                ErrorMessage = "Favor preencher o campo Identificador Serial RFID.", Ruleset = "Alterar")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore, 
                ErrorMessage = "Favor preencher o campo Identificador Serial RFID.", Ruleset = "Excluir")]
            public long RFIDSerial { get; set; }

            public System.DateTime DataEmisao { get; set; }
            
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Data Consumo.", Ruleset = "Incluir")]
            [RangeValidator(0, RangeBoundaryType.Exclusive, 0, RangeBoundaryType.Ignore,
                ErrorMessage = "Favor preencher o campo Data Consumo.", Ruleset = "Alterar")]
            public Nullable<System.DateTime> DataConsumo { get; set; }

            public Nullable<System.DateTime> DataUltimaLeitura { get; set; }
        }
    }
}
