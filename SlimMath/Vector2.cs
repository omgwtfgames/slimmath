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
using System.ComponentModel;

namespace SlimMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    [TypeConverter(typeof(SlimMath.Design.Vector2Converter))]
    public struct Vector2 : IEquatable<Vector2>, IFormattable
    {
        public const float ZeroTolerance = 1e-8f;
        public static readonly int SizeInBytes = Marshal.SizeOf(typeof(Vector2));

        public static readonly Vector2 Zero = new Vector2(0.0f, 0.0f);
        public static readonly Vector2 UnitX = new Vector2(1.0f, 0.0f);
        public static readonly Vector2 UnitY = new Vector2(0.0f, 1.0f);
        public static readonly Vector2 One = new Vector2(1.0f, 1.0f);

        public float X;
        public float Y;

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return X;
                    case 1: return Y;
                }

                throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
            }

            set
            {
                switch (index)
                {
                    case 0: X = value; break;
                    case 1: Y = value; break;
                    default: throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
                }
            }
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector2(float value)
        {
            X = value;
            Y = value;
        }

        public Vector2(float[] values)
        {
            if (values == null)
                throw new ArgumentNullException("values");
            if (values.Length != 2)
                throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");

            X = values[0];
            Y = values[1];
        }

        public float Length()
        {
            return (float)Math.Sqrt((X * X) + (Y * Y));
        }

        public float LengthSquared()
        {
            return (X * X) + (Y * Y);
        }

        public void Normalize()
        {
            float length = Length();
            if (length > ZeroTolerance)
            {
                float inv = 1.0f / length;
                X *= inv;
                Y *= inv;
            }
        }

        public float[] ToArray()
        {
            return new float[] { X, Y };
        }

        public static void Add(ref Vector2 left, ref Vector2 right, out Vector2 result)
        {
            result = new Vector2(left.X + right.X, left.Y + right.Y);
        }

        public static Vector2 Add(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
        }

        public static void Subtract(ref Vector2 left, ref Vector2 right, out Vector2 result)
        {
            result = new Vector2(left.X - right.X, left.Y - right.Y);
        }

        public static Vector2 Subtract(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X - right.X, left.Y - right.Y);
        }

        public static void Multiply(ref Vector2 vector, float scale, out Vector2 result)
        {
            result = new Vector2(vector.X * scale, vector.Y * scale);
        }

        public static Vector2 Multiply(Vector2 value, float scale)
        {
            return new Vector2(value.X * scale, value.Y * scale);
        }

        public static void Modulate(ref Vector2 left, ref Vector2 right, out Vector2 result)
        {
            result = new Vector2(left.X * right.X, left.Y * right.Y);
        }

        public static Vector2 Modulate(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X * right.X, left.Y * right.Y);
        }

        public static void Divide(ref Vector2 vector, float scale, out Vector2 result)
        {
            result = new Vector2(vector.X / scale, vector.Y / scale);
        }

        public static Vector2 Divide(Vector2 value, float scale)
        {
            return new Vector2(value.X / scale, value.Y / scale);
        }

        public static void Negate(ref Vector2 value, out Vector2 result)
        {
            result = new Vector2(-value.X, -value.Y);
        }

        public static Vector2 Negate(Vector2 value)
        {
            return new Vector2(-value.X, -value.Y);
        }

        public static void Barycentric(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, float amount1, float amount2, out Vector2 result)
        {
            result = new Vector2((value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X)),
                (value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y)));
        }

        public static Vector2 Barycentric(Vector2 value1, Vector2 value2, Vector2 value3, float amount1, float amount2)
        {
            Vector2 result;
            Barycentric(ref value1, ref value2, ref value3, amount1, amount2, out result);
            return result;
        }

        public static void CatmullRom(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, ref Vector2 value4, float amount, out Vector2 result)
        {
            float squared = amount * amount;
            float cubed = amount * squared;

            result.X = 0.5f * ((((2.0f * value2.X) + ((-value1.X + value3.X) * amount)) +
            (((((2.0f * value1.X) - (5.0f * value2.X)) + (4.0f * value3.X)) - value4.X) * squared)) +
            ((((-value1.X + (3.0f * value2.X)) - (3.0f * value3.X)) + value4.X) * cubed));

            result.Y = 0.5f * ((((2.0f * value2.Y) + ((-value1.Y + value3.Y) * amount)) +
                (((((2.0f * value1.Y) - (5.0f * value2.Y)) + (4.0f * value3.Y)) - value4.Y) * squared)) +
                ((((-value1.Y + (3.0f * value2.Y)) - (3.0f * value3.Y)) + value4.Y) * cubed));
        }

        public static Vector2 CatmullRom(Vector2 value1, Vector2 value2, Vector2 value3, Vector2 value4, float amount)
        {
            Vector2 result;
            CatmullRom(ref value1, ref value2, ref value3, ref value4, amount, out result);
            return result;
        }

        public static void Clamp(ref Vector2 value, ref Vector2 min, ref Vector2 max, out Vector2 result)
        {
            float x = value.X;
            x = (x > max.X) ? max.X : x;
            x = (x < min.X) ? min.X : x;

            float y = value.Y;
            y = (y > max.Y) ? max.Y : y;
            y = (y < min.Y) ? min.Y : y;

            result = new Vector2(x, y);
        }

        public static Vector2 Clamp(Vector2 value, Vector2 min, Vector2 max)
        {
            Vector2 result;
            Clamp(ref value, ref min, ref max, out result);
            return result;
        }

        public static float Distance(Vector2 value1, Vector2 value2)
        {
            float x = value1.X - value2.X;
            float y = value1.Y - value2.Y;

            return (float)Math.Sqrt((x * x) + (y * y));
        }

        public static float DistanceSquared(Vector2 value1, Vector2 value2)
        {
            float x = value1.X - value2.X;
            float y = value1.Y - value2.Y;

            return (x * x) + (y * y);
        }

        public static float Dot(Vector2 left, Vector2 right)
        {
            return (left.X * right.X) + (left.Y * right.Y);
        }

        public static void Hermite(ref Vector2 value1, ref Vector2 tangent1, ref Vector2 value2, ref Vector2 tangent2, float amount, out Vector2 result)
        {
            float squared = amount * amount;
            float cubed = amount * squared;
            float part1 = ((2.0f * cubed) - (3.0f * squared)) + 1.0f;
            float part2 = (-2.0f * cubed) + (3.0f * squared);
            float part3 = (cubed - (2.0f * squared)) + amount;
            float part4 = cubed - squared;

            result.X = (((value1.X * part1) + (value2.X * part2)) + (tangent1.X * part3)) + (tangent2.X * part4);
            result.Y = (((value1.Y * part1) + (value2.Y * part2)) + (tangent1.Y * part3)) + (tangent2.Y * part4);
        }

        public static Vector2 Hermite(Vector2 value1, Vector2 tangent1, Vector2 value2, Vector2 tangent2, float amount)
        {
            Vector2 result;
            Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
            return result;
        }

        public static void Lerp(ref Vector2 start, ref Vector2 end, float amount, out Vector2 result)
        {
            result.X = start.X + ((end.X - start.X) * amount);
            result.Y = start.Y + ((end.Y - start.Y) * amount);
        }

        public static Vector2 Lerp(Vector2 start, Vector2 end, float amount)
        {
            Vector2 result;
            Lerp(ref start, ref end, amount, out result);
            return result;
        }

        public static void Min(ref Vector2 left, ref Vector2 right, out Vector2 result)
        {
            result.X = (left.X < right.X) ? left.X : right.X;
            result.Y = (left.Y < right.Y) ? left.Y : right.Y;
        }

        public static Vector2 Min(Vector2 left, Vector2 right)
        {
            Vector2 result;
            Min(ref left, ref right, out result);
            return result;
        }

        public static void Max(ref Vector2 left, ref Vector2 right, out Vector2 result)
        {
            result.X = (left.X > right.X) ? left.X : right.X;
            result.Y = (left.Y > right.Y) ? left.Y : right.Y;
        }

        public static Vector2 Max(Vector2 left, Vector2 right)
        {
            Vector2 result;
            Max(ref left, ref right, out result);
            return result;
        }

        public static void Normalize(ref Vector2 vector, out Vector2 result)
        {
            Vector2 temp = vector;
            result = vector;
            result.Normalize();
        }

        public static Vector2 Normalize(Vector2 vector)
        {
            vector.Normalize();
            return vector;
        }

        public static void Reflect(ref Vector2 vector, ref Vector2 normal, out Vector2 result)
        {
            float dot = (vector.X * normal.X) + (vector.Y * normal.Y);

            result.X = vector.X - ((2.0f * dot) * normal.X);
            result.Y = vector.Y - ((2.0f * dot) * normal.Y);
        }

        public static Vector2 Reflect(Vector2 vector, Vector2 normal)
        {
            Vector2 result;
            Reflect(ref vector, ref normal, out result);
            return result;
        }

        public static void SmoothStep(ref Vector2 start, ref Vector2 end, float amount, out Vector2 result)
        {
            amount = (amount > 1.0f) ? 1.0f : ((amount < 0.0f) ? 0.0f : amount);
            amount = (amount * amount) * (3.0f - (2.0f * amount));

            result.X = start.X + ((end.X - start.X) * amount);
            result.Y = start.Y + ((end.Y - start.Y) * amount);
        }

        public static Vector2 SmoothStep(Vector2 start, Vector2 end, float amount)
        {
            Vector2 result;
            SmoothStep(ref start, ref end, amount, out result);
            return result;
        }

        public static void Transform(ref Vector2 vector, ref Quaternion rotation, out Vector2 result)
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

            result = new Vector2((vector.X * (1.0f - yy - zz)) + (vector.Y * (xy - wz)), (vector.X * (xy + wz)) + (vector.Y * (1.0f - xx - zz)));
        }

        public static Vector2 Transform(Vector2 vector, Quaternion rotation)
        {
            Vector2 result;
            Transform(ref vector, ref rotation, out result);
            return result;
        }

        public static void Transform(ref Vector2 vector, ref Matrix transform, out Vector4 result)
        {
            result = new Vector4(
                (vector.X * transform.M11) + (vector.Y * transform.M21) + transform.M41,
                (vector.X * transform.M12) + (vector.Y * transform.M22) + transform.M42,
                (vector.X * transform.M13) + (vector.Y * transform.M23) + transform.M43,
                (vector.X * transform.M14) + (vector.Y * transform.M24) + transform.M44);
        }

        public static Vector4 Transform(Vector2 vector, Matrix transform)
        {
            Vector4 result;
            Transform(ref vector, ref transform, out result);
            return result;
        }

        public static void TransformCoordinate(ref Vector2 coordinate, ref Matrix transform, out Vector2 result)
        {
            Vector4 vector = new Vector4();
            vector.X = (coordinate.X * transform.M11) + (coordinate.Y * transform.M21) + transform.M41;
            vector.Y = (coordinate.X * transform.M12) + (coordinate.Y * transform.M22) + transform.M42;
            vector.Z = (coordinate.X * transform.M13) + (coordinate.Y * transform.M23) + transform.M43;
            vector.W = 1 / ((coordinate.X * transform.M14) + (coordinate.Y * transform.M24) + transform.M44);

            result = new Vector2(vector.X * vector.W, vector.Y * vector.W);
        }

        public static Vector2 TransformCoordinate(Vector2 coordinate, Matrix transform)
        {
            Vector2 result;
            TransformCoordinate(ref coordinate, ref transform, out result);
            return result;
        }

        public static void TransformNormal(ref Vector2 normal, ref Matrix transform, out Vector2 result)
        {
            result = new Vector2(
                (normal.X * transform.M11) + (normal.Y * transform.M21),
                (normal.X * transform.M12) + (normal.Y * transform.M22));
        }

        public static Vector2 TransformNormal(Vector2 normal, Matrix transform)
        {
            Vector2 result;
            TransformNormal(ref normal, ref transform, out result);
            return result;
        }

        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
        }

        public static Vector2 operator -(Vector2 value)
        {
            return new Vector2(-value.X, -value.Y);
        }

        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X - right.X, left.Y - right.Y);
        }

        public static Vector2 operator *(float scale, Vector2 vector)
        {
            return new Vector2(vector.X * scale, vector.Y * scale);
        }

        public static Vector2 operator *(Vector2 vector, float scale)
        {
            return new Vector2(vector.X * scale, vector.Y * scale);
        }

        public static Vector2 operator /(Vector2 vector, float scale)
        {
            return new Vector2(vector.X / scale, vector.Y / scale);
        }

        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return Equals(ref left, ref right);
        }

        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !Equals(ref left, ref right);
        }

        public static explicit operator Vector3(Vector2 value)
        {
            return new Vector3(value, 0.0f);
        }

        public static explicit operator Vector4(Vector2 value)
        {
            return new Vector4(value, 0.0f, 0.0f);
        }

        public static explicit operator Vector2(float[] values)
        {
            return new Vector2(values);
        }

        public static implicit operator float[](Vector2 value)
        {
            return value.ToArray();
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", X, Y);
        }

        public string ToString(string format)
        {
            return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", X.ToString(format, CultureInfo.CurrentCulture), Y.ToString(format, CultureInfo.CurrentCulture));
        }

        public string ToString(IFormatProvider formatProvider)
        {
            return string.Format(formatProvider, "X:{0} Y:{1}", X, Y);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format(formatProvider, "X:{0} Y:{1}", X.ToString(format, formatProvider), Y.ToString(format, formatProvider));
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        public static bool Equals(ref Vector2 value1, ref Vector2 value2)
        {
            return (value1.X == value2.X && value1.Y == value2.Y);
        }

        public bool Equals(Vector2 value)
        {
            return (X == value.X && Y == value.Y);
        }

        public override bool Equals(object value)
        {
            if (value == null)
                return false;

            if (value.GetType() != GetType())
                return false;

            return Equals((Vector2)value);
        }
    }
}
