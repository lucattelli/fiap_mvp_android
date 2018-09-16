using DSC.SmartMarket.BusinessLogic.Repository;
using DSC.SmartMarket.BusinessLogic.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal class RFIDProdutoProcess : ProcessBase, IRFIDProdutoProcess
    {
        #region Propriedade(s)
        private IRFIDProdutoRepository RFIDProdutoRepository
        {
            get
            {
                var resultado = Resolve<IRFIDProdutoRepository>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return null;
            }
        }

        private IRFIDProdutoValidation RFIDProdutoValidation
        {
            get
            {
                var resultado = Resolve<IRFIDProdutoValidation>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return null;
            }
        }
        #endregion Propriedade(s)
    }
}
