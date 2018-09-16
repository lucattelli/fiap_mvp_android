using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    internal class ListaCompraItemRepository : RepositoryBase<ListaCompraItem>, IListaCompraItemRepository
    {
        #region Método(s)
        public Resultado<IList<ListaCompraItem>> SelecionarPorListaCompra(ListaCompra listaCompra)
        {
            var resultado = new Resultado<IList<ListaCompraItem>>();
            try
            {
                var resultadoSelect = Select();
                resultado += resultadoSelect;
                if (resultado)
                {
                    var query = resultadoSelect.Retorno
                        .Include("Produto")
                        .AsQueryable();
                    query.Where(lci => lci.IdListaCompra == listaCompra.Id);
                    resultado.Retorno = query.ToList();
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ListaCompraItem> Selecionar(ListaCompraItem listaCompraItem)
        {
            var resultado = new Resultado<ListaCompraItem>();
            try
            {
                var resultadoSelect = Select();
                resultado += resultadoSelect;
                if (resultado)
                {
                    var query = resultadoSelect.Retorno
                        .Include("Produto")
                        .AsQueryable();
                    query.Where(lci => 
                        (lci.IdListaCompra == listaCompraItem.IdListaCompra) &&
                        (lci.IdProduto == listaCompraItem.IdProduto));
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
