using System;

namespace Tms.Configuration.Implementation
{
    public class FileConfigProvider : IConfigProvider
    {
        public T GetSettingsAs<T>(string key)
        {
            throw new NotImplementedException();
        }

        public T GetDefaultOrSettingAs<T>(string key, T defaultValue = default(T))
        {
            throw new NotImplementedException();
        }

        public T GetSettingsAs<T>(string section, string key)
        {
            throw new NotImplementedException();
        }

        public T GetDefaultOrSettingAs<T>(string section, string key, T defaultValue = default(T))
        {
            throw new NotImplementedException();
        }

        public T GetSection<T>(string section) where T : IConfigSection
        {
            throw new NotImplementedException();
        }

        
    }
}