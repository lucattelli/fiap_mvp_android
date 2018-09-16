using DSC.SmartMarket.BusinessLogic.IoC;
using DSC.SmartMarket.Model;
using System;

namespace DSC.SmartMarket.BusinessLogic.Validation
{
    public interface IValidationBase : IUnityBase
    {
        Resultado Validate();
        //Resultado Validate(object target, object operation);
    }

    public interface IValidationBase<T, O> : IValidationBase 
        where T : class
        where O : struct , IConvertible
    {
        Resultado Validate(T target, O operation);
    }
}
