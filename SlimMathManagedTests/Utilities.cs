using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlimMath;

namespace SlimMathManagedTests
{
    static class Utilities
    {
        public const float ZeroTolerance = 1e-6f;
        public const float AssertDelta = 1e-3f;

        static Random random = new Random();
        static Queue<int> last = new Queue<int>();
        const int maxrepeat = 20;

        //Assert routines.
        public static void AreEqual(object expected, object actual)
        {
            Assert.AreEqual(expected, actual);
        }

        public static void AreEqual(float expected, float actual, float delta)
        {
            if (expected.ToString("e3") != actual.ToString("e3"))
            {
                Assert.AreEqual(expected, actual, delta);
            }
        }

        public static void AreEqual(Vector2 expected, Vector2 actual)
        {
            AreEqual(expected.X, actual.X, AssertDelta);
            AreEqual(expected.Y, actual.Y, AssertDelta);
        }

        public static void AreEqual(Vector3 expected, Vector3 actual)
        {
            AreEqual(expected.X, actual.X, AssertDelta);
            AreEqual(expected.Y, actual.Y, AssertDelta);
            AreEqual(expected.Z, actual.Z, AssertDelta);
        }

        public static void AreEqual(Vector4 expected, Vector4 actual)
        {
            AreEqual(expected.X, actual.X, AssertDelta);
            AreEqual(expected.Y, actual.Y, AssertDelta);
            AreEqual(expected.Z, actual.Z, AssertDelta);
            AreEqual(expected.W, actual.W, AssertDelta);
        }

        public static void AreEqual(Quaternion expected, Quaternion actual)
        {
            AreEqual(expected.X, actual.X, AssertDelta);
            AreEqual(expected.Y, actual.Y, AssertDelta);
            AreEqual(expected.Z, actual.Z, AssertDelta);
            AreEqual(expected.W, actual.W, AssertDelta);
        }

        public static void AreEqual(Matrix expected, Matrix actual)
        {
            AreEqual(expected.M11, actual.M11, AssertDelta);
            AreEqual(expected.M12, actual.M12, AssertDelta);
            AreEqual(expected.M13, actual.M13, AssertDelta);
            AreEqual(expected.M14, actual.M14, AssertDelta);

            AreEqual(expected.M21, actual.M21, AssertDelta);
            AreEqual(expected.M22, actual.M22, AssertDelta);
            AreEqual(expected.M23, actual.M23, AssertDelta);
            AreEqual(expected.M24, actual.M24, AssertDelta);

            AreEqual(expected.M31, actual.M31, AssertDelta);
            AreEqual(expected.M32, actual.M32, AssertDelta);
            AreEqual(expected.M33, actual.M33, AssertDelta);
            AreEqual(expected.M34, actual.M34, AssertDelta);

            AreEqual(expected.M41, actual.M41, AssertDelta);
            AreEqual(expected.M42, actual.M42, AssertDelta);
            AreEqual(expected.M43, actual.M43, AssertDelta);
            AreEqual(expected.M44, actual.M44, AssertDelta);

        }

        public static void AreNotEqual(object expected, object actual)
        {
            Assert.AreNotEqual(expected, actual);
        }

        public static void AreNotEqual(float expected, float actual, float delta)
        {
            Assert.AreNotEqual(expected, actual, delta);
        }

        public static void AreNotEqual(Vector2 expected, Vector2 actual)
        {
            AreNotEqual(expected.X, actual.X, AssertDelta);
            AreNotEqual(expected.Y, actual.Y, AssertDelta);
        }

        public static void AreNotEqual(Vector3 expected, Vector3 actual)
        {
            AreNotEqual(expected.X, actual.X, AssertDelta);
            AreNotEqual(expected.Y, actual.Y, AssertDelta);
            AreNotEqual(expected.Z, actual.Z, AssertDelta);
        }

