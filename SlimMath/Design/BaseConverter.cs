using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace SlimMath.Design
{
    public abstract class BaseConverter : ExpandableObjectConverter
    {
        protected PropertyDescriptorCollection Properties
        {
            get;
            set;
        }

        protected static string ConvertFromValues<T>(ITypeDescriptorContext context, CultureInfo culture, T[] values)
        {
            if (culture == null)
                culture = CultureInfo.CurrentCulture;

            var converter = TypeDescriptor.GetConverter(typeof(T));
            var results = Array.ConvertAll(values, t => converter.ConvertToString(context, culture, t));

            return string.Join(culture.TextInfo.ListSeparator + " ", results);
        }

        protected static T[] ConvertToValues<T>(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string str = value as string;
            if (string.IsNullOrEmpty(str))
                return null;

            if (culture == null)
                culture = CultureInfo.CurrentCulture;

            var converter = TypeDescriptor.GetConverter(typeof(T));
            var strings = str.Trim().Split(new[] { culture.TextInfo.ListSeparator }, StringSplitOptions.RemoveEmptyEntries);

            return Array.ConvertAll(strings, s => (T)converter.ConvertFromString(context, culture, s));
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string) || destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return Properties;
        }
    }
}
