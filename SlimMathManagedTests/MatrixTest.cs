using SlimMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SlimMathManagedTests
{
    [TestClass()]
    public class MatrixTest
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
        public void MatrixReadonlyFieldsTest()
        {
            Utilities.AreEqual(System.Runtime.InteropServices.Marshal.SizeOf(typeof(Matrix)), Matrix.SizeInBytes);
            Utilities.AreEqual(new Matrix()
            {
                M11 = 0, M12 = 0, M13 = 0, M14 = 0,
                M21 = 0, M22 = 0, M23 = 0, M24 = 0,
                M31 = 0, M32 = 0, M33 = 0, M34 = 0,
                M41 = 0, M42 = 0, M43 = 0, M44 = 0
            }, Matrix.Zero);
            Utilities.AreEqual(new Matrix()
            {
                M11 = 1, M12 = 0, M13 = 0, M14 = 0,
                M21 = 0, M22 = 1, M23 = 0, M24 = 0,
                M31 = 0, M32 = 0, M33 = 1, M34 = 0,
                M41 = 0, M42 = 0, M43 = 0, M44 = 1
            }, Matrix.Identity);
        }

        [TestMethod()]
        public void MatrixConstructorTest()
        {
            float[] values =
            {
                Utilities.GenerateFloat(), Utilities.GenerateFloat(), Utilities.GenerateFloat(), Utilities.GenerateFloat(),
                Utilities.GenerateFloat(), Utilities.GenerateFloat(), Utilities.GenerateFloat(), Utilities.GenerateFloat(),
                Utilities.GenerateFloat(), Utilities.GenerateFloat(), Utilities.GenerateFloat(), Utilities.GenerateFloat(),
                Utilities.GenerateFloat(), Utilities.GenerateFloat(), Utilities.GenerateFloat(), Utilities.GenerateFloat()
            };
            Matrix target = new Matrix(values);

            Utilities.AreEqual(values[0], target.M11, 0f);
            Utilities.AreEqual(values[1], target.M12, 0f);
            Utilities.AreEqual(values[2], target.M13, 0f);
            Utilities.AreEqual(values[3], target.M14, 0f);

            Utilities.AreEqual(values[4], target.M21, 0f);
            Utilities.AreEqual(values[5], target.M22, 0f);
            Utilities.AreEqual(values[6], target.M23, 0f);
            Utilities.AreEqual(values[7], target.M24, 0f);

            Utilities.AreEqual(values[8], target.M31, 0f);
            Utilities.AreEqual(values[9], target.M32, 0f);
            Utilities.AreEqual(values[10], target.M33, 0f);
            Utilities.AreEqual(values[11], target.M34, 0f);

            Utilities.AreEqual(values[12], target.M41, 0f);
            Utilities.AreEqual(values[13], target.M42, 0f);
            Utilities.AreEqual(values[14], target.M43, 0f);
            Utilities.AreEqual(values[15], target.M44, 0f);
        }

        [TestMethod()]
        public void MatrixConstructorTest1()
        {
            float M11 = Utilities.GenerateFloat();
            float M12 = Utilities.GenerateFloat();
            float M13 = Utilities.GenerateFloat();
            float M14 = Utilities.GenerateFloat();
            float M21 = Utilities.GenerateFloat();
            float M22 = Utilities.GenerateFloat();
            float M23 = Utilities.GenerateFloat();
            float M24 = Utilities.GenerateFloat();
            float M31 = Utilities.GenerateFloat();
            float M32 = Utilities.GenerateFloat();
            float M33 = Utilities.GenerateFloat();
            float M34 = Utilities.GenerateFloat();
            float M41 = Utilities.GenerateFloat();
            float M42 = Utilities.GenerateFloat();
            float M43 = Utilities.GenerateFloat();
            float M44 = Utilities.GenerateFloat();
            Matrix target = new Matrix(M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, M41, M42, M43, M44);

            Utilities.AreEqual(M11, target.M11, 0f);
            Utilities.AreEqual(M12, target.M12, 0f);
            Utilities.AreEqual(M13, target.M13, 0f);
            Utilities.AreEqual(M14, target.M14, 0f);

            Utilities.AreEqual(M21, target.M21, 0f);
            Utilities.AreEqual(M22, target.M22, 0f);
            Utilities.AreEqual(M23, target.M23, 0f);
            Utilities.AreEqual(M24, target.M24, 0f);

            Utilities.AreEqual(M31, target.M31, 0f);
            Utilities.AreEqual(M32, target.M32, 0f);
            Utilities.AreEqual(M33, target.M33, 0f);
            Utilities.AreEqual(M34, target.M34, 0f);

            Utilities.AreEqual(M41, target.M41, 0f);
            Utilities.AreEqual(M42, target.M42, 0f);
            Utilities.AreEqual(M43, target.M43, 0f);
            Utilities.AreEqual(M44, target.M44, 0f);
        }

        [TestMethod()]
        public void MatrixConstructorTest2()
        {
            float value = Utilities.GenerateFloat();
            Matrix target = new Matrix(value);

            Utilities.AreEqual(target.M11, value, 0f);
            Utilities.AreEqual(target.M12, value, 0f);
            Utilities.AreEqual(target.M13, value, 0f);
            Utilities.AreEqual(target.M14, value, 0f);

            Utilities.AreEqual(target.M21, value, 0f);
            Utilities.AreEqual(target.M22, value, 0f);
            Utilities.AreEqual(target.M23, value, 0f);
            Utilities.AreEqual(target.M24, value, 0f);

            Utilities.AreEqual(target.M31, value, 0f);
            Utilities.AreEqual(target.M32, value, 0f);
            Utilities.AreEqual(target.M33, value, 0f);
            Utilities.AreEqual(target.M34, value, 0f);

            Utilities.AreEqual(target.M41, value, 0f);
            Utilities.AreEqual(target.M42, value, 0f);
            Utilities.AreEqual(target.M43, value, 0f);
            Utilities.AreEqual(target.M44, value, 0f);
        }

        [TestMethod()]
        public void AddTest()
        {
            Matrix left = Utilities.GenerateMatrix();
            Matrix right = Utilities.GenerateMatrix();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Add(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Matrix actual;
            actual = Matrix.Add(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddByRefTest()
        {
            Matrix left = Utilities.GenerateMatrix();
            Matrix leftExpected = left;
            Matrix right = Utilities.GenerateMatrix();
            Matrix rightExpected = right;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Add(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Matrix.Add(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void AffineTransformationTest()
        {
            float scaling = Utilities.GenerateFloat();
            Quaternion rotation = Utilities.GenerateQuaternion();
            Vector3 translation = Utilities.GenerateVector3();

            Matrix expected = new Matrix(); // TODO: Initialize to an appropriate value

            Matrix actual;
            actual = Matrix.AffineTransformation(scaling, rotation, translation);
            //Utilities.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void AffineTransformationByRefTest()
        {
            float scaling = Utilities.GenerateFloat();
            Quaternion rotation = Utilities.GenerateQuaternion();
            Quaternion rotationExpected = rotation;
            Vector3 translation = Utilities.GenerateVector3();
            Vector3 translationExpected = translation;
            Matrix result;

            Matrix resultExpected = new Matrix(); // TODO: Initialize to an appropriate value

            Matrix.AffineTransformation(scaling, ref rotation, ref translation, out result);
            //Utilities.AreEqual(rotationExpected, rotation);
            //Utilities.AreEqual(translationExpected, translation);
            //Utilities.AreEqual(resultExpected, result);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void AffineTransformationTest1()
        {
            float scaling = Utilities.GenerateFloat();
            Vector3 rotationCenter = Utilities.GenerateVector3();
            Quaternion rotation = Utilities.GenerateQuaternion();
            Vector3 translation = Utilities.GenerateVector3();

            Matrix expected = new Matrix(); // TODO: Initialize to an appropriate value

            Matrix actual;
            actual = Matrix.AffineTransformation(scaling, rotationCenter, rotation, translation);
            //Utilities.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void AffineTransformationByRefTest1()
        {
            float scaling = Utilities.GenerateFloat();
            Vector3 rotationCenter = Utilities.GenerateVector3();
            Vector3 rotationCenterExpected = rotationCenter;
            Quaternion rotation = Utilities.GenerateQuaternion();
            Quaternion rotationExpected = rotation;
            Vector3 translation = Utilities.GenerateVector3();
            Vector3 translationExpected = translation;
            Matrix result;

            Matrix resultExpected = new Matrix(); // TODO: Initialize to an appropriate value

            Matrix.AffineTransformation(scaling, ref rotationCenter, ref rotation, ref translation, out result);
            //Utilities.AreEqual(rotationCenterExpected, rotationCenter);
            //Utilities.AreEqual(rotationExpected, rotation);
            //Utilities.AreEqual(translationExpected, translation);
            //Utilities.AreEqual(resultExpected, result);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void AffineTransformation2DTest()
        {
            float scaling = Utilities.GenerateFloat();
            float rotation = Utilities.GenerateFloat();
            Vector2 translation = Utilities.GenerateVector2();

            Matrix expected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.AffineTransformation2D(
                scaling,
                Utilities.ConvertToMdx(Vector2.Zero),
                rotation,
                Utilities.ConvertToMdx(translation)));

            Matrix actual;
            actual = Matrix.AffineTransformation2D(scaling, rotation, translation);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AffineTransformation2DByRefTest()
        {
            float scaling = Utilities.GenerateFloat();
            float rotation = Utilities.GenerateFloat();
            Vector2 translation = Utilities.GenerateVector2();
            Vector2 translationExpected = translation;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.AffineTransformation2D(
                scaling,
                Utilities.ConvertToMdx(Vector2.Zero),
                rotation,
                Utilities.ConvertToMdx(translation)));

            Matrix.AffineTransformation2D(scaling, rotation, ref translation, out result);
            Utilities.AreEqual(translationExpected, translation);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void AffineTransformation2DTest1()
        {
            float scaling = Utilities.GenerateFloat();
            Vector2 rotationCenter = Utilities.GenerateVector2();
            float rotation = Utilities.GenerateFloat();
            Vector2 translation = Utilities.GenerateVector2();

            Matrix expected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.AffineTransformation2D(
                scaling,
                Utilities.ConvertToMdx(rotationCenter),
                rotation,
                Utilities.ConvertToMdx(translation)));

            Matrix actual;
            actual = Matrix.AffineTransformation2D(scaling, rotationCenter, rotation, translation);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AffineTransformation2DByRefTest1()
        {
            float scaling = Utilities.GenerateFloat();
            Vector2 rotationCenter = Utilities.GenerateVector2();
            Vector2 rotationCenterExpected = rotationCenter;
            float rotation = Utilities.GenerateFloat();
            Vector2 translation = Utilities.GenerateVector2();
            Vector2 translationExpected = translation;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.AffineTransformation2D(
                scaling,
                Utilities.ConvertToMdx(rotationCenter),
                rotation,
                Utilities.ConvertToMdx(translation)));

            Matrix.AffineTransformation2D(scaling, ref rotationCenter, rotation, ref translation, out result);
            Utilities.AreEqual(rotationCenterExpected, rotationCenter);
            Utilities.AreEqual(translationExpected, translation);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void BillboardTest()
        {
            Vector3 objectPosition = Utilities.GenerateVector3();
            Vector3 cameraPosition = Utilities.GenerateVector3();
            Vector3 cameraUpVector = Utilities.GenerateVector3();
            Vector3 cameraForwardVector = Utilities.GenerateVector3();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateBillboard(
                Utilities.ConvertToXna(objectPosition),
                Utilities.ConvertToXna(cameraPosition),
                Utilities.ConvertToXna(cameraUpVector),
                Utilities.ConvertToXna(cameraForwardVector)));

            Matrix actual;
            actual = Matrix.Billboard(objectPosition, cameraPosition, cameraUpVector, cameraForwardVector);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BillboardByRefTest()
        {
            Vector3 objectPosition = Utilities.GenerateVector3();
            Vector3 objectPositionExpected = objectPosition;
            Vector3 cameraPosition = Utilities.GenerateVector3();
            Vector3 cameraPositionExpected = cameraPosition;
            Vector3 cameraUpVector = Utilities.GenerateVector3();
            Vector3 cameraUpVectorExpected = cameraUpVector;
            Vector3 cameraForwardVector = Utilities.GenerateVector3();
            Vector3 cameraForwardVectorExpected = cameraForwardVector;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateBillboard(
                Utilities.ConvertToXna(objectPosition),
                Utilities.ConvertToXna(cameraPosition),
                Utilities.ConvertToXna(cameraUpVector),
                Utilities.ConvertToXna(cameraForwardVector)));

            Matrix.Billboard(ref objectPosition, ref cameraPosition, ref cameraUpVector, ref cameraForwardVector, out result);
            Utilities.AreEqual(objectPositionExpected, objectPosition);
            Utilities.AreEqual(cameraPositionExpected, cameraPosition);
            Utilities.AreEqual(cameraUpVectorExpected, cameraUpVector);
            Utilities.AreEqual(cameraForwardVectorExpected, cameraForwardVector);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void DecomposeTest()
        {
            //Needs some work. This is for SRT matrices only.
            Vector3 scaleInput = Utilities.GenerateVector3();
            Quaternion rotationInput = Utilities.GenerateQuaternion();
            Vector3 translationInput = Utilities.GenerateVector3();

            Matrix target = Matrix.Scaling(scaleInput) * Matrix.RotationQuaternion(rotationInput) * Matrix.Translation(translationInput);
            Vector3 scale = Utilities.GenerateVector3();
            Quaternion rotation = Utilities.GenerateQuaternion();
            Vector3 translation = Utilities.GenerateVector3();

            Microsoft.Xna.Framework.Vector3 scaleXna;
            Microsoft.Xna.Framework.Quaternion rotationXna;
            Microsoft.Xna.Framework.Vector3 translationXna;
            bool expected = Utilities.ConvertToXna(target).Decompose(
                out scaleXna,
                out rotationXna,
                out translationXna);
            Vector3 scaleExpected = Utilities.ConvertFrom(scaleXna);
            Quaternion rotationExpected = Utilities.ConvertFrom(rotationXna);
            Vector3 translationExpected = Utilities.ConvertFrom(translationXna);

            bool actual;
            actual = target.Decompose(out scale, out rotation, out translation);
            //Utilities.AreEqual(scaleExpected, scale);
            //Utilities.AreEqual(rotationExpected, rotation);
            //Utilities.AreEqual(translationExpected, translation);
            //Utilities.AreEqual(expected, actual);

            Utilities.AreEqual(scaleInput, scale);
            Utilities.AreEqual(rotationInput, rotation);
            Utilities.AreEqual(translationInput, translation);
            Utilities.AreEqual(true, actual);
        }

        [TestMethod()]
        public void DecomposeLQTest()
        {
            Matrix target = Utilities.GenerateMatrix();

            Matrix L, Q;
            target.DecomposeLQ(out L, out Q);

            //The strict upper right triangle of L should be all zero.
            Utilities.AreEqual(0f, L.M12);
            Utilities.AreEqual(0f, L.M13);
            Utilities.AreEqual(0f, L.M14);
            Utilities.AreEqual(0f, L.M23);
            Utilities.AreEqual(0f, L.M24);
            Utilities.AreEqual(0f, L.M34);

            //Test if Q is orthonormalized.

            //Todo

            //Does L * Q make A?
            Utilities.AreEqual(target, L * Q);
        }

        [TestMethod()]
        public void DecomposeQRTest()
        {
            Matrix target = Utilities.GenerateMatrix();

            Matrix Q, R;
            target.DecomposeQR(out Q, out R);

            //The strict lower left triangle of R should be all zero.
            Utilities.AreEqual(0f, R.M21);
            Utilities.AreEqual(0f, R.M31);
            Utilities.AreEqual(0f, R.M32);
            Utilities.AreEqual(0f, R.M41);
            Utilities.AreEqual(0f, R.M42);
            Utilities.AreEqual(0f, R.M43);

            //Test if Q is orthonormalized.

            //Todo

            //Does Q * R make A?
            Utilities.AreEqual(target, Q * R);
        }

        [TestMethod()]
        public void DeterminantTest()
        {
            Matrix target = Utilities.GenerateMatrix();

            float expected = Utilities.ConvertToXna(target).Determinant();

            float actual;
            actual = target.Determinant;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DivideScaleTest()
        {
            Matrix left = Utilities.GenerateMatrix();
            float right = Utilities.GenerateFloat();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Divide(
                Utilities.ConvertToXna(left),
                right));

            Matrix actual;
            actual = Matrix.Divide(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DivideScaleByRefTest()
        {
            Matrix left = Utilities.GenerateMatrix();
            Matrix leftExpected = left;
            float right = Utilities.GenerateFloat();
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Divide(
                Utilities.ConvertToXna(left),
                right));

            Matrix.Divide(ref left, right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void DivideTest()
        {
            Matrix left = Utilities.GenerateMatrix();
            Matrix right = Utilities.GenerateMatrix();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Divide(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Matrix actual;
            actual = Matrix.Divide(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DivideByRefTest()
        {
            Matrix left = Utilities.GenerateMatrix();
            Matrix leftExpected = left;
            Matrix right = Utilities.GenerateMatrix();
            Matrix rightExpected = right;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Divide(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Matrix.Divide(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Matrix target = Utilities.GenerateMatrix();
            Matrix temp = target;
            temp.M11 += 1f; temp.M12 -= 2f; temp.M13 += 3f; temp.M14 += 1f;
            temp.M21 -= 1f; temp.M22 += 1f; temp.M23 += 1f; temp.M24 -= 1f;
            temp.M31 += 3f; temp.M32 -= 1f; temp.M33 += 1.5f; temp.M34 -= 2f;
            temp.M41 += 2f; temp.M42 -= 2f; temp.M43 -= 1f; temp.M44 += 2f;
            object value = temp;
            bool expected = false;
            bool actual;
            actual = target.Equals(value);
            Utilities.AreEqual(expected, actual);

            target = Utilities.GenerateMatrix();
            value = target;
            expected = true;
            actual = target.Equals(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EqualsTest1()
        {
            Matrix target = Utilities.GenerateMatrix();
            Matrix other = target;
            other.M11 += 1f; other.M12 -= 2f; other.M13 += 3f; other.M14 += 1f;
            other.M21 -= 1f; other.M22 += 1f; other.M23 += 1f; other.M24 -= 1f;
            other.M31 += 3f; other.M32 -= 1f; other.M33 += 1.5f; other.M34 -= 2f;
            other.M41 += 2f; other.M42 -= 2f; other.M43 -= 1f; other.M44 += 2f;
            bool expected = false;
            bool actual;
            actual = target.Equals(other);
            Utilities.AreEqual(expected, actual);

            target = Utilities.GenerateMatrix();
            other = target;
            expected = true;
            actual = target.Equals(other);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExchangeRows()
        {
            Matrix original = Utilities.GenerateMatrix();
            Matrix target = original;

            target.ExchangeRows(0, 3);
            Assert.AreEqual(original.Row4, target.Row1);
            Assert.AreEqual(original.Row1, target.Row4);

            target.ExchangeRows(1, 2);
            Assert.AreEqual(original.Row3, target.Row2);
            Assert.AreEqual(original.Row2, target.Row3);

            //Put back into original order.
            target.ExchangeRows(0, 3);
            target.ExchangeRows(1, 2);
            Assert.AreEqual(original, target);
        }

        public void ExchangeColumns()
        {
            Matrix original = Utilities.GenerateMatrix();
            Matrix target = original;

            target.ExchangeColumns(0, 3);
            Assert.AreEqual(original.Column4, target.Column1);
            Assert.AreEqual(original.Column1, target.Column4);

            target.ExchangeColumns(1, 2);
            Assert.AreEqual(original.Column3, target.Column2);
            Assert.AreEqual(original.Column2, target.Column3);

            //Put back into original order.
            target.ExchangeColumns(0, 3);
            target.ExchangeColumns(1, 2);
            Assert.AreEqual(original, target);
        }

        [TestMethod()]
        public void ExponentTest()
        {
            Matrix value = new Matrix(
                3f, 2f, 7f, 4f,
                7f, 6f, 1f, 9f,
                2f, 7f, 3f, 5f,
                2f, 5f, 7f, 4f);
            Matrix result;

            //Power of 2
            Matrix expected = new Matrix(
                45f, 87f, 72f, 81f,
                83f, 102f, 121f, 123f,
                71f, 92f, 65f, 106f,
                63f, 103f, 68f, 104f);
            //Power of 3
            Matrix expected1 = new Matrix(
                1050f, 1521f, 1185f, 1647f,
                1451f, 2240f, 1907f, 2347f,
                1199f, 1679f, 1526f, 1861f,
                1254f, 1740f, 1476f, 1935f);
            //Power of 5
            Matrix expected2 = new Matrix(
                361389f, 525153f, 448662f, 569031f,
                534473f, 771902f, 659063f, 839281f,
                418901f, 607646f, 515225f, 658936f,
                427551f, 621675f, 528348f, 673290f);

            result = Matrix.Exponent(value, 0);
            Assert.AreEqual(Matrix.Identity, result);
            result = Matrix.Exponent(value, 1);
            Assert.AreEqual(value, result);
            result = Matrix.Exponent(value, 2);
            Assert.AreEqual(expected, result);
            result = Matrix.Exponent(value, 3);
            Assert.AreEqual(expected1, result);
            result = Matrix.Exponent(value, 5);
            Assert.AreEqual(expected2, result);
        }

        [TestMethod()]
        public void ExponentByRefTest()
        {
            Matrix value = new Matrix(
                3f, 2f, 7f, 4f,
                7f, 6f, 1f, 9f,
                2f, 7f, 3f, 5f,
                2f, 5f, 7f, 4f);
            Matrix valueExpected = value;
            Matrix result;

            //Power of 2
            Matrix expected = new Matrix(
                45f, 87f, 72f, 81f,
                83f, 102f, 121f, 123f,
                71f, 92f, 65f, 106f,
                63f, 103f, 68f, 104f);
            //Power of 3
            Matrix expected1 = new Matrix(
                1050f, 1521f, 1185f, 1647f,
                1451f, 2240f, 1907f, 2347f,
                1199f, 1679f, 1526f, 1861f,
                1254f, 1740f, 1476f, 1935f);
            //Power of 5
            Matrix expected2 = new Matrix(
                361389f, 525153f, 448662f, 569031f,
                534473f, 771902f, 659063f, 839281f,
                418901f, 607646f, 515225f, 658936f,
                427551f, 621675f, 528348f, 673290f);

            Matrix.Exponent(ref value, 0, out result);
            Assert.AreEqual(valueExpected, value);
            Assert.AreEqual(Matrix.Identity, result);
            Matrix.Exponent(ref value, 1, out result);
            Assert.AreEqual(valueExpected, value);
            Assert.AreEqual(value, result);
            Matrix.Exponent(ref value, 2, out result);
            Assert.AreEqual(valueExpected, value);
            Assert.AreEqual(expected, result);
            Matrix.Exponent(ref value, 3, out result);
            Assert.AreEqual(valueExpected, value);
            Assert.AreEqual(expected1, result);
            Matrix.Exponent(ref value, 5, out result);
            Assert.AreEqual(valueExpected, value);
            Assert.AreEqual(expected2, result);
        }

        [TestMethod()]
        public void InvertTest()
        {
            Matrix target = Utilities.GenerateMatrix();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Invert(
                Utilities.ConvertToXna(target)));

            target.Invert();
            Utilities.AreEqual(target, expected);
        }

        [TestMethod()]
        public void InvertTest1()
        {
            Matrix value = Utilities.GenerateMatrix();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Invert(
                Utilities.ConvertToXna(value)));

            Matrix actual;
            actual = Matrix.Invert(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void InvertByRefTest()
        {
            Matrix value = Utilities.GenerateMatrix();
            Matrix valueExpected = value;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Invert(
                Utilities.ConvertToXna(value)));

            Matrix.Invert(ref value, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void LerpTest()
        {
            Matrix start = Utilities.GenerateMatrix();
            Matrix end = Utilities.GenerateMatrix();
            float amount = Utilities.GenerateFloat();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Lerp(
                Utilities.ConvertToXna(start),
                Utilities.ConvertToXna(end),
                amount));

            Matrix actual;
            actual = Matrix.Lerp(start, end, amount);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LerpByRefTest()
        {
            Matrix start = Utilities.GenerateMatrix();
            Matrix startExpected = start;
            Matrix end = Utilities.GenerateMatrix();
            Matrix endExpected = end;
            float amount = Utilities.GenerateFloat();
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Lerp(
                Utilities.ConvertToXna(start),
                Utilities.ConvertToXna(end),
                amount));

            Matrix.Lerp(ref start, ref end, amount, out result);
            Utilities.AreEqual(startExpected, start);
            Utilities.AreEqual(endExpected, end);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void LookAtLHTest()
        {
            Vector3 eye = Utilities.GenerateVector3();
            Vector3 target = Utilities.GenerateVector3();
            Vector3 up = Utilities.GenerateVector3();

            Matrix expected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.LookAtLH(
                Utilities.ConvertToMdx(eye),
                Utilities.ConvertToMdx(target),
                Utilities.ConvertToMdx(up)));

            Matrix actual;
            actual = Matrix.LookAtLH(eye, target, up);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LookAtLHByRefTest()
        {
            Vector3 eye = Utilities.GenerateVector3();
            Vector3 eyeExpected = eye;
            Vector3 target = Utilities.GenerateVector3();
            Vector3 targetExpected = target;
            Vector3 up = Utilities.GenerateVector3();
            Vector3 upExpected = up;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.LookAtLH(
                Utilities.ConvertToMdx(eye),
                Utilities.ConvertToMdx(target),
                Utilities.ConvertToMdx(up)));

            Matrix.LookAtLH(ref eye, ref target, ref up, out result);
            Utilities.AreEqual(eyeExpected, eye);
            Utilities.AreEqual(targetExpected, target);
            Utilities.AreEqual(upExpected, up);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void LookAtRHTest()
        {
            Vector3 eye = Utilities.GenerateVector3();
            Vector3 target = Utilities.GenerateVector3();
            Vector3 up = Utilities.GenerateVector3();

            Matrix expected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.LookAtRH(
                Utilities.ConvertToMdx(eye),
                Utilities.ConvertToMdx(target),
                Utilities.ConvertToMdx(up)));

            Matrix actual;
            actual = Matrix.LookAtRH(eye, target, up);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LookAtRHByRefTest()
        {
            Vector3 eye = Utilities.GenerateVector3();
            Vector3 eyeExpected = eye;
            Vector3 target = Utilities.GenerateVector3();
            Vector3 targetExpected = target;
            Vector3 up = Utilities.GenerateVector3();
            Vector3 upExpected = up;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.LookAtRH(
                Utilities.ConvertToMdx(eye),
                Utilities.ConvertToMdx(target),
                Utilities.ConvertToMdx(up)));

            Matrix.LookAtRH(ref eye, ref target, ref up, out result);
            Utilities.AreEqual(eyeExpected, eye);
            Utilities.AreEqual(targetExpected, target);
            Utilities.AreEqual(upExpected, up);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void LowerTriangularFormTest()
        {
            Matrix target = Utilities.GenerateMatrix();

            Matrix result = Matrix.LowerTriangularForm(target);

            //Strict right upper triangle should be all zero.
            Utilities.Equals(0f, result.M12);
            Utilities.Equals(0f, result.M13);
            Utilities.Equals(0f, result.M14);
            Utilities.Equals(0f, result.M23);
            Utilities.Equals(0f, result.M24);
            Utilities.Equals(0f, result.M34);
        }

        [TestMethod()]
        public void LowerTriangularFormByRefTest()
        {
            Matrix target = Utilities.GenerateMatrix();
            Matrix targetExpected = target;

            Matrix result;
            Matrix.LowerTriangularForm(ref target, out result);

            Utilities.Equals(targetExpected, target);

            //Strict right upper triangle should be all zero.
            Utilities.Equals(0f, result.M12);
            Utilities.Equals(0f, result.M13);
            Utilities.Equals(0f, result.M14);
            Utilities.Equals(0f, result.M23);
            Utilities.Equals(0f, result.M24);
            Utilities.Equals(0f, result.M34);
        }

        [TestMethod()]
        public void MultiplyScaleTest()
        {
            Matrix left = Utilities.GenerateMatrix();
            float right = Utilities.GenerateFloat();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Multiply(
                Utilities.ConvertToXna(left),
                right));

            Matrix actual;
            actual = Matrix.Multiply(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MultiplyScaleByRefTest()
        {
            Matrix left = Utilities.GenerateMatrix();
            Matrix leftExpected = left;
            float right = Utilities.GenerateFloat();
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Multiply(
                Utilities.ConvertToXna(left),
                right));

            Matrix.Multiply(ref left, right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            Matrix left = Utilities.GenerateMatrix();
            Matrix right = Utilities.GenerateMatrix();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Multiply(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Matrix actual;
            actual = Matrix.Multiply(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MultiplyByRefTest()
        {
            Matrix left = Utilities.GenerateMatrix();
            Matrix leftExpected = left;
            Matrix right = Utilities.GenerateMatrix();
            Matrix rightExpected = right;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Multiply(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Matrix.Multiply(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void NegateTest()
        {
            Matrix value = Utilities.GenerateMatrix();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Negate(
                Utilities.ConvertToXna(value)));

            Matrix actual;
            actual = Matrix.Negate(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NegateByRefTest()
        {
            Matrix value = Utilities.GenerateMatrix();
            Matrix valueExpected = value;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Negate(
                Utilities.ConvertToXna(value)));

            Matrix.Negate(ref value, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void OrthoLHTest()
        {
            float width = Utilities.GenerateFloat();
            float height = Utilities.GenerateFloat() + width + 1f;
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;

            Matrix expected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.OrthoLH(
                width,
                height,
                znear,
                zfar));

            Matrix actual;
            actual = Matrix.OrthoLH(width, height, znear, zfar);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrthoLHByRefTest()
        {
            float width = Utilities.GenerateFloat();
            float height = Utilities.GenerateFloat() + width + 1f;
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.OrthoLH(
                width,
                height,
                znear,
                zfar));

            Matrix.OrthoLH(width, height, znear, zfar, out result);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void OrthoOffCenterLHTest()
        {
            float left = Utilities.GenerateFloat();
            float right = Utilities.GenerateFloat() + left + 1f;
            float top = Utilities.GenerateFloat();
            float bottom = Utilities.GenerateFloat() + top + 1f;
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;

            Matrix expected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.OrthoOffCenterLH(
                left,
                right,
                bottom,
                top,
                znear,
                zfar));

            Matrix actual;
            actual = Matrix.OrthoOffCenterLH(left, right, bottom, top, znear, zfar);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrthoOffCenterLHByRefTest()
        {
            float left = Utilities.GenerateFloat();
            float right = Utilities.GenerateFloat() + left + 1f;
            float top = Utilities.GenerateFloat();
            float bottom = Utilities.GenerateFloat() + top + 1f;
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.OrthoOffCenterLH(
                left,
                right,
                bottom,
                top,
                znear,
                zfar));

            Matrix.OrthoOffCenterLH(left, right, bottom, top, znear, zfar, out result);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void OrthoOffCenterRHTest()
        {
            float left = Utilities.GenerateFloat();
            float right = Utilities.GenerateFloat() + left + 1f;
            float top = Utilities.GenerateFloat();
            float bottom = Utilities.GenerateFloat() + top + 1f;
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;

            Matrix expected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.OrthoOffCenterRH(
                left,
                right,
                bottom,
                top,
                znear,
                zfar));

            Matrix actual;
            actual = Matrix.OrthoOffCenterRH(left, right, bottom, top, znear, zfar);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrthoOffCenterRHByRefTest()
        {
            float left = Utilities.GenerateFloat();
            float right = Utilities.GenerateFloat() + left + 1f;
            float top = Utilities.GenerateFloat();
            float bottom = Utilities.GenerateFloat() + top + 1f;
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.OrthoOffCenterRH(
                left,
                right,
                bottom,
                top,
                znear,
                zfar));

            Matrix.OrthoOffCenterRH(left, right, bottom, top, znear, zfar, out result);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void OrthogonalizeTest()
        {
            //Because orthogonalization is numerically unstable, we adjust the assert delta.
            float deltabefore = Utilities.AssertDelta;
            Utilities.AssertDelta = 1e-2f;

            Matrix target = Utilities.GenerateMatrix();
            target.Orthogonalize();

            //All rows should be orthogonal to each other.
            Utilities.AreEqual(0f, Vector4.Dot(target.Row1, target.Row2));
            Utilities.AreEqual(0f, Vector4.Dot(target.Row1, target.Row3));
            Utilities.AreEqual(0f, Vector4.Dot(target.Row1, target.Row4));

            Utilities.AreEqual(0f, Vector4.Dot(target.Row2, target.Row3));
            Utilities.AreEqual(0f, Vector4.Dot(target.Row2, target.Row4));

            Utilities.AreEqual(0f, Vector4.Dot(target.Row3, target.Row4));

            //Reset the assert delta.
            Utilities.AssertDelta = deltabefore;
        }

        [TestMethod()]
        public void OrthogonalizeTest1()
        {
            //Because orthogonalization is numerically unstable, we adjust the assert delta.
            float deltabefore = Utilities.AssertDelta;
            Utilities.AssertDelta = 1e-2f;

            Matrix value = Utilities.GenerateMatrix();
            Matrix result = Matrix.Orthogonalize(value);

            //All rows should be orthogonal to each other.
            Utilities.AreEqual(0f, Vector4.Dot(result.Row1, result.Row2));
            Utilities.AreEqual(0f, Vector4.Dot(result.Row1, result.Row3));
            Utilities.AreEqual(0f, Vector4.Dot(result.Row1, result.Row4));

            Utilities.AreEqual(0f, Vector4.Dot(result.Row2, result.Row3));
            Utilities.AreEqual(0f, Vector4.Dot(result.Row2, result.Row4));

            Utilities.AreEqual(0f, Vector4.Dot(result.Row3, result.Row4));

            //Reset the assert delta.
            Utilities.AssertDelta = deltabefore;
        }

        [TestMethod()]
        public void OrthogonalizeByRefTest()
        {
            //Because orthogonalization is numerically unstable, we adjust the assert delta.
            float deltabefore = Utilities.AssertDelta;
            Utilities.AssertDelta = 1e-2f;

            Matrix value = Utilities.GenerateMatrix();
            Matrix valueExpected = value;
            Matrix result;
            
            Matrix.Orthogonalize(ref value, out result);

            Utilities.AreEqual(value, valueExpected);

            //All rows should be orthogonal to each other.
            Utilities.AreEqual(0f, Vector4.Dot(result.Row1, result.Row2));
            Utilities.AreEqual(0f, Vector4.Dot(result.Row1, result.Row3));
            Utilities.AreEqual(0f, Vector4.Dot(result.Row1, result.Row4));

            Utilities.AreEqual(0f, Vector4.Dot(result.Row2, result.Row3));
            Utilities.AreEqual(0f, Vector4.Dot(result.Row2, result.Row4));

            Utilities.AreEqual(0f, Vector4.Dot(result.Row3, result.Row4));

            //Reset the assert delta.
            Utilities.AssertDelta = deltabefore;
        }

        [TestMethod()]
        public void OrthonormalizeTest()
        {
            Matrix target = Utilities.GenerateMatrix();
            target.Orthonormalize();

            //All lengths of rows should be equal.
            Utilities.AreEqual(target.Row1.Length, target.Row2.Length);
            Utilities.AreEqual(target.Row2.Length, target.Row3.Length);
            Utilities.AreEqual(target.Row3.Length, target.Row4.Length);

            //All lengths of columns should be equal.
            Utilities.AreEqual(target.Column1.Length, target.Column2.Length);
            Utilities.AreEqual(target.Column2.Length, target.Column3.Length);
            Utilities.AreEqual(target.Column3.Length, target.Column4.Length);

            //All rows should be orthogonal to each other.
            Utilities.AreEqual(0f, Vector4.Dot(target.Row1, target.Row2));
            Utilities.AreEqual(0f, Vector4.Dot(target.Row1, target.Row3));
            Utilities.AreEqual(0f, Vector4.Dot(target.Row1, target.Row4));

            Utilities.AreEqual(0f, Vector4.Dot(target.Row2, target.Row3));
            Utilities.AreEqual(0f, Vector4.Dot(target.Row2, target.Row4));

            Utilities.AreEqual(0f, Vector4.Dot(target.Row3, target.Row4));

            //All columns should be orthogonal to each other.
            Utilities.AreEqual(0f, Vector4.Dot(target.Column1, target.Column2));
            Utilities.AreEqual(0f, Vector4.Dot(target.Column1, target.Column3));
            Utilities.AreEqual(0f, Vector4.Dot(target.Column1, target.Column4));

            Utilities.AreEqual(0f, Vector4.Dot(target.Column2, target.Column3));
            Utilities.AreEqual(0f, Vector4.Dot(target.Column2, target.Column4));

            Utilities.AreEqual(0f, Vector4.Dot(target.Column3, target.Column4));
        }

        [TestMethod()]
        public void Orthonormalize1Test()
        {
            Matrix value = Utilities.GenerateMatrix();
            Matrix result = Matrix.Orthonormalize(value);

            //All lengths of rows should be equal.
            Utilities.AreEqual(result.Row1.Length, result.Row2.Length);
            Utilities.AreEqual(result.Row2.Length, result.Row3.Length);
            Utilities.AreEqual(result.Row3.Length, result.Row4.Length);

            //All lengths of columns should be equal.
            Utilities.AreEqual(result.Column1.Length, result.Column2.Length);
            Utilities.AreEqual(result.Column2.Length, result.Column3.Length);
            Utilities.AreEqual(result.Column3.Length, result.Column4.Length);

            //All rows should be orthogonal to each other.
            Utilities.AreEqual(0f, Vector4.Dot(result.Row1, result.Row2));
            Utilities.AreEqual(0f, Vector4.Dot(result.Row1, result.Row3));
            Utilities.AreEqual(0f, Vector4.Dot(result.Row1, result.Row4));

            Utilities.AreEqual(0f, Vector4.Dot(result.Row2, result.Row3));
            Utilities.AreEqual(0f, Vector4.Dot(result.Row2, result.Row4));

            Utilities.AreEqual(0f, Vector4.Dot(result.Row3, result.Row4));

            //All columns should be orthogonal to each other.
            Utilities.AreEqual(0f, Vector4.Dot(result.Column1, result.Column2));
            Utilities.AreEqual(0f, Vector4.Dot(result.Column1, result.Column3));
            Utilities.AreEqual(0f, Vector4.Dot(result.Column1, result.Column4));

            Utilities.AreEqual(0f, Vector4.Dot(result.Column2, result.Column3));
            Utilities.AreEqual(0f, Vector4.Dot(result.Column2, result.Column4));

            Utilities.AreEqual(0f, Vector4.Dot(result.Column3, result.Column4));
        }

        [TestMethod()]
        public void OrthonormalizeByRefTest()
        {
            Matrix value = Utilities.GenerateMatrix();
            Matrix valueExpected = value;
            Matrix result;

            Matrix.Orthonormalize(ref value, out result);

            Utilities.AreEqual(value, valueExpected);

            //All lengths of rows should be equal.
            Utilities.AreEqual(result.Row1.Length, result.Row2.Length);
            Utilities.AreEqual(result.Row2.Length, result.Row3.Length);
            Utilities.AreEqual(result.Row3.Length, result.Row4.Length);

            //All lengths of columns should be equal.
            Utilities.AreEqual(result.Column1.Length, result.Column2.Length);
            Utilities.AreEqual(result.Column2.Length, result.Column3.Length);
            Utilities.AreEqual(result.Column3.Length, result.Column4.Length);

            //All rows should be orthogonal to each other.
            Utilities.AreEqual(0f, Vector4.Dot(result.Row1, result.Row2));
            Utilities.AreEqual(0f, Vector4.Dot(result.Row1, result.Row3));
            Utilities.AreEqual(0f, Vector4.Dot(result.Row1, result.Row4));

            Utilities.AreEqual(0f, Vector4.Dot(result.Row2, result.Row3));
            Utilities.AreEqual(0f, Vector4.Dot(result.Row2, result.Row4));

            Utilities.AreEqual(0f, Vector4.Dot(result.Row3, result.Row4));

            //All columns should be orthogonal to each other.
            Utilities.AreEqual(0f, Vector4.Dot(result.Column1, result.Column2));
            Utilities.AreEqual(0f, Vector4.Dot(result.Column1, result.Column3));
            Utilities.AreEqual(0f, Vector4.Dot(result.Column1, result.Column4));

            Utilities.AreEqual(0f, Vector4.Dot(result.Column2, result.Column3));
            Utilities.AreEqual(0f, Vector4.Dot(result.Column2, result.Column4));

            Utilities.AreEqual(0f, Vector4.Dot(result.Column3, result.Column4));
        }

        [TestMethod()]
        public void OrthoRHTest()
        {
            float width = Utilities.GenerateFloat();
            float height = Utilities.GenerateFloat() + width + 1f;
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;

            Matrix expected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.OrthoRH(
                width,
                height,
                znear,
                zfar));

            Matrix actual;
            actual = Matrix.OrthoRH(width, height, znear, zfar);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OrthoRHByRefTest()
        {
            float width = Utilities.GenerateFloat();
            float height = Utilities.GenerateFloat() + width + 1f;
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.OrthoRH(
                width,
                height,
                znear,
                zfar));

            Matrix.OrthoRH(width, height, znear, zfar, out result);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void PerspectiveFovLHTest()
        {
            float fov = Utilities.GenerateFloat();
            float aspect = Utilities.GenerateFloat();
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;

            Matrix expected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.PerspectiveFovLH(
                fov,
                aspect,
                znear,
                zfar));

            Matrix actual;
            actual = Matrix.PerspectiveFovLH(fov, aspect, znear, zfar);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PerspectiveFovLHByRefTest()
        {
            float fov = Utilities.GenerateFloat();
            float aspect = Utilities.GenerateFloat();
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.PerspectiveFovLH(
                fov,
                aspect,
                znear,
                zfar));

            Matrix.PerspectiveFovLH(fov, aspect, znear, zfar, out result);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void PerspectiveFovRHTest()
        {
            float fov = Utilities.GenerateFloat();
            float aspect = Utilities.GenerateFloat();
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;

            Matrix expected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.PerspectiveFovRH(
                fov,
                aspect,
                znear,
                zfar));

            Matrix actual;
            actual = Matrix.PerspectiveFovRH(fov, aspect, znear, zfar);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PerspectiveFovRHByRefTest()
        {
            float fov = Utilities.GenerateFloat();
            float aspect = Utilities.GenerateFloat();
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.PerspectiveFovRH(
                fov,
                aspect,
                znear,
                zfar));

            Matrix.PerspectiveFovRH(fov, aspect, znear, zfar, out result);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void PerspectiveLHTest()
        {
            float width = Utilities.GenerateFloat();
            float height = Utilities.GenerateFloat();
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;

            Matrix expected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.PerspectiveLH(
                width,
                height,
                znear,
                zfar));

            Matrix actual;
            actual = Matrix.PerspectiveLH(width, height, znear, zfar);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PerspectiveLHByRefTest()
        {
            float width = Utilities.GenerateFloat();
            float height = Utilities.GenerateFloat();
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.PerspectiveLH(
                width,
                height,
                znear,
                zfar));

            Matrix.PerspectiveLH(width, height, znear, zfar, out result);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void PerspectiveOffCenterLHTest()
        {
            float left = Utilities.GenerateFloat();
            float right = Utilities.GenerateFloat() + left + 1f;
            float top = Utilities.GenerateFloat();
            float bottom = Utilities.GenerateFloat() + top + 1f;
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;

            Matrix expected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.PerspectiveOffCenterLH(
                left,
                right,
                bottom,
                top,
                znear,
                zfar));

            Matrix actual;
            actual = Matrix.PerspectiveOffCenterLH(left, right, bottom, top, znear, zfar);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PerspectiveOffCenterLHByRefTest()
        {
            float left = Utilities.GenerateFloat();
            float right = Utilities.GenerateFloat() + left + 1f;
            float top = Utilities.GenerateFloat();
            float bottom = Utilities.GenerateFloat() + top + 1f;
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.PerspectiveOffCenterLH(
                left,
                right,
                bottom,
                top,
                znear,
                zfar));

            Matrix.PerspectiveOffCenterLH(left, right, bottom, top, znear, zfar, out result);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void PerspectiveOffCenterRHTest()
        {
            float left = Utilities.GenerateFloat();
            float right = Utilities.GenerateFloat() + left + 1f;
            float top = Utilities.GenerateFloat();
            float bottom = Utilities.GenerateFloat() + top + 1f;
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;

            Matrix expected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.PerspectiveOffCenterRH(
                left,
                right,
                bottom,
                top,
                znear,
                zfar));

            Matrix actual;
            actual = Matrix.PerspectiveOffCenterRH(left, right, bottom, top, znear, zfar);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PerspectiveOffCenterRHByRefTest()
        {
            float left = Utilities.GenerateFloat();
            float right = Utilities.GenerateFloat() + left + 1f;
            float top = Utilities.GenerateFloat();
            float bottom = Utilities.GenerateFloat() + top + 1f;
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.PerspectiveOffCenterRH(
                left,
                right,
                bottom,
                top,
                znear,
                zfar));

            Matrix.PerspectiveOffCenterRH(left, right, bottom, top, znear, zfar, out result);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void PerspectiveRHTest()
        {
            float width = Utilities.GenerateFloat();
            float height = Utilities.GenerateFloat();
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;

            Matrix expected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.PerspectiveRH(
                width,
                height,
                znear,
                zfar));

            Matrix actual;
            actual = Matrix.PerspectiveRH(width, height, znear, zfar);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PerspectiveRHByRefTest()
        {
            float width = Utilities.GenerateFloat();
            float height = Utilities.GenerateFloat();
            float znear = Utilities.GenerateFloat();
            float zfar = Utilities.GenerateFloat() + znear + 1f;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.PerspectiveRH(
                width,
                height,
                znear,
                zfar));

            Matrix.PerspectiveRH(width, height, znear, zfar, out result);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void ReflectionTest()
        {
            //Note: Xna implicitly normalizes the plane.
            Plane plane = Utilities.GeneratePlane();
            plane.Normalize();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateReflection(
                Utilities.ConvertToXna(plane)));

            Matrix actual;
            actual = Matrix.Reflection(plane);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ReflectionByRefTest()
        {
            //Note: Xna implicitly normalizes the plane.
            Plane plane = Utilities.GeneratePlane();
            plane.Normalize();
            Plane planeExpected = plane;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateReflection(
                Utilities.ConvertToXna(plane)));

            Matrix.Reflection(ref plane, out result);
            Utilities.AreEqual(planeExpected, plane);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void RotationAxisTest()
        {
            Vector3 axis = Utilities.GenerateVector3();
            float angle = Utilities.GenerateFloat();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateFromAxisAngle(
                Utilities.ConvertToXna(axis),
                angle));

            Matrix actual;
            actual = Matrix.RotationAxis(axis, angle);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RotationAxisByRefTest()
        {
            Vector3 axis = Utilities.GenerateVector3();
            axis.Normalize();
            Vector3 axisExpected = axis;
            float angle = Utilities.GenerateFloat();
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateFromAxisAngle(
                Utilities.ConvertToXna(axis),
                angle));

            Matrix.RotationAxis(ref axis, angle, out result);
            Utilities.AreEqual(axisExpected, axis);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void RotationQuaternionTest()
        {
            Quaternion rotation = Utilities.GenerateQuaternion();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateFromQuaternion(
                Utilities.ConvertToXna(rotation)));

            Matrix actual;
            actual = Matrix.RotationQuaternion(rotation);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RotationQuaternionByRefTest()
        {
            Quaternion rotation = Utilities.GenerateQuaternion();
            Quaternion rotationExpected = rotation;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateFromQuaternion(
                Utilities.ConvertToXna(rotation)));

            Matrix.RotationQuaternion(ref rotation, out result);
            Utilities.AreEqual(rotationExpected, rotation);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void RotationXTest()
        {
            float angle = Utilities.GenerateFloat();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateRotationX(
                angle));

            Matrix actual;
            actual = Matrix.RotationX(angle);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RotationXByRefTest()
        {
            float angle = Utilities.GenerateFloat();
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateRotationX(
                angle));

            Matrix.RotationX(angle, out result);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void RotationYTest()
        {
            float angle = Utilities.GenerateFloat();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateRotationY(
                angle));

            Matrix actual;
            actual = Matrix.RotationY(angle);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RotationYByRefTest()
        {
            float angle = Utilities.GenerateFloat();
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateRotationY(
                angle));

            Matrix.RotationY(angle, out result);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void RotationYawPitchRollTest()
        {
            float yaw = Utilities.GenerateFloat();
            float pitch = Utilities.GenerateFloat();
            float roll = Utilities.GenerateFloat();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateFromYawPitchRoll(
                yaw,
                pitch,
                roll));

            Matrix actual;
            actual = Matrix.RotationYawPitchRoll(yaw, pitch, roll);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RotationYawPitchRollByRefTest()
        {
            float yaw = Utilities.GenerateFloat();
            float pitch = Utilities.GenerateFloat();
            float roll = Utilities.GenerateFloat();
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateFromYawPitchRoll(
                yaw,
                pitch,
                roll));

            Matrix.RotationYawPitchRoll(yaw, pitch, roll, out result);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void RotationZTest()
        {
            float angle = Utilities.GenerateFloat();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateRotationZ(
                angle));

            Matrix actual;
            actual = Matrix.RotationZ(angle);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RotationZByRefTest()
        {
            float angle = Utilities.GenerateFloat();
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateRotationZ(
                angle));

            Matrix.RotationZ(angle, out result);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void RowEchelonFormTest()
        {
            Matrix value = Utilities.GenerateMatrix();
            Matrix result = Matrix.RowEchelonForm(value);

            Utilities.AreEqual(1f, result.M11);
            Utilities.AreEqual(1f, result.M22);
            Utilities.AreEqual(1f, result.M33);
            Utilities.AreEqual(1f, result.M44);

            Utilities.AreEqual(0f, result.M21);
            Utilities.AreEqual(0f, result.M31);
            Utilities.AreEqual(0f, result.M41);
            Utilities.AreEqual(0f, result.M32);
            Utilities.AreEqual(0f, result.M42);
            Utilities.AreEqual(0f, result.M43);
        }

        [TestMethod()]
        public void RowEchelonFormByRefTest()
        {
            Matrix value = Utilities.GenerateMatrix();
            Matrix valueExpected = value;

            Matrix result;
            Matrix.RowEchelonForm(ref value, out result);

            Utilities.AreEqual(valueExpected, value);

            Utilities.AreEqual(1f, result.M11);
            Utilities.AreEqual(1f, result.M22);
            Utilities.AreEqual(1f, result.M33);
            Utilities.AreEqual(1f, result.M44);

            Utilities.AreEqual(0f, result.M21);
            Utilities.AreEqual(0f, result.M31);
            Utilities.AreEqual(0f, result.M41);
            Utilities.AreEqual(0f, result.M32);
            Utilities.AreEqual(0f, result.M42);
            Utilities.AreEqual(0f, result.M43);
        }

        [TestMethod()]
        public void ReducedRowEchelonFormByRefTest()
        {
            Matrix value = Utilities.GenerateMatrix();
            Matrix valueExpected = value;
            Vector4 augment = Utilities.GenerateVector4();
            Vector4 augmentExpected = augment;

            Matrix result;
            Vector4 augmentResult;
            Matrix.ReducedRowEchelonForm(ref value, ref augment, out result, out augmentResult);

            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(augmentExpected, augment);

            Utilities.AreEqual(1f, result.M11);
            Utilities.AreEqual(1f, result.M22);
            Utilities.AreEqual(1f, result.M33);
            Utilities.AreEqual(1f, result.M44);

            Utilities.AreEqual(0f, result.M21);
            Utilities.AreEqual(0f, result.M31);
            Utilities.AreEqual(0f, result.M41);
            Utilities.AreEqual(0f, result.M32);
            Utilities.AreEqual(0f, result.M42);
            Utilities.AreEqual(0f, result.M43);

            Utilities.AreEqual(0f, result.M12);
            Utilities.AreEqual(0f, result.M13);
            Utilities.AreEqual(0f, result.M14);
            Utilities.AreEqual(0f, result.M23);
            Utilities.AreEqual(0f, result.M24);
            Utilities.AreEqual(0f, result.M34);
        }

        [TestMethod()]
        public void ScalingTest()
        {
            Vector3 scale = Utilities.GenerateVector3();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateScale(
                Utilities.ConvertToXna(scale)));

            Matrix actual;
            actual = Matrix.Scaling(scale);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ScalingByRefTest()
        {
            Vector3 scale = Utilities.GenerateVector3();
            Vector3 scaleExpected = scale;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateScale(
                Utilities.ConvertToXna(scale)));

            Matrix.Scaling(ref scale, out result);
            Utilities.AreEqual(scaleExpected, scale);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void ScalingScalarSingleTest()
        {
            float scale = Utilities.GenerateFloat();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateScale(
                scale));

            Matrix actual;
            actual = Matrix.Scaling(scale);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ScalingScalarSingleByRefTest()
        {
            float scale = Utilities.GenerateFloat();
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateScale(
                scale));

            Matrix.Scaling(scale, out result);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void ScalingScalarsTest()
        {
            float x = Utilities.GenerateFloat();
            float y = Utilities.GenerateFloat();
            float z = Utilities.GenerateFloat();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateScale(
                x,
                y,
                z));

            Matrix actual;
            actual = Matrix.Scaling(x, y, z);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ScalingScalarsByRefTest()
        {
            float x = Utilities.GenerateFloat();
            float y = Utilities.GenerateFloat();
            float z = Utilities.GenerateFloat();
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateScale(
                x,
                y,
                z));

            Matrix.Scaling(x, y, z, out result);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void ShadowTest()
        {
            Vector4 light = Utilities.GenerateVector4();
            light.W = 0f;
            Plane plane = Utilities.GeneratePlane();
            plane.Normalize();

            Microsoft.DirectX.Matrix temp = new Microsoft.DirectX.Matrix();
            temp.Shadow(Utilities.ConvertToMdx(light), Utilities.ConvertToMdx(plane));
            Matrix expected = Utilities.ConvertFrom(temp);

            Matrix actual;
            actual = Matrix.Shadow(light, plane);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ShadowByRefTest()
        {
            Vector4 light = Utilities.GenerateVector4();
            Vector4 lightExpected = light;
            Plane plane = Utilities.GeneratePlane();
            plane.Normalize();
            Plane planeExpected = plane;
            Matrix result;

            Microsoft.DirectX.Matrix temp = new Microsoft.DirectX.Matrix();
            temp.Shadow(Utilities.ConvertToMdx(light), Utilities.ConvertToMdx(plane));
            Matrix resultExpected = Utilities.ConvertFrom(temp);

            Matrix.Shadow(ref light, ref plane, out result);
            Utilities.AreEqual(lightExpected, light);
            Utilities.AreEqual(planeExpected, plane);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void SmoothStepTest()
        {
            Matrix start = Utilities.GenerateMatrix();
            Matrix end = Utilities.GenerateMatrix();
            float amount = Utilities.GenerateFloat();

            Matrix result = Matrix.SmoothStep(start, end, amount);

            Vector4 row1result = Vector4.SmoothStep(start.Row1, end.Row1, amount);
            Vector4 row2result = Vector4.SmoothStep(start.Row2, end.Row2, amount);
            Vector4 row3result = Vector4.SmoothStep(start.Row3, end.Row3, amount);
            Vector4 row4result = Vector4.SmoothStep(start.Row4, end.Row4, amount);

            Utilities.AreEqual(row1result, result.Row1);
            Utilities.AreEqual(row2result, result.Row2);
            Utilities.AreEqual(row3result, result.Row3);
            Utilities.AreEqual(row4result, result.Row4);
        }

        [TestMethod()]
        public void SmoothStepByRefTest()
        {
            Matrix start = Utilities.GenerateMatrix();
            Matrix startExpected = start;
            Matrix end = Utilities.GenerateMatrix();
            Matrix endExpected = end;
            float amount = Utilities.GenerateFloat();

            Matrix result;
            Matrix.SmoothStep(ref start, ref end, amount, out result);

            Utilities.AreEqual(startExpected, start);
            Utilities.AreEqual(endExpected, end);

            Vector4 row1result = Vector4.SmoothStep(start.Row1, end.Row1, amount);
            Vector4 row2result = Vector4.SmoothStep(start.Row2, end.Row2, amount);
            Vector4 row3result = Vector4.SmoothStep(start.Row3, end.Row3, amount);
            Vector4 row4result = Vector4.SmoothStep(start.Row4, end.Row4, amount);

            Utilities.AreEqual(row1result, result.Row1);
            Utilities.AreEqual(row2result, result.Row2);
            Utilities.AreEqual(row3result, result.Row3);
            Utilities.AreEqual(row4result, result.Row4);
        }

        [TestMethod()]
        public void SubtractTest()
        {
            Matrix left = Utilities.GenerateMatrix();
            Matrix right = Utilities.GenerateMatrix();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Subtract(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Matrix actual;
            actual = Matrix.Subtract(left, right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SubtractByRefTest()
        {
            Matrix left = Utilities.GenerateMatrix();
            Matrix leftExpected = left;
            Matrix right = Utilities.GenerateMatrix();
            Matrix rightExpected = right;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Subtract(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Matrix.Subtract(ref left, ref right, out result);
            Utilities.AreEqual(leftExpected, left);
            Utilities.AreEqual(rightExpected, right);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void ToArrayTest()
        {
            Matrix target = Utilities.GenerateMatrix();
            float[] expected =
            {
                target.M11, target.M12, target.M13, target.M14,
                target.M21, target.M22, target.M23, target.M24,
                target.M31, target.M32, target.M33, target.M34,
                target.M41, target.M42, target.M43, target.M44
            };
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
        public void TransformationTest()
        {
            Vector3 scalingCenter = Utilities.GenerateVector3();
            Quaternion scalingRotation = Utilities.GenerateQuaternion();
            Vector3 scaling = Utilities.GenerateVector3();
            Vector3 rotationCenter = Utilities.GenerateVector3();
            Quaternion rotation = Utilities.GenerateQuaternion();
            Vector3 translation = Utilities.GenerateVector3();

            Matrix expected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.Transformation(
                Utilities.ConvertToMdx(scalingCenter),
                Utilities.ConvertToMdx(scalingRotation),
                Utilities.ConvertToMdx(scaling),
                Utilities.ConvertToMdx(rotationCenter),
                Utilities.ConvertToMdx(rotation),
                Utilities.ConvertToMdx(translation)));

            Matrix actual;
            actual = Matrix.Transformation(scalingCenter, scalingRotation, scaling, rotationCenter, rotation, translation);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TransformationByRefTest()
        {
            Vector3 scalingCenter = Utilities.GenerateVector3();
            Vector3 scalingCenterExpected = scalingCenter;
            Quaternion scalingRotation = Utilities.GenerateQuaternion();
            Quaternion scalingRotationExpected = scalingRotation;
            Vector3 scaling = Utilities.GenerateVector3();
            Vector3 scalingExpected = scaling;
            Vector3 rotationCenter = Utilities.GenerateVector3();
            Vector3 rotationCenterExpected = rotationCenter;
            Quaternion rotation = Utilities.GenerateQuaternion();
            Quaternion rotationExpected = rotation;
            Vector3 translation = Utilities.GenerateVector3();
            Vector3 translationExpected = translation;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.Transformation(
                Utilities.ConvertToMdx(scalingCenter),
                Utilities.ConvertToMdx(scalingRotation),
                Utilities.ConvertToMdx(scaling),
                Utilities.ConvertToMdx(rotationCenter),
                Utilities.ConvertToMdx(rotation),
                Utilities.ConvertToMdx(translation)));

            Matrix.Transformation(ref scalingCenter, ref scalingRotation, ref scaling, ref rotationCenter, ref rotation, ref translation, out result);
            Utilities.AreEqual(scalingCenterExpected, scalingCenter);
            Utilities.AreEqual(scalingRotationExpected, scalingRotation);
            Utilities.AreEqual(scalingExpected, scaling);
            Utilities.AreEqual(rotationCenterExpected, rotationCenter);
            Utilities.AreEqual(rotationExpected, rotation);
            Utilities.AreEqual(translationExpected, translation);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void Transformation2DTest()
        {
            Vector2 scalingCenter = Utilities.GenerateVector2();
            float scalingRotation = Utilities.GenerateFloat();
            Vector2 scaling = Utilities.GenerateVector2();
            Vector2 rotationCenter = Utilities.GenerateVector2();
            float rotation = Utilities.GenerateFloat();
            Vector2 translation = Utilities.GenerateVector2();

            Matrix expected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.Transformation2D(
                Utilities.ConvertToMdx(scalingCenter),
                scalingRotation,
                Utilities.ConvertToMdx(scaling),
                Utilities.ConvertToMdx(rotationCenter),
                rotation,
                Utilities.ConvertToMdx(translation)));

            Matrix actual;
            actual = Matrix.Transformation2D(scalingCenter, scalingRotation, scaling, rotationCenter, rotation, translation);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Transformation2DByRefTest()
        {
            Vector2 scalingCenter = Utilities.GenerateVector2();
            Vector2 scalingCenterExpected = scalingCenter;
            float scalingRotation = Utilities.GenerateFloat();
            Vector2 scaling = Utilities.GenerateVector2();
            Vector2 scalingExpected = scaling;
            Vector2 rotationCenter = Utilities.GenerateVector2();
            Vector2 rotationCenterExpected = rotationCenter;
            float rotation = Utilities.GenerateFloat();
            Vector2 translation = Utilities.GenerateVector2();
            Vector2 translationExpected = translation;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.DirectX.Matrix.Transformation2D(
                Utilities.ConvertToMdx(scalingCenter),
                scalingRotation,
                Utilities.ConvertToMdx(scaling),
                Utilities.ConvertToMdx(rotationCenter),
                rotation,
                Utilities.ConvertToMdx(translation)));

            Matrix.Transformation2D(ref scalingCenter, scalingRotation, ref scaling, ref rotationCenter, rotation, ref translation, out result);
            Utilities.AreEqual(scalingCenterExpected, scalingCenter);
            Utilities.AreEqual(scalingExpected, scaling);
            Utilities.AreEqual(rotationCenterExpected, rotationCenter);
            Utilities.AreEqual(translationExpected, translation);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void TranslationTest()
        {
            Vector3 value = Utilities.GenerateVector3();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateTranslation(
                Utilities.ConvertToXna(value)));

            Matrix actual;
            actual = Matrix.Translation(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TranslationByRefTest()
        {
            Vector3 value = Utilities.GenerateVector3();
            Vector3 valueExpected = value;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateTranslation(
                Utilities.ConvertToXna(value)));

            Matrix.Translation(ref value, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void TranslationScalarsTest()
        {
            float x = Utilities.GenerateFloat();
            float y = Utilities.GenerateFloat();
            float z = Utilities.GenerateFloat();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateTranslation(
                x,
                y,
                z));

            Matrix actual;
            actual = Matrix.Translation(x, y, z);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TranslationScalarsByRefTest()
        {
            float x = Utilities.GenerateFloat();
            float y = Utilities.GenerateFloat();
            float z = Utilities.GenerateFloat();
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.CreateTranslation(
                x,
                y,
                z));

            Matrix.Translation(x, y, z, out result);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void TranposeTest()
        {
            Matrix target = Utilities.GenerateMatrix();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Transpose(
                Utilities.ConvertToXna(target)));

            Matrix actual;
            actual = Matrix.Transpose(target);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TransposeTest1()
        {
            Matrix value = Utilities.GenerateMatrix();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Transpose(
                Utilities.ConvertToXna(value)));

            Matrix actual;
            actual = Matrix.Transpose(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TransposeByRefTest()
        {
            Matrix value = Utilities.GenerateMatrix();
            Matrix valueExpected = value;
            Matrix result;

            Matrix resultExpected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Transpose(
                Utilities.ConvertToXna(value)));

            Matrix.Transpose(ref value, out result);
            Utilities.AreEqual(valueExpected, value);
            Utilities.AreEqual(resultExpected, result);
        }

        [TestMethod()]
        public void UpperTriangularFormTest()
        {
            Matrix target = Utilities.GenerateMatrix();

            Matrix result = Matrix.UpperTriangularForm(target);

            //Strict lower left triangle should all be zero.
            Utilities.AreEqual(0f, result.M21);
            Utilities.AreEqual(0f, result.M31);
            Utilities.AreEqual(0f, result.M32);
            Utilities.AreEqual(0f, result.M41);
            Utilities.AreEqual(0f, result.M42);
            Utilities.AreEqual(0f, result.M43);
        }

        [TestMethod()]
        public void UpperTriangularFormByRefTest()
        {
            Matrix target = Utilities.GenerateMatrix();
            Matrix targetExpected = target;

            Matrix result = Matrix.UpperTriangularForm(target);

            Utilities.AreEqual(targetExpected, target);

            //Strict lower left triangle should all be zero.
            Utilities.AreEqual(0f, result.M21);
            Utilities.AreEqual(0f, result.M31);
            Utilities.AreEqual(0f, result.M32);
            Utilities.AreEqual(0f, result.M41);
            Utilities.AreEqual(0f, result.M42);
            Utilities.AreEqual(0f, result.M43);
        }

        [TestMethod()]
        public void op_AdditionTest()
        {
            Matrix left = Utilities.GenerateMatrix();
            Matrix right = Utilities.GenerateMatrix();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Add(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Matrix actual;
            actual = (left + right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_DivisionTest()
        {
            Matrix left = Utilities.GenerateMatrix();
            Matrix right = Utilities.GenerateMatrix();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Divide(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Matrix actual;
            actual = (left / right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_DivisionTest1()
        {
            Matrix left = Utilities.GenerateMatrix();
            float right = Utilities.GenerateFloat();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Divide(
                Utilities.ConvertToXna(left),
                right));

            Matrix actual;
            actual = (left / right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_EqualityTest()
        {
            Matrix target = Utilities.GenerateMatrix();
            Matrix other = target;
            other.M11 += 1f; other.M12 -= 2f; other.M13 += 3f; other.M14 += 1f;
            other.M21 -= 1f; other.M22 += 1f; other.M23 += 1f; other.M24 -= 1f;
            other.M31 += 3f; other.M32 -= 1f; other.M33 += 1.5f; other.M34 -= 2f;
            other.M41 += 2f; other.M42 -= 2f; other.M43 -= 1f; other.M44 += 2f;
            bool expected = false;
            bool actual;
            actual = target == other;
            Utilities.AreEqual(expected, actual);

            target = Utilities.GenerateMatrix();
            other = target;
            expected = true;
            actual = target == other;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_InequalityTest()
        {
            Matrix target = Utilities.GenerateMatrix();
            Matrix other = target;
            other.M11 += 1f; other.M12 -= 2f; other.M13 += 3f; other.M14 += 1f;
            other.M21 -= 1f; other.M22 += 1f; other.M23 += 1f; other.M24 -= 1f;
            other.M31 += 3f; other.M32 -= 1f; other.M33 += 1.5f; other.M34 -= 2f;
            other.M41 += 2f; other.M42 -= 2f; other.M43 -= 1f; other.M44 += 2f;
            bool expected = true;
            bool actual;
            actual = target != other;
            Utilities.AreEqual(expected, actual);

            target = Utilities.GenerateMatrix();
            other = target;
            expected = false;
            actual = target != other;
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_MultiplyTest()
        {
            Matrix left = Utilities.GenerateMatrix();
            Matrix right = Utilities.GenerateMatrix();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Multiply(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Matrix actual;
            actual = (left * right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_MultiplyTest1()
        {
            float left = Utilities.GenerateFloat();
            Matrix right = Utilities.GenerateMatrix();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Multiply(
                Utilities.ConvertToXna(right),
                left));

            Matrix actual;
            actual = (left * right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_MultiplyTest2()
        {
            Matrix left = Utilities.GenerateMatrix();
            float right = Utilities.GenerateFloat();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Multiply(
                Utilities.ConvertToXna(left),
                right));

            Matrix actual;
            actual = (left * right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_SubtractionTest()
        {
            Matrix left = Utilities.GenerateMatrix();
            Matrix right = Utilities.GenerateMatrix();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Subtract(
                Utilities.ConvertToXna(left),
                Utilities.ConvertToXna(right)));

            Matrix actual;
            actual = (left - right);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_UnaryNegationTest()
        {
            Matrix value = Utilities.GenerateMatrix();

            Matrix expected = Utilities.ConvertFrom(Microsoft.Xna.Framework.Matrix.Negate(
                Utilities.ConvertToXna(value)));

            Matrix actual;
            actual = -(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void op_UnaryPlusTest()
        {
            Matrix value = Utilities.GenerateMatrix();

            Matrix expected = value;

            Matrix actual;
            actual = +(value);
            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Row1Test()
        {
            Matrix target = Utilities.GenerateMatrix();
            Vector4 actual = target.Row1;
            Vector4 expected = new Vector4()
            {
                X = target.M11,
                Y = target.M12,
                Z = target.M13,
                W = target.M14
            };

            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Row2Test()
        {
            Matrix target = Utilities.GenerateMatrix();
            Vector4 actual = target.Row2;
            Vector4 expected = new Vector4()
            {
                X = target.M21,
                Y = target.M22,
                Z = target.M23,
                W = target.M24
            };

            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Row3Test()
        {
            Matrix target = Utilities.GenerateMatrix();
            Vector4 actual = target.Row3;
            Vector4 expected = new Vector4()
            {
                X = target.M31,
                Y = target.M32,
                Z = target.M33,
                W = target.M34
            };

            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Row4Test()
        {
            Matrix target = Utilities.GenerateMatrix();
            Vector4 actual = target.Row4;
            Vector4 expected = new Vector4()
            {
                X = target.M41,
                Y = target.M42,
                Z = target.M43,
                W = target.M44
            };

            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Column1Test()
        {
            Matrix target = Utilities.GenerateMatrix();
            Vector4 actual = target.Column1;
            Vector4 expected = new Vector4()
            {
                X = target.M11,
                Y = target.M21,
                Z = target.M31,
                W = target.M41
            };

            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Column2Test()
        {
            Matrix target = Utilities.GenerateMatrix();
            Vector4 actual = target.Column2;
            Vector4 expected = new Vector4()
            {
                X = target.M12,
                Y = target.M22,
                Z = target.M32,
                W = target.M42
            };

            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Column3Test()
        {
            Matrix target = Utilities.GenerateMatrix();
            Vector4 actual = target.Column3;
            Vector4 expected = new Vector4()
            {
                X = target.M13,
                Y = target.M23,
                Z = target.M33,
                W = target.M43
            };

            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Column4Test()
        {
            Matrix target = Utilities.GenerateMatrix();
            Vector4 actual = target.Column4;
            Vector4 expected = new Vector4()
            {
                X = target.M14,
                Y = target.M24,
                Z = target.M34,
                W = target.M44
            };

            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TranslationVectorTest()
        {
            Matrix target = Utilities.GenerateMatrix();
            Vector3 actual = target.TranslationVector;
            Vector3 expected = new Vector3()
            {
                X = target.M41,
                Y = target.M42,
                Z = target.M43
            };

            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ScaleVectorTest()
        {
            Matrix target = Utilities.GenerateMatrix();
            Vector3 actual = target.ScaleVector;
            Vector3 expected = new Vector3()
            {
                X = target.M11,
                Y = target.M22,
                Z = target.M33
            };

            Utilities.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsIdentityTest()
        {
            Matrix target = Utilities.GenerateMatrix();
            Utilities.AreNotEqual(Matrix.Identity, target);
            Utilities.AreEqual(Matrix.Identity, Matrix.Identity);
        }

        [TestMethod()]
        public void ItemTest()
        {
            Matrix target = Utilities.GenerateMatrix();
            int row = 0; // TODO: Initialize to an appropriate value
            int column = 0; // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target[row, column] = expected;
            actual = target[row, column];
            Utilities.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void ItemTest1()
        {
            Matrix target = Utilities.GenerateMatrix();
            int index = 0; // TODO: Initialize to an appropriate value
            float expected = 0F; // TODO: Initialize to an appropriate value
            float actual;
            target[index] = expected;
            actual = target[index];
            Utilities.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
