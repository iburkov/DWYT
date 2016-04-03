using System;
using Microsoft.Practices.Unity;
using Tms.Common.Enums;

namespace Tms.Common.IoC
{
    internal sealed class ModuleRegister : IModuleRegister
    {
        private readonly IUnityContainer container;

        public ModuleRegister(IUnityContainer container)
        {
            this.container = container;
        }

        public IModuleRegister RegisterFactory<T>(string name, Func<IModuleRegister, T> factoryFunc, 
            ModuleLifetime lifetime = ModuleLifetime.PerRequest)
        {
            this.container.RegisterType<T>(
                name: name,
                lifetimeManager: this.MapToLifetimeManager(lifetime),
                injectionMembers: new InjectionFactory(c => factoryFunc(this))
            );

            return this;
        }

        public IModuleRegister RegisterFactory<T>(Func<IModuleRegister, T> factoryFunc,
            ModuleLifetime lifetime = ModuleLifetime.PerRequest)
        {
            this.container.RegisterType<T>(
                lifetimeManager: this.MapToLifetimeManager(lifetime),
                injectionMembers: new InjectionFactory(c => factoryFunc(this))
            );

            return this;
        }

        public IModuleRegister RegisterType<TFrom, TTo>(string name, ModuleLifetime lifetime = ModuleLifetime.PerRequest) where TTo : TFrom
        {
            this.container.RegisterType<TFrom, TTo>(name, this.MapToLifetimeManager(lifetime));

            return this;
        }

        public IModuleRegister RegisterType<TFrom, TTo>(ModuleLifetime lifetime = ModuleLifetime.PerRequest)
            where TTo : TFrom
        {
            this.container.RegisterType<TFrom, TTo>(this.MapToLifetimeManager(lifetime));

            return this;
        }

        public IModuleRegister RegisterInstance<T>(T instance, string name,
            ModuleLifetime lifetime = ModuleLifetime.PerRequest)
        {
            this.container.RegisterInstance(typeof(T), name, instance, this.MapToLifetimeManager(lifetime));

            return this;
        }

        public IModuleRegister RegisterInstance<T>(T instance, ModuleLifetime lifetime = ModuleLifetime.PerRequest)
        {
            this.container.RegisterInstance(instance, this.MapToLifetimeManager(lifetime));

            return this;
        }

        public T Resolve<T>(string name = null)
        {
            return string.IsNullOrEmpty(name)
                ? this.container.Resolve<T>()
                : this.container.Resolve<T>(name);
        }

        private LifetimeManager MapToLifetimeManager(ModuleLifetime lifetime)
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