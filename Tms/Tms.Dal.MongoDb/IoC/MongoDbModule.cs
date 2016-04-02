using System.ComponentModel.Composition;
using Tms.Common.IoC;
using Tms.Contracts.Dal.Repositories;
using Tms.Dal.MongoDb.Repositories;

namespace Tms.Dal.MongoDb.IoC
{
    [Export(typeof(IModule))]
    public class MongoDbModule : IModule
    {
        public void Initialize(IModuleRegister register)
        {
            //register.RegisterType<IRepository, Repository>();
        }
    }
}