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
#include "stdafx.h"
#include "Asserts.h"
#include "TestValues.h"

using namespace testing;
using namespace System;
using namespace SlimMath;

// ----- CONSTRUCTOR TESTS ----- //

TEST(Vector4Tests, ConstructDefault)
{
	Vector4 vector = Vector4();

	ASSERT_EQ(0.0f, vector.X);
	ASSERT_EQ(0.0f, vector.Y);
	ASSERT_EQ(0.0f, vector.Z);
	ASSERT_EQ(0.0f, vector.W);
}

TEST(Vector4Tests, ConstructWithX)
{
	Vector4 vector = Vector4(0.75f);

	ASSERT_EQ(0.75f, vector.X);
	ASSERT_EQ(0.75f, vector.Y);
	ASSERT_EQ(0.75f, vector.Z);
	ASSERT_EQ(0.75f, vector.W);
}

TEST(Vector4Tests, ConstructWithXYZW)
{
	Vector4 vector = Vector4(0.75f, 1.25f, 1.75f, 2.25f);

	ASSERT_EQ(0.75f, vector.X);
	ASSERT_EQ(1.25f, vector.Y);
	ASSERT_EQ(1.75f, vector.Z);
	ASSERT_EQ(2.25f, vector.W);
}

TEST(Vector4Tests, ConstructWithVector2)
{
	Vector2 source = Vector2(1.0f, 2.0f);
	Vector4 vector = Vector4(source, 3.0f, 4.0f);

	ASSERT_EQ(1.0f, vector.X);
	ASSERT_EQ(2.0f, vector.Y);
	ASSERT_EQ(3.0f, vector.Z);
	ASSERT_EQ(4.0f, vector.W);
}

TEST(Vector4Tests, ConstructWithVector3)
{
	Vector3 source = Vector3(1.0f, 2.0f, 3.0f);
	Vector4 vector = Vector4(source, 4.0f);

	ASSERT_EQ(1.0f, vector.X);
	ASSERT_EQ(2.0f, vector.Y);
	ASSERT_EQ(3.0f, vector.Z);
	ASSERT_EQ(4.0f, vector.W);
}

// ----- PROPERTY TESTS ----- //

TEST(Vector4Tests, SizeInBytes)
{
	ASSERT_EQ(Vector4::SizeInBytes, 16);
}

TEST(Vector4Tests, ZeroVector)
{
	Vector4 vector = Vector4::Zero;

	ASSERT_EQ(vector.X, 0.0f);
	ASSERT_EQ(vector.Y, 0.0f);
	ASSERT_EQ(vector.Z, 0.0f);
	ASSERT_EQ(vector.W, 0.0f);
}

TEST(Vector4Tests, UnitXVector)
{
	Vector4 vector = Vector4::UnitX;

	ASSERT_EQ(vector.X, 1.0f);
	ASSERT_EQ(vector.Y, 0.0f);
	ASSERT_EQ(vector.Z, 0.0f);
	ASSERT_EQ(vector.W, 0.0f);
}

TEST(Vector4Tests, UnitYVector)
{
	Vector4 vector = Vector4::UnitY;

	ASSERT_EQ(vector.X, 0.0f);
	ASSERT_EQ(vector.Y, 1.0f);
	ASSERT_EQ(vector.Z, 0.0f);
	ASSERT_EQ(vector.W, 0.0f);
}

TEST(Vector4Tests, UnitZVector)
{
	Vector4 vector = Vector4::UnitZ;

	ASSERT_EQ(vector.X, 0.0f);
	ASSERT_EQ(vector.Y, 0.0f);
	ASSERT_EQ(vector.Z, 1.0f);
	ASSERT_EQ(vector.W, 0.0f);
}

TEST(Vector4Tests, UnitWVector)
{
	Vector4 vector = Vector4::UnitW;

	ASSERT_EQ(vector.X, 0.0f);
	ASSERT_EQ(vector.Y, 0.0f);
	ASSERT_EQ(vector.Z, 0.0f);
	ASSERT_EQ(vector.W, 1.0f);
}

