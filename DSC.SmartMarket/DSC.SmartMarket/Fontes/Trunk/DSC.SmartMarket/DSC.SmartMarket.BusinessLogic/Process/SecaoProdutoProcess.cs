using DSC.SmartMarket.BusinessLogic.Repository;
using DSC.SmartMarket.BusinessLogic.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal class SecaoProdutoProcess : ProcessBase, ISecaoProdutoProcess
    {
        #region Propriedade(s)
        private ISecaoProdutoRepository SecaoProdutoRepository
        {
            get
            {
                var resultado = Resolve<ISecaoProdutoRepository>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return null;
            }
        }

        private ISecaoProdutoValidation SecaoProdutoValidation
        {
            get
            {
                var resultado = Resolve<ISecaoProdutoValidation>();
                if (resultado.Sucesso)
                    return resultado.Retorno;
                else
                    return null;
            }
        }
        #endregion Propriedade(s)
    }
}
