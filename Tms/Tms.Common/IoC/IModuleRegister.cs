namespace Tms.Common.IoC
{
    public interface IModuleRegister
    {
        IModuleRegister RegisterType<TFrom, TTo>(string name, ModuleLifetime lifetime = ModuleLifetime.PerRequest)
            where TTo : TFrom;

        IModuleRegister RegisterType<TFrom, TTo>(ModuleLifetime lifetime = ModuleLifetime.PerRequest) 
            where TTo : TFrom;
    }
}