TEST(Vector4Tests, IndexerGet)
{
	float x, y, z, w;
	Vector4 vector(1.0f, 2.0f, 3.0f, 4.0f);

	ASSERT_NO_THROW(x = vector[0]);
	ASSERT_NO_THROW(y = vector[1]);
	ASSERT_NO_THROW(z = vector[2]);
	ASSERT_NO_THROW(w = vector[3]);

	ASSERT_EQ(x, 1.0f);
	ASSERT_EQ(y, 2.0f);
	ASSERT_EQ(z, 3.0f);
	ASSERT_EQ(w, 4.0f);
}

TEST(Vector4Tests, IndexerGetOutOfRange)
{
	float x;
	Vector4 vector(1.0f, 2.0f, 3.0f, 4.0f);

	ASSERT_MANAGED_THROW(x = vector[-1], ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW(x = vector[4], ArgumentOutOfRangeException);
}

TEST(Vector4Tests, IndexerSet)
{
	Vector4 vector(1.0f, 2.0f, 3.0f, 4.0f);

	ASSERT_NO_THROW(vector[0] = 1.5f);
	ASSERT_NO_THROW(vector[1] = 2.5f);
	ASSERT_NO_THROW(vector[2] = 3.5f);
	ASSERT_NO_THROW(vector[3] = 4.5f);

	ASSERT_EQ(vector.X, 1.5f);
	ASSERT_EQ(vector.Y, 2.5f);
	ASSERT_EQ(vector.Z, 3.5f);
	ASSERT_EQ(vector.W, 4.5f);
}

TEST(Vector4Tests, IndexerSetOutOfRange)
{
	Vector4 vector(1.0f, 2.0f, 3.0f, 4.0f);

	ASSERT_MANAGED_THROW(vector[-1] = 5.0f, ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW(vector[4] = 5.0f, ArgumentOutOfRangeException);
}

// ----- METHOD TESTS ----- //

TEST(Vector4Tests, Length)
{
	Vector4 value(1.5f, 2.5f, 3.5f, 4.5f);

	float length1 = D3DXVec4Length(reinterpret_cast<D3DXVECTOR4*>(&value));
	float length2 = value.Length();

	ASSERT_EQ(length1, length2);
}

TEST(Vector4Tests, LengthSquared)
{
	Vector4 value(1.5f, 2.5f, 3.5f, 4.5f);

	float length1 = D3DXVec4LengthSq(reinterpret_cast<D3DXVECTOR4*>(&value));
	float length2 = value.LengthSquared();

	ASSERT_EQ(length1, length2);
}

TEST(Vector4Tests, Normalize)
{
	Vector4 value(1.5f, 2.5f, 3.5f, 4.5f);
	value.Normalize();

	D3DXVECTOR4 result1;
	D3DXVec4Normalize(&result1, reinterpret_cast<D3DXVECTOR4*>(&value));

	AssertEq(result1, value);
}

TEST(Vector4Tests, NormalizeZeroVector)
{
	Vector4 vector = Vector4(0.0f);
	vector.Normalize();

	ASSERT_EQ(0.0f, vector.X);
	ASSERT_EQ(0.0f, vector.Y);
	ASSERT_EQ(0.0f, vector.Z);
	ASSERT_EQ(0.0f, vector.W);
}

TEST(Vector4Tests, NormalizeStatic)
{
	Vector4 value(1.5f, 2.5f, 3.5f, 4.5f);

	D3DXVECTOR4 result1;
	D3DXVec4Normalize(&result1, reinterpret_cast<D3DXVECTOR4*>(&value));

	Vector4 result2 = Vector4::Normalize(value);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, NormalizeStaticByRef)
{
	Vector4 value(1.5f, 2.5f, 3.5f, 4.5f);

	D3DXVECTOR4 result1;
	D3DXVec4Normalize(&result1, reinterpret_cast<D3DXVECTOR4*>(&value));

	Vector4 result2;
	Vector4::Normalize(value, result2);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, Add)
{
	Vector4 vector1 = Vector4(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 vector2 = Vector4(5.0f, 6.0f, 7.0f, 8.0f);

	D3DXVECTOR4 result1;
	D3DXVec4Add(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector1), reinterpret_cast<D3DXVECTOR4*>(&vector2));

	Vector4 result2 = Vector4::Add(vector1, vector2);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, AddByRef)
{
	Vector4 vector1 = Vector4(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 vector2 = Vector4(5.0f, 6.0f, 7.0f, 8.0f);

	D3DXVECTOR4 result1;
	D3DXVec4Add(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector1), reinterpret_cast<D3DXVECTOR4*>(&vector2));

	Vector4 result2;
	Vector4::Add(vector1, vector2, result2);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, Subtract)
{
	Vector4 vector1 = Vector4(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 vector2 = Vector4(5.0f, 6.0f, 7.0f, 8.0f);

	D3DXVECTOR4 result1;
	D3DXVec4Subtract(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector1), reinterpret_cast<D3DXVECTOR4*>(&vector2));

	Vector4 result2 = Vector4::Subtract(vector1, vector2);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, SubtractByRef)
{
	Vector4 vector1 = Vector4(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 vector2 = Vector4(5.0f, 6.0f, 7.0f, 8.0f);

	D3DXVECTOR4 result1;
	D3DXVec4Subtract(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector1), reinterpret_cast<D3DXVECTOR4*>(&vector2));

	Vector4 result2;
	Vector4::Subtract(vector1, vector2, result2);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, Multiply)
{
	Vector4 vector1 = Vector4(1.0f, 2.0f, 3.0f, 4.0f);
	float amount = 2.5f;

	D3DXVECTOR4 result1;
	D3DXVec4Scale(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector1), amount);

	Vector4 result2 = Vector4::Multiply(vector1, amount);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, MultiplyByRef)
{
	Vector4 vector1 = Vector4(1.0f, 2.0f, 3.0f, 4.0f);
	float amount = 2.5f;

	D3DXVECTOR4 result1;
	D3DXVec4Scale(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector1), amount);

	Vector4 result2;
	Vector4::Multiply(vector1, amount, result2);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, Modulate)
{
	Vector4 vector1 = Vector4(2.0f, 3.0f, 1.0f, 1.5f);
	Vector4 vector2 = Vector4(4.0f, 5.0f, 1.0f, 0.0f);
	Vector4 result = Vector4::Modulate(vector1, vector2);

	ASSERT_EQ(8.0f, result.X);
	ASSERT_EQ(15.0f, result.Y);
	ASSERT_EQ(1.0f, result.Z);
	ASSERT_EQ(0.0f, result.W);
}

