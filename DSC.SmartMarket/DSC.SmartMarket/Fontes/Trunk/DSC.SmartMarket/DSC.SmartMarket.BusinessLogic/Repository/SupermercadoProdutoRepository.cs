using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    internal class SupermercadoProdutoRepository : RepositoryBase<SupermercadoProduto>, ISupermercadoProdutoRepository
    {
        #region Método(s)
        public Resultado<SupermercadoProduto> Selecionar(SupermercadoProduto supermercadoProduto)
        {
            var resultado = new Resultado<SupermercadoProduto>();
            try
            {
                var resultadoSelect = Select();
                resultado += resultadoSelect;
                if (resultado)
                {
                    var query = resultadoSelect.Retorno.AsQueryable();
                    query = query.Where(sup =>
                        (sup.IdMercado == supermercadoProduto.IdMercado) &&
                        (sup.IdProduto == supermercadoProduto.IdProduto));
                    resultado.Retorno = query.SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                resultado += ex;
            }
            return resultado;
        }

        public Resultado<IList<SupermercadoProduto>> SelecionarPorSupermercado(Supermercado supermercado)
        {
            var resultado = new Resultado<IList<SupermercadoProduto>>();
            try
            {
                var resultadoSelect = Select();
                resultado += resultadoSelect;
                if (resultado)
                {
                    var query = resultadoSelect.Retorno.AsQueryable();
                    query = query.Where(sup =>
                        (sup.IdMercado == supermercado.Id));
                    resultado.Retorno = query.ToList();
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
