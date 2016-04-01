using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace Tms.Common.IoC
{
    public static class ModuleLoader
    {
        public static IDependencyResolver LoadResolver()
        {
            var container = new UnityContainer();

            LoadContainer(container, ".\\bin", "Tms.*.dll");

            return new UnityDependencyResolver(container);
        }
        
        public static void LoadContainer(IUnityContainer container, string path, string pattern)
        {
            var dirCat = new DirectoryCatalog(path, pattern);

            var importDef = BuildImportDefinition();

            try
            {
                using (var aggregateCatalog = new AggregateCatalog())
                {
                    aggregateCatalog.Catalogs.Add(dirCat);
                    using (var componsitionContainer = new CompositionContainer(aggregateCatalog))
                    {
                        IEnumerable<Export> exports = componsitionContainer.GetExports(importDef);
                        IEnumerable<IModule> modules =
                            exports.Select(export => export.Value as IModule).Where(m => m != null);
                        var registrar = new ModuleRegister(container);
                        foreach (IModule module in modules)
                        {
                            module.Initialize(registrar);
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException typeLoadException)
            {
                var builder = new StringBuilder();

                foreach (Exception loaderException in typeLoadException.LoaderExceptions)
                {
                    builder.Append($"{loaderException.Message}\n");
                }

                throw new TypeLoadException(builder.ToString(), typeLoadException);
            }
        }
        private static ImportDefinition BuildImportDefinition()
        {
            return new ImportDefinition(
                def => true, typeof(IModule).FullName, 
                ImportCardinality.ZeroOrMore, 
                false, 
                false);
        }
    }
}