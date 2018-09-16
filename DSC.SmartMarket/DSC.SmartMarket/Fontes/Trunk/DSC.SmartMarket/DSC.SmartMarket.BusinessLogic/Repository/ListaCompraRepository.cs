using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    internal class ListaCompraRepository : RepositoryBase<ListaCompra>, IListaCompraRepository
    {
        #region Método(s)
        public Resultado<IList<ListaCompra>> SelecionarPorCliente(Cliente cliente)
        {
            var resultado = new Resultado<IList<ListaCompra>>();
            try
            {
                var resultadoSelect = Select();
                resultado += resultadoSelect;
                if (resultado)
                {
                    var query = resultadoSelect.Retorno.AsQueryable();
                    query = query.Where(lic => lic.IdCliente == cliente.Id);
                    query = query.OrderByDescending(lic => lic.DataCriacao);
                    resultado.Retorno = query.ToList();
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ListaCompra> Selecionar(ListaCompra listaCompra)
        {
            var resultado = new Resultado<ListaCompra>();
            try
            {
                var resultadoSelect = Select();
                resultado += resultadoSelect;
                if (resultado)
                {
                    var query = resultadoSelect.Retorno.AsQueryable();
                    query = query.Where(lic => lic.Id == listaCompra.Id);
                    query = query.OrderByDescending(lic => lic.DataCriacao);
                    resultado.Retorno = query.SingleOrDefault();
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
