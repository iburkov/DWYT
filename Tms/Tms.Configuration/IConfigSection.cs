using System.Collections.Generic;

namespace Tms.Configuration
{
    public interface IConfigSection
    {   
        bool Exists();

        string Name { get; }

        IDictionary<string, string> Settings { get; }
    }
}