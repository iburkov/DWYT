namespace Tms.Common.IoC
{
    public enum ModuleLifetime
    {
        PerRequest = 1,
        Hierarchical = 2,
        PerResolve = 3,
        PerThread = 4,
        Singleton = 5
    }
}