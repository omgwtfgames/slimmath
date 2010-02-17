using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SlimMath.Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            const int TestCount = 1000000;

            var timer = new Stopwatch();
            var random = new Random();
            var list = new List<Matrix>(TestCount);

            timer.Reset();
            timer.Start();

            for (int i = 0; i < TestCount; i++)
            {
                list.Add(Matrix.Projection1(random.NextEnum<ProjectionType>(), random.NextEnum<Handedness>(), random.NextFloat(), random.NextFloat(),
                    random.NextFloat(), random.NextFloat(), random.NextFloat(), random.NextFloat()));
            }

            timer.Stop();
            list.Clear();
            Console.WriteLine("Projection1: {0}", timer.ElapsedTicks);

            timer.Reset();
            timer.Start();

            for (int i = 0; i < TestCount; i++)
            {
                list.Add(Matrix.Projection2(random.NextEnum<ProjectionType>(), random.NextEnum<Handedness>(), random.NextFloat(), random.NextFloat(),
                    random.NextFloat(), random.NextFloat(), random.NextFloat(), random.NextFloat()));
            }

            timer.Stop();
            Console.WriteLine("Projection2: {0}", timer.ElapsedTicks);
        }
    }
}