        public static void AreNotEqual(Vector4 expected, Vector4 actual)
        {
            AreNotEqual(expected.X, actual.X, AssertDelta);
            AreNotEqual(expected.Y, actual.Y, AssertDelta);
            AreNotEqual(expected.Z, actual.Z, AssertDelta);
            AreNotEqual(expected.W, actual.W, AssertDelta);
        }

        public static void AreNotEqual(Quaternion expected, Quaternion actual)
        {
            AreNotEqual(expected.X, actual.X, AssertDelta);
            AreNotEqual(expected.Y, actual.Y, AssertDelta);
            AreNotEqual(expected.Z, actual.Z, AssertDelta);
            AreNotEqual(expected.W, actual.W, AssertDelta);
        }

        public static void AreNotEqual(Matrix expected, Matrix actual)
        {
            AreNotEqual(expected.M11, actual.M11, AssertDelta);
            AreNotEqual(expected.M12, actual.M12, AssertDelta);
            AreNotEqual(expected.M13, actual.M13, AssertDelta);
            AreNotEqual(expected.M14, actual.M14, AssertDelta);

            AreNotEqual(expected.M21, actual.M21, AssertDelta);
            AreNotEqual(expected.M22, actual.M22, AssertDelta);
            AreNotEqual(expected.M23, actual.M23, AssertDelta);
            AreNotEqual(expected.M24, actual.M24, AssertDelta);

            AreNotEqual(expected.M31, actual.M31, AssertDelta);
            AreNotEqual(expected.M32, actual.M32, AssertDelta);
            AreNotEqual(expected.M33, actual.M33, AssertDelta);
            AreNotEqual(expected.M34, actual.M34, AssertDelta);

            AreNotEqual(expected.M41, actual.M41, AssertDelta);
            AreNotEqual(expected.M42, actual.M42, AssertDelta);
            AreNotEqual(expected.M43, actual.M43, AssertDelta);
            AreNotEqual(expected.M44, actual.M44, AssertDelta);
        }

        //Generate routines.
        public static float GenerateFloat(float min, float max)
        {
            return Math.Min(Math.Max((float)random.Next((int)min, (int)max + 1), min), max);
        }

        public static float GenerateFloat()
        {
            //Generate a number in the range [5, 150).
            int temp = 0;

            do
                temp = random.Next(5, 150);
            while (last.Contains(temp));

            if (last.Count > maxrepeat)
                last.Dequeue();

            last.Enqueue(temp);

            return (float)temp;
        }

        public static float GenerateFloatLarge()
        {
            //Generate a number in the range [500, 1000).
            int temp = 0;

            do
                temp = random.Next(500, 1000);
            while (last.Contains(temp));

            if (last.Count > maxrepeat)
                last.Dequeue();

            last.Enqueue(temp);

            return (float)temp;
        }

        public static float GenerateFloatSmall()
        {
            //Generate a number in the range (-500, -1000].
            int temp = 0;

            do
                temp = random.Next(500, 1000) - 1500;
            while (last.Contains(temp));

            if (last.Count > maxrepeat)
                last.Dequeue();

            last.Enqueue(temp);

            return (float)temp;
        }

        public static Vector2 GenerateVector2()
        {
            return new Vector2()
            {
                X = GenerateFloat(),
                Y = GenerateFloat()
            };
        }

        public static Vector3 GenerateVector3()
        {
            return new Vector3()
            {
                X = GenerateFloat(),
                Y = GenerateFloat(),
                Z = GenerateFloat()
            };
        }

        public static Vector4 GenerateVector4()
        {
            return new Vector4()
            {
                X = GenerateFloat(),
                Y = GenerateFloat(),
                Z = GenerateFloat(),
                W = GenerateFloat()
            };
        }

        public static Quaternion GenerateQuaternion()
        {
            return new Quaternion()
            {
                X = GenerateFloat(),
                Y = GenerateFloat(),
                Z = GenerateFloat(),
                W = GenerateFloat()
            };
        }

