using System;
using Tms.Common.Enums;

namespace Tms.Common.IoC
{
    public interface IModuleRegister
    {
        IModuleRegister RegisterFactory<T>(string name, Func<IModuleRegister, T> factoryFunc,
            ModuleLifetime lifetime = ModuleLifetime.PerRequest);

        IModuleRegister RegisterFactory<T>(Func<IModuleRegister, T> factoryFunc,
            ModuleLifetime lifetime = ModuleLifetime.PerRequest);

        IModuleRegister RegisterType<TFrom, TTo>(string name, ModuleLifetime lifetime = ModuleLifetime.PerRequest)
            where TTo : TFrom;

        IModuleRegister RegisterType<TFrom, TTo>(ModuleLifetime lifetime = ModuleLifetime.PerRequest) 
            where TTo : TFrom;

        IModuleRegister RegisterInstance<T>(T instance, string name, ModuleLifetime lifetime = ModuleLifetime.PerRequest);

        IModuleRegister RegisterInstance<T>(T instance, ModuleLifetime lifetime = ModuleLifetime.PerRequest);

        T Resolve<T>(string name = null);
    }
}