TEST(Vector4Tests, ModulateByRef)
{
	Vector4 vector1 = Vector4(2.0f, 3.0f, 1.0f, 1.5f);
	Vector4 vector2 = Vector4(4.0f, 5.0f, 1.0f, 0.0f);
	Vector4 result;
	Vector4::Modulate(vector1, vector2, result);

	ASSERT_EQ(8.0f, result.X);
	ASSERT_EQ(15.0f, result.Y);
	ASSERT_EQ(1.0f, result.Z);
	ASSERT_EQ(0.0f, result.W);
}

TEST(Vector4Tests, Divide)
{
	Vector4 vector1 = Vector4(1.0f, 2.0f, 3.0f, 4.0f);
	float amount = 2.5f;

	D3DXVECTOR4 result1;
	D3DXVec4Scale(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector1), 1.0f / amount);

	Vector4 result2 = Vector4::Divide(vector1, amount);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, DivideByRef)
{
	Vector4 vector1 = Vector4(1.0f, 2.0f, 3.0f, 4.0f);
	float amount = 2.5f;

	D3DXVECTOR4 result1;
	D3DXVec4Scale(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector1), 1.0f / amount);

	Vector4 result2;
	Vector4::Divide(vector1, amount, result2);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, Negate)
{
	Vector4 vector = Vector4(1.0f, -2.0f, 3.0f, -4.0f);
	Vector4 result = Vector4::Negate(vector);

	ASSERT_EQ(result.X, -1.0f);
	ASSERT_EQ(result.Y, 2.0f);
	ASSERT_EQ(result.Z, -3.0f);
	ASSERT_EQ(result.W, 4.0f);
}

TEST(Vector4Tests, NegateByRef)
{
	Vector4 vector = Vector4(1.0f, -2.0f, 3.0f, -4.0f);
	Vector4 result;
	Vector4::Negate(vector, result);

	ASSERT_EQ(result.X, -1.0f);
	ASSERT_EQ(result.Y, 2.0f);
	ASSERT_EQ(result.Z, -3.0f);
	ASSERT_EQ(result.W, 4.0f);
}

