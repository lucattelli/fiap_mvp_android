using DSC.SmartMarket.BusinessLogic.Common;
using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    internal class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public Resultado<Produto> SelecionarPorId(Produto produtoFiltro)
        {
            var resultado = new Resultado<Produto>(true);
            try
            {
                var resultadoSelect = Select();
                if (resultadoSelect.Sucesso)
                {
                    var query = resultadoSelect.Retorno
                        .Where(prod => prod.Id == produtoFiltro.Id);
                    resultado.Retorno = query.SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado<Produto>(ex);
            }
            return resultado;
        }

        
        public Resultado<Produto> SelecionarPorNome(Produto produtoFiltro)
        {
            var resultado = new Resultado<Produto>(true);
            try
            {
                var resultadoSelect = Select();
                if (resultadoSelect.Sucesso)
                {
                    var query = resultadoSelect.Retorno
                        .Where(prod => prod.Nome == produtoFiltro.Nome);
                    resultado.Retorno = query.SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado<Produto>(ex);
            }
            return resultado;
        }
    }
}
