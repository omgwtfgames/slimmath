using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections;
using System.Globalization;
using System.ComponentModel.Design.Serialization;

namespace SlimMath.Design
{
    public class Vector2Converter : BaseConverter
    {
        public Vector2Converter()
        {
            Type type = typeof(Vector2);
            Properties = new PropertyDescriptorCollection(new[] { new FieldPropertyDescriptor(type.GetField("X")), new FieldPropertyDescriptor(type.GetField("Y")) });
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
                throw new ArgumentNullException("destinationType");

            if (value is Vector2)
            {
                Vector2 vector = (Vector2)value;

                if (destinationType == typeof(string))
                    return ConvertFromValues(context, culture, vector.ToArray());
                else if (destinationType == typeof(InstanceDescriptor))
                {
                    var constructor = typeof(Vector2).GetConstructor(new[] { typeof(float), typeof(float) });
                    if (constructor != null)
                        return new InstanceDescriptor(constructor, vector.ToArray());
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var values = ConvertToValues<float>(context, culture, value);
            if (values != null)
                return new Vector2(values);

            return base.ConvertFrom(context, culture, value);
        }

        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
                throw new ArgumentNullException("propertyValues");

            return new Vector2((float)propertyValues["X"], (float)propertyValues["Y"]);
        }
    }
}
