
using DSC.SmartMarket.BusinessLogic.IoC;
using DSC.SmartMarket.Model;
using System.Collections.Generic;

namespace DSC.SmartMarket.BusinessLogic.Repository
{
    public interface IRepositoryBase : IUnityBase { }

    public interface IRepositoryBase<T> : IRepositoryBase where T : class
    {
        Resultado<IList<T>> Selecionar(int? skip, int? take, string orderBy);

        Resultado<int> Contar();

        Resultado Inserir(T entity);

        Resultado Atualizar(T entity);

        Resultado Remover(T entity);
    }
}
