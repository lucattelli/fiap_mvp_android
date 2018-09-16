using DSC.SmartMarket.BusinessLogic.Repository;
using DSC.SmartMarket.BusinessLogic.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal class ItemVendaProcess : ProcessBase, IItemVendaProcess
    {
        #region Propriedade(s)
        private IItemVendaRepository ItemVendaRepository
        {
            get
            {
                var resultado = Resolve<IItemVendaRepository>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return null;
            }
        }

        private IItemVendaValidation ItemVendaValidation
        {
            get
            {
                var resultado = Resolve<IItemVendaValidation>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return null;
            }
        }
        #endregion Propriedade(s)
    }
}
