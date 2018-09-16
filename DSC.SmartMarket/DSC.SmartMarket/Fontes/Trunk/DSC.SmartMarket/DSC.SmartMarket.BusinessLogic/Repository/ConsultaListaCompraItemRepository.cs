using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSC.SmartMarket.Model;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    internal class ConsultaListaCompraItemRepository : RepositoryBase<ConsultaListaCompraItem>, IConsultaListaCompraItemRepository
    {
        public Resultado<IList<ConsultaListaCompraItem>> SelecionarPorConsultaListaCompra(ConsultaListaCompra consultaListaCompra)
        {
            var resultado = new Resultado<IList<ConsultaListaCompraItem>>();
            try
            {
                var resultadoSelect = Select();
                resultado += resultadoSelect;
                if (resultado)
                {
                    var query = resultadoSelect.Retorno
                        .AsQueryable();
                    query = query
                        .Where(clci => 
                            (clci.IdListaCompra == consultaListaCompra.IdListaCompra) &&
                            (clci.IdMercado == consultaListaCompra.IdMercado) &&
                            (clci.DataCriacao == consultaListaCompra.DataCriacao))
                        .OrderBy(clci => clci.ListaCompraItem.Produto.Nome);
                    resultado.Retorno = query.ToList();
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<ConsultaListaCompraItem> Selecionar(ConsultaListaCompraItem consultaListaCompraItem)
        {
            var resultado = new Resultado<ConsultaListaCompraItem>();
            try
            {
                var resultadoSelect = Select();
                resultado += resultadoSelect;
                if (resultado)
                {
                    var query = resultadoSelect.Retorno
                        .AsQueryable();
                    query = query
                        .Where(clci =>
                            (clci.IdListaCompra == consultaListaCompraItem.IdListaCompra) &&
                            (clci.IdMercado == consultaListaCompraItem.IdMercado) &&
                            (clci.DataCriacao == consultaListaCompraItem.DataCriacao) &&
                            (clci.IdProduto == consultaListaCompraItem.IdProduto));
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
