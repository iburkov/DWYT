using System.Collections.Generic;

namespace Tms.Configuration
{
    public interface IHierarchicalConfigSection : IConfigSection
    {
        IEnumerable<IConfigSection> ChildSections { get; }

        IConfigSection ParentSection { get; }
    }
}