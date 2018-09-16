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
    internal class ConsultaListaCompraProcess : ProcessBase, IConsultaListaCompraProcess
    {
        #region Propriedade(s)
        private IListaCompraValidation ListaCompraValidation
        {
            get
            {
                var resultado = Resolve<IListaCompraValidation>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IListaCompraValidation>(resultado);
            }
        }

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

        private IConsultaListaCompraRepository ConsultaListaCompraRepository
        {
            get
            {
                var resultado = Resolve<IConsultaListaCompraRepository>();
                if (resultado)
                    return resultado.Retorno;
                else
                    return ThrowUnableToResolve<IConsultaListaCompraRepository>(resultado);
            }
        }
        #endregion Propriedade(s)

        #region Método(s)
        public Resultado<IList<ConsultaListaCompra>> ListarPorListaCompra(ListaCompra listaCompra)
        {
            var resultado = new Resultado<IList<ConsultaListaCompra>>();
            try
            {
                resultado += ListaCompraValidation.Validate(listaCompra, ListaCompraOperation.Consultar);
                if (resultado)
                {
                    resultado = ConsultaListaCompraRepository.SelecionarPorListaCompra(listaCompra);
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }


        public Resultado<ConsultaListaCompra> Consultar(ConsultaListaCompra consultaListaCompra)
        {
            var resultado = new Resultado<ConsultaListaCompra>();
            try
            {
                resultado += ConsultaListaCompraValidation.Validate(consultaListaCompra, ConsultaListaCompraOperation.Consultar);
                if (resultado)
                {
                    resultado = ConsultaListaCompraRepository.Selecionar(consultaListaCompra);
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ConsultaListaCompra> Incluir(ConsultaListaCompra consultaListaCompra)
        {
            var resultado = new Resultado<ConsultaListaCompra>();
            try
            {
                consultaListaCompra.DataCriacao = DateTime.Now;
                resultado += ConsultaListaCompraValidation.Validate(consultaListaCompra, ConsultaListaCompraOperation.Incluir);
                if (resultado)
                {
                    resultado += ConsultaListaCompraRepository.Inserir(consultaListaCompra);
                    if (resultado)
                    {
                        resultado = ConsultaListaCompraRepository.Selecionar(consultaListaCompra);
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
