using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace SlimMath.Design
{
    class FieldPropertyDescriptor : PropertyDescriptor
    {
        FieldInfo fieldInfo;

        public override Type ComponentType
        {
            get { return fieldInfo.DeclaringType; }
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override Type PropertyType
        {
            get { return fieldInfo.FieldType; }
        }

        public FieldPropertyDescriptor(FieldInfo fieldInfo)
            : base(fieldInfo.Name, (Attribute[])fieldInfo.GetCustomAttributes(true))
        {
            this.fieldInfo = fieldInfo;
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override object GetValue(object component)
        {
            return fieldInfo.GetValue(component);
        }

        public override void ResetValue(object component)
        {
        }

        public override void SetValue(object component, object value)
        {
            fieldInfo.SetValue(component, value);
            OnValueChanged(component, EventArgs.Empty);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return fieldInfo.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            return (obj as FieldPropertyDescriptor).fieldInfo.Equals(fieldInfo);
        }
    }
}
