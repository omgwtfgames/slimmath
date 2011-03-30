using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlimMath;

namespace SlimMathManagedTests
{
    [TestClass()]
    public class Vector2Test
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
        public void Vector2ReadonlyFieldsTest()
        {
            Utilities.AreEqual(System.Runtime.InteropServices.Marshal.SizeOf(typeof(Vector2)), Vector2.SizeInBytes);
            Utilities.AreEqual(new Vector2() { X = 0f, Y = 0f }, Vector2.Zero);
            Utilities.AreEqual(new Vector2() { X = 1f, Y = 1f }, Vector2.One);
            Utilities.AreEqual(new Vector2() { X = 1f, Y = 0f }, Vector2.UnitX);
            Utilities.AreEqual(new Vector2() { X = 0f, Y = 1f }, Vector2.UnitY);

            Vector2 t = new Vector2(1, 1);
            Vector2 q = new Vector2(2, 2);

            t += q;
        }

        [TestMethod()]
        public void Vector2ConstructorTest()
        {
            float[] values = 
            {
                Utilities.GenerateFloat(),
                Utilities.GenerateFloat()
            };
            Vector2 target = new Vector2(values);

            Utilities.AreEqual(values[0], target.X, 0f);
            Utilities.AreEqual(values[1], target.Y, 0f);
        }

        [TestMethod()]
        public void Vector2ConstructorTest1()
        {
            float x = Utilities.GenerateFloat();
            float y = Utilities.GenerateFloat();
            Vector2 target = new Vector2(x, y);

            Utilities.AreEqual(x, target.X, 0f);
            Utilities.AreEqual(y, target.Y, 0f);
        }

        [TestMethod()]
        public void Vector2ConstructorTest2()
        {
            float value = Utilities.GenerateFloat();
            Vector2 target = new Vector2(value);

            Utilities.AreEqual(value, target.X, 0f);
            Utilities.AreEqual(value, target.Y, 0f);
        }

