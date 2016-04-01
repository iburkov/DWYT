using System;
using Microsoft.Practices.Unity;

namespace Tms.Common.IoC
{
    internal class ModuleRegister : IModuleRegister
    {
        private readonly IUnityContainer container;

        public ModuleRegister(IUnityContainer container)
        {
            this.container = container;
        }

        public IModuleRegister RegisterType<TFrom, TTo>(string name, ModuleLifetime lifetime = ModuleLifetime.PerRequest) where TTo : TFrom
        {
            LifetimeManager lifetimeManager = this.Map(lifetime);

            this.container.RegisterType<TFrom, TTo>(name, lifetimeManager);

            return this;
        }

        public IModuleRegister RegisterType<TFrom, TTo>(ModuleLifetime lifetime = ModuleLifetime.PerRequest) 
            where TTo : TFrom
        {
            LifetimeManager lifetimeManager = this.Map(lifetime);

            this.container.RegisterType<TFrom, TTo>(lifetimeManager);

            return this;
        }

        private LifetimeManager Map(ModuleLifetime lifetime)
        {
            switch (lifetime)
            {
                case ModuleLifetime.PerRequest:
                    return new TransientLifetimeManager();
                case ModuleLifetime.Hierarchical:
                    return new HierarchicalLifetimeManager();
                case ModuleLifetime.PerResolve:
                    return new PerResolveLifetimeManager();
                case ModuleLifetime.PerThread:
                    return new PerThreadLifetimeManager();
                case ModuleLifetime.Singleton:
                    return new ContainerControlledLifetimeManager();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}