TEST(Vector4Tests, Barycentric)
{
	Vector4 value1(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 value2(1.5f, 2.5f, 3.5f, 4.5f);
	Vector4 value3(1.75f, 2.75f, 3.75f, 4.75f);
	float amount1 = 2.0f;
	float amount2 = 3.0f;

	D3DXVECTOR4 result1;
	D3DXVec4BaryCentric(&result1, reinterpret_cast<D3DXVECTOR4*>(&value1), reinterpret_cast<D3DXVECTOR4*>(&value2), reinterpret_cast<D3DXVECTOR4*>(&value3), amount1, amount2);

	Vector4 result2 = Vector4::Barycentric(value1, value2, value3, amount1, amount2);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, BarycentricByRef)
{
	Vector4 value1(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 value2(1.5f, 2.5f, 3.5f, 4.5f);
	Vector4 value3(1.75f, 2.75f, 3.75f, 4.75f);
	float amount1 = 2.0f;
	float amount2 = 3.0f;

	D3DXVECTOR4 result1;
	D3DXVec4BaryCentric(&result1, reinterpret_cast<D3DXVECTOR4*>(&value1), reinterpret_cast<D3DXVECTOR4*>(&value2), reinterpret_cast<D3DXVECTOR4*>(&value3), amount1, amount2);

	Vector4 result2;
	Vector4::Barycentric(value1, value2, value3, amount1, amount2, result2);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, CatmullRom)
{
	Vector4 value1(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 value2(1.5f, 2.5f, 3.5f, 4.5f);
	Vector4 value3(1.75f, 2.75f, 3.75f, 4.75f);
	Vector4 value4(1.25f, 2.25f, 3.25f, 4.25f);
	float amount = 2.5f;

	D3DXVECTOR4 result1;
	D3DXVec4CatmullRom(&result1, reinterpret_cast<D3DXVECTOR4*>(&value1), reinterpret_cast<D3DXVECTOR4*>(&value2), reinterpret_cast<D3DXVECTOR4*>(&value3), reinterpret_cast<D3DXVECTOR4*>(&value4), amount);

	Vector4 result2 = Vector4::CatmullRom(value1, value2, value3, value4, amount);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, CatmullRomByRef)
{
	Vector4 value1(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 value2(1.5f, 2.5f, 3.5f, 4.5f);
	Vector4 value3(1.75f, 2.75f, 3.75f, 4.75f);
	Vector4 value4(1.25f, 2.25f, 3.25f, 4.25f);
	float amount = 2.5f;

	D3DXVECTOR4 result1;
	D3DXVec4CatmullRom(&result1, reinterpret_cast<D3DXVECTOR4*>(&value1), reinterpret_cast<D3DXVECTOR4*>(&value2), reinterpret_cast<D3DXVECTOR4*>(&value3), reinterpret_cast<D3DXVECTOR4*>(&value4), amount);

	Vector4 result2;
	Vector4::CatmullRom(value1, value2, value3, value4, amount, result2);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, Clamp)
{
	Vector4 value(2.0f, 2.0f, 2.0f, 2.0f);
	Vector4 minimum(1.0f, 2.5f, 2.5f, 0.0f);
	Vector4 maximum(2.75f, 2.75f, 3.75f, 1.75f);

	Vector4 result = Vector4::Clamp(value, minimum, maximum);

	ASSERT_EQ(result.X, 2.0f);
	ASSERT_EQ(result.Y, 2.5f);
	ASSERT_EQ(result.Z, 2.5f);
	ASSERT_EQ(result.W, 1.75f);
}

TEST(Vector4Tests, ClampByRef)
{
	Vector4 value(2.0f, 2.0f, 2.0f, 2.0f);
	Vector4 minimum(1.0f, 2.5f, 2.5f, 0.0f);
	Vector4 maximum(2.75f, 2.75f, 3.75f, 1.75f);

	Vector4 result;
	Vector4::Clamp(value, minimum, maximum, result);

	ASSERT_EQ(result.X, 2.0f);
	ASSERT_EQ(result.Y, 2.5f);
	ASSERT_EQ(result.Z, 2.5f);
	ASSERT_EQ(result.W, 1.75f);
}

TEST(Vector4Tests, Hermite)
{
	Vector4 value1(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 value2(1.5f, 2.5f, 3.5f, 4.5f);
	Vector4 value3(1.75f, 2.75f, 3.75f, 4.75f);
	Vector4 value4(1.25f, 2.25f, 3.25f, 4.25f);
	float amount = 2.5f;

	D3DXVECTOR4 result1;
	D3DXVec4Hermite(&result1, reinterpret_cast<D3DXVECTOR4*>(&value1), reinterpret_cast<D3DXVECTOR4*>(&value2), reinterpret_cast<D3DXVECTOR4*>(&value3), reinterpret_cast<D3DXVECTOR4*>(&value4), amount);

	Vector4 result2 = Vector4::Hermite(value1, value2, value3, value4, amount);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, HermiteByRef)
{
	Vector4 value1(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 value2(1.5f, 2.5f, 3.5f, 4.5f);
	Vector4 value3(1.75f, 2.75f, 3.75f, 4.75f);
	Vector4 value4(1.25f, 2.25f, 3.25f, 4.25f);
	float amount = 2.5f;

	D3DXVECTOR4 result1;
	D3DXVec4Hermite(&result1, reinterpret_cast<D3DXVECTOR4*>(&value1), reinterpret_cast<D3DXVECTOR4*>(&value2), reinterpret_cast<D3DXVECTOR4*>(&value3), reinterpret_cast<D3DXVECTOR4*>(&value4), amount);

	Vector4 result2;
	Vector4::Hermite(value1, value2, value3, value4, amount, result2);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, Lerp)
{
	Vector4 value1(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 value2(1.5f, 2.5f, 3.5f, 4.5f);
	float amount = 0.5f;

	D3DXVECTOR4 result1;
	D3DXVec4Lerp(&result1, reinterpret_cast<D3DXVECTOR4*>(&value1), reinterpret_cast<D3DXVECTOR4*>(&value2), amount);

	Vector4 result2 = Vector4::Lerp(value1, value2, amount);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, LerpByRef)
{
	Vector4 value1(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 value2(1.5f, 2.5f, 3.5f, 4.5f);
	float amount = 0.5f;

	D3DXVECTOR4 result1;
	D3DXVec4Lerp(&result1, reinterpret_cast<D3DXVECTOR4*>(&value1), reinterpret_cast<D3DXVECTOR4*>(&value2), amount);

	Vector4 result2;
	Vector4::Lerp(value1, value2, amount, result2);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, SmoothStep)
{
	Vector4 value1(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 value2(1.5f, 2.5f, 3.5f, 4.5f);
	float amount = 0.5f;

	Vector4 result = Vector4::SmoothStep(value1, value2, amount);

	ASSERT_EQ(result.X, 1.25f);
	ASSERT_EQ(result.Y, 2.25f);
	ASSERT_EQ(result.Z, 3.25f);
	ASSERT_EQ(result.W, 4.25f);
}

TEST(Vector4Tests, SmoothStepByRef)
{
	Vector4 value1(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 value2(1.5f, 2.5f, 3.5f, 4.5f);
	float amount = 0.5f;

	Vector4 result;
	Vector4::SmoothStep(value1, value2, amount, result);

	ASSERT_EQ(result.X, 1.25f);
	ASSERT_EQ(result.Y, 2.25f);
	ASSERT_EQ(result.Z, 3.25f);
	ASSERT_EQ(result.W, 4.25f);
}

TEST(Vector4Tests, Distance)
{
	Vector4 value1(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 value2(1.75f, 2.75f, 3.75f, 4.75f);

	float result = Vector4::Distance(value1, value2);

	ASSERT_EQ(result, 1.5f);
}

TEST(Vector4Tests, DistanceSquared)
{
	Vector4 value1(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 value2(1.75f, 2.75f, 3.75f, 4.75f);

	float result = Vector4::DistanceSquared(value1, value2);

	ASSERT_EQ(result, 2.25f);
}

TEST(Vector4Tests, Dot)
{
	Vector4 value1(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 value2(1.75f, 2.75f, 3.75f, 4.75f);

	float result1 = D3DXVec4Dot(reinterpret_cast<D3DXVECTOR4*>(&value1), reinterpret_cast<D3DXVECTOR4*>(&value2));
	float result2 = Vector4::Dot(value1, value2);

	ASSERT_EQ(result1, result2);
}

TEST(Vector4Tests, TransformByQuat)
{
	Vector4 vector(1.0f, 2.0f, 3.0f, 4.0f);
	Quaternion quat(0.5f, 1.5f, 2.5f, 3.5f);

	Vector4 result = Vector4::Transform(vector, quat);

	ASSERT_EQ(result.X, -9.0f);		// values otained from XNA GS math lib
	ASSERT_EQ(result.Y, 7.0f);
	ASSERT_EQ(result.Z, 2.0f);
	ASSERT_EQ(result.W, 4.0f);
}

TEST(Vector4Tests, TransformByQuatByRef)
{
	Vector4 vector(1.0f, 2.0f, 3.0f, 4.0f);
	Quaternion quat(0.5f, 1.5f, 2.5f, 3.5f);

	Vector4 result;
	Vector4::Transform(vector, quat, result);

	ASSERT_EQ(result.X, -9.0f);		// values otained from XNA GS math lib
	ASSERT_EQ(result.Y, 7.0f);
	ASSERT_EQ(result.Z, 2.0f);
	ASSERT_EQ(result.W, 4.0f);
}

TEST(Vector4Tests, TransformByMatrix)
{
	Vector4 vector(1.0f, 2.0f, 3.0f, 4.0f);
	Matrix matrix = CreateWorldMatrix();

	D3DXVECTOR4 result1;
	D3DXVec4Transform(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector), reinterpret_cast<D3DXMATRIX*>(&matrix));

	Vector4 result2 = Vector4::Transform(vector, matrix);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, TransformByMatrixByRef)
{
	Vector4 vector(1.0f, 2.0f, 3.0f, 4.0f);
	Matrix matrix = CreateWorldMatrix();

	D3DXVECTOR4 result1;
	D3DXVec4Transform(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector), reinterpret_cast<D3DXMATRIX*>(&matrix));

	Vector4 result2;
	Vector4::Transform(vector, matrix, result2);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, Min)
{
	Vector4 vector1(0.0f, 2.0f, 1.5f, 4.5f);
	Vector4 vector2(1.0f, 2.0f, 3.0f, 4.0f);

	D3DXVECTOR4 result1;
	D3DXVec4Minimize(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector1), reinterpret_cast<D3DXVECTOR4*>(&vector2));

	Vector4 result2 = Vector4::Min(vector1, vector2);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, MinByRef)
{
	Vector4 vector1(0.0f, 2.0f, 1.5f, 4.5f);
	Vector4 vector2(1.0f, 2.0f, 3.0f, 4.0f);

	D3DXVECTOR4 result1;
	D3DXVec4Minimize(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector1), reinterpret_cast<D3DXVECTOR4*>(&vector2));

	Vector4 result2;
	Vector4::Min(vector1, vector2, result2);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, Max)
{
	Vector4 vector1(0.0f, 2.0f, 1.5f, 4.5f);
	Vector4 vector2(1.0f, 2.0f, 3.0f, 4.0f);

	D3DXVECTOR4 result1;
	D3DXVec4Maximize(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector1), reinterpret_cast<D3DXVECTOR4*>(&vector2));

	Vector4 result2 = Vector4::Max(vector1, vector2);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, MaxeByRef)
{
	Vector4 vector1(0.0f, 2.0f, 1.5f, 4.5f);
	Vector4 vector2(1.0f, 2.0f, 3.0f, 4.0f);

	D3DXVECTOR4 result1;
	D3DXVec4Maximize(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector1), reinterpret_cast<D3DXVECTOR4*>(&vector2));

	Vector4 result2;
	Vector4::Max(vector1, vector2, result2);

	AssertEq(result1, result2);
}

// ----- OPERATOR TESTS ----- //

TEST(Vector4Tests, AddOperator)
{
	Vector4 vector1 = Vector4(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 vector2 = Vector4(5.0f, 6.0f, 7.0f, 8.0f);

	D3DXVECTOR4 result1;
	D3DXVec4Add(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector1), reinterpret_cast<D3DXVECTOR4*>(&vector2));

	Vector4 result2 = vector1 + vector2;

	AssertEq(result1, result2);
}

TEST(Vector4Tests, SubtractOperator)
{
	Vector4 vector1 = Vector4(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 vector2 = Vector4(5.0f, 6.0f, 7.0f, 8.0f);

	D3DXVECTOR4 result1;
	D3DXVec4Subtract(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector1), reinterpret_cast<D3DXVECTOR4*>(&vector2));

	Vector4 result2 = vector1 - vector2;

	AssertEq(result1, result2);
}

TEST(Vector4Tests, MultiplyOperatorScalarOnLeft)
{
	Vector4 vector1 = Vector4(1.0f, 2.0f, 3.0f, 4.0f);
	float amount = 2.5f;

	D3DXVECTOR4 result1;
	D3DXVec4Scale(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector1), amount);

	Vector4 result2 = amount * vector1;

	AssertEq(result1, result2);
}

TEST(Vector4Tests, MultiplyOperatorScalarOnRight)
{
	Vector4 vector1 = Vector4(1.0f, 2.0f, 3.0f, 4.0f);
	float amount = 2.5f;

	D3DXVECTOR4 result1;
	D3DXVec4Scale(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector1), amount);

	Vector4 result2 = vector1 * amount;

	AssertEq(result1, result2);
}

TEST(Vector4Tests, DivideOperator)
{
	Vector4 vector1 = Vector4(1.0f, 2.0f, 3.0f, 4.0f);
	float amount = 2.5f;

	D3DXVECTOR4 result1;
	D3DXVec4Scale(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector1), 1.0f / amount);

	Vector4 result2 = vector1 / amount;

	AssertEq(result1, result2);
}

TEST(Vector4Tests, NegateOperator)
{
	Vector4 vector = Vector4(1.0f, -2.0f, 3.0f, -4.0f);
	Vector4 result = -vector;

	ASSERT_EQ(result.X, -1.0f);
	ASSERT_EQ(result.Y, 2.0f);
	ASSERT_EQ(result.Z, -3.0f);
	ASSERT_EQ(result.W, 4.0f);
}

TEST(Vector4Tests, EqualityOperator)
{
	Vector4 vector1(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 vector2(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 vector3(2.0f, 2.0f, 2.0f, 2.0f);

	ASSERT_TRUE(vector1 == vector2);
	ASSERT_TRUE(vector2 == vector1);
	ASSERT_FALSE(vector3 == vector1);
}

TEST(Vector4Tests, InequalityOperator)
{
	Vector4 vector1(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 vector2(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 vector3(2.0f, 2.0f, 2.0f, 2.0f);

	ASSERT_FALSE(vector1 != vector2);
	ASSERT_FALSE(vector2 != vector1);
	ASSERT_TRUE(vector3 != vector1);
}

// ----- EQUALS TESTS ----- //

TEST(Vector4Tests, Equals)
{
	Vector4 vector1(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 vector2(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 vector3(2.0f, 2.0f, 2.0f, 2.0f);

	ASSERT_TRUE(vector1.Equals(vector2));
	ASSERT_TRUE(vector2.Equals(vector1));
	ASSERT_FALSE(vector3.Equals(vector1));
}

TEST(Vector4Tests, EqualsObject)
{
	Vector4 vector1(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 vector2(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 vector3(2.0f, 2.0f, 2.0f, 2.0f);

	ASSERT_TRUE(vector1.Equals(safe_cast<Object^>(vector2)));
	ASSERT_TRUE(vector2.Equals(safe_cast<Object^>(vector1)));
	ASSERT_FALSE(vector3.Equals(safe_cast<Object^>(vector1)));
}

TEST(Vector4Tests, GetHashCode)
{
	Vector4 vector1(1.0f, 2.0f, 3.0f, 4.0f);
	Vector4 vector2(1.0f, 2.0f, 3.0f, 4.0f);

	ASSERT_EQ(vector1.GetHashCode(), vector2.GetHashCode());
}