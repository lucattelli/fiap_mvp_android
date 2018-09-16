using Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using System.Reflection;
using System;
using System.Linq;

namespace DSC.SmartMarket.BusinessLogic.IoC
{
    public static class UnityContextHelper
    {
        #region Constante(s)
        public const string DefaultSectionName = "unity";
        #endregion Constante(s)

        #region Método(s)
        public static IUnityContainer LoadDefaultConfig(this IUnityContainer container)
        {
            container.LoadDefaultConfig(DefaultSectionName);
            return container;
        }

        public static IUnityContainer LoadDefaultConfigAllAssemblies(this IUnityContainer container, string rootNamespace)
        {
            var listaAssemblies = AppDomain.CurrentDomain.GetAssemblies()
               .Where(asb => asb.FullName.StartsWith(rootNamespace))
               .ToList();
            foreach (var assembly in listaAssemblies)
            {
                container.LoadDefaultConfig(assembly, DefaultSectionName);
            }
            return container;
        }

        public static IUnityContainer LoadDefaultConfig(this IUnityContainer container, string sectionName)
        {
            GetUnityConfigurationSection(sectionName).Configure(container);
            return container;
        }

        public static IUnityContainer LoadDefaultConfig(this IUnityContainer container, Assembly assembly, string sectionName)
        {
            var section = GetUnityConfigurationSection(assembly, sectionName);
            if (section != null)
            {
                section.Configure(container);
            }
            return container;
        }

        public static IUnityContainer LoadCustomConfig(this IUnityContainer container, string containerName)
        {
            container.LoadCustomConfig(DefaultSectionName, containerName);
            return container;
        }

        public static IUnityContainer LoadCustomConfig(this IUnityContainer container, string sectionName, string containerName)
        {
            GetUnityConfigurationSection(sectionName).Configure(container, containerName);
            return container;
        }

        private static UnityConfigurationSection GetUnityConfigurationSection(string sectionName)
        {
            return (UnityConfigurationSection)ConfigurationManager.GetSection(sectionName);
        }

        private static UnityConfigurationSection GetUnityConfigurationSection(Assembly assembly, string sectionName)
        {
            string path = new Uri(assembly.GetName().CodeBase).LocalPath;
            var config = ConfigurationManager.OpenExeConfiguration(path);
            return (UnityConfigurationSection)config.GetSection(sectionName);
        }
        #endregion Método(s)
    }
}
