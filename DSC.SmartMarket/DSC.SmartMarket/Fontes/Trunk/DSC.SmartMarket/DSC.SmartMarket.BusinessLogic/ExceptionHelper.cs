using DSC.SmartMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic
{
    public static class ExceptionHelper
    {
        public static object ThrowUnableToResolve(Type type, string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new UnableToResolveException(type.FullName + " não pode ser resolvida pelo container IoC.");
            else
                throw new UnableToResolveException(type.FullName + " não pode ser resolvida pelo container IoC. " + message);
        }

        public static object ThrowUnableToResolve(Type type)
        {
            return ThrowUnableToResolve(type, string.Empty);
        }

        public static object ThrowUnableToResolve(Type type, Resultado resultado)
        {
            return ThrowUnableToResolve(type, resultado.ConsolidaMensagens(" "));
        }

        public static T ThrowUnableToResolve<T>(string message)
        {
            return (T)ThrowUnableToResolve(typeof(T), string.Empty);
        }

        public static T ThrowUnableToResolve<T>()
        {
            return ThrowUnableToResolve<T>(string.Empty);
        }

        public static T ThrowUnableToResolve<T>(Resultado resultado)
        {
            return ThrowUnableToResolve<T>(resultado.ConsolidaMensagens(" "));
        }
    }
}
