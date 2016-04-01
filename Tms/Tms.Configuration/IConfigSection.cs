using System.Collections.Generic;

namespace Tms.Configuration
{
    public interface IConfigSection
    {   
        bool Exists { get; }

        string Name { get; }

        IDictionary<string, string> Settings { get; }
    }
}