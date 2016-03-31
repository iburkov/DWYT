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

        public bool Exists()
        {
            return this.lazyCollection.Value == null;
        }

        public string Name { get; }

        public IDictionary<string, string> Settings
        {
            get
            {
                NameValueCollection collection = this.lazyCollection.Value;

                if (collection == null)
                {
                    throw new ConfigurationErrorsException(
                        $"Could not locate section with name '{this.Name}' in app/web configuration file");
                }

                var settings = new Dictionary<string, string>(collection.AllKeys.Length);

                foreach (var key in collection.AllKeys)
                {
                    settings.Add(key, collection[key]);
                }

                return settings;
            }
        }
    }
}
