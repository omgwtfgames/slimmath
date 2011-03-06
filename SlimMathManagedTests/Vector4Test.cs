using SlimMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SlimMathManagedTests
{
    [TestClass()]
    public class Vector4Test
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod()]
        public void Vector4ReadonlyFieldsTest()
        {
            Utilities.AreEqual(System.Runtime.InteropServices.Marshal.SizeOf(typeof(Vector4)), Vector4.SizeInBytes);
            Utilities.AreEqual(new Vector4() { X = 0f, Y = 0f, Z = 0f, W = 0f }, Vector4.Zero);
            Utilities.AreEqual(new Vector4() { X = 1f, Y = 1f, Z = 1f, W = 1f }, Vector4.One);
            Utilities.AreEqual(new Vector4() { X = 1f, Y = 0f, Z = 0f, W = 0f }, Vector4.UnitX);
            Utilities.AreEqual(new Vector4() { X = 0f, Y = 1f, Z = 0f, W = 0f }, Vector4.UnitY);
            Utilities.AreEqual(new Vector4() { X = 0f, Y = 0f, Z = 1f, W = 0f }, Vector4.UnitZ);
            Utilities.AreEqual(new Vector4() { X = 0f, Y = 0f, Z = 0f, W = 1f }, Vector4.UnitW);
        }

        [TestMethod()]
        public void Vector4ConstructorTest()
        {
            Vector2 value = Utilities.GenerateVector2();
            float z = Utilities.GenerateFloat();
            float w = Utilities.GenerateFloat();
            Vector4 target = new Vector4(value, z, w);

            Utilities.AreEqual(value.X, target.X, 0f);
            Utilities.AreEqual(value.Y, target.Y, 0f);
            Utilities.AreEqual(z, target.Z, 0f);
            Utilities.AreEqual(w, target.W, 0f);
        }

        [TestMethod()]
        public void Vector4ConstructorTest1()
        {
            float[] values = new float[]
            {
                Utilities.GenerateFloat(),
                Utilities.GenerateFloat(),
                Utilities.GenerateFloat(),
                Utilities.GenerateFloat()
            };
            Vector4 target = new Vector4(values);

            Utilities.AreEqual(values[0], target.X, 0f);
            Utilities.AreEqual(values[1], target.Y, 0f);
            Utilities.AreEqual(values[2], target.Z, 0f);
            Utilities.AreEqual(values[3], target.W, 0f);
        }

        [TestMethod()]
        public void Vector4ConstructorTest2()
        {
            Vector3 value = Utilities.GenerateVector3();
            float w = Utilities.GenerateFloat();
            Vector4 target = new Vector4(value, w);

            Utilities.AreEqual(value.X, target.X, 0f);
            Utilities.AreEqual(value.Y, target.Y, 0f);
            Utilities.AreEqual(value.Z, target.Z, 0f);
            Utilities.AreEqual(w, target.W, 0f);
        }

        [TestMethod()]
        public void Vector4ConstructorTest3()
        {
            float value = Utilities.GenerateFloat();
            Vector4 target = new Vector4(value);

            Utilities.AreEqual(value, target.X, 0f);
            Utilities.AreEqual(value, target.Y, 0f);
            Utilities.AreEqual(value, target.Z, 0f);
            Utilities.AreEqual(value, target.W, 0f);
        }

        [TestMethod()]
        public void Vector4ConstructorTest4()
        {
            float x = Utilities.GenerateFloat();
            float y = Utilities.GenerateFloat();
            float z = Utilities.GenerateFloat();
            float w = Utilities.GenerateFloat();
            Vector4 target = new Vector4(x, y, z, w);

            Utilities.AreEqual(x, target.X, 0f);
            Utilities.AreEqual(y, target.Y, 0f);
            Utilities.AreEqual(z, target.Z, 0f);
            Utilities.AreEqual(w, target.W, 0f);
        }

        [TestMethod()]
        public void AddTest()
        {
            Vector4 left = Utilities.GenerateVector4();
            Vector4 right = Utilities.GenerateVector4();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Add(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector4 actual;
            actual = Vector4.Add(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddByRefTest()
        {
            Vector4 left = Utilities.GenerateVector4();
            Vector4 leftExpected = left;
            Vector4 right = Utilities.GenerateVector4();
            Vector4 rightExpected = right;
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Add(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector4.Add(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void BarycentricTest()
        {
            Vector4 value1 = Utilities.GenerateVector4();
            Vector4 value2 = Utilities.GenerateVector4();
            Vector4 value3 = Utilities.GenerateVector4();
            float amount1 = Utilities.GenerateFloat();
            float amount2 = Utilities.GenerateFloat();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Barycentric(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2),
                Utilities.ConvertToXna(value3),
                amount1,
                amount2));

            Vector4 actual;
            actual = Vector4.Barycentric(value1, value2, value3, amount1, amount2);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BarycentricByRefTest()
        {
            Vector4 value1 = Utilities.GenerateVector4();
            Vector4 value1Expected = value1;
            Vector4 value2 = Utilities.GenerateVector4();
            Vector4 value2Expected = value2;
            Vector4 value3 = Utilities.GenerateVector4();
            Vector4 value3Expected = value3;
            float amount1 = Utilities.GenerateFloat();
            float amount2 = Utilities.GenerateFloat();
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Barycentric(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2),
                Utilities.ConvertToXna(value3),
                amount1,
                amount2));

            Vector4.Barycentric(ref value1, ref value2, ref value3, amount1, amount2, out result);
            Utilities.AreEqual(value1Expected, value1);
            Utilities.AreEqual(value2Expected, value2);
            Utilities.AreEqual(value3Expected, value3);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void CatmullRomTest()
        {
            Vector4 value1 = Utilities.GenerateVector4();
            Vector4 value2 = Utilities.GenerateVector4();
            Vector4 value3 = Utilities.GenerateVector4();
            Vector4 value4 = Utilities.GenerateVector4();
            float amount = Utilities.GenerateFloat();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.CatmullRom(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2),
                Utilities.ConvertToXna(value3),
                Utilities.ConvertToXna(value4),
                amount));

            Vector4 actual;
            actual = Vector4.CatmullRom(value1, value2, value3, value4, amount);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CatmullRomByRefTest()
        {
            Vector4 value1 = Utilities.GenerateVector4();
            Vector4 value1Expected = value1;
            Vector4 value2 = Utilities.GenerateVector4();
            Vector4 value2Expected = value2;
            Vector4 value3 = Utilities.GenerateVector4();
            Vector4 value3Expected = value3;
            Vector4 value4 = Utilities.GenerateVector4();
            Vector4 value4Expected = value4;
            float amount = Utilities.GenerateFloat();
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.CatmullRom(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2),
                Utilities.ConvertToXna(value3),
                Utilities.ConvertToXna(value4),
                amount));

            Vector4.CatmullRom(ref value1, ref value2, ref value3, ref value4, amount, out result);
            Utilities.AreEqual(value1Expected, value1);
            Utilities.AreEqual(value2Expected, value2);
            Utilities.AreEqual(value3Expected, value3);
            Utilities.AreEqual(value4Expected, value4);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void ClampTest()
        {
            Vector4 value = new Vector4(Utilities.GenerateFloatSmall(), Utilities.GenerateFloatLarge(), Utilities.GenerateFloat(), Utilities.GenerateFloatLarge());
            Vector4 min = Utilities.GenerateVector4();
            Vector4 max = Utilities.GenerateVector4();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Clamp(
                Utilities.ConvertToXna(value),
                Utilities.ConvertToXna(min),
                Utilities.ConvertToXna(max)));

            Vector4 actual;
            actual = Vector4.Clamp(value, min, max);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ClampByRefTest()
        {
            Vector4 value = new Vector4(Utilities.GenerateFloatSmall(), Utilities.GenerateFloatLarge(), Utilities.GenerateFloat(), Utilities.GenerateFloatLarge());
            Vector4 valueExpected = value;
            Vector4 min = Utilities.GenerateVector4();
            Vector4 minExpected = min;
            Vector4 max = Utilities.GenerateVector4();
            Vector4 maxExpected = max;
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Clamp(
                Utilities.ConvertToXna(value),
                Utilities.ConvertToXna(min),
                Utilities.ConvertToXna(max)));

            Vector4.Clamp(ref value, ref min, ref max, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(minExpected, min);
            Utilities.AreEqual(maxExpected, max);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void DistanceTest()
        {
            Vector4 value1 = Utilities.GenerateVector4();
            Vector4 value2 = Utilities.GenerateVector4();

            float expected = Microsoft.Xna.Framework.Vector4.Distance(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2));

            float actual;
            actual = Vector4.Distance(value1, value2);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DistanceByRefTest()
        {
            Vector4 value1 = Utilities.GenerateVector4();
            Vector4 value1Expected = value1;
            Vector4 value2 = Utilities.GenerateVector4();
            Vector4 value2Expected = value2;
            float result;

            float resultExpected = Microsoft.Xna.Framework.Vector4.Distance(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2));

            Vector4.Distance(ref value1, ref value2, out result);
            Utilities.AreEqual(value1Expected, value1);
            Utilities.AreEqual(value2Expected, value2);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void DistanceSquaredTest()
        {
            Vector4 value1 = Utilities.GenerateVector4();
            Vector4 value2 = Utilities.GenerateVector4();

            float expected = Microsoft.Xna.Framework.Vector4.DistanceSquared(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2));

            float actual;
            actual = Vector4.DistanceSquared(value1, value2);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DistanceSquaredByRefTest()
        {
            Vector4 value1 = Utilities.GenerateVector4();
            Vector4 value1Expected = value1;
            Vector4 value2 = Utilities.GenerateVector4();
            Vector4 value2Expected = value2;
            float result;

            float resultExpected = Microsoft.Xna.Framework.Vector4.DistanceSquared(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2));

            Vector4.DistanceSquared(ref value1, ref value2, out result);
            Utilities.AreEqual(value1Expected, value1);
            Utilities.AreEqual(value2Expected, value2);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void DivideTest()
        {
            Vector4 value = Utilities.GenerateVector4();
            float scale = Utilities.GenerateFloat();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Divide(
                Utilities.ConvertToXna(value),
                scale));

            Vector4 actual;
            actual = Vector4.Divide(value, scale);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DivideByRefTest()
        {
            Vector4 value = Utilities.GenerateVector4();
            Vector4 valueExpected = value;
            float scale = Utilities.GenerateFloat();
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Divide(
                Utilities.ConvertToXna(value),
                scale));

            Vector4.Divide(ref value, scale, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void DotTest()
        {
            Vector4 left = Utilities.GenerateVector4();
            Vector4 right = Utilities.GenerateVector4();

            float expected = Microsoft.Xna.Framework.Vector4.Dot(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right));

            float actual;
            actual = Vector4.Dot(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DotByRefTest()
        {
            Vector4 left = Utilities.GenerateVector4();
            Vector4 leftExpected = left;
            Vector4 right = Utilities.GenerateVector4();
            Vector4 rightExpected = right;
            float result;

            float resultExpected = Microsoft.Xna.Framework.Vector4.Dot(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right));

            Vector4.Dot(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Vector4 target = Utilities.GenerateVector4();
            object value = new Vector4(target.X + 1f, target.Y - 1f, target.Z, target.W + 2f);
            bool expected = false;
            bool actual;
            actual = target.Equals(value);
            Utilities.AreEqual(expected, actual);

            target = Utilities.GenerateVector4();
            value = target;
            expected = true;
            actual = target.Equals(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EqualsTest1()
        {
            Vector4 target = Utilities.GenerateVector4();
            Vector4 other = new Vector4(target.X + 1f, target.Y - 1f, target.Z, target.W + 2f);
            bool expected = false;
            bool actual;
            actual = target.Equals(other);
            Utilities.AreEqual(expected, actual);

            target = Utilities.GenerateVector4();
            other = target;
            expected = true;
            actual = target.Equals(other);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void HermiteTest()
        {
            Vector4 value1 = Utilities.GenerateVector4();
            Vector4 tangent1 = Utilities.GenerateVector4();
            Vector4 value2 = Utilities.GenerateVector4();
            Vector4 tangent2 = Utilities.GenerateVector4();
            float amount = Utilities.GenerateFloat();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Hermite(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(tangent1),
                Utilities.ConvertToXna(value2),
                Utilities.ConvertToXna(tangent2),
                amount));

            Vector4 actual;
            actual = Vector4.Hermite(value1, tangent1, value2, tangent2, amount);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void HermiteByRefTest()
        {
            Vector4 value1 = Utilities.GenerateVector4();
            Vector4 value1Expected = value1;
            Vector4 tangent1 = Utilities.GenerateVector4();
            Vector4 tangent1Expected = tangent1;
            Vector4 value2 = Utilities.GenerateVector4();
            Vector4 value2Expected = value2;
            Vector4 tangent2 = Utilities.GenerateVector4();
            Vector4 tangent2Expected = tangent2;
            float amount = Utilities.GenerateFloat();
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Hermite(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(tangent1),
                Utilities.ConvertToXna(value2),
                Utilities.ConvertToXna(tangent2),
                amount));

            Vector4.Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
            Utilities.AreEqual(value1Expected, value1);
            Utilities.AreEqual(tangent1Expected, tangent1);
            Utilities.AreEqual(value2Expected, value2);
            Utilities.AreEqual(tangent2Expected, tangent2);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void LengthTest()
        {
            Vector4 target = Utilities.GenerateVector4();

            float expected = Utilities.ConvertToXna(target).Length();

            float actual;
            actual = target.Length;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LengthSquaredTest()
        {
            Vector4 target = Utilities.GenerateVector4();

            float expected = Utilities.ConvertToXna(target).LengthSquared();

            float actual;
            actual = target.LengthSquared;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LerpTest()
        {
            Vector4 start = Utilities.GenerateVector4();
            Vector4 end = Utilities.GenerateVector4();
            float amount = Utilities.GenerateFloat();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Lerp(
                Utilities.ConvertToXna(start),
                Utilities.ConvertToXna(end),
                amount));

            Vector4 actual;
            actual = Vector4.Lerp(start, end, amount);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LerpByRefTest()
        {
            Vector4 start = Utilities.GenerateVector4();
            Vector4 startExpected = start;
            Vector4 end = Utilities.GenerateVector4();
            Vector4 endExpected = end;
            float amount = Utilities.GenerateFloat();
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Lerp(
                Utilities.ConvertToXna(start),
                Utilities.ConvertToXna(end),
                amount));

            Vector4.Lerp(ref start, ref end, amount, out result);
            Utilities.AreEqual(startExpected, start);
            Utilities.AreEqual(endExpected, end);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void MaxTest()
        {
            Vector4 left = Utilities.GenerateVector4();
            Vector4 right = Utilities.GenerateVector4();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Max(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector4 actual;
            actual = Vector4.Max(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MaxByRefTest()
        {
            Vector4 left = Utilities.GenerateVector4();
            Vector4 leftExpected = left;
            Vector4 right = Utilities.GenerateVector4();
            Vector4 rightExpected = right;
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Max(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector4.Max(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void MinTest()
        {
            Vector4 left = Utilities.GenerateVector4();
            Vector4 right = Utilities.GenerateVector4();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Min(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector4 actual;
            actual = Vector4.Min(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinByRefTest()
        {
            Vector4 left = Utilities.GenerateVector4();
            Vector4 leftExpected = left;
            Vector4 right = Utilities.GenerateVector4();
            Vector4 rightExpected = right;
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Min(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector4.Min(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void ModulateTest()
        {
            Vector4 left = Utilities.GenerateVector4();
            Vector4 right = Utilities.GenerateVector4();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Multiply(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector4 actual;
            actual = Vector4.Modulate(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ModulateByRefTest()
        {
            Vector4 left = Utilities.GenerateVector4();
            Vector4 leftExpected = left;
            Vector4 right = Utilities.GenerateVector4();
            Vector4 rightExpected = right;
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Multiply(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector4.Modulate(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            Vector4 value = Utilities.GenerateVector4();
            float scale = Utilities.GenerateFloat();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Multiply(
                Utilities.ConvertToXna(value),
                scale));

            Vector4 actual;
            actual = Vector4.Multiply(value, scale);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MultiplyByRefTest()
        {
            Vector4 value = Utilities.GenerateVector4();
            Vector4 valueExpected = value;
            float scale = Utilities.GenerateFloat();
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Multiply(
                Utilities.ConvertToXna(value),
                scale));

            Vector4.Multiply(ref value, scale, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void NegateTest()
        {
            Vector4 value = Utilities.GenerateVector4();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Negate(
                Utilities.ConvertToXna(value)));

            Vector4 actual;
            actual = Vector4.Negate(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NegateByRefTest()
        {
            Vector4 value = Utilities.GenerateVector4();
            Vector4 valueExpected = value;
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Negate(
                Utilities.ConvertToXna(value)));

            Vector4.Negate(ref value, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void NormalizeTest()
        {
            Vector4 target = Utilities.GenerateVector4();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Normalize(
                Utilities.ConvertToXna(target)));

            target.Normalize();
            Utilities.AreEqual(expected, target);
        }

        [TestMethod()]
        public void NormalizeTest1()
        {
            Vector4 value = Utilities.GenerateVector4();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Normalize(
                Utilities.ConvertToXna(value)));

            Vector4 actual;
            actual = Vector4.Normalize(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NormalizeByRefTest()
        {
            Vector4 value = Utilities.GenerateVector4();
            Vector4 valueExpected = value;
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Normalize(
                Utilities.ConvertToXna(value)));

            Vector4.Normalize(ref value, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void OrthogonalizeTest()
        {
            //Because orthogonalization is numerically unstable, we adjust the assert delta.
            float deltabefore = Utilities.AssertDelta;
            Utilities.AssertDelta = 1e-2f;

            Vector4[] source = new Vector4[5];
            Vector4[] destination = new Vector4[5];

            for (int i = 0; i < source.Length; ++i)
            {
                source[i] = Utilities.GenerateVector4();
            }

            Vector4.Orthogonalize(destination, source);

            Utilities.AreEqual(0f, Vector4.Dot(destination[0], destination[1]));
            Utilities.AreEqual(0f, Vector4.Dot(destination[0], destination[2]));
            Utilities.AreEqual(0f, Vector4.Dot(destination[0], destination[3]));
            Utilities.AreEqual(0f, Vector4.Dot(destination[0], destination[4]));

            Utilities.AreEqual(0f, Vector4.Dot(destination[1], destination[2]));
            Utilities.AreEqual(0f, Vector4.Dot(destination[1], destination[3]));
            Utilities.AreEqual(0f, Vector4.Dot(destination[1], destination[4]));

            Utilities.AreEqual(0f, Vector4.Dot(destination[2], destination[3]));
            Utilities.AreEqual(0f, Vector4.Dot(destination[2], destination[4]));

            Utilities.AreEqual(0f, Vector4.Dot(destination[3], destination[4]));

            //Reset the assert delta.
            Utilities.AssertDelta = deltabefore;
        }

        [TestMethod()]
        public void Orthonormalize()
        {
            //Because orthogonalization is numerically unstable, we adjust the assert delta.
            float deltabefore = Utilities.AssertDelta;
            Utilities.AssertDelta = 1e-2f;

            Vector4[] source = new Vector4[4];
            Vector4[] destination = new Vector4[4];

            for (int i = 0; i < source.Length; ++i)
            {
                source[i] = Utilities.GenerateVector4();
            }

            Vector4.Orthonormalize(destination, source);

            for (int i = 0; i < destination.Length; ++i)
            {
                Utilities.AreEqual(1f, destination[i].Length);
            }

            Utilities.AreEqual(0f, Vector4.Dot(destination[0], destination[1]));
            Utilities.AreEqual(0f, Vector4.Dot(destination[0], destination[2]));
            Utilities.AreEqual(0f, Vector4.Dot(destination[0], destination[3]));

            Utilities.AreEqual(0f, Vector4.Dot(destination[1], destination[2]));
            Utilities.AreEqual(0f, Vector4.Dot(destination[1], destination[3]));

            Utilities.AreEqual(0f, Vector4.Dot(destination[2], destination[3]));

            //Reset the assert delta.
            Utilities.AssertDelta = deltabefore;
        }

        [TestMethod()]
        public void SmoothStepTest()
        {
            Vector4 start = Utilities.GenerateVector4();
            Vector4 end = Utilities.GenerateVector4();
            float amount = Utilities.GenerateFloat();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.SmoothStep(
                Utilities.ConvertToXna(start),
                Utilities.ConvertToXna(end),
                amount));

            Vector4 actual;
            actual = Vector4.SmoothStep(start, end, amount);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SmoothStepByRefTest()
        {
            Vector4 start = Utilities.GenerateVector4();
            Vector4 startExpected = start;
            Vector4 end = Utilities.GenerateVector4();
            Vector4 endExpected = end;
            float amount = Utilities.GenerateFloat();
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.SmoothStep(
                Utilities.ConvertToXna(start),
                Utilities.ConvertToXna(end),
                amount));

            Vector4.SmoothStep(ref start, ref end, amount, out result);
            Utilities.AreEqual(startExpected, start);
            Utilities.AreEqual(endExpected, end);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void SubtractTest()
        {
            Vector4 left = Utilities.GenerateVector4();
            Vector4 right = Utilities.GenerateVector4();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Subtract(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector4 actual;
            actual = Vector4.Subtract(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SubtractByRefTest()
        {
            Vector4 left = Utilities.GenerateVector4();
            Vector4 leftExpected = left;
            Vector4 right = Utilities.GenerateVector4();
            Vector4 rightExpected = right;
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Subtract(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector4.Subtract(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void ToArrayTest()
        {
            Vector4 target = Utilities.GenerateVector4();
            float[] expected = { target.X, target.Y, target.Z, target.W };
            float[] actual;
            actual = target.ToArray();

            Assert.IsNotNull(actual);
            Assert.IsTrue(expected.Length == actual.Length);

            for (int i = 0; i < expected.Length; ++i)
            {
                Utilities.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod()]
        public void TransformQuaternionTest()
        {
            Vector4 vector = Utilities.GenerateVector4();
            Quaternion rotation = Utilities.GenerateQuaternion();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Transform(
                Utilities.ConvertToXna(vector),
                Utilities.ConvertToXna(rotation)));

            Vector4 actual;
            actual = Vector4.Transform(vector, rotation);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TransformQuaternionByRefTest()
        {
            Vector4 vector = Utilities.GenerateVector4();
            Vector4 vectorExpected = vector;
            Quaternion rotation = Utilities.GenerateQuaternion();
            Quaternion rotationExpected = rotation;
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Transform(
                Utilities.ConvertToXna(vector),
                Utilities.ConvertToXna(rotation)));

            Vector4.Transform(ref vector, ref rotation, out result);
            Utilities.AreEqual(vectorExpected, vector);
            Utilities.AreEqual(rotationExpected, rotation);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void TransformQuaternionArrayByRefTest()
        {
            Vector4[] source =
            {
                Utilities.GenerateVector4(),
                Utilities.GenerateVector4(),
                Utilities.GenerateVector4(),
                Utilities.GenerateVector4(),
                Utilities.GenerateVector4()
            };
            Quaternion rotation = Utilities.GenerateQuaternion();
            Quaternion rotationExpected = rotation;
            Vector4[] destination = new Vector4[source.Length];
            Vector4.Transform(source, ref rotation, destination);

            for (int i = 0; i < source.Length; ++i)
            {
                Vector4 temp = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Transform(
                    Utilities.ConvertToXna(source[i]),
                    Utilities.ConvertToXna(rotation)));
                Utilities.AreEqual(destination[i], temp);
            }
        }

        [TestMethod()]
        public void TransformMatrixTest()
        {
            Vector4 vector = Utilities.GenerateVector4();
            Matrix transform = Utilities.GenerateMatrix();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.DirectX.Vector4.Transform(
                Utilities.ConvertToMdx(vector),
                Utilities.ConvertToMdx(transform)));

            Vector4 actual;
            actual = Vector4.Transform(vector, transform);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TransformMatrixByRefTest()
        {
            Vector4 vector = Utilities.GenerateVector4();
            Vector4 vectorExpected = vector;
            Matrix transform = Utilities.GenerateMatrix();
            Matrix transformExpected = transform;
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Vector4.Transform(
                Utilities.ConvertToMdx(vector),
                Utilities.ConvertToMdx(transform)));

            Vector4.Transform(ref vector, ref transform, out result);
            Utilities.AreEqual(vectorExpected, vector);
            Utilities.AreEqual(transformExpected, transform);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void TransformMatrixArrayByRefTest()
        {
            Vector4[] source =
            {
                Utilities.GenerateVector4(),
                Utilities.GenerateVector4(),
                Utilities.GenerateVector4(),
                Utilities.GenerateVector4(),
                Utilities.GenerateVector4()
            };
            Matrix transform = Utilities.GenerateMatrix();
            Matrix transformExpected = transform;
            Vector4[] destination = new Vector4[source.Length];
            Vector4.Transform(source, ref transform, destination);

            for (int i = 0; i < source.Length; ++i)
            {
                Vector4 temp = Utilities.ConvertFrom(Microsoft.DirectX.Vector4.Transform(
                    Utilities.ConvertToMdx(source[i]),
                    Utilities.ConvertToMdx(transform)));
                Utilities.AreEqual(destination[i], temp);
            }
        }

        [TestMethod()]
        public void op_AdditionTest()
        {
            Vector4 left = Utilities.GenerateVector4();
            Vector4 right = Utilities.GenerateVector4();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Add(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector4 actual;
            actual = (left + right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_DivisionTest()
        {
            Vector4 value = Utilities.GenerateVector4();
            float scale = Utilities.GenerateFloat();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Divide(
                Utilities.ConvertToXna(value),
                scale));

            Vector4 actual;
            actual = (value / scale);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_EqualityTest()
        {
            Vector4 left = Utilities.GenerateVector4();
            Vector4 right = new Vector4(left.X + 1f, left.Y - 1f, left.Z, left.W + 2f);
            bool expected = false;
            bool actual;
            actual = left == right;
            Utilities.AreEqual(expected, actual);

            left = Utilities.GenerateVector4();
            right = left;
            expected = true;
            actual = left == right;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_ExplicitTest()
        {
            Vector4 value = Utilities.GenerateVector4();

            Vector3 expected = new Vector3(value.X, value.Y, value.Z);

            Vector3 actual;
            actual = ((Vector3)(value));
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_ExplicitTest1()
        {
            Vector4 value = Utilities.GenerateVector4();

            Vector2 expected = new Vector2(value.X, value.Y);

            Vector2 actual;
            actual = ((Vector2)(value));
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_InequalityTest()
        {
            Vector4 left = Utilities.GenerateVector4();
            Vector4 right = new Vector4(left.X + 1f, left.Y - 1f, left.Z, left.W + 2f);
            bool expected = true;
            bool actual;
            actual = left != right;
            Utilities.AreEqual(expected, actual);

            left = Utilities.GenerateVector4();
            right = left;
            expected = false;
            actual = left != right;
            Utilities.AreEqual(expected, actual);

            left = Utilities.GenerateVector4();
            right = new Vector4(left.X + (Utilities.ZeroTolerance / 2f), left.Y - (Utilities.ZeroTolerance / 2f), left.Z + (Utilities.ZeroTolerance / 2f), left.W - (Utilities.ZeroTolerance / 2f));
            expected = false;
            actual = left != right;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_MultiplyTest()
        {
            Vector4 value = Utilities.GenerateVector4();
            float scale = Utilities.GenerateFloat();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Multiply(
                Utilities.ConvertToXna(value),
                scale));

            Vector4 actual;
            actual = (value * scale);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_MultiplyTest1()
        {
            float scale = Utilities.GenerateFloat();
            Vector4 value = Utilities.GenerateVector4();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Multiply(
                Utilities.ConvertToXna(value),
                scale));

            Vector4 actual;
            actual = (scale * value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_SubtractionTest()
        {
            Vector4 left = Utilities.GenerateVector4();
            Vector4 right = Utilities.GenerateVector4();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Subtract(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector4 actual;
            actual = (left - right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_UnaryNegationTest()
        {
            Vector4 value = Utilities.GenerateVector4();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector4.Negate(
                Utilities.ConvertToXna(value)));

            Vector4 actual;
            actual = -(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_UnaryPlusTest()
        {
            Vector4 value = Utilities.GenerateVector4();

            Vector4 expected = value;

            Vector4 actual;
            actual = +(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsNormalizedTest()
        {
            Vector4 target = Utilities.GenerateVector4();
            bool expected = false;
            bool actual;
            actual = target.IsNormalized;
            Utilities.AreEqual(expected, actual);

            target = Utilities.GenerateVector4();
            target.Normalize();
            expected = true;
            actual = target.IsNormalized;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ItemTest()
        {
            Vector4 target = Utilities.GenerateVector4();
            int index = 0;
            float expected = 7.3f;
            float actual;
            target[index] = expected;
            actual = target[index];
            Utilities.AreEqual(expected, actual);

            index = 1;
            expected = 5.8f;
            target[index] = expected;
            actual = target[index];
            Utilities.AreEqual(expected, actual);

            index = -1;
            expected = 4.1f;
            try
            {
                target[index] = expected;
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {

            }
            catch
            {
                Assert.Fail("Wrong exception type thrown.");
            }

            try
            {
                actual = target[index];
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {

            }
            catch
            {
                Assert.Fail("Wrong exception type thrown.");
            }

            index = 4;
            expected = 4.1f;
            try
            {
                target[index] = expected;
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {

            }
            catch
            {
                Assert.Fail("Wrong exception type thrown.");
            }

            try
            {
                actual = target[index];
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {

            }
            catch
            {
                Assert.Fail("Wrong exception type thrown.");
            }
        }
    }
}
