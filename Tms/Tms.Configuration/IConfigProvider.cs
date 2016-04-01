﻿using System.Threading.Tasks;

namespace Tms.Configuration
{
    public interface IConfigProvider
    {
        T GetSetting<T>(string key);

        Task<T> GetSettingAsync<T>(string key);

        T GetDefaultOrSetting<T>(string key, T defaultValue = default(T));

        Task<T> GetDefaultOrSettingAsync<T>(string key, T defaultValue = default(T));

        T GetSetting<T>(string section, string key);

        Task<T> GetSettingAsync<T>(string section, string key);

        T GetDefaultOrSetting<T>(string section, string key, T defaultValue = default(T));

        Task<T> GetDefaultOrSettingAsync<T>(string section, string key, T defaultValue = default(T));

        IConfigSection GetSection(string section);

        Task<IConfigSection> GetSectionAsync(string section);
    }
}
