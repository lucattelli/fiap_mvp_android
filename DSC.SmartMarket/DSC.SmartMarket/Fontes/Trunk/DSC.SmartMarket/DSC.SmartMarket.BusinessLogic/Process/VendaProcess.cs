using DSC.SmartMarket.BusinessLogic.Repository;
using DSC.SmartMarket.BusinessLogic.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal class VendaProcess : ProcessBase, IVendaProcess
    {
        #region Propriedade(s)
        private IVendaRepository VendaRepository
        {
            get
            {
                var resultado = Resolve<IVendaRepository>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return null;
            }
        }

        private IVendaValidation VendaValidation
        {
            get
            {
                var resultado = Resolve<IVendaValidation>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return null;

            }
        }
        #endregion Propriedade(s)
    }
}