        public static Matrix GenerateMatrix()
        {
            return new Matrix()
            {
                M11 = GenerateFloat(), M12 = GenerateFloat(), M13 = GenerateFloat(), M14 = GenerateFloat(),
                M21 = GenerateFloat(), M22 = GenerateFloat(), M23 = GenerateFloat(), M24 = GenerateFloat(),
                M31 = GenerateFloat(), M32 = GenerateFloat(), M33 = GenerateFloat(), M34 = GenerateFloat(),
                M41 = GenerateFloat(), M42 = GenerateFloat(), M43 = GenerateFloat(), M44 = GenerateFloat()
            };
        }

        public static Ray GenerateRay()
        {
            return new Ray()
            {
                Position = GenerateVector3(),
                Direction = GenerateVector3()
            };
        }

        public static Plane GeneratePlane()
        {
            return new Plane()
            {
                Normal = GenerateVector3(),
                D = GenerateFloat()
            };
        }

        //Xna conversion routines.
        public static Microsoft.Xna.Framework.Vector2 ConvertToXna(Vector2 value)
        {
            return new Microsoft.Xna.Framework.Vector2(value.X, value.Y);
        }

        public static Microsoft.Xna.Framework.Vector3 ConvertToXna(Vector3 value)
        {
            return new Microsoft.Xna.Framework.Vector3(value.X, value.Y, value.Z);
        }

        public static Microsoft.Xna.Framework.Vector4 ConvertToXna(Vector4 value)
        {
            return new Microsoft.Xna.Framework.Vector4(value.X, value.Y, value.Z, value.W);
        }

        public static Microsoft.Xna.Framework.Quaternion ConvertToXna(Quaternion value)
        {
            return new Microsoft.Xna.Framework.Quaternion(value.X, value.Y, value.Z, value.W);
        }

        public static Microsoft.Xna.Framework.Matrix ConvertToXna(Matrix value)
        {
            return new Microsoft.Xna.Framework.Matrix(
                value.M11, value.M12, value.M13, value.M14,
                value.M21, value.M22, value.M23, value.M24,
                value.M31, value.M32, value.M33, value.M34,
                value.M41, value.M42, value.M43, value.M44);
        }

        public static Microsoft.Xna.Framework.Ray ConvertToXna(Ray ray)
        {
            return new Microsoft.Xna.Framework.Ray(ConvertToXna(ray.Position), ConvertToXna(ray.Direction));
        }

        public static Microsoft.Xna.Framework.Plane ConvertToXna(Plane plane)
        {
            return new Microsoft.Xna.Framework.Plane(ConvertToXna(plane.Normal), plane.D);
        }

        public static Vector2 ConvertFrom(Microsoft.Xna.Framework.Vector2 value)
        {
            return new Vector2()
            {
                X = value.X,
                Y = value.Y
            };
        }

        public static Vector3 ConvertFrom(Microsoft.Xna.Framework.Vector3 value)
        {
            return new Vector3()
            {
                X = value.X,
                Y = value.Y,
                Z = value.Z
            };
        }

        public static Vector4 ConvertFrom(Microsoft.Xna.Framework.Vector4 value)
        {
            return new Vector4()
            {
                X = value.X,
                Y = value.Y,
                Z = value.Z,
                W = value.W
            };
        }

        public static Quaternion ConvertFrom(Microsoft.Xna.Framework.Quaternion value)
        {
            return new Quaternion()
            {
                X = value.X,
                Y = value.Y,
                Z = value.Z,
                W = value.W
            };
        }

        public static Matrix ConvertFrom(Microsoft.Xna.Framework.Matrix value)
        {
            return new Matrix()
            {
                M11 = value.M11, M12 = value.M12, M13 = value.M13, M14 = value.M14,
                M21 = value.M21, M22 = value.M22, M23 = value.M23, M24 = value.M24,
                M31 = value.M31, M32 = value.M32, M33 = value.M33, M34 = value.M34,
                M41 = value.M41, M42 = value.M42, M43 = value.M43, M44 = value.M44
            };
        }

