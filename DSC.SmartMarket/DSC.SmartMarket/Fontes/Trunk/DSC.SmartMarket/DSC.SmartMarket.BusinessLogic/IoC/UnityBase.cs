using DSC.SmartMarket.Model;
using Unity;
using Microsoft.Practices.Unity.Configuration;
using System;

namespace DSC.SmartMarket.BusinessLogic.IoC
{
    public abstract class UnityBase : IUnityBase
    {
        private static IUnityContainer m_container;

        private static IUnityContainer Container
        {
            get
            {
                if (m_container == null) 
                {
                    m_container = new UnityContainer();
                    m_container.LoadConfiguration();
                }
                return m_container;
            }
        }

        public static void SetContainer(IUnityContainer container)
        {
            m_container = container;
        }

        private static void RegisterType<T>()
        {
            Container.RegisterType<T>();
        }

        private static void RegisterType<I, T>() where T : I
        {
            Container.RegisterType<I, T>();
        }

        public Resultado<T> Resolve<T>()
        {
            Resultado<T> resultado;
            try
            {
                var target = Container.Resolve<T>();
                resultado = new Resultado<T>(target);
            }
            catch (Exception ex)
            {
                resultado = new Resultado<T>(ex);
            }
            return resultado;
        }

        protected object ThrowUnableToResolve(Type type, Resultado resultado)
        {
            return ExceptionHelper.ThrowUnableToResolve(type, resultado);
        }

        protected T ThrowUnableToResolve<T>()
        {
            return ExceptionHelper.ThrowUnableToResolve<T>();
        }

        protected T ThrowUnableToResolve<T>(Resultado resultado)
        {
            return ExceptionHelper.ThrowUnableToResolve<T>(resultado);
        }
    }
}
