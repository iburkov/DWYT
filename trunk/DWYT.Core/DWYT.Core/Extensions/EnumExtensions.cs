using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWYT.Core.Extensions
{
    /// <summary>
    /// Provides extension methods for System.Enum
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts emuneration to string value.
        /// </summary>
        /// <returns>Name of enumeration.</returns>
        public static string ConvertToString(this Enum enumeration)
        {
            return Enum.GetName(enumeration.GetType(), enumeration);
        }

        /// <summary>
        /// Converts string value to enumeration.
        /// </summary>
        /// <returns>Member of enumeration.</returns>
        public static T ConvertToEnum<T>(this string str) where T : struct
        {
            return (T)Enum.Parse(typeof(T), str);
        }
    }
}
