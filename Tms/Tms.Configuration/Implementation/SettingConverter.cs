using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

namespace Tms.Configuration.Implementation
{
    internal class SettingConverter
    {
        internal static T As<T>(IDictionary<string, string> settings, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            string value;

            if (!settings.TryGetValue(key, out value))
            {
                throw new ConfigurationErrorsException($"No setting can be found for key '{key}'");
            }

            return (T)converter.ConvertFromString(settings[key]);
        }

        internal static T DefaultOrAs<T>(IDictionary<string, string> settings, string key, T defaultValue = default(T))
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            try
            {
                return (T)converter.ConvertFromString(settings[key]);
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}