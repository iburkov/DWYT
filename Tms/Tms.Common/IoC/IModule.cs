namespace Tms.Common.IoC
{
    public interface IModule
    {
        void Initialize(IModuleRegister register);
    }
}