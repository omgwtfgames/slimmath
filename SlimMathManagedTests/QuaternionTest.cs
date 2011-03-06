using SlimMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SlimMathManagedTests
{
    [TestClass()]
    public class QuaternionTest
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
        public void QuaternionReadonlyFieldsTest()
        {
            Utilities.AreEqual(System.Runtime.InteropServices.Marshal.SizeOf(typeof(Quaternion)), Quaternion.SizeInBytes);
            Utilities.AreEqual(new Quaternion() { X = 0f, Y = 0f, Z = 0f, W = 0f }, Quaternion.Zero);
            Utilities.AreEqual(new Quaternion() { X = 1f, Y = 1f, Z = 1f, W = 1f }, Quaternion.One);
            Utilities.AreEqual(new Quaternion() { X = 0f, Y = 0f, Z = 0f, W = 1f }, Quaternion.Identity);
        }

        [TestMethod()]
        public void QuaternionConstructorTest()
        {
            Vector2 value = Utilities.GenerateVector2();
            float z = Utilities.GenerateFloat();
            float w = Utilities.GenerateFloat();
            Quaternion target = new Quaternion(value, z, w);

            Utilities.AreEqual(value.X, target.X, 0f);
            Utilities.AreEqual(value.Y, target.Y, 0f);
            Utilities.AreEqual(z, target.Z, 0f);
            Utilities.AreEqual(w, target.W, 0f);
        }

        [TestMethod()]
        public void QuaternionConstructorTest1()
        {
            float x = Utilities.GenerateFloat();
            float y = Utilities.GenerateFloat();
            float z = Utilities.GenerateFloat();
            float w = Utilities.GenerateFloat();
            Quaternion target = new Quaternion(x, y, z, w);

            Utilities.AreEqual(x, target.X, 0f);
            Utilities.AreEqual(y, target.Y, 0f);
            Utilities.AreEqual(z, target.Z, 0f);
            Utilities.AreEqual(w, target.W, 0f);
        }

        [TestMethod()]
        public void QuaternionConstructorTest2()
        {
            float[] values =
            {
                Utilities.GenerateFloat(),
                Utilities.GenerateFloat(),
                Utilities.GenerateFloat(),
                Utilities.GenerateFloat()
            };
            Quaternion target = new Quaternion(values);

            Utilities.AreEqual(values[0], target.X, 0f);
            Utilities.AreEqual(values[1], target.Y, 0f);
            Utilities.AreEqual(values[2], target.Z, 0f);
            Utilities.AreEqual(values[3], target.W, 0f);
        }

        [TestMethod()]
        public void QuaternionConstructorTest3()
        {
            float value = Utilities.GenerateFloat();
            Quaternion target = new Quaternion(value);

            Utilities.AreEqual(value, target.X, 0f);
            Utilities.AreEqual(value, target.Y, 0f);
            Utilities.AreEqual(value, target.Z, 0f);
            Utilities.AreEqual(value, target.W, 0f);
        }

        [TestMethod()]
        public void QuaternionConstructorTest4()
        {
            Vector4 value = Utilities.GenerateVector4();
            Quaternion target = new Quaternion(value);

            Utilities.AreEqual(value.X, target.X, 0f);
            Utilities.AreEqual(value.Y, target.Y, 0f);
            Utilities.AreEqual(value.Z, target.Z, 0f);
            Utilities.AreEqual(value.W, target.W, 0f);
        }

        [TestMethod()]
        public void QuaternionConstructorTest5()
        {
            Vector3 value = Utilities.GenerateVector3();
            float w = Utilities.GenerateFloat();
            Quaternion target = new Quaternion(value, w);

            Utilities.AreEqual(value.X, target.X, 0f);
            Utilities.AreEqual(value.Y, target.Y, 0f);
            Utilities.AreEqual(value.Z, target.Z, 0f);
            Utilities.AreEqual(w, target.W, 0f);
        }

        [TestMethod()]
        public void AddTest()
        {
            Quaternion left = Utilities.GenerateQuaternion();
            Quaternion right = Utilities.GenerateQuaternion();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Add(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Quaternion actual;
            actual = Quaternion.Add(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddByRefTest()
        {
            Quaternion left = Utilities.GenerateQuaternion();
            Quaternion leftExpected = left;
            Quaternion right = Utilities.GenerateQuaternion();
            Quaternion rightExpected = right;
            Quaternion result;

            Quaternion resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Add(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Quaternion.Add(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void BarycentricTest()
        {
            Quaternion value1 = Utilities.GenerateQuaternion();
            Quaternion value2 = Utilities.GenerateQuaternion();
            Quaternion value3 = Utilities.GenerateQuaternion();
            float amount1 = Utilities.GenerateFloat();
            float amount2 = Utilities.GenerateFloat();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.DirectX.Quaternion.BaryCentric(
                Utilities.ConvertToMdx(value1),
                Utilities.ConvertToMdx(value2),
                Utilities.ConvertToMdx(value3),
                amount1,
                amount2));

            Quaternion actual;
            actual = Quaternion.Barycentric(value1, value2, value3, amount1, amount2);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BarycentricByRefTest()
        {
            Quaternion value1 = Utilities.GenerateQuaternion();
            Quaternion value1Expected = value1;
            Quaternion value2 = Utilities.GenerateQuaternion();
            Quaternion value2Expected = value2;
            Quaternion value3 = Utilities.GenerateQuaternion();
            Quaternion value3Expected = value3;
            float amount1 = Utilities.GenerateFloat();
            float amount2 = Utilities.GenerateFloat();
            Quaternion result;

            Quaternion resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Quaternion.BaryCentric(
                Utilities.ConvertToMdx(value1),
                Utilities.ConvertToMdx(value2),
                Utilities.ConvertToMdx(value3),
                amount1,
                amount2));

            Quaternion.Barycentric(ref value1, ref value2, ref value3, amount1, amount2, out result);
            Utilities.AreEqual(value1Expected, value1);
            Utilities.AreEqual(value2Expected, value2);
            Utilities.AreEqual(value3Expected, value3);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void ConjugateTest()
        {
            Quaternion target = Utilities.GenerateQuaternion();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Conjugate(
                Utilities.ConvertToXna(target)));

            target.Conjugate();
            Utilities.AreEqual(expected, target);
        }

        [TestMethod()]
        public void ConjugateTest1()
        {
            Quaternion value = Utilities.GenerateQuaternion();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Conjugate(
                Utilities.ConvertToXna(value)));

            Quaternion actual;
            actual = Quaternion.Conjugate(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConjugateByRefTest()
        {
            Quaternion value = Utilities.GenerateQuaternion();
            Quaternion valueExpected = value;
            Quaternion result;

            Quaternion resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Conjugate(
                Utilities.ConvertToXna(value)));

            Quaternion.Conjugate(ref value, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void DotTest()
        {
            Quaternion left = Utilities.GenerateQuaternion();
            Quaternion right = Utilities.GenerateQuaternion();

            float expected = Microsoft.Xna.Framework.Quaternion.Dot(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right));

            float actual;
            actual = Quaternion.Dot(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DotByRefTest()
        {
            Quaternion left = Utilities.GenerateQuaternion();
            Quaternion leftExpected = left;
            Quaternion right = Utilities.GenerateQuaternion();
            Quaternion rightExpected = right;
            float result;

            float resultExpected = Microsoft.Xna.Framework.Quaternion.Dot(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right));

            Quaternion.Dot(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Quaternion target = Utilities.GenerateQuaternion();
            object value = new Quaternion(target.X + 1f, target.Y - 1f, target.Z, target.W + 2f);
            bool expected = false;
            bool actual;
            actual = target.Equals(value);
            Utilities.AreEqual(expected, actual);

            target = Utilities.GenerateQuaternion();
            value = target;
            expected = true;
            actual = target.Equals(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EqualsTest1()
        {
            Quaternion target = Utilities.GenerateQuaternion();
            Quaternion other = new Quaternion(target.X + 1f, target.Y - 1f, target.Z, target.W + 2f);
            bool expected = false;
            bool actual;
            actual = target.Equals(other);
            Utilities.AreEqual(expected, actual);

            target = Utilities.GenerateQuaternion();
            other = target;
            expected = true;
            actual = target.Equals(other);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExponentialTest()
        {
            Quaternion value = Utilities.GenerateQuaternion();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.DirectX.Quaternion.Exp(
                Utilities.ConvertToMdx(value)));

            Quaternion actual;
            actual = Quaternion.Exponential(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExponentialByRefTest()
        {
            Quaternion value = Utilities.GenerateQuaternion();
            Quaternion valueExpected = value;
            Quaternion result;

            Quaternion resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Quaternion.Exp(
                Utilities.ConvertToMdx(value)));

            Quaternion.Exponential(ref value, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void InvertTest()
        {
            Quaternion target = Utilities.GenerateQuaternion();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Inverse(
                Utilities.ConvertToXna(target)));

            target.Invert();
            Utilities.AreEqual(expected, target);
        }

        [TestMethod()]
        public void InvertTest1()
        {
            Quaternion value = Utilities.GenerateQuaternion();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Inverse(
                Utilities.ConvertToXna(value)));

            Quaternion actual;
            actual = Quaternion.Invert(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void InvertByRefTest()
        {
            Quaternion value = Utilities.GenerateQuaternion();
            Quaternion valueExpected = value;
            Quaternion result;

            Quaternion resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Inverse(
                Utilities.ConvertToXna(value)));

            Quaternion.Invert(ref value, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void LengthTest()
        {
            Quaternion target = Utilities.GenerateQuaternion();

            float expected = Microsoft.DirectX.Quaternion.Length(
                Utilities.ConvertToMdx(target));

            float actual;
            actual = target.Length;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LengthSquaredTest()
        {
            Quaternion target = Utilities.GenerateQuaternion();

            float expected = Microsoft.DirectX.Quaternion.LengthSq(
                Utilities.ConvertToMdx(target));

            float actual;
            actual = target.LengthSquared;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LerpTest()
        {
            Quaternion start = Utilities.GenerateQuaternion();
            Quaternion end = Utilities.GenerateQuaternion();
            float amount = Utilities.GenerateFloat();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Lerp(
                Utilities.ConvertToXna(start),
                Utilities.ConvertToXna(end),
                amount));

            Quaternion actual;
            actual = Quaternion.Lerp(start, end, amount);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LerpByRefTest()
        {
            Quaternion start = Utilities.GenerateQuaternion();
            Quaternion startExpected = start;
            Quaternion end = Utilities.GenerateQuaternion();
            Quaternion endExpected = end;
            float amount = Utilities.GenerateFloat();
            Quaternion result;

            Quaternion resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Lerp(
                Utilities.ConvertToXna(start),
                Utilities.ConvertToXna(end),
                amount));

            Quaternion.Lerp(ref start, ref end, amount, out result);
            Utilities.AreEqual(startExpected, start);
            Utilities.AreEqual(endExpected, end);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void LogarithmTest()
        {
            Quaternion value = Utilities.GenerateQuaternion();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.DirectX.Quaternion.Ln(
                Utilities.ConvertToMdx(value)));

            Quaternion actual;
            actual = Quaternion.Logarithm(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LogarithmByRefTest()
        {
            Quaternion value = Utilities.GenerateQuaternion();
            Quaternion valueExpected = value;
            Quaternion result;

            Quaternion resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Quaternion.Ln(
                Utilities.ConvertToMdx(value)));

            Quaternion.Logarithm(ref value, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void MultiplyScaleTest()
        {
            Quaternion value = Utilities.GenerateQuaternion();
            float scale = Utilities.GenerateFloat();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Multiply(
                Utilities.ConvertToXna(value),
                scale));

            Quaternion actual;
            actual = Quaternion.Multiply(value, scale);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MultiplyScaleByRefTest()
        {
            Quaternion value = Utilities.GenerateQuaternion();
            Quaternion valueExpected = value;
            float scale = Utilities.GenerateFloat();
            Quaternion result;

            Quaternion resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Multiply(
                Utilities.ConvertToXna(value),
                scale));

            Quaternion.Multiply(ref value, scale, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            Quaternion left = Utilities.GenerateQuaternion();
            Quaternion right = Utilities.GenerateQuaternion();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.DirectX.Quaternion.Multiply(
                Utilities.ConvertToMdx(left),
                Utilities.ConvertToMdx(right)));

            Quaternion actual;
            actual = Quaternion.Multiply(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MultiplyByRefTest()
        {
            Quaternion left = Utilities.GenerateQuaternion();
            Quaternion leftExpected = left;
            Quaternion right = Utilities.GenerateQuaternion();
            Quaternion rightExpected = right;
            Quaternion result;

            Quaternion resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Quaternion.Multiply(
                Utilities.ConvertToMdx(left),
                Utilities.ConvertToMdx(right)));

            Quaternion.Multiply(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void NegateTest()
        {
            Quaternion value = Utilities.GenerateQuaternion();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Negate(
                Utilities.ConvertToXna(value)));

            Quaternion actual;
            actual = Quaternion.Negate(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NegateByRefTest()
        {
            Quaternion value = Utilities.GenerateQuaternion();
            Quaternion valueExpected = value;
            Quaternion result;

            Quaternion resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Negate(
                Utilities.ConvertToXna(value)));

            Quaternion.Negate(ref value, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void NormalizeTest()
        {
            Quaternion target = Utilities.GenerateQuaternion();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Normalize(
                Utilities.ConvertToXna(target)));

            target.Normalize();
            Utilities.AreEqual(expected, target);
        }

        [TestMethod()]
        public void NormalizeTest1()
        {
            Quaternion value = Utilities.GenerateQuaternion();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Normalize(
                Utilities.ConvertToXna(value)));

            Quaternion actual;
            actual = Quaternion.Normalize(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NormalizeByRefTest()
        {
            Quaternion value = Utilities.GenerateQuaternion();
            Quaternion valueExpected = value;
            Quaternion result;

            Quaternion resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Normalize(
                Utilities.ConvertToXna(value)));

            Quaternion.Normalize(ref value, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void RotationAxisTest()
        {
            Vector3 axis = Utilities.GenerateVector3();
            float angle = Utilities.GenerateFloat();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.DirectX.Quaternion.RotationAxis(
                Utilities.ConvertToMdx(axis),
                angle));

            Quaternion actual;
            actual = Quaternion.RotationAxis(axis, angle);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RotationAxisByRefTest()
        {
            Vector3 axis = Utilities.GenerateVector3();
            Vector3 axisExpected = axis;
            float angle = Utilities.GenerateFloat();
            Quaternion result;

            Quaternion resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Quaternion.RotationAxis(
                Utilities.ConvertToMdx(axis),
                angle));

            Quaternion.RotationAxis(ref axis, angle, out result);
            Utilities.AreEqual(axisExpected, axis);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void RotationMatrixTest()
        {
            Matrix matrix = Utilities.GenerateMatrix();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.CreateFromRotationMatrix(
                Utilities.ConvertToXna(matrix)));

            Quaternion actual;
            actual = Quaternion.RotationMatrix(matrix);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RotationMatrixByRefTest()
        {
            Matrix matrix = Utilities.GenerateMatrix();
            Matrix matrixExpected = matrix;
            Quaternion result;

            Quaternion resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.CreateFromRotationMatrix(
                Utilities.ConvertToXna(matrix)));

            Quaternion.RotationMatrix(ref matrix, out result);
            Utilities.AreEqual(matrixExpected, matrix);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void RotationYawPitchRollTest()
        {
            float yaw = Utilities.GenerateFloat();
            float pitch = Utilities.GenerateFloat();
            float roll = Utilities.GenerateFloat();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.CreateFromYawPitchRoll(
                yaw,
                pitch,
                roll));

            Quaternion actual;
            actual = Quaternion.RotationYawPitchRoll(yaw, pitch, roll);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RotationYawPitchRollByRefTest()
        {
            float yaw = Utilities.GenerateFloat();
            float pitch = Utilities.GenerateFloat();
            float roll = Utilities.GenerateFloat();
            Quaternion result;

            Quaternion resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.CreateFromYawPitchRoll(
                yaw,
                pitch,
                roll));

            Quaternion.RotationYawPitchRoll(yaw, pitch, roll, out result);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void SlerpTest()
        {
            Quaternion start = Utilities.GenerateQuaternion();
            Quaternion end = Utilities.GenerateQuaternion();
            float amount = Utilities.GenerateFloat();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Slerp(
                Utilities.ConvertToXna(start),
                Utilities.ConvertToXna(end),
                amount));

            Quaternion actual;
            actual = Quaternion.Slerp(start, end, amount);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SlerpByRefTest()
        {
            Quaternion start = Utilities.GenerateQuaternion();
            Quaternion startExpected = start;
            Quaternion end = Utilities.GenerateQuaternion();
            Quaternion endExpected = end;
            float amount = Utilities.GenerateFloat();
            Quaternion result;

            Quaternion resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Slerp(
                Utilities.ConvertToXna(start),
                Utilities.ConvertToXna(end),
                amount));

            Quaternion.Slerp(ref start, ref end, amount, out result);
            Utilities.AreEqual(startExpected, start);
            Utilities.AreEqual(endExpected, end);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void SquadTest()
        {
            Quaternion value1 = Utilities.GenerateQuaternion();
            Quaternion value2 = Utilities.GenerateQuaternion();
            Quaternion value3 = Utilities.GenerateQuaternion();
            Quaternion value4 = Utilities.GenerateQuaternion();
            float amount = Utilities.GenerateFloat();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.DirectX.Quaternion.Squad(
                Utilities.ConvertToMdx(value1),
                Utilities.ConvertToMdx(value2),
                Utilities.ConvertToMdx(value3),
                Utilities.ConvertToMdx(value4),
                amount));

            Quaternion actual;
            actual = Quaternion.Squad(value1, value2, value3, value4, amount);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SquadByRefTest()
        {
            Quaternion value1 = Utilities.GenerateQuaternion();
            Quaternion value1Expected = value1;
            Quaternion value2 = Utilities.GenerateQuaternion();
            Quaternion value2Expected = value2;
            Quaternion value3 = Utilities.GenerateQuaternion();
            Quaternion value3Expected = value3;
            Quaternion value4 = Utilities.GenerateQuaternion();
            Quaternion value4Expected = value4;
            float amount = Utilities.GenerateFloat();
            Quaternion result;

            Quaternion resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Quaternion.Squad(
                Utilities.ConvertToMdx(value1),
                Utilities.ConvertToMdx(value2),
                Utilities.ConvertToMdx(value3),
                Utilities.ConvertToMdx(value4),
                amount));

            Quaternion.Squad(ref value1, ref value2, ref value3, ref value4, amount, out result);
            Utilities.AreEqual(value1Expected, value1);
            Utilities.AreEqual(value2Expected, value2);
            Utilities.AreEqual(value3Expected, value3);
            Utilities.AreEqual(value4Expected, value4);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void SquadSetupTest()
        {
            Quaternion value1 = Utilities.GenerateQuaternion();
            Quaternion value2 = Utilities.GenerateQuaternion();
            Quaternion value3 = Utilities.GenerateQuaternion();
            Quaternion value4 = Utilities.GenerateQuaternion();

            Quaternion[] expected = new Quaternion[3];
            Microsoft.DirectX.Quaternion outa = new Microsoft.DirectX.Quaternion();
            Microsoft.DirectX.Quaternion outb = new Microsoft.DirectX.Quaternion();
            Microsoft.DirectX.Quaternion outc = new Microsoft.DirectX.Quaternion();
            Microsoft.DirectX.Quaternion.SquadSetup(
                ref outa,
                ref outb,
                ref outc,
                Utilities.ConvertToMdx(value1),
                Utilities.ConvertToMdx(value2),
                Utilities.ConvertToMdx(value3),
                Utilities.ConvertToMdx(value4));
            expected[0] = Utilities.ConvertFrom(outa);
            expected[1] = Utilities.ConvertFrom(outb);
            expected[2] = Utilities.ConvertFrom(outc);

            Quaternion[] actual;
            actual = Quaternion.SquadSetup(value1, value2, value3, value4);

            Assert.IsNotNull(actual);
            Assert.IsTrue(expected.Length == actual.Length);

            for (int i = 0; i < expected.Length; ++i)
            {
                Utilities.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod()]
        public void SubtractTest()
        {
            Quaternion left = Utilities.GenerateQuaternion();
            Quaternion right = Utilities.GenerateQuaternion();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Subtract(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Quaternion actual;
            actual = Quaternion.Subtract(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SubtractByRefTest()
        {
            Quaternion left = Utilities.GenerateQuaternion();
            Quaternion leftExpected = left;
            Quaternion right = Utilities.GenerateQuaternion();
            Quaternion rightExpected = right;
            Quaternion result;

            Quaternion resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Subtract(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Quaternion.Subtract(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void ToArrayTest()
        {
            Quaternion target = Utilities.GenerateQuaternion();
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
        public void op_AdditionTest()
        {
            Quaternion left = Utilities.GenerateQuaternion();
            Quaternion right = Utilities.GenerateQuaternion();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Add(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Quaternion actual;
            actual = (left + right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_EqualityTest()
        {
            Quaternion left = Utilities.GenerateQuaternion();
            Quaternion right = new Quaternion(left.X + 1f, left.Y - 1f, left.Z, left.W + 2f);
            bool expected = false;
            bool actual;
            actual = left == right;
            Utilities.AreEqual(expected, actual);

            left = Utilities.GenerateQuaternion();
            right = left;
            expected = true;
            actual = left == right;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_InequalityTest()
        {
            Quaternion left = Utilities.GenerateQuaternion();
            Quaternion right = new Quaternion(left.X + 1f, left.Y - 1f, left.Z, left.W + 2f);
            bool expected = true;
            bool actual;
            actual = left != right;
            Utilities.AreEqual(expected, actual);

            left = Utilities.GenerateQuaternion();
            right = left;
            expected = false;
            actual = left != right;
            Utilities.AreEqual(expected, actual);

            left = Utilities.GenerateQuaternion();
            right = new Quaternion(left.X + (Utilities.ZeroTolerance / 2f), left.Y - (Utilities.ZeroTolerance / 2f), left.Z + (Utilities.ZeroTolerance / 2f), left.W - (Utilities.ZeroTolerance / 2f));
            expected = false;
            actual = left != right;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_MultiplyTest()
        {
            float scale = Utilities.GenerateFloat();
            Quaternion value = Utilities.GenerateQuaternion();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Multiply(
                Utilities.ConvertToXna(value),
                scale));

            Quaternion actual;
            actual = (scale * value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_MultiplyTest1()
        {
            Quaternion value = Utilities.GenerateQuaternion();
            float scale = Utilities.GenerateFloat();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Multiply(
                Utilities.ConvertToXna(value),
                scale));

            Quaternion actual;
            actual = (value * scale);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_MultiplyTest2()
        {
            Quaternion left = Utilities.GenerateQuaternion();
            Quaternion right = Utilities.GenerateQuaternion();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.DirectX.Quaternion.Multiply(
                Utilities.ConvertToMdx(left),
                Utilities.ConvertToMdx(right)));

            Quaternion actual;
            actual = (left * right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_SubtractionTest()
        {
            Quaternion left = Utilities.GenerateQuaternion();
            Quaternion right = Utilities.GenerateQuaternion();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Subtract(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Quaternion actual;
            actual = (left - right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_UnaryNegationTest()
        {
            Quaternion value = Utilities.GenerateQuaternion();

            Quaternion expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Quaternion.Negate(
                Utilities.ConvertToXna(value)));

            Quaternion actual;
            actual = -(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AngleTest()
        {
            //angle = 2 * arcos(qw)

            Quaternion target = Utilities.GenerateQuaternion();
            float actual;
            actual = target.Angle;

            float expected = 2.0f * (float)Math.Acos(target.W);

            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AxisTest()
        {
            //x = qx / sqrt(1 - qw²)
            //y = qy / sqrt(1 - qw²)
            //z = qz / sqrt(1 - qw²)

            Quaternion target = Utilities.GenerateQuaternion();
            Vector3 actual;
            actual = target.Axis;

            float denominator = (float)Math.Sqrt(1 - (target.W * target.W));
            Vector3 expected = new Vector3(
                target.X / denominator,
                target.Y / denominator,
                target.Z / denominator);

            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsIdentityTest()
        {
            Quaternion target = Utilities.GenerateQuaternion();
            Utilities.AreNotEqual(Quaternion.Identity, target);
            Utilities.AreEqual(Quaternion.Identity, Quaternion.Identity);
        }

        [TestMethod()]
        public void IsNormalizedTest()
        {
            Quaternion target = Utilities.GenerateQuaternion();
            bool expected = false;
            bool actual;
            actual = target.IsNormalized;
            Utilities.AreEqual(expected, actual);

            target = Utilities.GenerateQuaternion();
            target.Normalize();
            expected = true;
            actual = target.IsNormalized;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ItemTest()
        {
            Quaternion target = Utilities.GenerateQuaternion();
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
