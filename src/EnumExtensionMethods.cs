using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace src
{
    public static class EnumExtensionMethods
    {
        public static T ToEnum<T>(this int number)
        {
            return (T)Enum.ToObject(typeof(T), number);
        }

        public static string Description(this Enum value)
        {
            if (value == null) throw new ArgumentNullException("value");
            var fi = value.GetType().GetField(value.ToString());
            if (fi == null) throw new ApplicationException("Unable to get field info from enum");
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            return value.ToString();
        }
    }
}