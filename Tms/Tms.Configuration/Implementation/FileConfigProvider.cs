using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace Tms.Configuration.Implementation
{
    public sealed class FileConfigProvider : IConfigProvider
    {
        private readonly Lazy<IDictionary<string, string>> lazyAppSettings;

        public FileConfigProvider()
        {
            this.lazyAppSettings = new Lazy<IDictionary<string, string>>(
                   () => new FileConfigSection("appSettings").Settings
               );
        }

        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public Task<string> GetConnectionStringAsync(string name)
        {
            return Task.FromResult(this.GetConnectionString(name));
        }

        public T GetSetting<T>(string key)
        {
            return SettingConverter.As<T>(lazyAppSettings.Value, key);
        }

        public Task<T> GetSettingAsync<T>(string key)
        {
            return Task.FromResult(this.GetSetting<T>(key));
        }

        public T GetDefaultOrSetting<T>(string key, T defaultValue = default(T))
        {
            return SettingConverter.DefaultOrAs(lazyAppSettings.Value, key, defaultValue);
        }

        public Task<T> GetDefaultOrSettingAsync<T>(string key, T defaultValue = default(T))
        {
            return Task.FromResult(this.GetDefaultOrSetting(key, defaultValue));
        }

        public T GetSetting<T>(string section, string key)
        {
            var configSection = this.GetSection(section);

            return SettingConverter.As<T>(configSection.Settings, key);
        }

        public Task<T> GetSettingAsync<T>(string section, string key)
        {
            return Task.FromResult(this.GetSetting<T>(section, key));
        }

        public Task<T> GetDefaultOrSettingAsync<T>(string section, string key, T defaultValue = default(T))
        {
            return Task.FromResult(this.GetDefaultOrSetting(section, key, defaultValue));
        }

        public T GetDefaultOrSetting<T>(string section, string key, T defaultValue = default(T))
        {
            var configSection = this.GetSection(section);

            if (!configSection.Exists)
            {
                return defaultValue;
            }

            return SettingConverter.As<T>(configSection.Settings, key);
        }

        public IConfigSection GetSection(string section)
        {
            IConfigSection configSection = new FileConfigSection(section);

            return configSection;
        }

        public Task<IConfigSection> GetSectionAsync(string section)
        {
            return Task.FromResult(this.GetSection(section));
        }
    }
}