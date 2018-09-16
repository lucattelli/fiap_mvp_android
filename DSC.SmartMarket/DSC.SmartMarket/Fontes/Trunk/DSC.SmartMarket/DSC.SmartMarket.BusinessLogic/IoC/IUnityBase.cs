using DSC.SmartMarket.Model;

namespace DSC.SmartMarket.BusinessLogic.IoC
{
    public interface IUnityBase
    {
        Resultado<T> Resolve<T>();
    }
}
