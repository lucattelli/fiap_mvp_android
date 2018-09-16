using DSC.SmartMarket.BusinessLogic.Repository;
using DSC.SmartMarket.BusinessLogic.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal class SecaoProcess : ProcessBase, ISecaoProcess
    {
        #region Propriedade(s)
        private ISecaoRepository SecaoRepository
        {
            get
            {
                var resultado = Resolve<ISecaoRepository>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return null;
            }
        }

        private ISecaoValidation SecaoValidation
        {
            get
            {
                var resultado = Resolve<ISecaoValidation>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return null;
            }
        }
        #endregion Propriedade(s)
    }
}
