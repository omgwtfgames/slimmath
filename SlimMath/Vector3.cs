/*
* Copyright (c) 2007-2010 SlimDX Group
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*/
using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace SlimMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Vector3 : IEquatable<Vector3>
    {
        public static readonly int SizeInBytes = Marshal.SizeOf(typeof(Vector3));

        public float X;
        public float Y;
        public float Z;

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return X;
                    case 1: return Y;
                    case 2: return Z;
                }

                throw new ArgumentOutOfRangeException("index", "Indices for Vector3 run from 0 to 2, inclusive.");
            }

            set
            {
                switch (index)
                {
                    case 0: X = value; break;
                    case 1: Y = value; break;
                    case 2: Z = value; break;
                    default: throw new ArgumentOutOfRangeException("index", "Indices for Vector3 run from 0 to 2, inclusive.");
                }
            }
        }

        public static Vector3 Zero
        {
            get { return new Vector3(0.0f, 0.0f, 0.0f); }
        }

        public static Vector3 UnitX
        {
            get { return new Vector3(1.0f, 0.0f, 0.0f); }
        }

        public static Vector3 UnitY
        {
            get { return new Vector3(0.0f, 1.0f, 0.0f); }
        }

        public static Vector3 UnitZ
        {
            get { return new Vector3(0.0f, 0.0f, 1.0f); }
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
            return (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
        }

        public float LengthSquared()
        {
            return (X * X) + (Y * Y) + (Z * Z);
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
            if (length != 0.0f)
            {
                float inv = 1.0f / length;
                X *= inv;
                Y *= inv;
                Z *= inv;
            }
        }

        public static void Add(ref Vector3 left, ref Vector3 right, out Vector3 result)
        {
            result = new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static Vector3 Add(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static void Subtract(ref Vector3 left, ref Vector3 right, out Vector3 result)
        {
            result = new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
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
            result = new Vector3(vector.X / scale, vector.Y / scale, vector.Z / scale);
        }

        public static Vector3 Divide(Vector3 vector, float scale)
        {
            return new Vector3(vector.X / scale, vector.Y / scale, vector.Z / scale);
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
            result = new Vector3((value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X)),
                (value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y)),
                (value1.Z + (amount1 * (value2.Z - value1.Z))) + (amount2 * (value3.Z - value1.Z)));
        }

        public static Vector3 Barycentric(Vector3 value1, Vector3 value2, Vector3 value3, float amount1, float amount2)
        {
            Vector3 result;
            Barycentric(ref value1, ref value2, ref value3, amount1, amount2, out result);
            return result;
        }

        public static void CatmullRom(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, ref Vector3 value4, float amount, out Vector3 result)
        {
            float squared = amount * amount;
            float cubed = amount * squared;

            result.X = 0.5f * ((((2.0f * value2.X) + ((-value1.X + value3.X) * amount)) +
            (((((2.0f * value1.X) - (5.0f * value2.X)) + (4.0f * value3.X)) - value4.X) * squared)) +
            ((((-value1.X + (3.0f * value2.X)) - (3.0f * value3.X)) + value4.X) * cubed));

            result.Y = 0.5f * ((((2.0f * value2.Y) + ((-value1.Y + value3.Y) * amount)) +
                (((((2.0f * value1.Y) - (5.0f * value2.Y)) + (4.0f * value3.Y)) - value4.Y) * squared)) +
                ((((-value1.Y + (3.0f * value2.Y)) - (3.0f * value3.Y)) + value4.Y) * cubed));

            result.Z = 0.5f * ((((2.0f * value2.Z) + ((-value1.Z + value3.Z) * amount)) +
                (((((2.0f * value1.Z) - (5.0f * value2.Z)) + (4.0f * value3.Z)) - value4.Z) * squared)) +
                ((((-value1.Z + (3.0f * value2.Z)) - (3.0f * value3.Z)) + value4.Z) * cubed));
        }

        public static Vector3 CatmullRom(Vector3 value1, Vector3 value2, Vector3 value3, Vector3 value4, float amount)
        {
            Vector3 result;
            CatmullRom(ref value1, ref value2, ref value3, ref value4, amount, out result);
            return result;
        }

        public static void Clamp(ref Vector3 value, ref Vector3 min, ref Vector3 max, out Vector3 result)
        {
            float x = value.X;
            x = (x > max.X) ? max.X : x;
            x = (x < min.X) ? min.X : x;

            float y = value.Y;
            y = (y > max.Y) ? max.Y : y;
            y = (y < min.Y) ? min.Y : y;

            float z = value.Z;
            z = (z > max.Z) ? max.Z : z;
            z = (z < min.Z) ? min.Z : z;

            result = new Vector3(x, y, z);
        }

        public static Vector3 Clamp(Vector3 value, Vector3 min, Vector3 max)
        {
            Vector3 result;
            Clamp(ref value, ref min, ref max, out result);
            return result;
        }

        public static void Hermite(ref Vector3 value1, ref Vector3 tangent1, ref Vector3 value2, ref Vector3 tangent2, float amount, out Vector3 result)
        {
            float squared = amount * amount;
            float cubed = amount * squared;
            float part1 = ((2.0f * cubed) - (3.0f * squared)) + 1.0f;
            float part2 = (-2.0f * cubed) + (3.0f * squared);
            float part3 = (cubed - (2.0f * squared)) + amount;
            float part4 = cubed - squared;

            result.X = (((value1.X * part1) + (value2.X * part2)) + (tangent1.X * part3)) + (tangent2.X * part4);
            result.Y = (((value1.Y * part1) + (value2.Y * part2)) + (tangent1.Y * part3)) + (tangent2.Y * part4);
            result.Z = (((value1.Z * part1) + (value2.Z * part2)) + (tangent1.Z * part3)) + (tangent2.Z * part4);
        }

        public static Vector3 Hermite(Vector3 value1, Vector3 tangent1, Vector3 value2, Vector3 tangent2, float amount)
        {
            Vector3 result;
            Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
            return result;
        }

        public static void Lerp(ref Vector3 start, ref Vector3 end, float amount, out Vector3 result)
        {
            result.X = start.X + ((end.X - start.X) * amount);
            result.Y = start.Y + ((end.Y - start.Y) * amount);
            result.Z = start.Z + ((end.Z - start.Z) * amount);
        }

        public static Vector3 Lerp(Vector3 start, Vector3 end, float amount)
        {
            Vector3 result;
            Lerp(ref start, ref end, amount, out result);
            return result;
        }

        public static void SmoothStep(ref Vector3 start, ref Vector3 end, float amount, out Vector3 result)
        {
            amount = (amount > 1.0f) ? 1.0f : ((amount < 0.0f) ? 0.0f : amount);
            amount = (amount * amount) * (3.0f - (2.0f * amount));

            result.X = start.X + ((end.X - start.X) * amount);
            result.Y = start.Y + ((end.Y - start.Y) * amount);
            result.Z = start.Z + ((end.Z - start.Z) * amount);
        }

        public static Vector3 SmoothStep(Vector3 start, Vector3 end, float amount)
        {
            Vector3 result;
            SmoothStep(ref start, ref end, amount, out result);
            return result;
        }

        public static float Distance(Vector3 value1, Vector3 value2)
        {
            float x = value1.X - value2.X;
            float y = value1.Y - value2.Y;
            float z = value1.Z - value2.Z;

            return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        public static float DistanceSquared(Vector3 value1, Vector3 value2)
        {
            float x = value1.X - value2.X;
            float y = value1.Y - value2.Y;
            float z = value1.Z - value2.Z;

            return (x * x) + (y * y) + (z * z);
        }

        public static float Dot(Vector3 left, Vector3 right)
        {
            return (left.X * right.X) + (left.Y * right.Y) + (left.Z * right.Z);
        }

        public static void Cross(ref Vector3 left, ref Vector3 right, out Vector3 result)
        {
            result.X = (left.Y * right.Z) - (left.Z * right.Y);
            result.Y = (left.Z * right.X) - (left.X * right.Z);
            result.Z = (left.X * right.Y) - (left.Y * right.X);
        }

        public static Vector3 Cross(Vector3 left, Vector3 right)
        {
            Vector3 result;
            Cross(ref left, ref right, out result);
            return result;
        }

        public static void Reflect(ref Vector3 vector, ref Vector3 normal, out Vector3 result)
        {
            float dot = ((vector.X * normal.X) + (vector.Y * normal.Y)) + (vector.Z * normal.Z);

            result.X = vector.X - ((2.0f * dot) * normal.X);
            result.Y = vector.Y - ((2.0f * dot) * normal.Y);
            result.Z = vector.Z - ((2.0f * dot) * normal.Z);
        }

        public static Vector3 Reflect(Vector3 vector, Vector3 normal)
        {
            Vector3 result;
            Reflect(ref vector, ref normal, out result);
            return result;
        }

        public static void Transform(ref Vector3 vector, ref Quaternion rotation, out Vector3 result)
        {
            float x = rotation.X + rotation.X;
            float y = rotation.Y + rotation.Y;
            float z = rotation.Z + rotation.Z;
            float wx = rotation.W * x;
            float wy = rotation.W * y;
            float wz = rotation.W * z;
            float xx = rotation.X * x;
            float xy = rotation.X * y;
            float xz = rotation.X * z;
            float yy = rotation.Y * y;
            float yz = rotation.Y * z;
            float zz = rotation.Z * z;

            result.X = ((vector.X * ((1.0f - yy) - zz)) + (vector.Y * (xy - wz))) + (vector.Z * (xz + wy));
            result.Y = ((vector.X * (xy + wz)) + (vector.Y * ((1.0f - xx) - zz))) + (vector.Z * (yz - wx));
            result.Z = ((vector.X * (xz - wy)) + (vector.Y * (yz + wx))) + (vector.Z * ((1.0f - xx) - yy));
        }

        public static Vector3 Transform(Vector3 vector, Quaternion rotation)
        {
            Vector3 result;
            Transform(ref vector, ref rotation, out result);
            return result;
        }

        public static void Transform(ref Vector3 vector, ref Matrix transform, out Vector4 result)
        {
            result.X = (((vector.X * transform.M11) + (vector.Y * transform.M21)) + (vector.Z * transform.M31)) + transform.M41;
            result.Y = (((vector.X * transform.M12) + (vector.Y * transform.M22)) + (vector.Z * transform.M32)) + transform.M42;
            result.Z = (((vector.X * transform.M13) + (vector.Y * transform.M23)) + (vector.Z * transform.M33)) + transform.M43;
            result.W = (((vector.X * transform.M14) + (vector.Y * transform.M24)) + (vector.Z * transform.M34)) + transform.M44;
        }

        public static Vector4 Transform(Vector3 vector, Matrix transform)
        {
            Vector4 result;
            Transform(ref vector, ref transform, out result);
            return result;
        }

        public static void TransformCoordinate(ref Vector3 coordinate, ref Matrix transform, out Vector3 result)
        {
            Vector4 vector = new Vector4();
            vector.X = (coordinate.X * transform.M11) + (coordinate.Y * transform.M21) + (coordinate.Z * transform.M31) + transform.M41;
            vector.Y = (coordinate.X * transform.M12) + (coordinate.Y * transform.M22) + (coordinate.Z * transform.M32) + transform.M42;
            vector.Z = (coordinate.X * transform.M13) + (coordinate.Y * transform.M23) + (coordinate.Z * transform.M33) + transform.M43;
            vector.W = 1 / ((coordinate.X * transform.M14) + (coordinate.Y * transform.M24) + (coordinate.Z * transform.M34) + transform.M44);

            result = new Vector3(vector.X * vector.W, vector.Y * vector.W, vector.Z * vector.W);
        }

        public static Vector3 TransformCoordinate(Vector3 coordinate, Matrix transform)
        {
            Vector3 result;
            TransformCoordinate(ref coordinate, ref transform, out result);
            return result;
        }

        public static void TransformNormal(ref Vector3 normal, ref Matrix transformation, out Vector3 result)
        {
            result.X = (normal.X * transformation.M11) + (normal.Y * transformation.M21) + (normal.Z * transformation.M31);
            result.Y = (normal.X * transformation.M12) + (normal.Y * transformation.M22) + (normal.Z * transformation.M32);
            result.Z = (normal.X * transformation.M13) + (normal.Y * transformation.M23) + (normal.Z * transformation.M33);
        }

        public static Vector3 TransformNormal(Vector3 normal, Matrix transform)
        {
            Vector3 result;
            TransformNormal(ref normal, ref transform, out result);
            return result;
        }

        public static void Project(ref Vector3 vector, float x, float y, float width, float height, float minZ, float maxZ, ref Matrix worldViewProjection, out Vector3 result)
        {
            Vector3 v = new Vector3();
            TransformCoordinate(ref vector, ref worldViewProjection, out v);

            result = new Vector3(((1.0f + v.X) * 0.5f * width) + x, ((1.0f - v.Y) * 0.5f * height) + y, (v.Z * (maxZ - minZ)) + minZ);
        }

        public static Vector3 Project(Vector3 vector, float x, float y, float width, float height, float minZ, float maxZ, Matrix worldViewProjection)
        {
            Vector3 result;
            Project(ref vector, x, y, width, height, minZ, maxZ, ref worldViewProjection, out result);
            return result;
        }

        public static void Unproject(ref Vector3 vector, float x, float y, float width, float height, float minZ, float maxZ, ref Matrix worldViewProjection, out Vector3 result)
        {
            Vector3 v = new Vector3();
            Matrix matrix = new Matrix();
            Matrix.Invert(ref worldViewProjection, out matrix);

            v.X = (((vector.X - x) / width) * 2.0f) - 1.0f;
            v.Y = -((((vector.Y - y) / height) * 2.0f) - 1.0f);
            v.Z = (vector.Z - minZ) / (maxZ - minZ);

            TransformCoordinate(ref v, ref matrix, out result);
        }

        public static Vector3 Unproject(Vector3 vector, float x, float y, float width, float height, float minZ, float maxZ, Matrix worldViewProjection)
        {
            Vector3 result;
            Unproject(ref vector, x, y, width, height, minZ, maxZ, ref worldViewProjection, out result);
            return result;
        }

        public static void Minimize(ref Vector3 left, ref Vector3 right, out Vector3 result)
        {
            result.X = (left.X < right.X) ? left.X : right.X;
            result.Y = (left.Y < right.Y) ? left.Y : right.Y;
            result.Z = (left.Z < right.Z) ? left.Z : right.Z;
        }

        public static Vector3 Minimize(Vector3 left, Vector3 right)
        {
            Vector3 result;
            Minimize(ref left, ref right, out result);
            return result;
        }

        public static void Maximize(ref Vector3 left, ref Vector3 right, out Vector3 result)
        {
            result.X = (left.X > right.X) ? left.X : right.X;
            result.Y = (left.Y > right.Y) ? left.Y : right.Y;
            result.Z = (left.Z > right.Z) ? left.Z : right.Z;
        }

        public static Vector3 Maximize(Vector3 left, Vector3 right)
        {
            Vector3 result;
            Maximize(ref left, ref right, out result);
            return result;
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
            return vector * scale;
        }

        public static Vector3 operator *(Vector3 vector, float scale)
        {
            return new Vector3(vector.X * scale, vector.Y * scale, vector.Z * scale);
        }

        public static Vector3 operator /(Vector3 vector, float scale)
        {
            return new Vector3(vector.X / scale, vector.Y / scale, vector.Z / scale);
        }

        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return Equals(ref left, ref right);
        }

        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return !Equals(ref left, ref right);
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1} Z:{2}", X.ToString(CultureInfo.CurrentCulture), Y.ToString(CultureInfo.CurrentCulture), Z.ToString(CultureInfo.CurrentCulture));
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode();
        }

        public static bool Equals(ref Vector3 value1, ref Vector3 value2)
        {
            return (value1.X == value2.X && value1.Y == value2.Y && value1.Z == value2.Z);
        }

        public bool Equals(Vector3 value)
        {
            return (X == value.X && Y == value.Y && Z == value.Z);
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
