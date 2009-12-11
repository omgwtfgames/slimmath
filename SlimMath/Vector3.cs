using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Globalization;

namespace SlimMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Vector3 : IEquatable<Vector3>
    {
        public float X;
        public float Y;
        public float Z;

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return X;

                    case 1:
                        return Y;

                    case 2:
                        return Z;
                }
                throw new ArgumentOutOfRangeException("index", "Indices for Vector3 run from 0 to 2, inclusive.");
            }
            set
            {
                switch (index)
                {
                    case 0:
                        X = value;
                        break;

                    case 1:
                        Y = value;
                        break;

                    case 2:
                        Z = value;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("index", "Indices for Vector3 run from 0 to 2, inclusive.");
                }
            }
        }
        public static Vector3 Zero
        {
            get
            {
                return new Vector3(0f, 0f, 0f);
            }
        }
        public static Vector3 UnitX
        {
            get
            {
                return new Vector3(1f, 0f, 0f);
            }
        }
        public static Vector3 UnitY
        {
            get
            {
                return new Vector3(0f, 1f, 0f);
            }
        }
        public static Vector3 UnitZ
        {
            get
            {
                return new Vector3(0f, 0f, 1f);
            }
        }
        public static int SizeInBytes
        {
            get
            {
                return Marshal.SizeOf(typeof(Vector3));
            }
        }
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3(Vector2 value, float z)
        {
            X = value.X;
            Y = value.Y;
            Z = z;
        }

        public Vector3(float value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        public float Length()
        {
            return (float)Math.Sqrt(((X * X) + (Y * Y)) + (Z * Z));
        }

        public float LengthSquared()
        {
            return (((X * X) + (Y * Y)) + (Z * Z));
        }

        public static void Normalize(ref Vector3 vector, out Vector3 result)
        {
            Vector3 temp = vector;
            result = temp;
            result.Normalize();
        }

        public static Vector3 Normalize(Vector3 vector)
        {
            vector.Normalize();
            return vector;
        }

        public void Normalize()
        {
            float length = Length();
            if (length != 0.0)
            {
                float num = (float)(1.0 / ((double)length));
                X *= num;
                Y *= num;
                Z *= num;
            }
        }

        public static void Add(ref Vector3 left, ref Vector3 right, out Vector3 result)
        {
            Vector3 vector = new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
            result = vector;
        }

        public static Vector3 Add(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static void Subtract(ref Vector3 left, ref Vector3 right, out Vector3 result)
        {
            Vector3 vector = new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
            result = vector;
        }

        public static Vector3 Subtract(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static void Multiply(ref Vector3 vector, float scale, out Vector3 result)
        {
            result = new Vector3(vector.X * scale, vector.Y * scale, vector.Z * scale);
        }

        public static Vector3 Multiply(Vector3 value, float scale)
        {
            return new Vector3(value.X * scale, value.Y * scale, value.Z * scale);
        }

        public static void Modulate(ref Vector3 left, ref Vector3 right, out Vector3 result)
        {
            result = new Vector3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        }

        public static Vector3 Modulate(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        }

        public static void Divide(ref Vector3 vector, float scale, out Vector3 result)
        {
            result = new Vector3((float)(((double)vector.X) / ((double)scale)), (float)(((double)vector.Y) / ((double)scale)), (float)(((double)vector.Z) / ((double)scale)));
        }

        public static Vector3 Divide(Vector3 value, float scale)
        {
            return new Vector3((float)(((double)value.X) / ((double)scale)), (float)(((double)value.Y) / ((double)scale)), (float)(((double)value.Z) / ((double)scale)));
        }

        public static void Negate(ref Vector3 value, out Vector3 result)
        {
            result = new Vector3(-value.X, -value.Y, -value.Z);
        }

        public static Vector3 Negate(Vector3 value)
        {
            return new Vector3(-value.X, -value.Y, -value.Z);
        }

        public static void Barycentric(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, float amount1, float amount2, out Vector3 result)
        {
            result = new Vector3((value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X)), (value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y)), (value1.Z + (amount1 * (value2.Z - value1.Z))) + (amount2 * (value3.Z - value1.Z)));
        }

        public static Vector3 Barycentric(Vector3 value1, Vector3 value2, Vector3 value3, float amount1, float amount2)
        {
            Vector3 vector = new Vector3();
            vector.X = (value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X));
            vector.Y = (value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y));
            vector.Z = (value1.Z + (amount1 * (value2.Z - value1.Z))) + (amount2 * (value3.Z - value1.Z));
            return vector;
        }

        public static void CatmullRom(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, ref Vector3 value4, float amount, out Vector3 result)
        {
            float squared = amount * amount;
            float cubed = amount * squared;
            Vector3 r = new Vector3();
            r.X = (float)(0.5 * ((((2.0 * value2.X) + ((-value1.X + value3.X) * amount)) + (((((2.0 * value1.X) - (5.0 * value2.X)) + (4.0 * value3.X)) - value4.X) * squared)) + ((((-value1.X + (3.0 * value2.X)) - (3.0 * value3.X)) + value4.X) * cubed)));
            r.Y = (float)(0.5 * ((((2.0 * value2.Y) + ((-value1.Y + value3.Y) * amount)) + (((((2.0 * value1.Y) - (5.0 * value2.Y)) + (4.0 * value3.Y)) - value4.Y) * squared)) + ((((-value1.Y + (3.0 * value2.Y)) - (3.0 * value3.Y)) + value4.Y) * cubed)));
            r.Z = (float)(0.5 * ((((2.0 * value2.Z) + ((-value1.Z + value3.Z) * amount)) + (((((2.0 * value1.Z) - (5.0 * value2.Z)) + (4.0 * value3.Z)) - value4.Z) * squared)) + ((((-value1.Z + (3.0 * value2.Z)) - (3.0 * value3.Z)) + value4.Z) * cubed)));
            result = r;
        }

        public static Vector3 CatmullRom(Vector3 value1, Vector3 value2, Vector3 value3, Vector3 value4, float amount)
        {
            Vector3 vector = new Vector3();
            float squared = amount * amount;
            float cubed = amount * squared;
            vector.X = (float)(0.5 * ((((2.0 * value2.X) + ((-value1.X + value3.X) * amount)) + (((((2.0 * value1.X) - (5.0 * value2.X)) + (4.0 * value3.X)) - value4.X) * squared)) + ((((-value1.X + (3.0 * value2.X)) - (3.0 * value3.X)) + value4.X) * cubed)));
            vector.Y = (float)(0.5 * ((((2.0 * value2.Y) + ((-value1.Y + value3.Y) * amount)) + (((((2.0 * value1.Y) - (5.0 * value2.Y)) + (4.0 * value3.Y)) - value4.Y) * squared)) + ((((-value1.Y + (3.0 * value2.Y)) - (3.0 * value3.Y)) + value4.Y) * cubed)));
            vector.Z = (float)(0.5 * ((((2.0 * value2.Z) + ((-value1.Z + value3.Z) * amount)) + (((((2.0 * value1.Z) - (5.0 * value2.Z)) + (4.0 * value3.Z)) - value4.Z) * squared)) + ((((-value1.Z + (3.0 * value2.Z)) - (3.0 * value3.Z)) + value4.Z) * cubed)));
            return vector;
        }

        public static void Clamp(ref Vector3 value, ref Vector3 min, ref Vector3 max, out Vector3 result)
        {
            float num;
            float num2;
            float num3;
            float num4;
            float num5;
            float num6;
            float x = value.X;
            if (x > max.X)
            {
                num6 = max.X;
            }
            else
            {
                num6 = x;
            }
            x = num6;
            if (x < min.X)
            {
                num5 = min.X;
            }
            else
            {
                num5 = x;
            }
            x = num5;
            float y = value.Y;
            if (y > max.Y)
            {
                num4 = max.Y;
            }
            else
            {
                num4 = y;
            }
            y = num4;
            if (y < min.Y)
            {
                num3 = min.Y;
            }
            else
            {
                num3 = y;
            }
            y = num3;
            float z = value.Z;
            if (z > max.Z)
            {
                num2 = max.Z;
            }
            else
            {
                num2 = z;
            }
            z = num2;
            if (z < min.Z)
            {
                num = min.Z;
            }
            else
            {
                num = z;
            }
            z = num;
            Vector3 vector = new Vector3(x, y, z);
            result = vector;
        }

        public static Vector3 Clamp(Vector3 value, Vector3 min, Vector3 max)
        {
            float num;
            float num2;
            float num3;
            float num4;
            float num5;
            float num6;
            float x = value.X;
            if (x > max.X)
            {
                num6 = max.X;
            }
            else
            {
                num6 = x;
            }
            x = num6;
            if (x < min.X)
            {
                num5 = min.X;
            }
            else
            {
                num5 = x;
            }
            x = num5;
            float y = value.Y;
            if (y > max.Y)
            {
                num4 = max.Y;
            }
            else
            {
                num4 = y;
            }
            y = num4;
            if (y < min.Y)
            {
                num3 = min.Y;
            }
            else
            {
                num3 = y;
            }
            y = num3;
            float z = value.Z;
            if (z > max.Z)
            {
                num2 = max.Z;
            }
            else
            {
                num2 = z;
            }
            z = num2;
            if (z < min.Z)
            {
                num = min.Z;
            }
            else
            {
                num = z;
            }
            return new Vector3(x, y, num);
        }

        public static void Hermite(ref Vector3 value1, ref Vector3 tangent1, ref Vector3 value2, ref Vector3 tangent2, float amount, out Vector3 result)
        {
            float squared = amount * amount;
            float cubed = amount * squared;
            float part1 = (float)(((2.0 * cubed) - (3.0 * squared)) + 1.0);
            float part2 = (float)((-2.0 * cubed) + (3.0 * squared));
            float part3 = (cubed - ((float)(2.0 * squared))) + amount;
            float part4 = cubed - squared;
            result.X = (((value1.X * part1) + (value2.X * part2)) + (tangent1.X * part3)) + (tangent2.X * part4);
            result.Y = (((value1.Y * part1) + (value2.Y * part2)) + (tangent1.Y * part3)) + (tangent2.Y * part4);
            result.Z = (((value1.Z * part1) + (value2.Z * part2)) + (tangent1.Z * part3)) + (tangent2.Z * part4);
        }

        public static Vector3 Hermite(Vector3 value1, Vector3 tangent1, Vector3 value2, Vector3 tangent2, float amount)
        {
            Vector3 vector = new Vector3();
            float squared = amount * amount;
            float cubed = amount * squared;
            float part1 = (float)(((2.0 * cubed) - (3.0 * squared)) + 1.0);
            float part2 = (float)((-2.0 * cubed) + (3.0 * squared));
            float part3 = (cubed - ((float)(2.0 * squared))) + amount;
            float part4 = cubed - squared;
            vector.X = (((value1.X * part1) + (value2.X * part2)) + (tangent1.X * part3)) + (tangent2.X * part4);
            vector.Y = (((value1.Y * part1) + (value2.Y * part2)) + (tangent1.Y * part3)) + (tangent2.Y * part4);
            vector.Z = (((value1.Z * part1) + (value2.Z * part2)) + (tangent1.Z * part3)) + (tangent2.Z * part4);
            return vector;
        }

        public static void Lerp(ref Vector3 start, ref Vector3 end, float amount, out Vector3 result)
        {
            result.X = start.X + ((end.X - start.X) * amount);
            result.Y = start.Y + ((end.Y - start.Y) * amount);
            result.Z = start.Z + ((end.Z - start.Z) * amount);
        }

        public static Vector3 Lerp(Vector3 start, Vector3 end, float amount)
        {
            Vector3 vector = new Vector3();
            vector.X = start.X + ((end.X - start.X) * amount);
            vector.Y = start.Y + ((end.Y - start.Y) * amount);
            vector.Z = start.Z + ((end.Z - start.Z) * amount);
            return vector;
        }

        public static void SmoothStep(ref Vector3 start, ref Vector3 end, float amount, out Vector3 result)
        {
            float num2;
            if (amount > 1.0)
            {
                num2 = 1f;
            }
            else
            {
                float num;
                if (amount < 0.0)
                {
                    num = 0f;
                }
                else
                {
                    num = amount;
                }
                num2 = num;
            }
            amount = num2;
            amount = (float)((amount * amount) * (3.0 - (2.0 * amount)));
            result.X = start.X + ((end.X - start.X) * amount);
            result.Y = start.Y + ((end.Y - start.Y) * amount);
            result.Z = start.Z + ((end.Z - start.Z) * amount);
        }

        public static Vector3 SmoothStep(Vector3 start, Vector3 end, float amount)
        {
            float num2;
            Vector3 vector = new Vector3();
            if (amount > 1.0)
            {
                num2 = 1f;
            }
            else
            {
                float num;
                if (amount < 0.0)
                {
                    num = 0f;
                }
                else
                {
                    num = amount;
                }
                num2 = num;
            }
            amount = num2;
            amount = (float)((amount * amount) * (3.0 - (2.0 * amount)));
            vector.X = start.X + ((end.X - start.X) * amount);
            vector.Y = start.Y + ((end.Y - start.Y) * amount);
            vector.Z = start.Z + ((end.Z - start.Z) * amount);
            return vector;
        }

        public static float Distance(Vector3 value1, Vector3 value2)
        {
            float x = value1.X - value2.X;
            float y = value1.Y - value2.Y;
            float z = value1.Z - value2.Z;
            return (float)Math.Sqrt(((x * x) + (y * y)) + (z * z));
        }

        public static float DistanceSquared(Vector3 value1, Vector3 value2)
        {
            float x = value1.X - value2.X;
            float y = value1.Y - value2.Y;
            float z = value1.Z - value2.Z;
            return (((x * x) + (y * y)) + (z * z));
        }

        public static float Dot(Vector3 left, Vector3 right)
        {
            return (((left.X * right.X) + (left.Y * right.Y)) + (left.Z * right.Z));
        }

        public static void Cross(ref Vector3 left, ref Vector3 right, out Vector3 result)
        {
            Vector3 r = new Vector3();
            r.X = (left.Y * right.Z) - (left.Z * right.Y);
            r.Y = (left.Z * right.X) - (left.X * right.Z);
            r.Z = (left.X * right.Y) - (left.Y * right.X);
            result = r;
        }

        public static Vector3 Cross(Vector3 left, Vector3 right)
        {
            Vector3 result = new Vector3();
            result.X = (left.Y * right.Z) - (left.Z * right.Y);
            result.Y = (left.Z * right.X) - (left.X * right.Z);
            result.Z = (left.X * right.Y) - (left.Y * right.X);
            return result;
        }

        public static void Reflect(ref Vector3 vector, ref Vector3 normal, out Vector3 result)
        {
            float dot = ((vector.X * normal.X) + (vector.Y * normal.Y)) + (vector.Z * normal.Z);
            result.X = vector.X - ((float)((2.0 * dot) * normal.X));
            result.Y = vector.Y - ((float)((2.0 * dot) * normal.Y));
            result.Z = vector.Z - ((float)((2.0 * dot) * normal.Z));
        }

        public static Vector3 Reflect(Vector3 vector, Vector3 normal)
        {
            Vector3 result = new Vector3();
            float dot = ((vector.X * normal.X) + (vector.Y * normal.Y)) + (vector.Z * normal.Z);
            result.X = vector.X - ((float)((2.0 * dot) * normal.X));
            result.Y = vector.Y - ((float)((2.0 * dot) * normal.Y));
            result.Z = vector.Z - ((float)((2.0 * dot) * normal.Z));
            return result;
        }

        //public static void Transform(ref Vector3 vector, ref Quaternion rotation, out Vector4 result)
        //{
        //    float x = rotation.X + rotation.X;
        //    float y = rotation.Y + rotation.Y;
        //    float z = rotation.Z + rotation.Z;
        //    float wx = rotation.W * x;
        //    float wy = rotation.W * y;
        //    float wz = rotation.W * z;
        //    float xx = rotation.X * x;
        //    float xy = rotation.X * y;
        //    float xz = rotation.X * z;
        //    float yy = rotation.Y * y;
        //    float yz = rotation.Y * z;
        //    float zz = rotation.Z * z;
        //    Vector4 vector = new Vector4();
        //    result = vector;
        //    result.X = (((float)(vector.X * ((1.0 - yy) - zz))) + (vector.Y * (xy - wz))) + (vector.Z * (xz + wy));
        //    result.Y = ((vector.X * (xy + wz)) + ((float)(vector.Y * ((1.0 - xx) - zz)))) + (vector.Z * (yz - wx));
        //    result.Z = ((vector.X * (xz - wy)) + (vector.Y * (yz + wx))) + ((float)(vector.Z * ((1.0 - xx) - yy)));
        //    result.W = 1f;
        //}

        //public static Vector4 Transform(Vector3 vector, Quaternion rotation)
        //{
        //    Vector4 vector = new Vector4();
        //    float x = rotation.X + rotation.X;
        //    float y = rotation.Y + rotation.Y;
        //    float z = rotation.Z + rotation.Z;
        //    float wx = rotation.W * x;
        //    float wy = rotation.W * y;
        //    float wz = rotation.W * z;
        //    float xx = rotation.X * x;
        //    float xy = rotation.X * y;
        //    float xz = rotation.X * z;
        //    float yy = rotation.Y * y;
        //    float yz = rotation.Y * z;
        //    float zz = rotation.Z * z;
        //    vector.X = (((float)(vector.X * ((1.0 - yy) - zz))) + (vector.Y * (xy - wz))) + (vector.Z * (xz + wy));
        //    vector.Y = ((vector.X * (xy + wz)) + ((float)(vector.Y * ((1.0 - xx) - zz)))) + (vector.Z * (yz - wx));
        //    vector.Z = ((vector.X * (xz - wy)) + (vector.Y * (yz + wx))) + ((float)(vector.Z * ((1.0 - xx) - yy)));
        //    vector.W = 1f;
        //    return vector;
        //}

        //public static void Transform(ref Vector3 vector, ref Matrix transformation, out Vector4 result)
        //{
        //    Vector4 vector = new Vector4();
        //    result = vector;
        //    result.X = (((vector.X * transformation.M11) + (vector.Y * transformation.M21)) + (vector.Z * transformation.M31)) + transformation.M41;
        //    result.Y = (((vector.X * transformation.M12) + (vector.Y * transformation.M22)) + (vector.Z * transformation.M32)) + transformation.M42;
        //    result.Z = (((vector.X * transformation.M13) + (vector.Y * transformation.M23)) + (vector.Z * transformation.M33)) + transformation.M43;
        //    result.W = (((vector.X * transformation.M14) + (vector.Y * transformation.M24)) + (vector.Z * transformation.M34)) + transformation.M44;
        //}

        public static Vector4 Transform(Vector3 vector, Matrix transformation)
        {
            Vector4 result = new Vector4();
            result.X = (((vector.X * transformation.M11) + (vector.Y * transformation.M21)) + (vector.Z * transformation.M31)) + transformation.M41;
            result.Y = (((vector.X * transformation.M12) + (vector.Y * transformation.M22)) + (vector.Z * transformation.M32)) + transformation.M42;
            result.Z = (((vector.X * transformation.M13) + (vector.Y * transformation.M23)) + (vector.Z * transformation.M33)) + transformation.M43;
            result.W = (((vector.X * transformation.M14) + (vector.Y * transformation.M24)) + (vector.Z * transformation.M34)) + transformation.M44;
            return result;
        }

        public static void TransformCoordinate(ref Vector3 coordinate, ref Matrix transformation, out Vector3 result)
        {
            Vector4 vector = new Vector4();
            vector.X = (((coordinate.X * transformation.M11) + (coordinate.Y * transformation.M21)) + (coordinate.Z * transformation.M31)) + transformation.M41;
            vector.Y = (((coordinate.X * transformation.M12) + (coordinate.Y * transformation.M22)) + (coordinate.Z * transformation.M32)) + transformation.M42;
            vector.Z = (((coordinate.X * transformation.M13) + (coordinate.Y * transformation.M23)) + (coordinate.Z * transformation.M33)) + transformation.M43;
            vector.W = (float)(1.0 / ((((coordinate.X * transformation.M14) + (coordinate.Y * transformation.M24)) + (coordinate.Z * transformation.M34)) + transformation.M44));
            Vector3 vector2 = new Vector3(vector.X * vector.W, vector.Y * vector.W, vector.Z * vector.W);
            result = vector2;
        }

        public static Vector3 TransformCoordinate(Vector3 coordinate, Matrix transformation)
        {
            Vector4 vector = new Vector4();
            vector.X = (((coordinate.X * transformation.M11) + (coordinate.Y * transformation.M21)) + (coordinate.Z * transformation.M31)) + transformation.M41;
            vector.Y = (((coordinate.X * transformation.M12) + (coordinate.Y * transformation.M22)) + (coordinate.Z * transformation.M32)) + transformation.M42;
            vector.Z = (((coordinate.X * transformation.M13) + (coordinate.Y * transformation.M23)) + (coordinate.Z * transformation.M33)) + transformation.M43;
            vector.W = (float)(1.0 / ((((coordinate.X * transformation.M14) + (coordinate.Y * transformation.M24)) + (coordinate.Z * transformation.M34)) + transformation.M44));
            return new Vector3(vector.X * vector.W, vector.Y * vector.W, vector.Z * vector.W);
        }

        public static void TransformNormal(ref Vector3 normal, ref Matrix transformation, out Vector3 result)
        {
            result.X = ((normal.X * transformation.M11) + (normal.Y * transformation.M21)) + (normal.Z * transformation.M31);
            result.Y = ((normal.X * transformation.M12) + (normal.Y * transformation.M22)) + (normal.Z * transformation.M32);
            result.Z = ((normal.X * transformation.M13) + (normal.Y * transformation.M23)) + (normal.Z * transformation.M33);
        }

        public static Vector3 TransformNormal(Vector3 normal, Matrix transformation)
        {
            Vector3 vector = new Vector3();
            vector.X = ((normal.X * transformation.M11) + (normal.Y * transformation.M21)) + (normal.Z * transformation.M31);
            vector.Y = ((normal.X * transformation.M12) + (normal.Y * transformation.M22)) + (normal.Z * transformation.M32);
            vector.Z = ((normal.X * transformation.M13) + (normal.Y * transformation.M23)) + (normal.Z * transformation.M33);
            return vector;
        }

        //public static void Project(ref Vector3 vector, float x, float y, float width, float height, float minZ, float maxZ, ref Matrix worldViewProjection, out Vector3 result)
        //{
        //    Vector3 v = new Vector3();
        //    TransformCoordinate(ref vector, ref worldViewProjection, out v);
        //    Vector3 vector = new Vector3(((float)(((1.0 + v.X) * 0.5) * width)) + x, ((float)(((1.0 - v.Y) * 0.5) * height)) + y, (v.Z * (maxZ - minZ)) + minZ);
        //    result = vector;
        //}

        public static Vector3 Project(Vector3 vector, float x, float y, float width, float height, float minZ, float maxZ, Matrix worldViewProjection)
        {
            TransformCoordinate(ref vector, ref worldViewProjection, out vector);
            return new Vector3(((float)(((1.0 + vector.X) * 0.5) * width)) + x, ((float)(((1.0 - vector.Y) * 0.5) * height)) + y, (vector.Z * (maxZ - minZ)) + minZ);
        }

        public static void Unproject(ref Vector3 vector, float x, float y, float width, float height, float minZ, float maxZ, ref Matrix worldViewProjection, out Vector3 result)
        {
            Vector3 v = new Vector3();
            Matrix matrix = new Matrix();
            Matrix.Invert(ref worldViewProjection, out matrix);
            v.X = (float)((((vector.X - x) / ((double)width)) * 2.0) - 1.0);
            v.Y = (float)-((((vector.Y - y) / ((double)height)) * 2.0) - 1.0);
            v.Z = (vector.Z - minZ) / (maxZ - minZ);
            TransformCoordinate(ref v, ref matrix, out v);
            result = v;
        }

        public static Vector3 Unproject(Vector3 vector, float x, float y, float width, float height, float minZ, float maxZ, Matrix worldViewProjection)
        {
            Vector3 v = new Vector3();
            Matrix matrix = new Matrix();
            Matrix.Invert(ref worldViewProjection, out matrix);
            v.X = (float)((((vector.X - x) / ((double)width)) * 2.0) - 1.0);
            v.Y = (float)-((((vector.Y - y) / ((double)height)) * 2.0) - 1.0);
            v.Z = (vector.Z - minZ) / (maxZ - minZ);
            TransformCoordinate(ref v, ref matrix, out v);
            return v;
        }

        public static void Minimize(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            float z;
            float y;
            float x;
            if (value1.X < value2.X)
            {
                x = value1.X;
            }
            else
            {
                x = value2.X;
            }
            result.X = x;
            if (value1.Y < value2.Y)
            {
                y = value1.Y;
            }
            else
            {
                y = value2.Y;
            }
            result.Y = y;
            if (value1.Z < value2.Z)
            {
                z = value1.Z;
            }
            else
            {
                z = value2.Z;
            }
            result.Z = z;
        }

        public static Vector3 Minimize(Vector3 value1, Vector3 value2)
        {
            float z;
            float y;
            float x;
            Vector3 vector = new Vector3();
            if (value1.X < value2.X)
            {
                x = value1.X;
            }
            else
            {
                x = value2.X;
            }
            vector.X = x;
            if (value1.Y < value2.Y)
            {
                y = value1.Y;
            }
            else
            {
                y = value2.Y;
            }
            vector.Y = y;
            if (value1.Z < value2.Z)
            {
                z = value1.Z;
            }
            else
            {
                z = value2.Z;
            }
            vector.Z = z;
            return vector;
        }

        public static void Maximize(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            float z;
            float y;
            float x;
            if (value1.X > value2.X)
            {
                x = value1.X;
            }
            else
            {
                x = value2.X;
            }
            result.X = x;
            if (value1.Y > value2.Y)
            {
                y = value1.Y;
            }
            else
            {
                y = value2.Y;
            }
            result.Y = y;
            if (value1.Z > value2.Z)
            {
                z = value1.Z;
            }
            else
            {
                z = value2.Z;
            }
            result.Z = z;
        }

        public static Vector3 Maximize(Vector3 value1, Vector3 value2)
        {
            float z;
            float y;
            float x;
            Vector3 vector = new Vector3();
            if (value1.X > value2.X)
            {
                x = value1.X;
            }
            else
            {
                x = value2.X;
            }
            vector.X = x;
            if (value1.Y > value2.Y)
            {
                y = value1.Y;
            }
            else
            {
                y = value2.Y;
            }
            vector.Y = y;
            if (value1.Z > value2.Z)
            {
                z = value1.Z;
            }
            else
            {
                z = value2.Z;
            }
            vector.Z = z;
            return vector;
        }

        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static Vector3 operator -(Vector3 value)
        {
            return new Vector3(-value.X, -value.Y, -value.Z);
        }

        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static Vector3 operator *(float scale, Vector3 vector)
        {
            return (Vector3)(vector * scale);
        }

        public static Vector3 operator *(Vector3 vector, float scale)
        {
            return new Vector3(vector.X * scale, vector.Y * scale, vector.Z * scale);
        }

        public static Vector3 operator /(Vector3 vector, float scale)
        {
            return new Vector3((float)(((double)vector.X) / ((double)scale)), (float)(((double)vector.Y) / ((double)scale)), (float)(((double)vector.Z) / ((double)scale)));
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return Equals(ref left, ref right);
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return !Equals(ref left, ref right);
        }

        public override string ToString()
        {
            object[] args = new object[] { X.ToString(CultureInfo.CurrentCulture), Y.ToString(CultureInfo.CurrentCulture), Z.ToString(CultureInfo.CurrentCulture) };
            return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1} Z:{2}", args);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        public static bool Equals(ref Vector3 value1, ref Vector3 value2)
        {
            return (value1.X == value2.X && value1.Y == value2.Y);
        }

        public bool Equals(Vector3 value)
        {
            return (X == value.X && Y == value.Y);
        }

        public override bool Equals(object value)
        {
            if (value == null)
                return false;

            if (value.GetType() != GetType())
                return false;

            return Equals((Vector3)value);
        }
    }
}
