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
    public struct Quaternion : IEquatable<Quaternion>
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public Quaternion(Vector3 value, float w)
        {
            X = value.X;
            Y = value.Y;
            Z = value.Z;
            W = w;
        }

        public Quaternion(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static Quaternion Identity
        {
            get
            {
                Quaternion result = new Quaternion();
                result.X = 0.0f;
                result.Y = 0.0f;
                result.Z = 0.0f;
                result.W = 1.0f;
                return result;
            }
        }

        [Browsable(false)]
        public bool IsIdentity
        {
            get
            {
                if (X != 0.0f || Y != 0.0f || Z != 0.0f)
                    return false;

                return (W == 1.0f);
            }
        }

        /*public Vector3 Axis
        {
            get
            {
            }
        }

        public float Angle
        {
            get
            {
            }
        }*/

        public float Length()
        {
            return (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z) + (W * W));
        }

        public float LengthSquared()
        {
            return (X * X) + (Y * Y) + (Z * Z) + (W * W);
        }

        public static void Normalize(ref Quaternion quaternion, out Quaternion result)
        {
            float length = 1.0f / quaternion.Length();
            result.X = quaternion.X * length;
            result.Y = quaternion.Y * length;
            result.Z = quaternion.Z * length;
            result.W = quaternion.W * length;
        }

        public static Quaternion Normalize(Quaternion quaternion)
        {
            quaternion.Normalize();
            return quaternion;
        }

        public void Normalize()
        {
            float length = 1.0f / Length();
            X *= length;
            Y *= length;
            Z *= length;
            W *= length;
        }

        public static void Conjugate(ref Quaternion quaternion, out Quaternion result)
        {
            result.X = -quaternion.X;
            result.Y = -quaternion.Y;
            result.Z = -quaternion.Z;
            result.W = quaternion.W;
        }

        public static Quaternion Conjugate(Quaternion quaternion)
        {
            Quaternion result;
            Conjugate(ref quaternion, out result);
            return result;
        }

        public void Conjugate()
        {
            X = -X;
            Y = -Y;
            Z = -Z;
        }

        public static void Invert(ref Quaternion quaternion, out Quaternion result)
        {
            float lengthSq = 1.0f / ((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y) + (quaternion.Z * quaternion.Z) + (quaternion.W * quaternion.W));

            result.X = -quaternion.X * lengthSq;
            result.Y = -quaternion.Y * lengthSq;
            result.Z = -quaternion.Z * lengthSq;
            result.W = quaternion.W * lengthSq;
        }

        public static Quaternion Invert(Quaternion quaternion)
        {
            Quaternion result;
            Invert(ref quaternion, out result);
            return result;
        }

        public void Invert()
        {
            float lengthSq = 1.0f / ((X * X) + (Y * Y) + (Z * Z) + (W * W));
            X = -X * lengthSq;
            Y = -Y * lengthSq;
            Z = -Z * lengthSq;
            W = W * lengthSq;
        }

        public static void Add(ref Quaternion left, ref Quaternion right, out Quaternion result)
        {
            result.X = left.X + right.X;
            result.Y = left.Y + right.Y;
            result.Z = left.Z + right.Z;
            result.W = left.W + right.W;
        }

        public static Quaternion Add(Quaternion left, Quaternion right)
        {
            Quaternion result;
            Add(ref left, ref right, out result);
            return result;
        }

        public static void Subtract(ref Quaternion left, ref Quaternion right, out Quaternion result)
        {
            result.X = left.X - right.X;
            result.Y = left.Y - right.Y;
            result.Z = left.Z - right.Z;
            result.W = left.W - right.W;
        }

        public static Quaternion Subtract(Quaternion left, Quaternion right)
        {
            Quaternion result;
            Subtract(ref left, ref right, out result);
            return result;
        }

        //public static void Barycentric(ref Quaternion source1, ref Quaternion source2, ref Quaternion source3, float weight1, float weight2, out Quaternion result)
        //{
        //}

        //public static Quaternion Barycentric(Quaternion source1, Quaternion source2, Quaternion source3, float weight1, float weight2)
        //{
        //}

        public static void Divide(ref Quaternion left, ref Quaternion right, out Quaternion result)
        {
            result.X = left.X / right.X;
            result.Y = left.Y / right.Y;
            result.Z = left.Z / right.Z;
            result.W = left.W / right.W;
        }

        public static Quaternion Divide(Quaternion left, Quaternion right)
        {
            Quaternion result;
            Divide(ref left, ref right, out result);
            return result;
        }

        public static float Dot(Quaternion left, Quaternion right)
        {
            return (left.X * right.X) + (left.Y * right.Y) + (left.Z * right.Z) + (left.W * right.W);
        }

        //public static void Exponential(ref Quaternion quaternion, out Quaternion result)
        //{
        //}

        //public static Quaternion Exponential(Quaternion quaternion)
        //{
        //}

        public static void Lerp(ref Quaternion start, ref Quaternion end, float amount, out Quaternion result)
        {
            float inverse = 1.0f - amount;
            float dot = (start.X * end.X) + (start.Y * end.Y) + (start.Z * end.Z) + (start.W * end.W);

            if (dot >= 0.0f)
            {
                result.X = (inverse * start.X) + (amount * end.X);
                result.Y = (inverse * start.Y) + (amount * end.Y);
                result.Z = (inverse * start.Z) + (amount * end.Z);
                result.W = (inverse * start.W) + (amount * end.W);
            }
            else
            {
                result.X = (inverse * start.X) - (amount * end.X);
                result.Y = (inverse * start.Y) - (amount * end.Y);
                result.Z = (inverse * start.Z) - (amount * end.Z);
                result.W = (inverse * start.W) - (amount * end.W);
            }

            float invLength = 1.0f / result.Length();

            result.X *= invLength;
            result.Y *= invLength;
            result.Z *= invLength;
            result.W *= invLength;
        }

        public static Quaternion Lerp(Quaternion start, Quaternion end, float amount)
        {
            Quaternion result;
            Lerp(ref start, ref end, amount, out result);
            return result;
        }

        //public static void Logarithm(ref Quaternion quaternion, out Quaternion result)
        //{
        //}

        //public static Quaternion Logarithm(Quaternion quaternion)
        //{
        //}

        public static void Multiply(ref Quaternion quaternion, float scale, out Quaternion result)
        {
            result.X = quaternion.X * scale;
            result.Y = quaternion.Y * scale;
            result.Z = quaternion.Z * scale;
            result.W = quaternion.W * scale;
        }

        public static Quaternion Multiply(Quaternion quaternion, float scale)
        {
            Quaternion result;
            Multiply(ref quaternion, scale, out result);
            return result;
        }

        public static void Multiply(ref Quaternion left, ref Quaternion right, out Quaternion result)
        {
            float lx = left.X;
            float ly = left.Y;
            float lz = left.Z;
            float lw = left.W;
            float rx = right.X;
            float ry = right.Y;
            float rz = right.Z;
            float rw = right.W;

            result.X = (((lx * rw) + (rx * lw)) + (ly * rz)) - (lz * ry);
            result.Y = (((ly * rw) + (ry * lw)) + (lz * rx)) - (lx * rz);
            result.Z = (((lz * rw) + (rz * lw)) + (lx * ry)) - (ly * rx);
            result.W = (lw * rw) - (((lx * rx) + (ly * ry)) + (lz * rz));
        }

        public static Quaternion Multiply(Quaternion left, Quaternion right)
        {
            Quaternion result;
            Multiply(ref left, ref right, out result);
            return result;
        }

        public static void Negate(ref Quaternion quaternion, out Quaternion result)
        {
            result.X = -quaternion.X;
            result.Y = -quaternion.Y;
            result.Z = -quaternion.Z;
            result.W = -quaternion.W;
        }

        public static Quaternion Negate(Quaternion quaternion)
        {
            Quaternion result;
            Negate(ref quaternion, out result);
            return result;
        }

        public static void RotationAxis(ref Vector3 axis, float angle, out Quaternion result)
        {
            axis.Normalize();

            float half = angle * 0.5f;
            float sin = (float)Math.Sin(half);
            float cos = (float)Math.Cos(half);

            result.X = axis.X * sin;
            result.Y = axis.Y * sin;
            result.Z = axis.Z * sin;
            result.W = cos;
        }

        public static Quaternion RotationAxis(Vector3 axis, float angle)
        {
            Quaternion result;
            RotationAxis(ref axis, angle, out result);
            return result;
        }

        public static void RotationMatrix(ref Matrix matrix, out Quaternion result)
        {
            float sqrt;
            float half;
            float scale = matrix.M11 + matrix.M22 + matrix.M33;

            if (scale > 0.0f)
            {
                sqrt = (float)Math.Sqrt(scale + 1.0f);

                result.W = sqrt * 0.5f;
                sqrt = 0.5f / sqrt;

                result.X = (matrix.M23 - matrix.M32) * sqrt;
                result.Y = (matrix.M31 - matrix.M13) * sqrt;
                result.Z = (matrix.M12 - matrix.M21) * sqrt;
                return;
            }

            if ((matrix.M11 >= matrix.M22) && (matrix.M11 >= matrix.M33))
            {
                sqrt = (float)Math.Sqrt(1.0f + matrix.M11 - matrix.M22 - matrix.M33);
                half = 0.5f / sqrt;

                result.X = 0.5f * sqrt;
                result.Y = (matrix.M12 + matrix.M21) * half;
                result.Z = (matrix.M13 + matrix.M31) * half;
                result.W = (matrix.M23 - matrix.M32) * half;
                return;
            }

            if (matrix.M22 > matrix.M33)
            {
                sqrt = (float)Math.Sqrt(1.0f + matrix.M22 - matrix.M11 - matrix.M33);
                half = 0.5f / sqrt;

                result.X = (matrix.M21 + matrix.M12) * half;
                result.Y = 0.5f * sqrt;
                result.Z = (matrix.M32 + matrix.M23) * half;
                result.W = (matrix.M31 - matrix.M13) * half;
                return;
            }

            sqrt = (float)Math.Sqrt(1.0f + matrix.M33 - matrix.M11 - matrix.M22);
            half = 0.5f / sqrt;

            result.X = (matrix.M31 + matrix.M13) * half;
            result.Y = (matrix.M32 + matrix.M23) * half;
            result.Z = 0.5f * sqrt;
            result.W = (matrix.M12 - matrix.M21) * half;
        }

        public static Quaternion RotationMatrix(Matrix matrix)
        {
            Quaternion result;
            RotationMatrix(ref matrix, out result);
            return result;
        }

        public static void RotationYawPitchRoll(float yaw, float pitch, float roll, out Quaternion result)
        {
            float halfRoll = roll * 0.5f;
            float sinRoll = (float)Math.Sin(halfRoll);
            float cosRoll = (float)Math.Cos(halfRoll);
            float halfPitch = pitch * 0.5f;
            float sinPitch = (float)Math.Sin(halfPitch);
            float cosPitch = (float)Math.Cos(halfPitch);
            float halfYaw = yaw * 0.5f;
            float sinYaw = (float)Math.Sin(halfYaw);
            float cosYaw = (float)Math.Cos(halfYaw);

            result.X = (cosYaw * sinPitch * cosRoll) + (sinYaw * cosPitch * sinRoll);
            result.Y = (sinYaw * cosPitch * cosRoll) - (cosYaw * sinPitch * sinRoll);
            result.Z = (cosYaw * cosPitch * sinRoll) - (sinYaw * sinPitch * cosRoll);
            result.W = (cosYaw * cosPitch * cosRoll) + (sinYaw * sinPitch * sinRoll);
        }

        public static Quaternion RotationYawPitchRoll(float yaw, float pitch, float roll)
        {
            Quaternion result;
            RotationYawPitchRoll(yaw, pitch, roll, out result);
            return result;
        }

        public static void Slerp(ref Quaternion start, ref Quaternion end, float amount, out Quaternion result)
        {
            float opposite;
            float inverse;
            float dot = (start.X * end.X) + (start.Y * end.Y) + (start.Z * end.Z) + (start.W * end.W);
            bool flag = false;

            if (dot < 0.0f)
            {
                flag = true;
                dot = -dot;
            }

            if (dot > 0.999999f)
            {
                inverse = 1.0f - amount;
                opposite = flag ? -amount : amount;
            }
            else
            {
                float acos = (float)Math.Acos(dot);
                float invSin = (float)(1.0 / Math.Sin(acos));

                inverse = ((float)Math.Sin((1.0f - amount) * acos)) * invSin;
                opposite = flag ? (((float)-Math.Sin(amount * acos)) * invSin) : (((float)Math.Sin(amount * acos)) * invSin);
            }

            result.X = (inverse * start.X) + (opposite * end.X);
            result.Y = (inverse * start.Y) + (opposite * end.Y);
            result.Z = (inverse * start.Z) + (opposite * end.Z);
            result.W = (inverse * start.W) + (opposite * end.W);
        }

        public static Quaternion Slerp(Quaternion start, Quaternion end, float amount)
        {
            Quaternion result;
            Slerp(ref start, ref end, amount, out result);
            return result;
        }

        //public static void Squad(ref Quaternion source1, ref Quaternion source2, ref Quaternion source3, ref Quaternion source4, float amount, out Quaternion result)
        //{
        //}

        //public static Quaternion Squad(Quaternion source1, Quaternion source2, Quaternion source3, Quaternion source4, float amount)
        //{
        //}

        //public static Quaternion[] SquadSetup(Quaternion source1, Quaternion source2, Quaternion source3, Quaternion source4)
        //{
        //}

        public static Quaternion operator *(float scale, Quaternion quaternion)
        {
            Quaternion result;
            Multiply(ref quaternion, scale, out result);
            return result;
        }

        public static Quaternion operator *(Quaternion quaternion, float scale)
        {
            Quaternion result;
            Multiply(ref quaternion, scale, out result);
            return result;
        }

        public static Quaternion operator *(Quaternion left, Quaternion right)
        {
            Quaternion result;
            Multiply(ref left, ref right, out result);
            return result;
        }

        //public static Quaternion operator /(Quaternion left, float right)
        //{
        //    Quaternion result;
        //    Divide(ref left, right, out result);
        //    return result;
        //}

        public static Quaternion operator +(Quaternion left, Quaternion right)
        {
            Quaternion result;
            Add(ref left, ref right, out result);
            return result;
        }

        public static Quaternion operator -(Quaternion quaternion)
        {
            Quaternion result;
            Negate(ref quaternion, out result);
            return result;
        }

        public static Quaternion operator -(Quaternion left, Quaternion right)
        {
            Quaternion result;
            Subtract(ref left, ref right, out result);
            return result;
        }

        public static bool operator ==(Quaternion left, Quaternion right)
        {
            return Equals(ref left, ref right);
        }

        public static bool operator !=(Quaternion left, Quaternion right)
        {
            return !Equals(ref left, ref right);
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1} Z:{2} W:{3}", X.ToString(CultureInfo.CurrentCulture), 
                Y.ToString(CultureInfo.CurrentCulture), Z.ToString(CultureInfo.CurrentCulture), W.ToString(CultureInfo.CurrentCulture));
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode() + W.GetHashCode();
        }

        public static bool Equals(ref Quaternion value1, ref Quaternion value2)
        {
            return (value1.X == value2.X && value1.Y == value2.Y && value1.Z == value2.Z && value1.W == value2.W);
        }

        public bool Equals(Quaternion value)
        {
            return (X == value.X && Y == value.Y && Z == value.Z && W == value.W);
        }

        public override bool Equals(object value)
        {
            if (value == null)
                return false;

            if (value.GetType() != GetType())
                return false;

            return Equals((Quaternion)value);
        }
    }
}
