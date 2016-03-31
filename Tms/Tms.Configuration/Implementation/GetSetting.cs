using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tms.Configuration.Implementation
{
    internal class GetSetting
    {
        internal static T As<T>(IDictionary<string, string> settings, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            var value = settings[key];
            if (value == null)
                throw new ArgumentException("No setting can be found for key " + key);

            return (T)converter.ConvertFromString(settings[key]);
        }

        internal static T DefaultOrAs<T>(IDictionary<string, string> settings, string key)
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
                return default(T);
            }
        }
    }
}