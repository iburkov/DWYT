using System.ComponentModel.Composition;
using Tms.Common.IoC;
using Tms.Configuration.Implementation;

namespace Tms.Configuration.IoC
{
    [Export(typeof(IModule))]
    public class ConfigModule : IModule
    {
        public void Initialize(IModuleRegister register)
        {
            register.RegisterType<IConfigProvider, FileConfigProvider>(ModuleLifetime.Singleton);
        }
    }
}
