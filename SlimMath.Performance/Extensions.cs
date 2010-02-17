using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SlimMath.Performance
{
    static class Extensions
    {
        public static T NextEnum<T>(this Random random)
        {
            var values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(random.Next(values.Length));
        }

        public static float NextFloat(this Random random)
        {
            return (float)random.NextDouble();
        }
    }
}
