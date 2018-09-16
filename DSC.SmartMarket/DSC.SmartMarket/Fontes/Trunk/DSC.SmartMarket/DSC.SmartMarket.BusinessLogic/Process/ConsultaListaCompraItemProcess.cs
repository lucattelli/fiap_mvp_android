using DSC.SmartMarket.BusinessLogic.Repository;
using DSC.SmartMarket.BusinessLogic.Validation;
using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Process
{
    internal class ConsultaListaCompraItemProcess : ProcessBase, IConsultaListaCompraItemProcess
    {
        #region Propriedade(s)
        private IConsultaListaCompraValidation ConsultaListaCompraValidation
        {
            get
            {
                var resultado = Resolve<IConsultaListaCompraValidation>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IConsultaListaCompraValidation>(resultado);
            }
        }

        private IConsultaListaCompraItemValidation ConsultaListaCompraItemValidation
        {
            get
            {
                var resultado = Resolve<IConsultaListaCompraItemValidation>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IConsultaListaCompraItemValidation>(resultado);
            }
        }

        private IConsultaListaCompraItemRepository ConsultaListaCompraItemRepository
        {
            get
            {
                var resultado = Resolve<IConsultaListaCompraItemRepository>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IConsultaListaCompraItemRepository>(resultado);
            }
        }
        #endregion Propriedade(s)

        #region Método(s)
        public Resultado<IList<ConsultaListaCompraItem>> ListarPorConsultaListaCompra(ConsultaListaCompra consultaListaCompra)
        {
            var resultado = new Resultado<IList<ConsultaListaCompraItem>>();
            try
            {
                resultado += ConsultaListaCompraValidation.Validate(consultaListaCompra, ConsultaListaCompraOperation.Consultar);
                if (resultado)
                {
                    resultado = ConsultaListaCompraItemRepository.SelecionarPorConsultaListaCompra(consultaListaCompra);
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ConsultaListaCompraItem> Consultar(ConsultaListaCompraItem consultaListaCompraItem)
        {
            var resultado = new Resultado<ConsultaListaCompraItem>();
            try
            {
                resultado += ConsultaListaCompraItemValidation.Validate(consultaListaCompraItem, ConsultaListaCompraItemOperation.Consultar);
                if (resultado)
                {
                    resultado = ConsultaListaCompraItemRepository.Selecionar(consultaListaCompraItem);
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ConsultaListaCompraItem> Incluir(ConsultaListaCompraItem consultaListaCompraItem)
        {
            var resultado = new Resultado<ConsultaListaCompraItem>();
            try
            {
                resultado += ConsultaListaCompraItemValidation.Validate(consultaListaCompraItem, ConsultaListaCompraItemOperation.Incluir);
                if (resultado)
                {
                    resultado += ConsultaListaCompraItemRepository.Inserir(consultaListaCompraItem);
                    if (resultado)
                    {
                        resultado = ConsultaListaCompraItemRepository.Selecionar(consultaListaCompraItem);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }
        #endregion Método(s)
    }
}
