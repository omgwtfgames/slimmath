using SlimMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SlimMathManagedTests
{
    [TestClass()]
    public class Vector3Test
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
        public void Vector3ReadonlyFieldsTest()
        {
            Utilities.AreEqual(System.Runtime.InteropServices.Marshal.SizeOf(typeof(Vector3)), Vector3.SizeInBytes);
            Utilities.AreEqual(new Vector3() { X = 0f, Y = 0f, Z = 0f }, Vector3.Zero);
            Utilities.AreEqual(new Vector3() { X = 1f, Y = 1f, Z = 1f }, Vector3.One);
            Utilities.AreEqual(new Vector3() { X = 1f, Y = 0f, Z = 0f }, Vector3.UnitX);
            Utilities.AreEqual(new Vector3() { X = 0f, Y = 1f, Z = 0f }, Vector3.UnitY);
            Utilities.AreEqual(new Vector3() { X = 0f, Y = 0f, Z = 1f }, Vector3.UnitZ);
        }

        [TestMethod()]
        public void Vector3ConstructorTest()
        {
            Vector2 value = Utilities.GenerateVector2();
            float z = Utilities.GenerateFloat();
            Vector3 target = new Vector3(value, z);

            Utilities.AreEqual(value.X, target.X, 0f);
            Utilities.AreEqual(value.Y, target.Y, 0f);
            Utilities.AreEqual(z, target.Z, 0f);
        }

        [TestMethod()]
        public void Vector3ConstructorTest1()
        {
            float[] values = new float[]
            {
                Utilities.GenerateFloat(),
                Utilities.GenerateFloat(),
                Utilities.GenerateFloat()
            };
            Vector3 target = new Vector3(values);

            Utilities.AreEqual(values[0], target.X, 0f);
            Utilities.AreEqual(values[1], target.Y, 0f);
            Utilities.AreEqual(values[2], target.Z, 0f);
        }

        [TestMethod()]
        public void Vector3ConstructorTest2()
        {
            float value = Utilities.GenerateFloat();
            Vector3 target = new Vector3(value);

            Utilities.AreEqual(value, target.X, 0f);
            Utilities.AreEqual(value, target.Y, 0f);
            Utilities.AreEqual(value, target.Z, 0f);
        }

        [TestMethod()]
        public void Vector3ConstructorTest3()
        {
            float x = Utilities.GenerateFloat();
            float y = Utilities.GenerateFloat();
            float z = Utilities.GenerateFloat();
            Vector3 target = new Vector3(x, y, z);

            Utilities.AreEqual(x, target.X, 0f);
            Utilities.AreEqual(y, target.Y, 0f);
            Utilities.AreEqual(z, target.Z, 0f);
        }

        [TestMethod()]
        public void AddTest()
        {
            Vector3 left = Utilities.GenerateVector3();
            Vector3 right = Utilities.GenerateVector3();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Add(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector3 actual;
            actual = Vector3.Add(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddByRefTest()
        {
            Vector3 left = Utilities.GenerateVector3();
            Vector3 leftExpected = left;
            Vector3 right = Utilities.GenerateVector3();
            Vector3 rightExpected = right;
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Add(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector3.Add(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void BarycentricByRefTest()
        {
            Vector3 value1 = Utilities.GenerateVector3();
            Vector3 value1Expected = value1;
            Vector3 value2 = Utilities.GenerateVector3();
            Vector3 value2Expected = value2;
            Vector3 value3 = Utilities.GenerateVector3();
            Vector3 value3Expected = value3;
            float amount1 = Utilities.GenerateFloat();
            float amount2 = Utilities.GenerateFloat();
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Barycentric(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2),
                Utilities.ConvertToXna(value3),
                amount1,
                amount2));

            Vector3.Barycentric(ref value1, ref value2, ref value3, amount1, amount2, out result);
            Utilities.AreEqual(value1Expected, value1);
            Utilities.AreEqual(value2Expected, value2);
            Utilities.AreEqual(value3Expected, value3);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void BarycentricTest()
        {
            Vector3 value1 = Utilities.GenerateVector3();
            Vector3 value2 = Utilities.GenerateVector3();
            Vector3 value3 = Utilities.GenerateVector3();
            float amount1 = Utilities.GenerateFloat();
            float amount2 = Utilities.GenerateFloat();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Barycentric(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2),
                Utilities.ConvertToXna(value3),
                amount1,
                amount2));

            Vector3 actual;
            actual = Vector3.Barycentric(value1, value2, value3, amount1, amount2);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CatmullRomTest()
        {
            Vector3 value1 = Utilities.GenerateVector3();
            Vector3 value2 = Utilities.GenerateVector3();
            Vector3 value3 = Utilities.GenerateVector3();
            Vector3 value4 = Utilities.GenerateVector3();
            float amount = Utilities.GenerateFloat();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.CatmullRom(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2),
                Utilities.ConvertToXna(value3),
                Utilities.ConvertToXna(value4),
                amount));

            Vector3 actual;
            actual = Vector3.CatmullRom(value1, value2, value3, value4, amount);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CatmullRomByRefTest()
        {
            Vector3 value1 = Utilities.GenerateVector3();
            Vector3 value1Expected = value1;
            Vector3 value2 = Utilities.GenerateVector3();
            Vector3 value2Expected = value2;
            Vector3 value3 = Utilities.GenerateVector3();
            Vector3 value3Expected = value3;
            Vector3 value4 = Utilities.GenerateVector3();
            Vector3 value4Expected = value4;
            float amount = Utilities.GenerateFloat();
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.CatmullRom(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2),
                Utilities.ConvertToXna(value3),
                Utilities.ConvertToXna(value4),
                amount));

            Vector3.CatmullRom(ref value1, ref value2, ref value3, ref value4, amount, out result);
            Utilities.AreEqual(value1Expected, value1);
            Utilities.AreEqual(value2Expected, value2);
            Utilities.AreEqual(value3Expected, value3);
            Utilities.AreEqual(value4Expected, value4);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void ClampTest()
        {
            Vector3 value = new Vector3(Utilities.GenerateFloatSmall(), Utilities.GenerateFloatLarge(), Utilities.GenerateFloat());
            Vector3 min = Utilities.GenerateVector3();
            Vector3 max = Utilities.GenerateVector3();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Clamp(
                Utilities.ConvertToXna(value),
                Utilities.ConvertToXna(min),
                Utilities.ConvertToXna(max)));

            Vector3 actual;
            actual = Vector3.Clamp(value, min, max);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ClampByRefTest()
        {
            Vector3 value = new Vector3(Utilities.GenerateFloatSmall(), Utilities.GenerateFloatLarge(), Utilities.GenerateFloat());
            Vector3 valueExpected = value;
            Vector3 min = Utilities.GenerateVector3();
            Vector3 minExpected = min;
            Vector3 max = Utilities.GenerateVector3();
            Vector3 maxExpected = max;
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Clamp(
                Utilities.ConvertToXna(value),
                Utilities.ConvertToXna(min),
                Utilities.ConvertToXna(max)));

            Vector3.Clamp(ref value, ref min, ref max, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(minExpected, min);
            Utilities.AreEqual(maxExpected, max);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void CrossTest()
        {
            Vector3 left = Utilities.GenerateVector3();
            Vector3 right = Utilities.GenerateVector3();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Cross(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector3 actual;
            actual = Vector3.Cross(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CrossByRefTest()
        {
            Vector3 left = Utilities.GenerateVector3();
            Vector3 leftExpected = left;
            Vector3 right = Utilities.GenerateVector3();
            Vector3 rightExpected = right;
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Cross(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector3.Cross(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void DistanceTest()
        {
            Vector3 value1 = Utilities.GenerateVector3();
            Vector3 value2 = Utilities.GenerateVector3();

            float expected = Microsoft.Xna.Framework.Vector3.Distance(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2));

            float actual;
            actual = Vector3.Distance(value1, value2);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DistanceByRefTest()
        {
            Vector3 value1 = Utilities.GenerateVector3();
            Vector3 value1Expected = value1;
            Vector3 value2 = Utilities.GenerateVector3();
            Vector3 value2Expected = value2;
            float result;

            float resultExpected = Microsoft.Xna.Framework.Vector3.Distance(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2));

            Vector3.Distance(ref value1, ref value2, out result);
            Utilities.AreEqual(value1Expected, value1);
            Utilities.AreEqual(value2Expected, value2);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void DistanceSquaredTest()
        {
            Vector3 value1 = Utilities.GenerateVector3();
            Vector3 value2 = Utilities.GenerateVector3();

            float expected = Microsoft.Xna.Framework.Vector3.DistanceSquared(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2));

            float actual;
            actual = Vector3.DistanceSquared(value1, value2);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DistanceSquaredByRefTest()
        {
            Vector3 value1 = Utilities.GenerateVector3();
            Vector3 value1Expected = value1;
            Vector3 value2 = Utilities.GenerateVector3();
            Vector3 value2Expected = value2;
            float result;

            float resultExpected = Microsoft.Xna.Framework.Vector3.DistanceSquared(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(value2));

            Vector3.DistanceSquared(ref value1, ref value2, out result);
            Utilities.AreEqual(value1Expected, value1);
            Utilities.AreEqual(value2Expected, value2);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void DivideTest()
        {
            Vector3 value = Utilities.GenerateVector3();
            float scale = Utilities.GenerateFloat();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Divide(
                Utilities.ConvertToXna(value),
                scale));

            Vector3 actual;
            actual = Vector3.Divide(value, scale);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DivideByRefTest()
        {
            Vector3 value = Utilities.GenerateVector3();
            Vector3 valueExpected = value;
            float scale = Utilities.GenerateFloat();
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Divide(
                Utilities.ConvertToXna(value),
                scale));

            Vector3.Divide(ref value, scale, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void DotTest()
        {
            Vector3 left = Utilities.GenerateVector3();
            Vector3 right = Utilities.GenerateVector3();

            float expected = Microsoft.Xna.Framework.Vector3.Dot(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right));

            float actual;
            actual = Vector3.Dot(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DotByRefTest()
        {
            Vector3 left = Utilities.GenerateVector3();
            Vector3 leftExpected = left;
            Vector3 right = Utilities.GenerateVector3();
            Vector3 rightExpected = right;
            float result;

            float resultExpected = Microsoft.Xna.Framework.Vector3.Dot(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right));

            Vector3.Dot(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Vector3 target = Utilities.GenerateVector3();
            object value = new Vector3(target.X + 1f, target.Y - 1f, target.Z);
            bool expected = false;
            bool actual;
            actual = target.Equals(value);
            Utilities.AreEqual(expected, actual);

            target = Utilities.GenerateVector3();
            value = target;
            expected = true;
            actual = target.Equals(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EqualsTest1()
        {
            Vector3 target = Utilities.GenerateVector3();
            Vector3 other = new Vector3(target.X + 1f, target.Y - 1f, target.Z);
            bool expected = false;
            bool actual;
            actual = target.Equals(other);
            Utilities.AreEqual(expected, actual);

            target = Utilities.GenerateVector3();
            other = target;
            expected = true;
            actual = target.Equals(other);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void HermiteTest()
        {
            Vector3 value1 = Utilities.GenerateVector3();
            Vector3 tangent1 = Utilities.GenerateVector3();
            Vector3 value2 = Utilities.GenerateVector3();
            Vector3 tangent2 = Utilities.GenerateVector3();
            float amount = Utilities.GenerateFloat();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Hermite(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(tangent1),
                Utilities.ConvertToXna(value2),
                Utilities.ConvertToXna(tangent2),
                amount));

            Vector3 actual;
            actual = Vector3.Hermite(value1, tangent1, value2, tangent2, amount);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void HermiteByRefTest()
        {
            Vector3 value1 = Utilities.GenerateVector3();
            Vector3 value1Expected = value1;
            Vector3 tangent1 = Utilities.GenerateVector3();
            Vector3 tangent1Expected = tangent1;
            Vector3 value2 = Utilities.GenerateVector3();
            Vector3 value2Expected = value2;
            Vector3 tangent2 = Utilities.GenerateVector3();
            Vector3 tangent2Expected = tangent2;
            float amount = Utilities.GenerateFloat();
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Hermite(
                Utilities.ConvertToXna(value1),
                Utilities.ConvertToXna(tangent1),
                Utilities.ConvertToXna(value2),
                Utilities.ConvertToXna(tangent2),
                amount));

            Vector3.Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
            Utilities.AreEqual(value1Expected, value1);
            Utilities.AreEqual(tangent1Expected, tangent1);
            Utilities.AreEqual(value2Expected, value2);
            Utilities.AreEqual(tangent2Expected, tangent2);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void LengthTest()
        {
            Vector3 target = Utilities.GenerateVector3();

            float expected = Utilities.ConvertToXna(target).Length();

            float actual;
            actual = target.Length;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LengthSquaredTest()
        {
            Vector3 target = Utilities.GenerateVector3();

            float expected = Utilities.ConvertToXna(target).LengthSquared();

            float actual;
            actual = target.LengthSquared;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LerpTest()
        {
            Vector3 start = Utilities.GenerateVector3();
            Vector3 end = Utilities.GenerateVector3();
            float amount = Utilities.GenerateFloat();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Lerp(
                Utilities.ConvertToXna(start),
                Utilities.ConvertToXna(end),
                amount));

            Vector3 actual;
            actual = Vector3.Lerp(start, end, amount);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LerpByRefTest()
        {
            Vector3 start = Utilities.GenerateVector3();
            Vector3 startExpected = start;
            Vector3 end = Utilities.GenerateVector3();
            Vector3 endExpected = end;
            float amount = Utilities.GenerateFloat();
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Lerp(
                Utilities.ConvertToXna(start),
                Utilities.ConvertToXna(end),
                amount));

            Vector3.Lerp(ref start, ref end, amount, out result);
            Utilities.AreEqual(startExpected, start);
            Utilities.AreEqual(endExpected, end);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void MaxTest()
        {
            Vector3 left = Utilities.GenerateVector3();
            Vector3 right = Utilities.GenerateVector3();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Max(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector3 actual;
            actual = Vector3.Max(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MaxByRefTest()
        {
            Vector3 left = Utilities.GenerateVector3();
            Vector3 leftExpected = left;
            Vector3 right = Utilities.GenerateVector3();
            Vector3 rightExpected = right;
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Max(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector3.Max(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void MinTest()
        {
            Vector3 left = Utilities.GenerateVector3();
            Vector3 right = Utilities.GenerateVector3();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Min(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector3 actual;
            actual = Vector3.Min(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinByRefTest()
        {
            Vector3 left = Utilities.GenerateVector3();
            Vector3 leftExpected = left;
            Vector3 right = Utilities.GenerateVector3();
            Vector3 rightExpected = right;
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Min(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector3.Min(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void ModulateTest()
        {
            Vector3 left = Utilities.GenerateVector3();
            Vector3 right = Utilities.GenerateVector3();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Multiply(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector3 actual;
            actual = Vector3.Modulate(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ModulateByRefTest()
        {
            Vector3 left = Utilities.GenerateVector3();
            Vector3 leftExpected = left;
            Vector3 right = Utilities.GenerateVector3();
            Vector3 rightExpected = right;
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Multiply(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector3.Modulate(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            Vector3 value = Utilities.GenerateVector3();
            float scale = Utilities.GenerateFloat();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Multiply(
                Utilities.ConvertToXna(value),
                scale));

            Vector3 actual;
            actual = Vector3.Multiply(value, scale);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MultiplyByRefTest()
        {
            Vector3 value = Utilities.GenerateVector3();
            Vector3 valueExpected = value;
            float scale = Utilities.GenerateFloat();
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Multiply(
                Utilities.ConvertToXna(value),
                scale));

            Vector3.Multiply(ref value, scale, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void NegateTest()
        {
            Vector3 value = Utilities.GenerateVector3();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Negate(
                Utilities.ConvertToXna(value)));

            Vector3 actual;
            actual = Vector3.Negate(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NegateByRefTest()
        {
            Vector3 value = Utilities.GenerateVector3();
            Vector3 valueExpected = value;
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Negate(
                Utilities.ConvertToXna(value)));

            Vector3.Negate(ref value, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void NormalizeTest()
        {
            Vector3 target = Utilities.GenerateVector3();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Normalize(
                Utilities.ConvertToXna(target)));

            target.Normalize();
            Utilities.AreEqual(expected, target);
        }

        [TestMethod()]
        public void NormalizeTest1()
        {
            Vector3 value = Utilities.GenerateVector3();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Normalize(
                Utilities.ConvertToXna(value)));

            Vector3 actual;
            actual = Vector3.Normalize(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NormalizeByRefTest()
        {
            Vector3 value = Utilities.GenerateVector3();
            Vector3 valueExpected = value;
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Normalize(
                Utilities.ConvertToXna(value)));

            Vector3.Normalize(ref value, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void OrthogonalizeTest()
        {
            //Because orthogonalization is numerically unstable, we adjust the assert delta.
            float deltabefore = Utilities.AssertDelta;
            Utilities.AssertDelta = 1e-2f;

            Vector3[] source = new Vector3[5];
            Vector3[] destination = new Vector3[5];

            for (int i = 0; i < source.Length; ++i)
            {
                source[i] = Utilities.GenerateVector3();
            }

            Vector3.Orthogonalize(destination, source);

            Utilities.AreEqual(0f, Vector3.Dot(destination[0], destination[1]));
            Utilities.AreEqual(0f, Vector3.Dot(destination[0], destination[2]));
            Utilities.AreEqual(0f, Vector3.Dot(destination[0], destination[3]));
            Utilities.AreEqual(0f, Vector3.Dot(destination[0], destination[4]));

            Utilities.AreEqual(0f, Vector3.Dot(destination[1], destination[2]));
            Utilities.AreEqual(0f, Vector3.Dot(destination[1], destination[3]));
            Utilities.AreEqual(0f, Vector3.Dot(destination[1], destination[4]));

            Utilities.AreEqual(0f, Vector3.Dot(destination[2], destination[3]));
            Utilities.AreEqual(0f, Vector3.Dot(destination[2], destination[4]));

            Utilities.AreEqual(0f, Vector3.Dot(destination[3], destination[4]));

            //Reset the assert delta.
            Utilities.AssertDelta = deltabefore;
        }

        [TestMethod()]
        public void Orthonormalize()
        {
            //Because orthogonalization is numerically unstable, we adjust the assert delta.
            float deltabefore = Utilities.AssertDelta;
            Utilities.AssertDelta = 1e-2f;

            Vector3[] source = new Vector3[4];
            Vector3[] destination = new Vector3[4];

            for (int i = 0; i < source.Length; ++i)
            {
                source[i] = Utilities.GenerateVector3();
            }

            Vector3.Orthonormalize(destination, source);

            for (int i = 0; i < destination.Length; ++i)
            {
                Utilities.AreEqual(1f, destination[i].Length);
            }

            Utilities.AreEqual(0f, Vector3.Dot(destination[0], destination[1]));
            Utilities.AreEqual(0f, Vector3.Dot(destination[0], destination[2]));
            Utilities.AreEqual(0f, Vector3.Dot(destination[0], destination[3]));

            Utilities.AreEqual(0f, Vector3.Dot(destination[1], destination[2]));
            Utilities.AreEqual(0f, Vector3.Dot(destination[1], destination[3]));

            Utilities.AreEqual(0f, Vector3.Dot(destination[2], destination[3]));

            //Reset the assert delta.
            Utilities.AssertDelta = deltabefore;
        }

        [TestMethod()]
        public void ProjectTest()
        {
            Vector3 vector = Utilities.GenerateVector3();
            float x = (float)Math.Floor(Utilities.GenerateFloat());
            float y = (float)Math.Floor(Utilities.GenerateFloat());
            float width = (float)Math.Floor(Utilities.GenerateFloat() + x);
            float height = (float)Math.Floor(Utilities.GenerateFloat() + y);
            float minZ = Utilities.GenerateFloat();
            float maxZ = Utilities.GenerateFloat() + minZ + 1f;
            Matrix worldViewProjection = Utilities.GenerateMatrix();

            Microsoft.Xna.Framework.Graphics.Viewport viewport = new Microsoft.Xna.Framework.Graphics.Viewport()
            {
                X = (int)x,
                Y = (int)y,
                Width = (int)width,
                Height = (int)height,
                MinDepth = minZ,
                MaxDepth = maxZ
            };
            Vector3 expected = Utilities.ConvertFrom(viewport.Project(
                Utilities.ConvertToXna(vector),
                Utilities.ConvertToXna(worldViewProjection),
                Utilities.ConvertToXna(Matrix.Identity),
                Utilities.ConvertToXna(Matrix.Identity)));
           
            Vector3 actual;
            actual = Vector3.Project(vector, x, y, width, height, minZ, maxZ, worldViewProjection);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProjectByRefTest()
        {
            Vector3 vector = Utilities.GenerateVector3();
            Vector3 vectorExpected = vector;
            float x = (float)Math.Floor(Utilities.GenerateFloat());
            float y = (float)Math.Floor(Utilities.GenerateFloat());
            float width = (float)Math.Floor(Utilities.GenerateFloat() + x);
            float height = (float)Math.Floor(Utilities.GenerateFloat() + y);
            float minZ = Utilities.GenerateFloat();
            float maxZ = Utilities.GenerateFloat() + minZ + 1f;
            Matrix worldViewProjection = Utilities.GenerateMatrix();
            Matrix worldViewProjectionExpected = worldViewProjection;
            Vector3 result;

            Microsoft.Xna.Framework.Graphics.Viewport viewport = new Microsoft.Xna.Framework.Graphics.Viewport()
            {
                X = (int)x,
                Y = (int)y,
                Width = (int)width,
                Height = (int)height,
                MinDepth = minZ,
                MaxDepth = maxZ
            };
            Vector3 resultExpected = Utilities.ConvertFrom(viewport.Project(
                Utilities.ConvertToXna(vector),
                Utilities.ConvertToXna(worldViewProjection),
                Utilities.ConvertToXna(Matrix.Identity),
                Utilities.ConvertToXna(Matrix.Identity)));

            Vector3.Project(ref vector, x, y, width, height, minZ, maxZ, ref worldViewProjection, out result);
            Utilities.AreEqual(vectorExpected, vector);
            Utilities.AreEqual(worldViewProjectionExpected, worldViewProjection);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void ReflectTest()
        {
            Vector3 vector = Utilities.GenerateVector3();
            Vector3 normal = Utilities.GenerateVector3();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Reflect(
                Utilities.ConvertToXna(vector),
                Utilities.ConvertToXna(normal)));

            Vector3 actual;
            actual = Vector3.Reflect(vector, normal);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ReflectByRefTest()
        {
            Vector3 vector = Utilities.GenerateVector3();
            Vector3 vectorExpected = vector;
            Vector3 normal = Utilities.GenerateVector3();
            Vector3 normalExpected = normal;
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Reflect(
                Utilities.ConvertToXna(vector),
                Utilities.ConvertToXna(normal)));

            Vector3.Reflect(ref vector, ref normal, out result);
            Utilities.AreEqual(vectorExpected, vector);
            Utilities.AreEqual(normalExpected, normal);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void RefractTest()
        {
            Vector3 vector = new Vector3(); // TODO: Initialize to an appropriate value
            Vector3 normal = new Vector3(); // TODO: Initialize to an appropriate value
            float index = 0F; // TODO: Initialize to an appropriate value
            Vector3 expected = new Vector3(); // TODO: Initialize to an appropriate value
            Vector3 actual;

            actual = Vector3.Refract(vector, normal, index);

            Assert.AreEqual(expected, actual);

            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void RefractByRefTest()
        {
            Vector3 vector = new Vector3(); // TODO: Initialize to an appropriate value
            Vector3 vectorExpected = new Vector3(); // TODO: Initialize to an appropriate value
            Vector3 normal = new Vector3(); // TODO: Initialize to an appropriate value
            Vector3 normalExpected = new Vector3(); // TODO: Initialize to an appropriate value
            float index = 0F; // TODO: Initialize to an appropriate value
            Vector3 result = new Vector3(); // TODO: Initialize to an appropriate value
            Vector3 resultExpected = new Vector3(); // TODO: Initialize to an appropriate value

            Vector3.Refract(ref vector, ref normal, index, out result);

            Assert.AreEqual(vectorExpected, vector);
            Assert.AreEqual(normalExpected, normal);
            Assert.AreEqual(resultExpected, result);

            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void SmoothStepTest()
        {
            Vector3 start = Utilities.GenerateVector3();
            Vector3 end = Utilities.GenerateVector3();
            float amount = Utilities.GenerateFloat();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.SmoothStep(
                Utilities.ConvertToXna(start),
                Utilities.ConvertToXna(end),
                amount));

            Vector3 actual;
            actual = Vector3.SmoothStep(start, end, amount);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SmoothStepByRefTest()
        {
            Vector3 start = Utilities.GenerateVector3();
            Vector3 startExpected = start;
            Vector3 end = Utilities.GenerateVector3();
            Vector3 endExpected = end;
            float amount = Utilities.GenerateFloat();
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.SmoothStep(
                Utilities.ConvertToXna(start),
                Utilities.ConvertToXna(end),
                amount));

            Vector3.SmoothStep(ref start, ref end, amount, out result);
            Utilities.AreEqual(startExpected, start);
            Utilities.AreEqual(endExpected, end);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void SubtractTest()
        {
            Vector3 left = Utilities.GenerateVector3();
            Vector3 right = Utilities.GenerateVector3();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Subtract(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector3 actual;
            actual = Vector3.Subtract(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SubtractByRefTest()
        {
            Vector3 left = Utilities.GenerateVector3();
            Vector3 leftExpected = left;
            Vector3 right = Utilities.GenerateVector3();
            Vector3 rightExpected = right;
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Subtract(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector3.Subtract(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void ToArrayTest()
        {
            Vector3 target = Utilities.GenerateVector3();
            float[] expected = { target.X, target.Y, target.Z };
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
            Vector3 vector = Utilities.GenerateVector3();
            Quaternion rotation = Utilities.GenerateQuaternion();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Transform(
                Utilities.ConvertToXna(vector),
                Utilities.ConvertToXna(rotation)));

            Vector3 actual;
            actual = Vector3.Transform(vector, rotation);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TransformQuaternionByRefTest()
        {
            Vector3 vector = Utilities.GenerateVector3();
            Vector3 vectorExpected = vector;
            Quaternion rotation = Utilities.GenerateQuaternion();
            Quaternion rotationExpected = rotation;
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Transform(
                Utilities.ConvertToXna(vector),
                Utilities.ConvertToXna(rotation)));

            Vector3.Transform(ref vector, ref rotation, out result);
            Utilities.AreEqual(vectorExpected, vector);
            Utilities.AreEqual(rotationExpected, rotation);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void TransformQuaternionArrayByRefTest()
        {
            Vector3[] source =
            {
                Utilities.GenerateVector3(),
                Utilities.GenerateVector3(),
                Utilities.GenerateVector3(),
                Utilities.GenerateVector3(),
                Utilities.GenerateVector3()
            };
            Quaternion rotation = Utilities.GenerateQuaternion();
            Quaternion rotationExpected = rotation;
            Vector3[] destination = new Vector3[source.Length];
            Vector3.Transform(source, ref rotation, destination);

            for (int i = 0; i < source.Length; ++i)
            {
                Vector3 temp = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Transform(
                    Utilities.ConvertToXna(source[i]),
                    Utilities.ConvertToXna(rotation)));
                Utilities.AreEqual(destination[i], temp);
            }
        }

        [TestMethod()]
        public void TransformMatrixTest()
        {
            Vector3 vector = Utilities.GenerateVector3();
            Matrix transform = Utilities.GenerateMatrix();

            Vector4 expected = Utilities.ConvertFrom(Microsoft.DirectX.Vector3.Transform(
                Utilities.ConvertToMdx(vector),
                Utilities.ConvertToMdx(transform)));

            Vector4 actual;
            actual = Vector3.Transform(vector, transform);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TransformMatrixByRefTest()
        {
            Vector3 vector = Utilities.GenerateVector3();
            Vector3 vectorExpected = vector;
            Matrix transform = Utilities.GenerateMatrix();
            Matrix transformExpected = transform;
            Vector4 result;

            Vector4 resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Vector3.Transform(
                Utilities.ConvertToMdx(vector),
                Utilities.ConvertToMdx(transform)));

            Vector3.Transform(ref vector, ref transform, out result);
            Utilities.AreEqual(vectorExpected, vector);
            Utilities.AreEqual(transformExpected, transform);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void TransformMatrixArrayByRefTest()
        {
            Vector3[] source =
            {
                Utilities.GenerateVector3(),
                Utilities.GenerateVector3(),
                Utilities.GenerateVector3(),
                Utilities.GenerateVector3(),
                Utilities.GenerateVector3()
            };
            Matrix transform = Utilities.GenerateMatrix();
            Matrix transformExpected = transform;
            Vector4[] destination = new Vector4[source.Length];
            Vector3.Transform(source, ref transform, destination);

            for (int i = 0; i < source.Length; ++i)
            {
                Vector4 temp = Utilities.ConvertFrom(Microsoft.DirectX.Vector3.Transform(
                    Utilities.ConvertToMdx(source[i]),
                    Utilities.ConvertToMdx(transform)));
                Utilities.AreEqual(destination[i], temp);
            }
        }

        [TestMethod()]
        public void TransformCoordinateTest()
        {
            Vector3 coordinate = Utilities.GenerateVector3();
            Matrix transform = Utilities.GenerateMatrix();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.DirectX.Vector3.TransformCoordinate(
                Utilities.ConvertToMdx(coordinate),
                Utilities.ConvertToMdx(transform)));

            Vector3 actual;
            actual = Vector3.TransformCoordinate(coordinate, transform);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TransformCoordinateByRefTest()
        {
            Vector3 coordinate = Utilities.GenerateVector3();
            Vector3 coordinateExpected = coordinate;
            Matrix transform = Utilities.GenerateMatrix();
            Matrix transformExpected = transform;
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Vector3.TransformCoordinate(
                Utilities.ConvertToMdx(coordinate),
                Utilities.ConvertToMdx(transform)));

            Vector3.TransformCoordinate(ref coordinate, ref transform, out result);
            Utilities.AreEqual(coordinateExpected, coordinate);
            Utilities.AreEqual(transformExpected, transform);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void TransformCoordinateArrayByRefTest()
        {
            Vector3[] source =
            {
                Utilities.GenerateVector3(),
                Utilities.GenerateVector3(),
                Utilities.GenerateVector3(),
                Utilities.GenerateVector3(),
                Utilities.GenerateVector3()
            };
            Matrix transform = Utilities.GenerateMatrix();
            Matrix transformExpected = transform;
            Vector3[] destination = new Vector3[source.Length];
            Vector3.TransformCoordinate(source, ref transform, destination);

            for (int i = 0; i < destination.Length; ++i)
            {
                Vector3 temp = Utilities.ConvertFrom(Microsoft.DirectX.Vector3.TransformCoordinate(
                    Utilities.ConvertToMdx(source[i]),
                    Utilities.ConvertToMdx(transform)));
                Utilities.AreEqual(destination[i], temp);
            }
        }

        [TestMethod()]
        public void TransformNormalTest()
        {
            Vector3 normal = Utilities.GenerateVector3();
            Matrix transform = Utilities.GenerateMatrix();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.DirectX.Vector3.TransformNormal(
                Utilities.ConvertToMdx(normal),
                Utilities.ConvertToMdx(transform)));

            Vector3 actual;
            actual = Vector3.TransformNormal(normal, transform);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TransformNormalByRefTest()
        {
            Vector3 normal = Utilities.GenerateVector3();
            Vector3 normalExpected = normal;
            Matrix transform = Utilities.GenerateMatrix();
            Matrix transformExpected = transform;
            Vector3 result;

            Vector3 resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Vector3.TransformNormal(
                Utilities.ConvertToMdx(normal),
                Utilities.ConvertToMdx(transform)));

            Vector3.TransformNormal(ref normal, ref transform, out result);
            Utilities.AreEqual(normalExpected, normal);
            Utilities.AreEqual(transformExpected, transform);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void TransformNormalArrayByRefTest()
        {
            Vector3[] source =
            {
                Utilities.GenerateVector3(),
                Utilities.GenerateVector3(),
                Utilities.GenerateVector3(),
                Utilities.GenerateVector3(),
                Utilities.GenerateVector3()
            };
            Matrix transform = Utilities.GenerateMatrix();
            Matrix transformExpected = transform;
            Vector3[] destination = new Vector3[source.Length];
            Vector3.TransformNormal(source, ref transform, destination);

            for (int i = 0; i < destination.Length; ++i)
            {
                Vector3 temp = Utilities.ConvertFrom(Microsoft.DirectX.Vector3.TransformNormal(
                Utilities.ConvertToMdx(source[i]),
                Utilities.ConvertToMdx(transform)));
                Utilities.AreEqual(destination[i], temp);
            }
        }

        [TestMethod()]
        public void UnprojectTest()
        {
            Vector3 vector = Utilities.GenerateVector3();
            float x = (float)Math.Floor(Utilities.GenerateFloat());
            float y = (float)Math.Floor(Utilities.GenerateFloat());
            float width = (float)Math.Floor(Utilities.GenerateFloat() + x);
            float height = (float)Math.Floor(Utilities.GenerateFloat() + y);
            float minZ = Utilities.GenerateFloat();
            float maxZ = Utilities.GenerateFloat() + minZ + 1f;
            Matrix worldViewProjection = Utilities.GenerateMatrix();

            Microsoft.Xna.Framework.Graphics.Viewport viewport = new Microsoft.Xna.Framework.Graphics.Viewport()
            {
                X = (int)x,
                Y = (int)y,
                Width = (int)width,
                Height = (int)height,
                MinDepth = minZ,
                MaxDepth = maxZ
            };
            Vector3 expected = Utilities.ConvertFrom(viewport.Unproject(
                Utilities.ConvertToXna(vector),
                Utilities.ConvertToXna(worldViewProjection),
                Utilities.ConvertToXna(Matrix.Identity),
                Utilities.ConvertToXna(Matrix.Identity)));

            Vector3 actual;
            actual = Vector3.Unproject(vector, x, y, width, height, minZ, maxZ, worldViewProjection);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UnprojectTest1()
        {
            Vector3 vector = Utilities.GenerateVector3();
            Vector3 vectorExpected = vector;
            float x = (float)Math.Floor(Utilities.GenerateFloat());
            float y = (float)Math.Floor(Utilities.GenerateFloat());
            float width = (float)Math.Floor(Utilities.GenerateFloat() + x);
            float height = (float)Math.Floor(Utilities.GenerateFloat() + y);
            float minZ = Utilities.GenerateFloat();
            float maxZ = Utilities.GenerateFloat() + minZ + 1f;
            Matrix worldViewProjection = Utilities.GenerateMatrix();
            Matrix worldViewProjectionExpected = worldViewProjection;
            Vector3 result;

            Microsoft.Xna.Framework.Graphics.Viewport viewport = new Microsoft.Xna.Framework.Graphics.Viewport()
            {
                X = (int)x,
                Y = (int)y,
                Width = (int)width,
                Height = (int)height,
                MinDepth = minZ,
                MaxDepth = maxZ
            };
            Vector3 resultExpected = Utilities.ConvertFrom(viewport.Unproject(
                Utilities.ConvertToXna(vector),
                Utilities.ConvertToXna(worldViewProjection),
                Utilities.ConvertToXna(Matrix.Identity),
                Utilities.ConvertToXna(Matrix.Identity)));

            Vector3.Unproject(ref vector, x, y, width, height, minZ, maxZ, ref worldViewProjection, out result);
            Utilities.AreEqual(vectorExpected, vector);
            Utilities.AreEqual(worldViewProjectionExpected, worldViewProjection);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void op_AdditionTest()
        {
            Vector3 left = Utilities.GenerateVector3();
            Vector3 right = Utilities.GenerateVector3();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Add(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector3 actual;
            actual = (left + right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_DivisionTest()
        {
            Vector3 value = Utilities.GenerateVector3();
            float scale = Utilities.GenerateFloat();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Divide(
                Utilities.ConvertToXna(value),
                scale));

            Vector3 actual;
            actual = (value / scale);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_EqualityTest()
        {
            Vector3 left = Utilities.GenerateVector3();
            Vector3 right = new Vector3(left.X + 1f, left.Y - 1f, left.Z);
            bool expected = false;
            bool actual;
            actual = left == right;
            Utilities.AreEqual(expected, actual);

            left = Utilities.GenerateVector3();
            right = left;
            expected = true;
            actual = left == right;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_ExplicitTest()
        {
            Vector3 value = Utilities.GenerateVector3();

            Vector2 expected = new Vector2(value.X, value.Y);

            Vector2 actual;
            actual = ((Vector2)(value));
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_ExplicitTest1()
        {
            Vector3 value = Utilities.GenerateVector3();

            Vector4 expected = new Vector4(value.X, value.Y, value.Z, 0f);

            Vector4 actual;
            actual = ((Vector4)(value));
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_InequalityTest()
        {
            Vector3 left = Utilities.GenerateVector3();
            Vector3 right = new Vector3(left.X + 1f, left.Y - 1f, left.Z);
            bool expected = true;
            bool actual;
            actual = left != right;
            Utilities.AreEqual(expected, actual);

            left = Utilities.GenerateVector3();
            right = left;
            expected = false;
            actual = left != right;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_MultiplyTest()
        {
            float scale = Utilities.GenerateFloat();
            Vector3 value = Utilities.GenerateVector3();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Multiply(
                Utilities.ConvertToXna(value),
                scale));

            Vector3 actual;
            actual = (scale * value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_MultiplyTest1()
        {
            Vector3 value = Utilities.GenerateVector3();
            float scale = Utilities.GenerateFloat();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Multiply(
                Utilities.ConvertToXna(value),
                scale));

            Vector3 actual;
            actual = (value * scale);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_SubtractionTest()
        {
            Vector3 left = Utilities.GenerateVector3();
            Vector3 right = Utilities.GenerateVector3();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Subtract(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Vector3 actual;
            actual = (left - right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_UnaryNegationTest()
        {
            Vector3 value = Utilities.GenerateVector3();

            Vector3 expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Vector3.Negate(
                Utilities.ConvertToXna(value)));

            Vector3 actual;
            actual = -(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_UnaryPlusTest()
        {
            Vector3 value = Utilities.GenerateVector3();

            Vector3 expected = value;

            Vector3 actual;
            actual = +(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsNormalizedTest()
        {
            Vector3 target = Utilities.GenerateVector3();
            bool expected = false;
            bool actual;
            actual = target.IsNormalized;
            Utilities.AreEqual(expected, actual);

            target = Utilities.GenerateVector3();
            target.Normalize();
            expected = true;
            actual = target.IsNormalized;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ItemTest()
        {
            Vector3 target = Utilities.GenerateVector3();
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

            index = 3;
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