        [TestMethod()]
        public void AddTest()
        {
            Vector2 left = Utilities.GenerateVector2();
            Vector2 right = Utilities.GenerateVector2();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Add(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector2 actual;
            actual = Vector2.Add(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddByRefTest()
        {
            Vector2 left = Utilities.GenerateVector2();
            Vector2 leftExpected = left;
            Vector2 right = Utilities.GenerateVector2();
            Vector2 rightExpected = right;
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Add(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector2.Add(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void BarycentricTest()
        {
            Vector2 value1 = Utilities.GenerateVector2();
            Vector2 value2 = Utilities.GenerateVector2();
            Vector2 value3 = Utilities.GenerateVector2();
            float amount1 = Utilities.GenerateFloat();
            float amount2 = Utilities.GenerateFloat();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Barycentric(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2),
                Utilities.ConvertToXna(value3),
                amount1,
                amount2));

            Vector2 actual;
            actual = Vector2.Barycentric(value1, value2, value3, amount1, amount2);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BarycentricByRefTest()
        {
            Vector2 value1 = Utilities.GenerateVector2();
            Vector2 value1Expected = value1;
            Vector2 value2 = Utilities.GenerateVector2();
            Vector2 value2Expected = value2;
            Vector2 value3 = Utilities.GenerateVector2();
            Vector2 value3Expected = value3;
            float amount1 = Utilities.GenerateFloat();
            float amount2 = Utilities.GenerateFloat();
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Barycentric(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2),
                Utilities.ConvertToXna(value3),
                amount1,
                amount2));

            Vector2.Barycentric(ref value1, ref value2, ref value3, amount1, amount2, out result);
            Utilities.AreEqual(value1Expected, value1);
            Utilities.AreEqual(value2Expected, value2);
            Utilities.AreEqual(value3Expected, value3);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void CatmullRomTest()
        {
            Vector2 value1 = Utilities.GenerateVector2();
            Vector2 value2 = Utilities.GenerateVector2();
            Vector2 value3 = Utilities.GenerateVector2();
            Vector2 value4 = Utilities.GenerateVector2();
            float amount = Utilities.GenerateFloat();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.CatmullRom(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2),
                Utilities.ConvertToXna(value3),
                Utilities.ConvertToXna(value4),
                amount));

            Vector2 actual;
            actual = Vector2.CatmullRom(value1, value2, value3, value4, amount);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CatmullRomByRefTest()
        {
            Vector2 value1 = Utilities.GenerateVector2();
            Vector2 value1Expected = value1;
            Vector2 value2 = Utilities.GenerateVector2();
            Vector2 value2Expected = value2;
            Vector2 value3 = Utilities.GenerateVector2();
            Vector2 value3Expected = value3;
            Vector2 value4 = Utilities.GenerateVector2();
            Vector2 value4Expected = value4;
            float amount = Utilities.GenerateFloat();
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.CatmullRom(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2),
                Utilities.ConvertToXna(value3),
                Utilities.ConvertToXna(value4),
                amount));

            Vector2.CatmullRom(ref value1, ref value2, ref value3, ref value4, amount, out result);
            Utilities.AreEqual(value1Expected, value1);
            Utilities.AreEqual(value2Expected, value2);
            Utilities.AreEqual(value3Expected, value3);
            Utilities.AreEqual(value4Expected, value4);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void ClampTest()
        {
            Vector2 value = new Vector2(Utilities.GenerateFloatSmall(), Utilities.GenerateFloatLarge());
            Vector2 min = Utilities.GenerateVector2();
            Vector2 max = Utilities.GenerateVector2();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Clamp(
                Utilities.ConvertToXna(value),
                Utilities.ConvertToXna(min),
                Utilities.ConvertToXna(max)));

            Vector2 actual;
            actual = Vector2.Clamp(value, min, max);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ClampByRefTest()
        {
            Vector2 value = new Vector2(Utilities.GenerateFloatSmall(), Utilities.GenerateFloatLarge());
            Vector2 valueExpected = value;
            Vector2 min = Utilities.GenerateVector2();
            Vector2 minExpected = min;
            Vector2 max = Utilities.GenerateVector2();
            Vector2 maxExpected = max;
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Clamp(
                Utilities.ConvertToXna(value),
                Utilities.ConvertToXna(min),
                Utilities.ConvertToXna(max)));

            Vector2.Clamp(ref value, ref min, ref max, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(minExpected, min);
            Utilities.AreEqual(maxExpected, max);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void DistanceTest()
        {
            Vector2 value1 = Utilities.GenerateVector2();
            Vector2 value2 = Utilities.GenerateVector2();

            float expected = Microsoft.Xna.Framework.Vector2.Distance(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2));

            float actual;
            actual = Vector2.Distance(value1, value2);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DistanceByRefTest()
        {
            Vector2 value1 = Utilities.GenerateVector2();
            Vector2 value1Expected = value1;
            Vector2 value2 = Utilities.GenerateVector2();
            Vector2 value2Expected = value2;
            float result;

            float resultExpected = Microsoft.Xna.Framework.Vector2.Distance(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2));

            Vector2.Distance(ref value1, ref value2, out result);
            Utilities.AreEqual(value1Expected, value1);
            Utilities.AreEqual(value2Expected, value2);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void DistanceSquaredTest()
        {
            Vector2 value1 = Utilities.GenerateVector2();
            Vector2 value2 = Utilities.GenerateVector2();

            float expected = Microsoft.Xna.Framework.Vector2.DistanceSquared(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2));

            float actual;
            actual = Vector2.DistanceSquared(value1, value2);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DistanceSquaredByRefTest()
        {
            Vector2 value1 = Utilities.GenerateVector2();
            Vector2 value1Expected = value1;
            Vector2 value2 = Utilities.GenerateVector2();
            Vector2 value2Expected = value2;
            float result;

            float resultExpected = Microsoft.Xna.Framework.Vector2.DistanceSquared(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2));

            Vector2.DistanceSquared(ref value1, ref value2, out result);
            Utilities.AreEqual(value1Expected, value1);
            Utilities.AreEqual(value2Expected, value2);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void DivideTest()
        {
            Vector2 value = Utilities.GenerateVector2();
            float scale = Utilities.GenerateFloat();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Divide(
                Utilities.ConvertToXna(value),
                scale));

            Vector2 actual;
            actual = Vector2.Divide(value, scale);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DivideByRefTest()
        {
            Vector2 value = Utilities.GenerateVector2();
            Vector2 valueExpected = value;
            float scale = Utilities.GenerateFloat();
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Divide(
                Utilities.ConvertToXna(value),
                scale));

            Vector2.Divide(ref value, scale, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void DotTest()
        {
            Vector2 left = Utilities.GenerateVector2();
            Vector2 right = Utilities.GenerateVector2();

            float expected = Microsoft.Xna.Framework.Vector2.Dot(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right));

            float actual;
            actual = Vector2.Dot(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DotByRefTest()
        {
            Vector2 left = Utilities.GenerateVector2();
            Vector2 leftExpected = left;
            Vector2 right = Utilities.GenerateVector2();
            Vector2 rightExpected = right;
            float result;

            float resultExpected = Microsoft.Xna.Framework.Vector2.Dot(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right));

            Vector2.Dot(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Vector2 target = Utilities.GenerateVector2();
            Vector2 other = new Vector2(target.X + 1f, target.Y - 1f);
            bool expected = false;
            bool actual;
            actual = target.Equals(other);
            Utilities.AreEqual(expected, actual);

            target = Utilities.GenerateVector2();
            other = target;
            expected = true;
            actual = target.Equals(other);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EqualsTest1()
        {
            Vector2 target = new Vector2(5f, 8.5f);
            object value = new Vector2(6f, 15.1f);
            bool expected = false;
            bool actual;
            actual = target.Equals(value);
            Utilities.AreEqual(expected, actual);

            target = new Vector2(7f, 3f);
            value = new Vector2(7f, 3f);
            expected = true;
            actual = target.Equals(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void HermiteTest()
        {
            Vector2 value1 = Utilities.GenerateVector2();
            Vector2 tangent1 = Utilities.GenerateVector2();
            Vector2 value2 = Utilities.GenerateVector2();
            Vector2 tangent2 = Utilities.GenerateVector2();
            float amount = Utilities.GenerateFloat();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Hermite(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(tangent1),
                Utilities.ConvertToXna(value2),
                Utilities.ConvertToXna(tangent2),
                amount));

            Vector2 actual;
            actual = Vector2.Hermite(value1, tangent1, value2, tangent2, amount);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void HermiteByRefTest()
        {
            Vector2 value1 = Utilities.GenerateVector2();
            Vector2 value1Expected = value1;
            Vector2 tangent1 = Utilities.GenerateVector2();
            Vector2 tangent1Expected = tangent1;
            Vector2 value2 = Utilities.GenerateVector2();
            Vector2 value2Expected = value2;
            Vector2 tangent2 = Utilities.GenerateVector2();
            Vector2 tangent2Expected = tangent2;
            float amount = Utilities.GenerateFloat();
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Hermite(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(tangent1),
                Utilities.ConvertToXna(value2),
                Utilities.ConvertToXna(tangent2),
                amount));

            Vector2.Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
            Utilities.AreEqual(value1Expected, value1);
            Utilities.AreEqual(tangent1Expected, tangent1);
            Utilities.AreEqual(value2Expected, value2);
            Utilities.AreEqual(tangent2Expected, tangent2);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void LengthTest()
        {
            Vector2 target = Utilities.GenerateVector2();

            float expected = Utilities.ConvertToXna(target).Length();

            float actual;
            actual = target.Length;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LengthSquaredTest()
        {
            Vector2 target = Utilities.GenerateVector2();

            float expected = Utilities.ConvertToXna(target).LengthSquared();

            float actual;
            actual = target.LengthSquared;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LerpTest()
        {
            Vector2 start = Utilities.GenerateVector2();
            Vector2 end = Utilities.GenerateVector2();
            float amount = Utilities.GenerateFloat();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Lerp(
                Utilities.ConvertToXna(start),
                Utilities.ConvertToXna(end),
                amount));

            Vector2 actual;
            actual = Vector2.Lerp(start, end, amount);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LerpByRefTest()
        {
            Vector2 start = Utilities.GenerateVector2();
            Vector2 startExpected = start;
            Vector2 end = Utilities.GenerateVector2();
            Vector2 endExpected = end;
            float amount = Utilities.GenerateFloat();
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Lerp(
                Utilities.ConvertToXna(start),
                Utilities.ConvertToXna(end),
                amount));

            Vector2.Lerp(ref start, ref end, amount, out result);
            Utilities.AreEqual(startExpected, start);
            Utilities.AreEqual(endExpected, end);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void MaxTest()
        {
            Vector2 left = Utilities.GenerateVector2();
            Vector2 right = Utilities.GenerateVector2();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Max(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector2 actual;
            actual = Vector2.Max(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MaxByRefTest()
        {
            Vector2 left = Utilities.GenerateVector2();
            Vector2 leftExpected = left;
            Vector2 right = Utilities.GenerateVector2();
            Vector2 rightExpected = right;
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Max(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector2.Max(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void MinTest()
        {
            Vector2 left = Utilities.GenerateVector2();
            Vector2 right = Utilities.GenerateVector2();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Min(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector2 actual;
            actual = Vector2.Min(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinByRefTest()
        {
            Vector2 left = Utilities.GenerateVector2();
            Vector2 leftExpected = left;
            Vector2 right = Utilities.GenerateVector2();
            Vector2 rightExpected = right;
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Min(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector2.Min(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void ModulateTest()
        {
            Vector2 left = Utilities.GenerateVector2();
            Vector2 right = Utilities.GenerateVector2();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Multiply(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector2 actual;
            actual = Vector2.Modulate(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ModulateByRefTest()
        {
            Vector2 left = Utilities.GenerateVector2();
            Vector2 leftExpected = left;
            Vector2 right = Utilities.GenerateVector2();
            Vector2 rightExpected = right;
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Multiply(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector2.Modulate(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            Vector2 value = Utilities.GenerateVector2();
            float scale = Utilities.GenerateFloat();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Multiply(
                Utilities.ConvertToXna(value),
                scale));

            Vector2 actual;
            actual = Vector2.Multiply(value, scale);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MultiplyByRefTest()
        {
            Vector2 value = Utilities.GenerateVector2();
            Vector2 valueExpected = value;
            float scale = Utilities.GenerateFloat();
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Multiply(
                Utilities.ConvertToXna(value),
                scale));

            Vector2.Multiply(ref value, scale, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void NegateTest()
        {
            Vector2 value = Utilities.GenerateVector2();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Negate(
                Utilities.ConvertToXna(value)));

            Vector2 actual;
            actual = Vector2.Negate(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NegateByRefTest()
        {
            Vector2 value = Utilities.GenerateVector2();
            Vector2 valueExpected = value;
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Negate(
                Utilities.ConvertToXna(value)));

            Vector2.Negate(ref value, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void NormalizeTest()
        {
            Vector2 target = Utilities.GenerateVector2();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Normalize(
                Utilities.ConvertToXna(target)));

            target.Normalize();
            Utilities.AreEqual(expected, target);
        }

        [TestMethod()]
        public void NormalizeTest1()
        {
            Vector2 value = Utilities.GenerateVector2();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Normalize(
                Utilities.ConvertToXna(value)));

            Vector2 actual;
            actual = Vector2.Normalize(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NormalizeByRefTest()
        {
            Vector2 value = Utilities.GenerateVector2();
            Vector2 valueExpected = value;
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Normalize(
                Utilities.ConvertToXna(value)));

            Vector2.Normalize(ref value, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void OrthogonalizeTest()
        {
            //Because orthogonalization is numerically unstable, we adjust the assert delta.
            float deltabefore = Utilities.AssertDelta;
            Utilities.AssertDelta = 1e-2f;

            Vector2[] source = new Vector2[5];
            Vector2[] destination = new Vector2[5];

            for (int i = 0; i < source.Length; ++i)
            {
                source[i] = Utilities.GenerateVector2();
            }

            Vector2.Orthogonalize(destination, source);

            Utilities.AreEqual(0f, Vector2.Dot(destination[0], destination[1]));
            Utilities.AreEqual(0f, Vector2.Dot(destination[0], destination[2]));
            Utilities.AreEqual(0f, Vector2.Dot(destination[0], destination[3]));
            Utilities.AreEqual(0f, Vector2.Dot(destination[0], destination[4]));

            Utilities.AreEqual(0f, Vector2.Dot(destination[1], destination[2]));
            Utilities.AreEqual(0f, Vector2.Dot(destination[1], destination[3]));
            Utilities.AreEqual(0f, Vector2.Dot(destination[1], destination[4]));

            Utilities.AreEqual(0f, Vector2.Dot(destination[2], destination[3]));
            Utilities.AreEqual(0f, Vector2.Dot(destination[2], destination[4]));

            Utilities.AreEqual(0f, Vector2.Dot(destination[3], destination[4]));

            //Reset the assert delta.
            Utilities.AssertDelta = deltabefore;
        }

        [TestMethod()]
        public void OrthonormalizeTest()
        {
            //Because orthogonalization is numerically unstable, we adjust the assert delta.
            float deltabefore = Utilities.AssertDelta;
            Utilities.AssertDelta = 1e-2f;

            Vector2[] source = new Vector2[4];
            Vector2[] destination = new Vector2[4];

            for (int i = 0; i < source.Length; ++i)
            {
                source[i] = Utilities.GenerateVector2();
            }

            Vector2.Orthonormalize(destination, source);

            for (int i = 0; i < destination.Length; ++i)
            {
                Utilities.AreEqual(1f, destination[i].Length);
            }

            Utilities.AreEqual(0f, Vector2.Dot(destination[0], destination[1]));
            Utilities.AreEqual(0f, Vector2.Dot(destination[0], destination[2]));
            Utilities.AreEqual(0f, Vector2.Dot(destination[0], destination[3]));

            Utilities.AreEqual(0f, Vector2.Dot(destination[1], destination[2]));
            Utilities.AreEqual(0f, Vector2.Dot(destination[1], destination[3]));

            Utilities.AreEqual(0f, Vector2.Dot(destination[2], destination[3]));

            //Reset the assert delta.
            Utilities.AssertDelta = deltabefore;
        }

        [TestMethod()]
        public void PerpDotTest()
        {
            Vector2 left = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 right = new Vector2(); // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;

            actual = Vector2.PerpDot(left, right);

            Assert.AreEqual(expected, actual);

            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void PerpDotByRefTest()
        {
            Vector2 left = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 leftExpected = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 right = new Vector2(); // TODO: Initialize to an appropriate value
            Vector2 rightExpected = new Vector2(); // TODO: Initialize to an appropriate value
            float result = 0F; // TODO: Initialize to an appropriate value
            float resultExpected = 0F; // TODO: Initialize to an appropriate value

            Vector2.PerpDot(ref left, ref right, out result);

            Assert.AreEqual(leftExpected, left);
            Assert.AreEqual(rightExpected, right);
            Assert.AreEqual(resultExpected, result);

            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void PerpTest()
        {
            Vector2 vector = Utilities.GenerateVector2();
            Vector2 actual;

            actual = Vector2.Perp(vector);

            Vector2 expected = (Vector2)Vector3.Cross(new Vector3(vector.X, vector.Y, 0f), new Vector3(0f, 0f, -1f));

            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PerpByRefTest()
        {
            Vector2 vector = Utilities.GenerateVector2();
            Vector2 vectorExpected = vector;

            Vector2 result = Utilities.GenerateVector2();

            Vector2 expected = (Vector2)Vector3.Cross(new Vector3(vector.X, vector.Y, 0f), new Vector3(0f, 0f, -1f));

            Utilities.AreEqual(vectorExpected, vector);
            Utilities.AreEqual(result, result);
        }

        [TestMethod()]
        public void ReflectTest()
        {
            Vector2 vector = Utilities.GenerateVector2();
            Vector2 normal = Utilities.GenerateVector2();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Reflect(
                Utilities.ConvertToXna(vector),
                Utilities.ConvertToXna(normal)));

            Vector2 actual;
            actual = Vector2.Reflect(vector, normal);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ReflectByRefTest()
        {
            Vector2 vector = Utilities.GenerateVector2();
            Vector2 vectorExpected = vector;
            Vector2 normal = Utilities.GenerateVector2();
            Vector2 normalExpected = normal;
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Reflect(
                Utilities.ConvertToXna(vector),
                Utilities.ConvertToXna(normal)));

            Vector2.Reflect(ref vector, ref normal, out result);
            Utilities.AreEqual(vectorExpected, vector);
            Utilities.AreEqual(normalExpected, normal);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void SmoothStepTest()
        {
            Vector2 start = Utilities.GenerateVector2();
            Vector2 end = Utilities.GenerateVector2();
            float amount = Utilities.GenerateFloat();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.SmoothStep(
                Utilities.ConvertToXna(start),
                Utilities.ConvertToXna(end),
                amount));

            Vector2 actual;
            actual = Vector2.SmoothStep(start, end, amount);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SmoothStepByRefTest()
        {
            Vector2 start = Utilities.GenerateVector2();
            Vector2 startExpected = start;
            Vector2 end = Utilities.GenerateVector2();
            Vector2 endExpected = end;
            float amount = Utilities.GenerateFloat();
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.SmoothStep(
                Utilities.ConvertToXna(start),
                Utilities.ConvertToXna(end),
                amount));

            Vector2.SmoothStep(ref start, ref end, amount, out result);
            Utilities.AreEqual(startExpected, start);
            Utilities.AreEqual(endExpected, end);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void SubtractTest()
        {
            Vector2 left = Utilities.GenerateVector2();
            Vector2 right = Utilities.GenerateVector2();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Subtract(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector2 actual;
            actual = Vector2.Subtract(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SubtractByRefTest()
        {
            Vector2 left = Utilities.GenerateVector2();
            Vector2 leftExpected = left;
            Vector2 right = Utilities.GenerateVector2();
            Vector2 rightExpected = right;
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Subtract(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector2.Subtract(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void ToArrayTest()
        {
            Vector2 target = Utilities.GenerateVector2();
            float[] expected = { target.X, target.Y };
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
            Vector2 vector = Utilities.GenerateVector2();
            Quaternion rotation = Utilities.GenerateQuaternion();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Transform(
                Utilities.ConvertToXna(vector),
                Utilities.ConvertToXna(rotation)));

            Vector2 actual;
            actual = Vector2.Transform(vector, rotation);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TransformQuaternionByRefTest()
        {
            Vector2 vector = Utilities.GenerateVector2();
            Vector2 vectorExpected = vector;
            Quaternion rotation = Utilities.GenerateQuaternion();
            Quaternion rotationExpected = rotation;
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Transform(
                Utilities.ConvertToXna(vector),
                Utilities.ConvertToXna(rotation)));

            Vector2.Transform(ref vector, ref rotation, out result);
            Utilities.AreEqual(vectorExpected, vector);
            Utilities.AreEqual(rotationExpected, rotation);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void TransformQuaternionArrayByRefTest()
        {
            Vector2[] source =
            {
                Utilities.GenerateVector2(),
                Utilities.GenerateVector2(),
                Utilities.GenerateVector2(),
                Utilities.GenerateVector2(),
                Utilities.GenerateVector2()
            };
            Quaternion rotation = Utilities.GenerateQuaternion();
            Quaternion rotationExpected = rotation;
            Vector2[] destination = new Vector2[source.Length];
            Vector2.Transform(source, ref rotation, destination);

            for (int i = 0; i < source.Length; ++i)
            {
                Vector2 temp = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Transform(
                    Utilities.ConvertToXna(source[i]),
                    Utilities.ConvertToXna(rotation)));
                Utilities.AreEqual(destination[i], temp);
            }
        }

        [TestMethod()]
        public void TransformMatrixTest()
        {
            Vector2 vector = Utilities.GenerateVector2();
            Matrix transform = Utilities.GenerateMatrix();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.DirectX.Vector2.Transform(
                Utilities.ConvertToMdx(vector),
                Utilities.ConvertToMdx(transform)));

            Vector4 actual;
            actual = Vector2.Transform(vector, transform);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TransformMatrixByRefTest()
        {
            Vector2 vector = Utilities.GenerateVector2();
            Vector2 vectorExpected = vector;
            Matrix transform = Utilities.GenerateMatrix();
            Matrix transformExpected = transform;
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Vector2.Transform(
                Utilities.ConvertToMdx(vector),
                Utilities.ConvertToMdx(transform)));

            Vector2.Transform(ref vector, ref transform, out result);
            Utilities.AreEqual(vectorExpected, vector);
            Utilities.AreEqual(transformExpected, transform);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void TransformMatrixArrayByRefTest()
        {
            Vector2[] source =
            {
                Utilities.GenerateVector2(),
                Utilities.GenerateVector2(),
                Utilities.GenerateVector2(),
                Utilities.GenerateVector2(),
                Utilities.GenerateVector2()
            };
            Matrix transform = Utilities.GenerateMatrix();
            Matrix transformExpected = transform;
            Vector4[] destination = new Vector4[source.Length];
            Vector2.Transform(source, ref transform, destination);

            for (int i = 0; i < source.Length; ++i)
            {
                Vector4 temp = Utilities.ConvertFrom(Microsoft.DirectX.Vector2.Transform(
                    Utilities.ConvertToMdx(source[i]),
                    Utilities.ConvertToMdx(transform)));
                Utilities.AreEqual(destination[i], temp);
            }
        }

        [TestMethod()]
        public void TransformCoordinateTest()
        {
            Vector2 coordinate = Utilities.GenerateVector2();
            Matrix transform = Utilities.GenerateMatrix();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.DirectX.Vector2.TransformCoordinate(
                Utilities.ConvertToMdx(coordinate),
                Utilities.ConvertToMdx(transform)));

            Vector2 actual;
            actual = Vector2.TransformCoordinate(coordinate, transform);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TransformCoordinateByRefTest()
        {
            Vector2 coordinate = Utilities.GenerateVector2();
            Vector2 coordinateExpected = coordinate;
            Matrix transform = Utilities.GenerateMatrix();
            Matrix transformExpected = transform;
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Vector2.TransformCoordinate(
                Utilities.ConvertToMdx(coordinate),
                Utilities.ConvertToMdx(transform)));

            Vector2.TransformCoordinate(ref coordinate, ref transform, out result);
            Utilities.AreEqual(coordinateExpected, coordinate);
            Utilities.AreEqual(transformExpected, transform);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void TransformCoordinateArrayByRefTest()
        {
            Vector2[] source =
            {
                Utilities.GenerateVector2(),
                Utilities.GenerateVector2(),
                Utilities.GenerateVector2(),
                Utilities.GenerateVector2(),
                Utilities.GenerateVector2()
            };
            Matrix transform = Utilities.GenerateMatrix();
            Matrix transformExpected = transform;
            Vector2[] destination = new Vector2[source.Length];
            Vector2.TransformCoordinate(source, ref transform, destination);

            for (int i = 0; i < destination.Length; ++i)
            {
                Vector2 temp = Utilities.ConvertFrom(Microsoft.DirectX.Vector2.TransformCoordinate(
                    Utilities.ConvertToMdx(source[i]),
                    Utilities.ConvertToMdx(transform)));
                Utilities.AreEqual(destination[i], temp);
            }
        }

        [TestMethod()]
        public void TransformNormalTest()
        {
            Vector2 normal = Utilities.GenerateVector2();
            Matrix transform = Utilities.GenerateMatrix();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.DirectX.Vector2.TransformNormal(
                Utilities.ConvertToMdx(normal),
                Utilities.ConvertToMdx(transform)));

            Vector2 actual;
            actual = Vector2.TransformNormal(normal, transform);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TransformNormalByRefTest()
        {
            Vector2 normal = Utilities.GenerateVector2();
            Vector2 normalExpected = normal;
            Matrix transform = Utilities.GenerateMatrix();
            Matrix transformExpected = transform;
            Vector2 result;

            Vector2 resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Vector2.TransformNormal(
                Utilities.ConvertToMdx(normal),
                Utilities.ConvertToMdx(transform)));

            Vector2.TransformNormal(ref normal, ref transform, out result);
            Utilities.AreEqual(normalExpected, normal);
            Utilities.AreEqual(transformExpected, transform);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void TransformNormalArrayByRefTest()
        {
            Vector2[] source = new Vector2[]
            {
                Utilities.GenerateVector2(),
                Utilities.GenerateVector2(),
                Utilities.GenerateVector2(),
                Utilities.GenerateVector2(),
                Utilities.GenerateVector2()
            };
            Matrix transform = Utilities.GenerateMatrix();
            Matrix transformExpected = transform;
            Vector2[] destination = new Vector2[source.Length];
            Vector2.TransformNormal(source, ref transform, destination);

            for (int i = 0; i < destination.Length; ++i)
            {
                Vector2 temp = Utilities.ConvertFrom(Microsoft.DirectX.Vector2.TransformNormal(
                Utilities.ConvertToMdx(source[i]),
                Utilities.ConvertToMdx(transform)));
                Utilities.AreEqual(destination[i], temp);
            }
        }

        [TestMethod()]
        public void op_AdditionTest()
        {
            Vector2 left = Utilities.GenerateVector2();
            Vector2 right = Utilities.GenerateVector2();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Add(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector2 actual;
            actual = (left + right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_DivisionTest()
        {
            Vector2 value = Utilities.GenerateVector2();
            float scale = Utilities.GenerateFloat();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Divide(
                Utilities.ConvertToXna(value),
                scale));

            Vector2 actual;
            actual = (value / scale);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_EqualityTest()
        {
            Vector2 left = new Vector2(5f, 8.5f);
            Vector2 right = new Vector2(6f, 15.1f);
            bool expected = false;
            bool actual;
            actual = (left == right);
            Utilities.AreEqual(expected, actual);

            left = new Vector2(7f, 3f);
            right = new Vector2(7f, 3f);
            expected = true;
            actual = (left == right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_ExplicitTest()
        {
            Vector2 value = Utilities.GenerateVector2();

            Vector4 expected = new Vector4(value.X, value.Y, 0f, 0f);

            Vector4 actual;
            actual = ((Vector4)(value));
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_ExplicitTest1()
        {
            Vector2 value = Utilities.GenerateVector2();

            Vector3 expected = new Vector3(value.X, value.Y, 0f);

            Vector3 actual;
            actual = ((Vector3)(value));
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_InequalityTest()
        {
            Vector2 left = new Vector2(5f, 8.5f);
            Vector2 right = new Vector2(6f, 15.1f);
            bool expected = true;
            bool actual;
            actual = (left != right);
            Utilities.AreEqual(expected, actual);

            left = new Vector2(7f, 3f);
            right = new Vector2(7f, 3f);
            expected = false;
            actual = (left != right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_MultiplyTest()
        {
            Vector2 value = Utilities.GenerateVector2();
            float scale = Utilities.GenerateFloat();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Multiply(
                Utilities.ConvertToXna(value),
                scale));

            Vector2 actual;
            actual = (value * scale);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_MultiplyTest1()
        {
            float scale = Utilities.GenerateFloat();
            Vector2 value = Utilities.GenerateVector2();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Multiply(
                Utilities.ConvertToXna(value),
                scale));

            Vector2 actual;
            actual = (scale * value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_SubtractionTest()
        {
            Vector2 left = Utilities.GenerateVector2();
            Vector2 right = Utilities.GenerateVector2();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Subtract(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector2 actual;
            actual = (left - right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_UnaryNegationTest()
        {
            Vector2 value = Utilities.GenerateVector2();

            Vector2 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector2.Negate(
                Utilities.ConvertToXna(value)));

            Vector2 actual;
            actual = -(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_UnaryPlusTest()
        {
            Vector2 value = Utilities.GenerateVector2();

            Vector2 expected = value;

            Vector2 actual;
            actual = +(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsNormalizedTest()
        {
            Vector2 target = Utilities.GenerateVector2();
            bool expected = false;
            bool actual;
            actual = target.IsNormalized;
            Utilities.AreEqual(expected, actual);

            target = Utilities.GenerateVector2();
            target.Normalize();
            expected = true;
            actual = target.IsNormalized;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ItemTest()
        {
            Vector2 target = Utilities.GenerateVector2();
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

            index = 2;
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
