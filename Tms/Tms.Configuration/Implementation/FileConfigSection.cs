using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace Tms.Configuration.Implementation
{
    public class FileConfigSection : IConfigSection
    {
        private readonly Lazy<NameValueCollection> lazyCollection;

        public FileConfigSection(string name)
        {
            this.Name = name;
            this.lazyCollection = new Lazy<NameValueCollection>(
                () => ConfigurationManager.GetSection(Name) as NameValueCollection
            );
        }

        public bool Exists => lazyCollection.Value != null;

        public string Name { get; }

        public IDictionary<string, string> Settings
        {
            get
            {
                if (!this.Exists)
                {
                    throw new ConfigurationErrorsException(
                        $"Could not locate section with name '{this.Name}' in app/web configuration file");
                }

                var settings = new Dictionary<string, string>(this.lazyCollection.Value.AllKeys.Length);

                foreach (var key in this.lazyCollection.Value.AllKeys)
                {
                    settings.Add(key, this.lazyCollection.Value[key]);
                }

                return settings;
            }
        }
    }
}
