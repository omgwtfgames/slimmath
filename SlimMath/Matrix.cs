using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Globalization;

namespace SlimMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Matrix : IEquatable<Matrix>
    {
        public float M11;
        public float M12;
        public float M13;
        public float M14;
        public float M21;
        public float M22;
        public float M23;
        public float M24;
        public float M31;
        public float M32;
        public float M33;
        public float M34;
        public float M41;
        public float M42;
        public float M43;
        public float M44;

        [Browsable(false)]
        public float this[int row, int column]
        {
            get
            {
                if (row < 0 || row > 3)
                    throw new ArgumentOutOfRangeException("row", "Rows and columns for matrices run from 0 to 3, inclusive.");
                if (column < 0 || column > 3)
                    throw new ArgumentOutOfRangeException("column", "Rows and columns for matrices run from 0 to 3, inclusive.");

                switch ((row * 4) + column)
                {
                    case 0: return M11;
                    case 1: return M12;
                    case 2: return M13;
                    case 3: return M14;
                    case 4: return M21;
                    case 5: return M22;
                    case 6: return M23;
                    case 7: return M24;
                    case 8: return M31;
                    case 9: return M32;
                    case 10: return M33;
                    case 11: return M34;
                    case 12: return M41;
                    case 13: return M42;
                    case 14: return M43;
                    case 15: return M44;
                }

                return 0.0f;
            }

            set
            {
                if (row < 0 || row > 3)
                    throw new ArgumentOutOfRangeException("row", "Rows and columns for matrices run from 0 to 3, inclusive.");
                if (column < 0 || column > 3)
                    throw new ArgumentOutOfRangeException("column", "Rows and columns for matrices run from 0 to 3, inclusive.");

                switch ((row * 4) + column)
                {
                    case 0:
                        M11 = value;
                        break;

                    case 1:
                        M12 = value;
                        break;

                    case 2:
                        M13 = value;
                        break;

                    case 3:
                        M14 = value;
                        break;

                    case 4:
                        M21 = value;
                        break;

                    case 5:
                        M22 = value;
                        break;

                    case 6:
                        M23 = value;
                        break;

                    case 7:
                        M24 = value;
                        break;

                    case 8:
                        M31 = value;
                        break;

                    case 9:
                        M32 = value;
                        break;

                    case 10:
                        M33 = value;
                        break;

                    case 11:
                        M34 = value;
                        break;

                    case 12:
                        M41 = value;
                        break;

                    case 13:
                        M42 = value;
                        break;

                    case 14:
                        M43 = value;
                        break;

                    case 15:
                        M44 = value;
                        break;
                }
            }
        }

        public static Matrix Identity
        {
            get
            {
                Matrix result = new Matrix();
                result.M11 = 1.0f;
                result.M22 = 1.0f;
                result.M33 = 1.0f;
                result.M44 = 1.0f;
                return result;
            }
        }

        [Browsable(false)]
        public bool IsIdentity
        {
            get
            {
                if (M11 != 1.0f || M22 != 1.0f || M33 != 1.0f || M44 != 1.0f)
                    return false;

                if (M12 != 0.0f || M13 != 0.0f || M14 != 0.0f ||
                    M21 != 0.0f || M23 != 0.0f || M24 != 0.0f ||
                    M31 != 0.0f || M32 != 0.0f || M34 != 0.0f ||
                    M41 != 0.0f || M42 != 0.0f || M43 != 0.0f)
                    return false;

                return true;
            }
        }

        public float[] ToArray()
        {
            return new[] { M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, M41, M42, M43, M44 };
        }

        public static void Invert(ref Matrix matrix, out Matrix result)
        {
            Matrix m = matrix;
            result = m;
            result.Invert();
        }

        public static Matrix Invert(Matrix matrix)
        {
            matrix.Invert();
            return matrix;
        }

        public void Invert()
        {
        }

        //public bool Decompose(out Vector3 scale, out Quaternion rotation, out Vector3 translation)
        //{
        //}

        public float Determinant()
        {
            float temp1 = (M33 * M44) - (M34 * M43);
            float temp2 = (M32 * M44) - (M34 * M42);
            float temp3 = (M32 * M43) - (M33 * M42);
            float temp4 = (M31 * M44) - (M34 * M41);
            float temp5 = (M31 * M43) - (M33 * M41);
            float temp6 = (M31 * M42) - (M32 * M41);

            return ((((M11 * (((M22 * temp1) - (M23 * temp2)) + (M24 * temp3))) - (M12 * (((M21 * temp1) -
                (M23 * temp4)) + (M24 * temp5)))) + (M13 * (((M21 * temp2) - (M22 * temp4)) + (M24 * temp6)))) -
                (M14 * (((M21 * temp3) - (M22 * temp5)) + (M23 * temp6))));
        }

        public static void Add(ref Matrix left, ref Matrix right, out Matrix result)
        {
            result.M11 = left.M11 + right.M11;
            result.M12 = left.M12 + right.M12;
            result.M13 = left.M13 + right.M13;
            result.M14 = left.M14 + right.M14;
            result.M21 = left.M21 + right.M21;
            result.M22 = left.M22 + right.M22;
            result.M23 = left.M23 + right.M23;
            result.M24 = left.M24 + right.M24;
            result.M31 = left.M31 + right.M31;
            result.M32 = left.M32 + right.M32;
            result.M33 = left.M33 + right.M33;
            result.M34 = left.M34 + right.M34;
            result.M41 = left.M41 + right.M41;
            result.M42 = left.M42 + right.M42;
            result.M43 = left.M43 + right.M43;
            result.M44 = left.M44 + right.M44;
        }

        public static Matrix Add(Matrix left, Matrix right)
        {
            Matrix result;
            Add(ref left, ref right, out result);
            return result;
        }

        public static void Subtract(ref Matrix left, ref Matrix right, out Matrix result)
        {
            result.M11 = left.M11 - right.M11;
            result.M12 = left.M12 - right.M12;
            result.M13 = left.M13 - right.M13;
            result.M14 = left.M14 - right.M14;
            result.M21 = left.M21 - right.M21;
            result.M22 = left.M22 - right.M22;
            result.M23 = left.M23 - right.M23;
            result.M24 = left.M24 - right.M24;
            result.M31 = left.M31 - right.M31;
            result.M32 = left.M32 - right.M32;
            result.M33 = left.M33 - right.M33;
            result.M34 = left.M34 - right.M34;
            result.M41 = left.M41 - right.M41;
            result.M42 = left.M42 - right.M42;
            result.M43 = left.M43 - right.M43;
            result.M44 = left.M44 - right.M44;
        }

        public static Matrix Subtract(Matrix left, Matrix right)
        {
            Matrix result;
            Subtract(ref left, ref right, out result);
            return result;
        }

        public static void Multiply(ref Matrix left, float right, out Matrix result)
        {
            result.M11 = left.M11 * right;
            result.M12 = left.M12 * right;
            result.M13 = left.M13 * right;
            result.M14 = left.M14 * right;
            result.M21 = left.M21 * right;
            result.M22 = left.M22 * right;
            result.M23 = left.M23 * right;
            result.M24 = left.M24 * right;
            result.M31 = left.M31 * right;
            result.M32 = left.M32 * right;
            result.M33 = left.M33 * right;
            result.M34 = left.M34 * right;
            result.M41 = left.M41 * right;
            result.M42 = left.M42 * right;
            result.M43 = left.M43 * right;
            result.M44 = left.M44 * right;
        }

        public static Matrix Multiply(Matrix left, float right)
        {
            Matrix result;
            Multiply(ref left, right, out result);
            return result;
        }

        public static void Multiply(ref Matrix left, ref Matrix right, out Matrix result)
        {
            result.M11 = (left.M11 * right.M11) + (left.M12 * right.M21) + (left.M13 * right.M31) + (left.M14 * right.M41);
            result.M12 = (left.M11 * right.M12) + (left.M12 * right.M22) + (left.M13 * right.M32) + (left.M14 * right.M42);
            result.M13 = (left.M11 * right.M13) + (left.M12 * right.M23) + (left.M13 * right.M33) + (left.M14 * right.M43);
            result.M14 = (left.M11 * right.M14) + (left.M12 * right.M24) + (left.M13 * right.M34) + (left.M14 * right.M44);
            result.M21 = (left.M21 * right.M11) + (left.M22 * right.M21) + (left.M23 * right.M31) + (left.M24 * right.M41);
            result.M22 = (left.M21 * right.M12) + (left.M22 * right.M22) + (left.M23 * right.M32) + (left.M24 * right.M42);
            result.M23 = (left.M21 * right.M13) + (left.M22 * right.M23) + (left.M23 * right.M33) + (left.M24 * right.M43);
            result.M24 = (left.M21 * right.M14) + (left.M22 * right.M24) + (left.M23 * right.M34) + (left.M24 * right.M44);
            result.M31 = (left.M31 * right.M11) + (left.M32 * right.M21) + (left.M33 * right.M31) + (left.M34 * right.M41);
            result.M32 = (left.M31 * right.M12) + (left.M32 * right.M22) + (left.M33 * right.M32) + (left.M34 * right.M42);
            result.M33 = (left.M31 * right.M13) + (left.M32 * right.M23) + (left.M33 * right.M33) + (left.M34 * right.M43);
            result.M34 = (left.M31 * right.M14) + (left.M32 * right.M24) + (left.M33 * right.M34) + (left.M34 * right.M44);
            result.M41 = (left.M41 * right.M11) + (left.M42 * right.M21) + (left.M43 * right.M31) + (left.M44 * right.M41);
            result.M42 = (left.M41 * right.M12) + (left.M42 * right.M22) + (left.M43 * right.M32) + (left.M44 * right.M42);
            result.M43 = (left.M41 * right.M13) + (left.M42 * right.M23) + (left.M43 * right.M33) + (left.M44 * right.M43);
            result.M44 = (left.M41 * right.M14) + (left.M42 * right.M24) + (left.M43 * right.M34) + (left.M44 * right.M44);
        }

        public static Matrix Multiply(Matrix left, Matrix right)
        {
            Matrix result;
            Multiply(ref left, ref right, out result);
            return result;
        }

        public static void Divide(ref Matrix left, float right, out Matrix result)
        {
            float inv = 1.0f / right;

            result.M11 = left.M11 * inv;
            result.M12 = left.M12 * inv;
            result.M13 = left.M13 * inv;
            result.M14 = left.M14 * inv;
            result.M21 = left.M21 * inv;
            result.M22 = left.M22 * inv;
            result.M23 = left.M23 * inv;
            result.M24 = left.M24 * inv;
            result.M31 = left.M31 * inv;
            result.M32 = left.M32 * inv;
            result.M33 = left.M33 * inv;
            result.M34 = left.M34 * inv;
            result.M41 = left.M41 * inv;
            result.M42 = left.M42 * inv;
            result.M43 = left.M43 * inv;
            result.M44 = left.M44 * inv;
        }

        public static Matrix Divide(Matrix left, float right)
        {
            Matrix result;
            Divide(ref left, right, out result);
            return result;
        }

        public static void Divide(ref Matrix left, ref Matrix right, out Matrix result)
        {
            result.M11 = left.M11 / right.M11;
            result.M12 = left.M12 / right.M12;
            result.M13 = left.M13 / right.M13;
            result.M14 = left.M14 / right.M14;
            result.M21 = left.M21 / right.M21;
            result.M22 = left.M22 / right.M22;
            result.M23 = left.M23 / right.M23;
            result.M24 = left.M24 / right.M24;
            result.M31 = left.M31 / right.M31;
            result.M32 = left.M32 / right.M32;
            result.M33 = left.M33 / right.M33;
            result.M34 = left.M34 / right.M34;
            result.M41 = left.M41 / right.M41;
            result.M42 = left.M42 / right.M42;
            result.M43 = left.M43 / right.M43;
            result.M44 = left.M44 / right.M44;
        }

        public static Matrix Divide(Matrix left, Matrix right)
        {
            Matrix result;
            Divide(ref left, ref right, out result);
            return result;
        }

        public static void Negate(ref Matrix matrix, out Matrix result)
        {
            result.M11 = -matrix.M11;
            result.M12 = -matrix.M12;
            result.M13 = -matrix.M13;
            result.M14 = -matrix.M14;
            result.M21 = -matrix.M21;
            result.M22 = -matrix.M22;
            result.M23 = -matrix.M23;
            result.M24 = -matrix.M24;
            result.M31 = -matrix.M31;
            result.M32 = -matrix.M32;
            result.M33 = -matrix.M33;
            result.M34 = -matrix.M34;
            result.M41 = -matrix.M41;
            result.M42 = -matrix.M42;
            result.M43 = -matrix.M43;
            result.M44 = -matrix.M44;
        }

        public static Matrix Negate(Matrix matrix)
        {
            Matrix result;
            Negate(ref matrix, out result);
            return result;
        }

        public static void Lerp(ref Matrix start, ref Matrix end, float amount, out Matrix result)
        {
            result.M11 = start.M11 + ((end.M11 - start.M11) * amount);
            result.M12 = start.M12 + ((end.M12 - start.M12) * amount);
            result.M13 = start.M13 + ((end.M13 - start.M13) * amount);
            result.M14 = start.M14 + ((end.M14 - start.M14) * amount);
            result.M21 = start.M21 + ((end.M21 - start.M21) * amount);
            result.M22 = start.M22 + ((end.M22 - start.M22) * amount);
            result.M23 = start.M23 + ((end.M23 - start.M23) * amount);
            result.M24 = start.M24 + ((end.M24 - start.M24) * amount);
            result.M31 = start.M31 + ((end.M31 - start.M31) * amount);
            result.M32 = start.M32 + ((end.M32 - start.M32) * amount);
            result.M33 = start.M33 + ((end.M33 - start.M33) * amount);
            result.M34 = start.M34 + ((end.M34 - start.M34) * amount);
            result.M41 = start.M41 + ((end.M41 - start.M41) * amount);
            result.M42 = start.M42 + ((end.M42 - start.M42) * amount);
            result.M43 = start.M43 + ((end.M43 - start.M43) * amount);
            result.M44 = start.M44 + ((end.M44 - start.M44) * amount);
        }

        public static Matrix Lerp(Matrix start, Matrix end, float amount)
        {
            Matrix result;
            Lerp(ref start, ref end, amount, out result);
            return result;
        }

        public static void Billboard(ref Vector3 objectPosition, ref Vector3 cameraPosition, ref Vector3 cameraUpVector, ref Vector3 cameraForwardVector, out Matrix result)
        {
            Vector3 crossed;
            Vector3 final;
            Vector3 difference = objectPosition - cameraPosition;

            float lengthSq = difference.LengthSquared();
            if (lengthSq < 0.0001f)
                difference = -cameraForwardVector;
            else
                difference *= (float)(1.0 / Math.Sqrt(lengthSq));

            Vector3.Cross(ref cameraUpVector, ref difference, out crossed);
            crossed.Normalize();
            Vector3.Cross(ref difference, ref crossed, out final);

            result.M11 = final.X;
            result.M12 = final.Y;
            result.M13 = final.Z;
            result.M14 = 0.0f;
            result.M21 = crossed.X;
            result.M22 = crossed.Y;
            result.M23 = crossed.Z;
            result.M24 = 0.0f;
            result.M31 = difference.X;
            result.M32 = difference.Y;
            result.M33 = difference.Z;
            result.M34 = 0.0f;
            result.M41 = objectPosition.X;
            result.M42 = objectPosition.Y;
            result.M43 = objectPosition.Z;
            result.M44 = 1.0f;
        }

        public static Matrix Billboard(Vector3 objectPosition, Vector3 cameraPosition, Vector3 cameraUpVector, Vector3 cameraForwardVector)
        {
            Matrix result;
            Billboard(ref objectPosition, ref cameraPosition, ref cameraUpVector, ref cameraForwardVector, out result);
            return result;
        }

        public static void RotationX(float angle, out Matrix result)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            result.M11 = 1.0f;
            result.M12 = 0.0f;
            result.M13 = 0.0f;
            result.M14 = 0.0f;
            result.M21 = 0.0f;
            result.M22 = cos;
            result.M23 = sin;
            result.M24 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = -sin;
            result.M33 = cos;
            result.M34 = 0.0f;
            result.M41 = 0.0f;
            result.M42 = 0.0f;
            result.M43 = 0.0f;
            result.M44 = 1.0f;
        }

        public static Matrix RotationX(float angle)
        {
            Matrix result;
            RotationX(angle, out result);
            return result;
        }

        public static void RotationY(float angle, out Matrix result)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            result.M11 = cos;
            result.M12 = 0.0f;
            result.M13 = -sin;
            result.M14 = 0.0f;
            result.M21 = 0.0f;
            result.M22 = 1.0f;
            result.M23 = 0.0f;
            result.M24 = 0.0f;
            result.M31 = sin;
            result.M32 = 0.0f;
            result.M33 = cos;
            result.M34 = 0.0f;
            result.M41 = 0.0f;
            result.M42 = 0.0f;
            result.M43 = 0.0f;
            result.M44 = 1.0f;
        }

        public static Matrix RotationY(float angle)
        {
            Matrix result;
            RotationY(angle, out result);
            return result;
        }

        public static void RotationZ(float angle, out Matrix result)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            result.M11 = cos;
            result.M12 = sin;
            result.M13 = 0.0f;
            result.M14 = 0.0f;
            result.M21 = -sin;
            result.M22 = cos;
            result.M23 = 0.0f;
            result.M24 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = 0.0f;
            result.M33 = 1.0f;
            result.M34 = 0.0f;
            result.M41 = 0.0f;
            result.M42 = 0.0f;
            result.M43 = 0.0f;
            result.M44 = 1.0f;
        }

        public static Matrix RotationZ(float angle)
        {
            Matrix result;
            RotationZ(angle, out result);
            return result;
        }

        public static void RotationAxis(ref Vector3 axis, float angle, out Matrix result)
        {
            if (axis.LengthSquared() != 1.0f)
                axis.Normalize();

            float x = axis.X;
            float y = axis.Y;
            float z = axis.Z;
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);
            float xx = x * x;
            float yy = y * y;
            float zz = z * z;
            float xy = x * y;
            float xz = x * z;
            float yz = y * z;

            result.M11 = xx + (cos * (1.0f - xx));
            result.M12 = (xy - (cos * xy)) + (sin * z);
            result.M13 = (xz - (cos * xz)) - (sin * y);
            result.M14 = 0.0f;
            result.M21 = (xy - (cos * xy)) - (sin * z);
            result.M22 = yy + (cos * (1.0f - yy));
            result.M23 = (yz - (cos * yz)) + (sin * x);
            result.M24 = 0.0f;
            result.M31 = (xz - (cos * xz)) + (sin * y);
            result.M32 = (yz - (cos * yz)) - (sin * x);
            result.M33 = zz + (cos * (1.0f - zz));
            result.M34 = 0.0f;
            result.M41 = 0.0f;
            result.M42 = 0.0f;
            result.M43 = 0.0f;
            result.M44 = 1.0f;
        }

        public static Matrix RotationAxis(Vector3 axis, float angle)
        {
            Matrix result;
            RotationAxis(ref axis, angle, out result);
            return result;
        }

        public static void RotationQuaternion(ref Quaternion rotation, out Matrix result)
        {
            float xx = rotation.X * rotation.X;
            float yy = rotation.Y * rotation.Y;
            float zz = rotation.Z * rotation.Z;
            float xy = rotation.X * rotation.Y;
            float zw = rotation.Z * rotation.W;
            float zx = rotation.Z * rotation.X;
            float yw = rotation.Y * rotation.W;
            float yz = rotation.Y * rotation.Z;
            float xw = rotation.X * rotation.W;

            result.M11 = 1.0f - (2.0f * (yy + zz));
            result.M12 = 2.0f * (xy + zw);
            result.M13 = 2.0f * (zx - yw);
            result.M14 = 0.0f;
            result.M21 = 2.0f * (xy - zw);
            result.M22 = 1.0f - (2.0f * (zz + xx));
            result.M23 = 2.0f * (yz + xw);
            result.M24 = 0.0f;
            result.M31 = 2.0f * (zx + yw);
            result.M32 = 2.0f * (yz - xw);
            result.M33 = 1.0f - (2.0f * (yy + xx));
            result.M34 = 0.0f;
            result.M41 = 0.0f;
            result.M42 = 0.0f;
            result.M43 = 0.0f;
            result.M44 = 1.0f;
        }

        public static Matrix RotationQuaternion(Quaternion rotation)
        {
            Matrix result;
            RotationQuaternion(ref rotation, out result);
            return result;
        }

        public static void RotationYawPitchRoll(float yaw, float pitch, float roll, out Matrix result)
        {
            Quaternion quaternion = new Quaternion();
            Quaternion.RotationYawPitchRoll(yaw, pitch, roll, out quaternion);
            RotationQuaternion(ref quaternion, out result);
        }

        public static Matrix RotationYawPitchRoll(float yaw, float pitch, float roll)
        {
            Matrix result;
            RotationYawPitchRoll(yaw, pitch, roll, out result);
            return result;
        }

        //public static void LookAtLH(ref Vector3 eye, ref Vector3 target, ref Vector3 up, out Matrix result)
        //{
        //}

        //public static Matrix LookAtLH(Vector3 eye, Vector3 target, Vector3 up)
        //{
        //}

        //public static void LookAtRH(ref Vector3 eye, ref Vector3 target, ref Vector3 up, out Matrix result)
        //{
        //}

        //public static Matrix LookAtRH(Vector3 eye, Vector3 target, Vector3 up)
        //{
        //}

        //public static void OrthoLH(float width, float height, float znear, float zfar, out Matrix result)
        //{
        //}

        //public static Matrix OrthoLH(float width, float height, float znear, float zfar)
        //{
        //}

        //public static void OrthoRH(float width, float height, float znear, float zfar, out Matrix result)
        //{
        //}

        //public static Matrix OrthoRH(float width, float height, float znear, float zfar)
        //{
        //}

        //public static void OrthoOffCenterLH(float left, float right, float bottom, float top, float znear, float zfar, out Matrix result)
        //{
        //}

        //public static Matrix OrthoOffCenterLH(float left, float right, float bottom, float top, float znear, float zfar)
        //{
        //}

        //public static void OrthoOffCenterRH(float left, float right, float bottom, float top, float znear, float zfar, out Matrix result)
        //{
        //}

        //public static Matrix OrthoOffCenterRH(float left, float right, float bottom, float top, float znear, float zfar)
        //{
        //}

        //public static void PerspectiveLH(float width, float height, float znear, float zfar, out Matrix result)
        //{
        //}

        //public static Matrix PerspectiveLH(float width, float height, float znear, float zfar)
        //{
        //}

        //public static void PerspectiveRH(float width, float height, float znear, float zfar, out Matrix result)
        //{
        //}

        //public static Matrix PerspectiveRH(float width, float height, float znear, float zfar)
        //{
        //}

        //public static void PerspectiveFovLH(float fov, float aspect, float znear, float zfar, out Matrix result)
        //{
        //}

        //public static Matrix PerspectiveFovLH(float fov, float aspect, float znear, float zfar)
        //{
        //}

        //public static void PerspectiveFovRH(float fov, float aspect, float znear, float zfar, out Matrix result)
        //{
        //}

        //public static Matrix PerspectiveFovRH(float fov, float aspect, float znear, float zfar)
        //{
        //}

        //public static void PerspectiveOffCenterLH(float left, float right, float bottom, float top, float znear, float zfar, out Matrix result)
        //{
        //}

        //public static Matrix PerspectiveOffCenterLH(float left, float right, float bottom, float top, float znear, float zfar)
        //{
        //}

        //public static void PerspectiveOffCenterRH(float left, float right, float bottom, float top, float znear, float zfar, out Matrix result)
        //{
        //}

        //public static Matrix PerspectiveOffCenterRH(float left, float right, float bottom, float top, float znear, float zfar)
        //{
        //}

        //public static void Reflection(ref Plane plane, out Matrix result)
        //{
        //    plane.Normalize();

        //    float x = plane.Normal.X;
        //    float y = plane.Normal.Y;
        //    float z = plane.Normal.Z;
        //    float x2 = -2.0f * x;
        //    float y2 = -2.0f * y;
        //    float z2 = -2.0f * z;

        //    result.M11 = (x2 * x) + 1.0f;
        //    result.M12 = y2 * x;
        //    result.M13 = z2 * x;
        //    result.M14 = 0.0f;
        //    result.M21 = x2 * y;
        //    result.M22 = (y2 * y) + 1.0f;
        //    result.M23 = z2 * y;
        //    result.M24 = 0.0f;
        //    result.M31 = x2 * z;
        //    result.M32 = y2 * z;
        //    result.M33 = (z2 * z) + 1.0f;
        //    result.M34 = 0.0f;
        //    result.M41 = x2 * plane.D;
        //    result.M42 = y2 * plane.D;
        //    result.M43 = z2 * plane.D;
        //    result.M44 = 1.0f;
        //}

        //public static Matrix Reflection(Plane plane)
        //{
        //    Matrix result;
        //    Reflection(ref plane, out result);
        //    return result;
        //}

        public static void Scaling(ref Vector3 scale, out Matrix result)
        {
            result.M11 = scale.X;
            result.M12 = 0.0f;
            result.M13 = 0.0f;
            result.M14 = 0.0f;
            result.M21 = 0.0f;
            result.M22 = scale.Y;
            result.M23 = 0.0f;
            result.M24 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = 0.0f;
            result.M33 = scale.Z;
            result.M34 = 0.0f;
            result.M41 = 0.0f;
            result.M42 = 0.0f;
            result.M43 = 0.0f;
            result.M44 = 1.0f;
        }

        public static Matrix Scaling(Vector3 scale)
        {
            Matrix result;
            Scaling(ref scale, out result);
            return result;
        }

        public static void Scaling(float x, float y, float z, out Matrix result)
        {
            result.M11 = x;
            result.M12 = 0.0f;
            result.M13 = 0.0f;
            result.M14 = 0.0f;
            result.M21 = 0.0f;
            result.M22 = y;
            result.M23 = 0.0f;
            result.M24 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = 0.0f;
            result.M33 = z;
            result.M34 = 0.0f;
            result.M41 = 0.0f;
            result.M42 = 0.0f;
            result.M43 = 0.0f;
            result.M44 = 1.0f;
        }

        public static Matrix Scaling(float x, float y, float z)
        {
            Matrix result;
            Scaling(x, y, z, out result);
            return result;
        }

        //public static void Shadow(ref Vector4 light, ref Plane plane, out Matrix result)
        //{
        //    plane.Normalize();

        //    float dot = ((plane.Normal.X * light.X) + (plane.Normal.Y * light.Y)) + (plane.Normal.Z * light.Z);
        //    float x = -plane.Normal.X;
        //    float y = -plane.Normal.Y;
        //    float z = -plane.Normal.Z;
        //    float d = -plane.D;

        //    result.M11 = (x * light.X) + dot;
        //    result.M21 = y * light.X;
        //    result.M31 = z * light.X;
        //    result.M41 = d * light.X;
        //    result.M12 = x * light.Y;
        //    result.M22 = (y * light.Y) + dot;
        //    result.M32 = z * light.Y;
        //    result.M42 = d * light.Y;
        //    result.M13 = x * light.Z;
        //    result.M23 = y * light.Z;
        //    result.M33 = (z * light.Z) + dot;
        //    result.M43 = d * light.Z;
        //    result.M14 = 0.0f;
        //    result.M24 = 0.0f;
        //    result.M34 = 0.0f;
        //    result.M44 = dot;
        //}

        //public static Matrix Shadow(Vector4 light, Plane plane)
        //{
        //    Matrix result;
        //    Shadow(ref light, ref plane, out result);
        //    return result;
        //}

        public static void Translation(ref Vector3 amount, out Matrix result)
        {
            result.M11 = 1.0f;
            result.M12 = 0.0f;
            result.M13 = 0.0f;
            result.M14 = 0.0f;
            result.M21 = 0.0f;
            result.M22 = 1.0f;
            result.M23 = 0.0f;
            result.M24 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = 0.0f;
            result.M33 = 1.0f;
            result.M34 = 0.0f;
            result.M41 = amount.X;
            result.M42 = amount.Y;
            result.M43 = amount.Z;
            result.M44 = 1.0f;
        }

        public static Matrix Translation(Vector3 amount)
        {
            Matrix result;
            Translation(ref amount, out result);
            return result;
        }

        public static void Translation(float x, float y, float z, out Matrix result)
        {
            result.M11 = 1.0f;
            result.M12 = 0.0f;
            result.M13 = 0.0f;
            result.M14 = 0.0f;
            result.M21 = 0.0f;
            result.M22 = 1.0f;
            result.M23 = 0.0f;
            result.M24 = 0.0f;
            result.M31 = 0.0f;
            result.M32 = 0.0f;
            result.M33 = 1.0f;
            result.M34 = 0.0f;
            result.M41 = x;
            result.M42 = y;
            result.M43 = z;
            result.M44 = 1.0f;
        }

        public static Matrix Translation(float x, float y, float z)
        {
            Matrix result;
            Translation(x, y, z, out result);
            return result;
        }

        public static void Transpose(ref Matrix matrix, out Matrix result)
        {
            result.M11 = matrix.M11;
            result.M12 = matrix.M21;
            result.M13 = matrix.M31;
            result.M14 = matrix.M41;
            result.M21 = matrix.M12;
            result.M22 = matrix.M22;
            result.M23 = matrix.M32;
            result.M24 = matrix.M42;
            result.M31 = matrix.M13;
            result.M32 = matrix.M23;
            result.M33 = matrix.M33;
            result.M34 = matrix.M43;
            result.M41 = matrix.M14;
            result.M42 = matrix.M24;
            result.M43 = matrix.M34;
            result.M44 = matrix.M44;
        }

        public static Matrix Transpose(Matrix matrix)
        {
            Matrix result;
            Transpose(ref matrix, out result);
            return result;
        }

        //public static void AffineTransformation(float scaling, ref Vector3 rotationCenter, ref Quaternion rotation, ref Vector3 translation, out Matrix result)
        //{
        //}

        //public static Matrix AffineTransformation(float scaling, Vector3 rotationCenter, Quaternion rotation, Vector3 translation)
        //{
        //}

        //public static void AffineTransformation2D(float scaling, ref Vector2 rotationCenter, float rotation, ref Vector2 translation, out Matrix result)
        //{
        //}

        //public static Matrix AffineTransformation2D(float scaling, Vector2 rotationCenter, float rotation, Vector2 translation)
        //{
        //}

        //public static void Transformation(ref Vector3 scalingCenter, ref Quaternion scalingRotation, ref Vector3 scaling, ref Vector3 rotationCenter, ref Quaternion rotation, ref Vector3 translation, out Matrix result)
        //{
        //}

        //public static Matrix Transformation(Vector3 scalingCenter, Quaternion scalingRotation, Vector3 scaling, Vector3 rotationCenter, Quaternion rotation, Vector3 translation)
        //{
        //}

        //public static void Transformation2D(ref Vector2 scalingCenter, float scalingRotation, ref Vector2 scaling, ref Vector2 rotationCenter, float rotation, ref Vector2 translation, out Matrix result)
        //{
        //}

        //public static Matrix Transformation2D(Vector2 scalingCenter, float scalingRotation, Vector2 scaling, Vector2 rotationCenter, float rotation, Vector2 translation)
        //{
        //}

        public static Matrix operator -(Matrix left, Matrix right)
        {
            Matrix result;
            Subtract(ref left, ref right, out result);
            return result;
        }

        public static Matrix operator -(Matrix matrix)
        {
            Matrix result;
            Negate(ref matrix, out result);
            return result;
        }

        public static Matrix operator +(Matrix left, Matrix right)
        {
            Matrix result;
            Add(ref left, ref right, out result);
            return result;
        }

        public static Matrix operator /(Matrix left, float right)
        {
            Matrix result;
            Divide(ref left, right, out result);
            return result;
        }

        public static Matrix operator /(Matrix left, Matrix right)
        {
            Matrix result;
            Divide(ref left, ref right, out result);
            return result;
        }

        public static Matrix operator *(float left, Matrix right)
        {
            return right * left;
        }

        public static Matrix operator *(Matrix left, float right)
        {
            Matrix result;
            Multiply(ref left, right, out result);
            return result;
        }

        public static Matrix operator *(Matrix left, Matrix right)
        {
            Matrix result;
            Multiply(ref left, ref right, out result);
            return result;
        }

        public static bool operator ==(Matrix left, Matrix right)
        {
            return Equals(ref left, ref right);
        }

        public static bool operator !=(Matrix left, Matrix right)
        {
            return !Equals(ref left, ref right);
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "[[M11:{0} M12:{1} M13:{2} M14:{3}] [M21:{4} M22:{5} M23:{6} M24:{7}] [M31:{8} M32:{9} M33:{10} M34:{11}] [M41:{12} M42:{13} M43:{14} M44:{15}]]", M11.ToString(CultureInfo.CurrentCulture), 
                M12.ToString(CultureInfo.CurrentCulture), M13.ToString(CultureInfo.CurrentCulture), M14.ToString(CultureInfo.CurrentCulture), 
                M21.ToString(CultureInfo.CurrentCulture), M22.ToString(CultureInfo.CurrentCulture), M23.ToString(CultureInfo.CurrentCulture),
                M24.ToString(CultureInfo.CurrentCulture), M31.ToString(CultureInfo.CurrentCulture), M32.ToString(CultureInfo.CurrentCulture), 
                M33.ToString(CultureInfo.CurrentCulture), M34.ToString(CultureInfo.CurrentCulture), M41.ToString(CultureInfo.CurrentCulture), 
                M42.ToString(CultureInfo.CurrentCulture), M43.ToString(CultureInfo.CurrentCulture), M44.ToString(CultureInfo.CurrentCulture));
        }

        public override int GetHashCode()
        {
            return M11.GetHashCode() + M12.GetHashCode() + M13.GetHashCode() + M14.GetHashCode() +
               M21.GetHashCode() + M22.GetHashCode() + M23.GetHashCode() + M24.GetHashCode() +
               M31.GetHashCode() + M32.GetHashCode() + M33.GetHashCode() + M34.GetHashCode() +
               M41.GetHashCode() + M42.GetHashCode() + M43.GetHashCode() + M44.GetHashCode();
        }

        public static bool Equals(ref Matrix value1, ref Matrix value2)
        {
            return (value1.M11 == value2.M11 && value1.M12 == value2.M12 && value1.M13 == value2.M13 && value1.M14 == value2.M14 &&
                 value1.M21 == value2.M21 && value1.M22 == value2.M22 && value1.M23 == value2.M23 && value1.M24 == value2.M24 &&
                 value1.M31 == value2.M31 && value1.M32 == value2.M32 && value1.M33 == value2.M33 && value1.M34 == value2.M34 &&
                 value1.M41 == value2.M41 && value1.M42 == value2.M42 && value1.M43 == value2.M43 && value1.M44 == value2.M44);
        }

        public bool Equals(Matrix value)
        {
            return (M11 == value.M11 && M12 == value.M12 && M13 == value.M13 && M14 == value.M14 &&
                 M21 == value.M21 && M22 == value.M22 && M23 == value.M23 && M24 == value.M24 &&
                 M31 == value.M31 && M32 == value.M32 && M33 == value.M33 && M34 == value.M34 &&
                 M41 == value.M41 && M42 == value.M42 && M43 == value.M43 && M44 == value.M44);
        }

        public override bool Equals(object value)
        {
            if (value == null)
                return false;

            if (value.GetType() != GetType())
                return false;

            return Equals((Matrix)value);
        }
    }
}