        public static Ray ConvertFrom(Microsoft.Xna.Framework.Ray value)
        {
            return new Ray()
            {
                Position = ConvertFrom(value.Position),
                Direction = ConvertFrom(value.Direction)
            };
        }

        public static Plane ConvertFrom(Microsoft.Xna.Framework.Plane value)
        {
            return new Plane()
            {
                Normal = ConvertFrom(value.Normal),
                D = value.D
            };
        }

        //MDX conversion routines.
        public static Microsoft.DirectX.Vector2 ConvertToMdx(Vector2 value)
        {
            return new Microsoft.DirectX.Vector2(value.X, value.Y);
        }

        public static Microsoft.DirectX.Vector3 ConvertToMdx(Vector3 value)
        {
            return new Microsoft.DirectX.Vector3(value.X, value.Y, value.Z);
        }

        public static Microsoft.DirectX.Vector4 ConvertToMdx(Vector4 value)
        {
            return new Microsoft.DirectX.Vector4(value.X, value.Y, value.Z, value.W);
        }

        public static Microsoft.DirectX.Quaternion ConvertToMdx(Quaternion value)
        {
            return new Microsoft.DirectX.Quaternion(value.X, value.Y, value.Z, value.W);
        }

        public static Microsoft.DirectX.Matrix ConvertToMdx(Matrix value)
        {
            return new Microsoft.DirectX.Matrix()
            {
                M11 = value.M11, M12 = value.M12, M13 = value.M13, M14 = value.M14,
                M21 = value.M21, M22 = value.M22, M23 = value.M23, M24 = value.M24,
                M31 = value.M31, M32 = value.M32, M33 = value.M33, M34 = value.M34,
                M41 = value.M41, M42 = value.M42, M43 = value.M43, M44 = value.M44
            };
        }

        public static Microsoft.DirectX.Plane ConvertToMdx(Plane value)
        {
            return new Microsoft.DirectX.Plane(value.Normal.X, value.Normal.Y, value.Normal.Z, value.D);
        }

        public static Vector2 ConvertFrom(Microsoft.DirectX.Vector2 value)
        {
            return new Vector2()
            {
                X = value.X,
                Y = value.Y
            };
        }

        public static Vector3 ConvertFrom(Microsoft.DirectX.Vector3 value)
        {
            return new Vector3()
            {
                X = value.X,
                Y = value.Y,
                Z = value.Z
            };
        }

        public static Vector4 ConvertFrom(Microsoft.DirectX.Vector4 value)
        {
            return new Vector4()
            {
                X = value.X,
                Y = value.Y,
                Z = value.Z,
                W = value.W
            };
        }

        public static Quaternion ConvertFrom(Microsoft.DirectX.Quaternion value)
        {
            return new Quaternion()
            {
                X = value.X,
                Y = value.Y,
                Z = value.Z,
                W = value.W
            };
        }

        public static Matrix ConvertFrom(Microsoft.DirectX.Matrix value)
        {
            return new Matrix()
            {
                M11 = value.M11, M12 = value.M12, M13 = value.M13, M14 = value.M14,
                M21 = value.M21, M22 = value.M22, M23 = value.M23, M24 = value.M24,
                M31 = value.M31, M32 = value.M32, M33 = value.M33, M34 = value.M34,
                M41 = value.M41, M42 = value.M42, M43 = value.M43, M44 = value.M44
            };
        }

        public static Plane ConvertFrom(Microsoft.DirectX.Plane value)
        {
            return new Plane()
            {
                Normal = new Vector3()
                {
                    X = value.A,
                    Y = value.B,
                    Z = value.C
                },
                D = value.D
            };
        }
    }
}
