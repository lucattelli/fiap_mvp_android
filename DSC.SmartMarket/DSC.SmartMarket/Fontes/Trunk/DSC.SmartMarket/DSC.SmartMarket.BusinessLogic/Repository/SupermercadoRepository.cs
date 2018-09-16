using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    internal class SupermercadoRepository : RepositoryBase<Supermercado>, ISupermercadoRepository
    {
        public Resultado<Supermercado> Selecionar(Supermercado supermercadoFiltro)
        {
            var resultado = new Resultado<Supermercado>(true);
            try
            {
                var resultadoSelect = Select();
                resultado += resultadoSelect;
                if (resultado)
                {
                    var query = resultadoSelect.Retorno
                        .Where(prod => prod.Id == supermercadoFiltro.Id);
                    resultado.Retorno = query.SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                resultado = new Resultado<Supermercado>(ex);
            }
            return resultado;
        }


        public Resultado<Supermercado> SelecionarPorNome(Supermercado supermercadoFiltro)
        {
            var resultado = new Resultado<Supermercado>();
            try
            {
                var resultadoSelect = Select();
                resultado += resultadoSelect;
                if (resultado)
                {
                    var query = resultadoSelect.Retorno
                        .Where(prod => prod.Nome == supermercadoFiltro.Nome);
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
