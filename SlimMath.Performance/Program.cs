using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Globalization;

namespace SlimMath.Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            var scaling = Matrix.Scaling(2.0f, 2.0f, 2.0f);
            Console.WriteLine(ToString(scaling));
            Console.WriteLine();

            var translation = Matrix.Translation(3.0f, 3.0f, 3.0f);
            Console.WriteLine(ToString(translation));
            Console.WriteLine();

            Console.WriteLine(ToString(scaling * translation));
            Console.WriteLine();
        }

        static string ToString(Matrix matrix)
        {
            return string.Format("{0} {1} {2} {3}\n{4} {5} {6} {7}\n{8} {9} {10} {11}\n{12} {13} {14} {15}",
                matrix.M11.ToString(CultureInfo.CurrentCulture),
                matrix.M12.ToString(CultureInfo.CurrentCulture), matrix.M13.ToString(CultureInfo.CurrentCulture), matrix.M14.ToString(CultureInfo.CurrentCulture),
                matrix.M21.ToString(CultureInfo.CurrentCulture), matrix.M22.ToString(CultureInfo.CurrentCulture), matrix.M23.ToString(CultureInfo.CurrentCulture),
                matrix.M24.ToString(CultureInfo.CurrentCulture), matrix.M31.ToString(CultureInfo.CurrentCulture), matrix.M32.ToString(CultureInfo.CurrentCulture),
                matrix.M33.ToString(CultureInfo.CurrentCulture), matrix.M34.ToString(CultureInfo.CurrentCulture), matrix.M41.ToString(CultureInfo.CurrentCulture),
                matrix.M42.ToString(CultureInfo.CurrentCulture), matrix.M43.ToString(CultureInfo.CurrentCulture), matrix.M44.ToString(CultureInfo.CurrentCulture));
        }
    }
}
