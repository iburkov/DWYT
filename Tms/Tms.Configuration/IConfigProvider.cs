using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tms.Configuration
{
    public interface IConfigProvider
    {
        T GetSettingsAs<T>(string key);

        T GetDefaultOrSettingAs<T>(string key, T defaultValue = default(T));

        T GetSettingsAs<T>(string section, string key);

        T GetDefaultOrSettingAs<T>(string section, string key, T defaultValue = default(T));

        T GetSection<T>(string section) where T : IConfigSection;
    }
}
