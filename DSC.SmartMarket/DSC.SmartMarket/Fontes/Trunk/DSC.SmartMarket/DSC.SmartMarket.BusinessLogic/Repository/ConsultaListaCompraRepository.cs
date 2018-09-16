using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    internal class ConsultaListaCompraRepository : RepositoryBase<ConsultaListaCompra>, IConsultaListaCompraRepository
    {
        public Resultado<IList<ConsultaListaCompra>> SelecionarPorListaCompra(ListaCompra listaCompra)
        {
            var resultado = new Resultado<IList<ConsultaListaCompra>>();
            try
            {
                var resultadoSelect = Select();
                resultado += resultadoSelect;
                if (resultado)
                {
                    var query = resultadoSelect.Retorno
                        .AsQueryable();
                    query = query
                        .Where(clc => clc.IdListaCompra == listaCompra.Id)
                        .OrderByDescending(clc => clc.DataCriacao);
                    resultado.Retorno = query.ToList();
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ConsultaListaCompra> Selecionar(ConsultaListaCompra consultaListaCompra)
        {
            var resultado = new Resultado<ConsultaListaCompra>();
            try
            {
                var resultadoSelect = Select();
                resultado += resultadoSelect;
                if (resultado)
                {
                    var query = resultadoSelect.Retorno
                        .Include("ListaCompra")
                        .AsQueryable();
                    query = query
                        .Where(clc => 
                            (clc.IdListaCompra == consultaListaCompra.IdListaCompra) &&
                            (clc.IdMercado == consultaListaCompra.IdMercado) && 
                            (clc.DataCriacao == consultaListaCompra.DataCriacao));
                    resultado.Retorno = query.SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }
    }
}
