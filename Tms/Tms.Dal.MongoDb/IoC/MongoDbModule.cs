using System.ComponentModel.Composition;
using MongoDB.Driver;
using Tms.Common.Constants;
using Tms.Common.Enums;
using Tms.Common.IoC;
using Tms.Configuration;
using Tms.Contracts.Dal.Repositories;
using Tms.Dal.MongoDb.Base;
using Tms.Dal.MongoDb.Constants;
using Tms.Dal.MongoDb.Repositories;

namespace Tms.Dal.MongoDb.IoC
{
    [Export(typeof(IModule))]
    public class MongoDbModule : IModule
    {
        public void Initialize(IModuleRegister register)
        {
            register.RegisterFactory<IMongoClient>(r => 
                new MongoClient(r.Resolve<IConfigProvider>().GetSetting<string>(
                    section: MongoConfigKeys.MongoSection, 
                    key: MongoConfigKeys.MongoConnectionString)
                ), 
                ModuleLifetime.Singleton
            );

            register.RegisterFactory<IMongoDatabase>(r =>
               r.Resolve<IMongoClient>().GetDatabase(r.Resolve<IConfigProvider>()
                   .GetSetting<string>(
                        section: MongoConfigKeys.MongoSection,
                        key: MongoConfigKeys.MongoDatabase
                    )
               ),
               ModuleLifetime.Hierarchical
           );

            register.RegisterType<IUserRepository, UserRepository>();

            BsonMapper.Register();
        }
    }
}