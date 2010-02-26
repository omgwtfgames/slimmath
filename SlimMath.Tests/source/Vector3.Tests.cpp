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

TEST(Vector3Tests, ConstructDefault)
{
	Vector3 vector = Vector3();

	ASSERT_EQ(0.0f, vector.X);
	ASSERT_EQ(0.0f, vector.Y);
	ASSERT_EQ(0.0f, vector.Z);
}

TEST(Vector3Tests, ConstructWithX)
{
	Vector3 vector = Vector3(0.75f);

	ASSERT_EQ(0.75f, vector.X);
	ASSERT_EQ(0.75f, vector.Y);
	ASSERT_EQ(0.75f, vector.Z);
}

TEST(Vector3Tests, ConstructWithXYZ)
{
	Vector3 vector = Vector3(0.75f, 1.25f, 1.75f);

	ASSERT_EQ(0.75f, vector.X);
	ASSERT_EQ(1.25f, vector.Y);
	ASSERT_EQ(1.75f, vector.Z);
}

TEST(Vector3Tests, ConstructWithVector2)
{
	Vector2 source = Vector2(1.0f, 2.0f);
	Vector3 vector = Vector3(source, 3.0f);

	ASSERT_EQ(1.0f, vector.X);
	ASSERT_EQ(2.0f, vector.Y);
	ASSERT_EQ(3.0f, vector.Z);
}

// ----- PROPERTY TESTS ----- //

TEST(Vector3Tests, SizeInBytes)
{
	ASSERT_EQ(Vector3::SizeInBytes, 12);
}

TEST(Vector3Tests, ZeroVector)
{
	Vector3 vector = Vector3::Zero;

	ASSERT_EQ(vector.X, 0.0f);
	ASSERT_EQ(vector.Y, 0.0f);
	ASSERT_EQ(vector.Z, 0.0f);
}

TEST(Vector3Tests, UnitXVector)
{
	Vector3 vector = Vector3::UnitX;

	ASSERT_EQ(vector.X, 1.0f);
	ASSERT_EQ(vector.Y, 0.0f);
	ASSERT_EQ(vector.Z, 0.0f);
}

TEST(Vector3Tests, UnitYVector)
{
	Vector3 vector = Vector3::UnitY;

	ASSERT_EQ(vector.X, 0.0f);
	ASSERT_EQ(vector.Y, 1.0f);
	ASSERT_EQ(vector.Z, 0.0f);
}

TEST(Vector3Tests, UnitZVector)
{
	Vector3 vector = Vector3::UnitZ;

	ASSERT_EQ(vector.X, 0.0f);
	ASSERT_EQ(vector.Y, 0.0f);
	ASSERT_EQ(vector.Z, 1.0f);
}

TEST(Vector3Tests, IndexerGet)
{
	float x, y, z;
	Vector3 vector(1.0f, 2.0f, 3.0f);

	ASSERT_NO_THROW(x = vector[0]);
	ASSERT_NO_THROW(y = vector[1]);
	ASSERT_NO_THROW(z = vector[2]);

	ASSERT_EQ(x, 1.0f);
	ASSERT_EQ(y, 2.0f);
	ASSERT_EQ(z, 3.0f);
}

TEST(Vector3Tests, IndexerGetOutOfRange)
{
	float x;
	Vector3 vector(1.0f, 2.0f, 3.0f);

	ASSERT_MANAGED_THROW(x = vector[-1], ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW(x = vector[3], ArgumentOutOfRangeException);
}

TEST(Vector3Tests, IndexerSet)
{
	Vector3 vector(1.0f, 2.0f, 3.0f);

	ASSERT_NO_THROW(vector[0] = 1.5f);
	ASSERT_NO_THROW(vector[1] = 2.5f);
	ASSERT_NO_THROW(vector[2] = 3.5f);

	ASSERT_EQ(vector.X, 1.5f);
	ASSERT_EQ(vector.Y, 2.5f);
	ASSERT_EQ(vector.Z, 3.5f);
}

TEST(Vector3Tests, IndexerSetOutOfRange)
{
	Vector3 vector(1.0f, 2.0f, 3.0f);

	ASSERT_MANAGED_THROW(vector[-1] = 5.0f, ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW(vector[3] = 5.0f, ArgumentOutOfRangeException);
}

// ----- METHOD TESTS ----- //

TEST(Vector3Tests, Length)
{
	Vector3 value(1.5f, 2.5f, 3.5f);

	float length1 = D3DXVec3Length(reinterpret_cast<D3DXVECTOR3*>(&value));
	float length2 = value.Length();

	ASSERT_EQ(length1, length2);
}

TEST(Vector3Tests, LengthSquared)
{
	Vector3 value(1.5f, 2.5f, 3.5f);

	float length1 = D3DXVec3LengthSq(reinterpret_cast<D3DXVECTOR3*>(&value));
	float length2 = value.LengthSquared();

	ASSERT_EQ(length1, length2);
}

TEST(Vector3Tests, Normalize)
{
	Vector3 value(1.5f, 2.5f, 3.5f);
	value.Normalize();

	D3DXVECTOR3 result1;
	D3DXVec3Normalize(&result1, reinterpret_cast<D3DXVECTOR3*>(&value));

	AssertEq(result1, value);
}

TEST(Vector3Tests, NormalizeZeroVector)
{
	Vector3 vector = Vector3(0.0f);
	vector.Normalize();

	ASSERT_EQ(0.0f, vector.X);
	ASSERT_EQ(0.0f, vector.Y);
	ASSERT_EQ(0.0f, vector.Z);
}

TEST(Vector3Tests, NormalizeStatic)
{
	Vector3 value(1.5f, 2.5f, 3.5f);

	D3DXVECTOR3 result1;
	D3DXVec3Normalize(&result1, reinterpret_cast<D3DXVECTOR3*>(&value));

	Vector3 result2 = Vector3::Normalize(value);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, NormalizeStaticByRef)
{
	Vector3 value(1.5f, 2.5f, 3.5f);

	D3DXVECTOR3 result1;
	D3DXVec3Normalize(&result1, reinterpret_cast<D3DXVECTOR3*>(&value));

	Vector3 result2;
	Vector3::Normalize(value, result2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, Add)
{
	Vector3 vector1 = Vector3(1.0f, 2.0f, 3.0f);
	Vector3 vector2 = Vector3(5.0f, 6.0f, 7.0f);

	D3DXVECTOR3 result1;
	D3DXVec3Add(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector1), reinterpret_cast<D3DXVECTOR3*>(&vector2));

	Vector3 result2 = Vector3::Add(vector1, vector2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, AddByRef)
{
	Vector3 vector1 = Vector3(1.0f, 2.0f, 3.0f);
	Vector3 vector2 = Vector3(5.0f, 6.0f, 7.0f);

	D3DXVECTOR3 result1;
	D3DXVec3Add(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector1), reinterpret_cast<D3DXVECTOR3*>(&vector2));

	Vector3 result2;
	Vector3::Add(vector1, vector2, result2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, Subtract)
{
	Vector3 vector1 = Vector3(1.0f, 2.0f, 3.0f);
	Vector3 vector2 = Vector3(5.0f, 6.0f, 7.0f);

	D3DXVECTOR3 result1;
	D3DXVec3Subtract(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector1), reinterpret_cast<D3DXVECTOR3*>(&vector2));

	Vector3 result2 = Vector3::Subtract(vector1, vector2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, SubtractByRef)
{
	Vector3 vector1 = Vector3(1.0f, 2.0f, 3.0f);
	Vector3 vector2 = Vector3(5.0f, 6.0f, 7.0f);

	D3DXVECTOR3 result1;
	D3DXVec3Subtract(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector1), reinterpret_cast<D3DXVECTOR3*>(&vector2));

	Vector3 result2;
	Vector3::Subtract(vector1, vector2, result2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, Multiply)
{
	Vector3 vector1 = Vector3(1.0f, 2.0f, 3.0f);
	float amount = 2.5f;

	D3DXVECTOR3 result1;
	D3DXVec3Scale(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector1), amount);

	Vector3 result2 = Vector3::Multiply(vector1, amount);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, MultiplyByRef)
{
	Vector3 vector1 = Vector3(1.0f, 2.0f, 3.0f);
	float amount = 2.5f;

	D3DXVECTOR3 result1;
	D3DXVec3Scale(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector1), amount);

	Vector3 result2;
	Vector3::Multiply(vector1, amount, result2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, Modulate)
{
	Vector3 vector1 = Vector3(2.0f, 3.0f, 1.0f);
	Vector3 vector2 = Vector3(4.0f, 5.0f, 1.0f);
	Vector3 result = Vector3::Modulate(vector1, vector2);

	ASSERT_EQ(8.0f, result.X);
	ASSERT_EQ(15.0f, result.Y);
	ASSERT_EQ(1.0f, result.Z);
}

TEST(Vector3Tests, ModulateByRef)
{
	Vector3 vector1 = Vector3(2.0f, 3.0f, 1.0f);
	Vector3 vector2 = Vector3(4.0f, 5.0f, 1.0f);
	Vector3 result;
	Vector3::Modulate(vector1, vector2, result);

	ASSERT_EQ(8.0f, result.X);
	ASSERT_EQ(15.0f, result.Y);
	ASSERT_EQ(1.0f, result.Z);
}

TEST(Vector3Tests, Divide)
{
	Vector3 vector1 = Vector3(1.0f, 2.0f, 3.0f);
	float amount = 2.5f;

	D3DXVECTOR3 result1;
	D3DXVec3Scale(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector1), 1.0f / amount);

	Vector3 result2 = Vector3::Divide(vector1, amount);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, DivideByRef)
{
	Vector3 vector1 = Vector3(1.0f, 2.0f, 3.0f);
	float amount = 2.5f;

	D3DXVECTOR3 result1;
	D3DXVec3Scale(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector1), 1.0f / amount);

	Vector3 result2;
	Vector3::Divide(vector1, amount, result2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, Negate)
{
	Vector3 vector = Vector3(1.0f, -2.0f, 3.0f);
	Vector3 result = Vector3::Negate(vector);

	ASSERT_EQ(result.X, -1.0f);
	ASSERT_EQ(result.Y, 2.0f);
	ASSERT_EQ(result.Z, -3.0f);
}

TEST(Vector3Tests, NegateByRef)
{
	Vector3 vector = Vector3(1.0f, -2.0f, 3.0f);
	Vector3 result;
	Vector3::Negate(vector, result);

	ASSERT_EQ(result.X, -1.0f);
	ASSERT_EQ(result.Y, 2.0f);
	ASSERT_EQ(result.Z, -3.0f);
}

TEST(Vector3Tests, Barycentric)
{
	Vector3 value1(1.0f, 2.0f, 3.0f);
	Vector3 value2(1.5f, 2.5f, 3.5f);
	Vector3 value3(1.75f, 2.75f, 3.75f);
	float amount1 = 2.0f;
	float amount2 = 3.0f;

	D3DXVECTOR3 result1;
	D3DXVec3BaryCentric(&result1, reinterpret_cast<D3DXVECTOR3*>(&value1), reinterpret_cast<D3DXVECTOR3*>(&value2), reinterpret_cast<D3DXVECTOR3*>(&value3), amount1, amount2);

	Vector3 result2 = Vector3::Barycentric(value1, value2, value3, amount1, amount2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, BarycentricByRef)
{
	Vector3 value1(1.0f, 2.0f, 3.0f);
	Vector3 value2(1.5f, 2.5f, 3.5f);
	Vector3 value3(1.75f, 2.75f, 3.75f);
	float amount1 = 2.0f;
	float amount2 = 3.0f;

	D3DXVECTOR3 result1;
	D3DXVec3BaryCentric(&result1, reinterpret_cast<D3DXVECTOR3*>(&value1), reinterpret_cast<D3DXVECTOR3*>(&value2), reinterpret_cast<D3DXVECTOR3*>(&value3), amount1, amount2);

	Vector3 result2;
	Vector3::Barycentric(value1, value2, value3, amount1, amount2, result2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, CatmullRom)
{
	Vector3 value1(1.0f, 2.0f, 3.0f);
	Vector3 value2(1.5f, 2.5f, 3.5f);
	Vector3 value3(1.75f, 2.75f, 3.75f);
	Vector3 value4(1.25f, 2.25f, 3.25f);
	float amount = 2.5f;

	D3DXVECTOR3 result1;
	D3DXVec3CatmullRom(&result1, reinterpret_cast<D3DXVECTOR3*>(&value1), reinterpret_cast<D3DXVECTOR3*>(&value2), reinterpret_cast<D3DXVECTOR3*>(&value3), reinterpret_cast<D3DXVECTOR3*>(&value4), amount);

	Vector3 result2 = Vector3::CatmullRom(value1, value2, value3, value4, amount);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, CatmullRomByRef)
{
	Vector3 value1(1.0f, 2.0f, 3.0f);
	Vector3 value2(1.5f, 2.5f, 3.5f);
	Vector3 value3(1.75f, 2.75f, 3.75f);
	Vector3 value4(1.25f, 2.25f, 3.25f);
	float amount = 2.5f;

	D3DXVECTOR3 result1;
	D3DXVec3CatmullRom(&result1, reinterpret_cast<D3DXVECTOR3*>(&value1), reinterpret_cast<D3DXVECTOR3*>(&value2), reinterpret_cast<D3DXVECTOR3*>(&value3), reinterpret_cast<D3DXVECTOR3*>(&value4), amount);

	Vector3 result2;
	Vector3::CatmullRom(value1, value2, value3, value4, amount, result2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, Clamp)
{
	Vector3 value(2.0f, 2.0f, 2.0f);
	Vector3 minimum(1.0f, 2.5f, 2.5f);
	Vector3 maximum(2.75f, 2.75f, 3.75f);

	Vector3 result = Vector3::Clamp(value, minimum, maximum);

	ASSERT_EQ(result.X, 2.0f);
	ASSERT_EQ(result.Y, 2.5f);
	ASSERT_EQ(result.Z, 2.5f);
}

TEST(Vector3Tests, ClampByRef)
{
	Vector3 value(2.0f, 2.0f, 2.0f);
	Vector3 minimum(1.0f, 2.5f, 2.5f);
	Vector3 maximum(2.75f, 2.75f, 3.75f);

	Vector3 result;
	Vector3::Clamp(value, minimum, maximum, result);

	ASSERT_EQ(result.X, 2.0f);
	ASSERT_EQ(result.Y, 2.5f);
	ASSERT_EQ(result.Z, 2.5f);
}

TEST(Vector3Tests, Hermite)
{
	Vector3 value1(1.0f, 2.0f, 3.0f);
	Vector3 value2(1.5f, 2.5f, 3.5f);
	Vector3 value3(1.75f, 2.75f, 3.75f);
	Vector3 value4(1.25f, 2.25f, 3.25f);
	float amount = 2.5f;

	D3DXVECTOR3 result1;
	D3DXVec3Hermite(&result1, reinterpret_cast<D3DXVECTOR3*>(&value1), reinterpret_cast<D3DXVECTOR3*>(&value2), reinterpret_cast<D3DXVECTOR3*>(&value3), reinterpret_cast<D3DXVECTOR3*>(&value4), amount);

	Vector3 result2 = Vector3::Hermite(value1, value2, value3, value4, amount);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, HermiteByRef)
{
	Vector3 value1(1.0f, 2.0f, 3.0f);
	Vector3 value2(1.5f, 2.5f, 3.5f);
	Vector3 value3(1.75f, 2.75f, 3.75f);
	Vector3 value4(1.25f, 2.25f, 3.25f);
	float amount = 2.5f;

	D3DXVECTOR3 result1;
	D3DXVec3Hermite(&result1, reinterpret_cast<D3DXVECTOR3*>(&value1), reinterpret_cast<D3DXVECTOR3*>(&value2), reinterpret_cast<D3DXVECTOR3*>(&value3), reinterpret_cast<D3DXVECTOR3*>(&value4), amount);

	Vector3 result2;
	Vector3::Hermite(value1, value2, value3, value4, amount, result2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, Lerp)
{
	Vector3 value1(1.0f, 2.0f, 3.0f);
	Vector3 value2(1.5f, 2.5f, 3.5f);
	float amount = 0.5f;

	D3DXVECTOR3 result1;
	D3DXVec3Lerp(&result1, reinterpret_cast<D3DXVECTOR3*>(&value1), reinterpret_cast<D3DXVECTOR3*>(&value2), amount);

	Vector3 result2 = Vector3::Lerp(value1, value2, amount);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, LerpByRef)
{
	Vector3 value1(1.0f, 2.0f, 3.0f);
	Vector3 value2(1.5f, 2.5f, 3.5f);
	float amount = 0.5f;

	D3DXVECTOR3 result1;
	D3DXVec3Lerp(&result1, reinterpret_cast<D3DXVECTOR3*>(&value1), reinterpret_cast<D3DXVECTOR3*>(&value2), amount);

	Vector3 result2;
	Vector3::Lerp(value1, value2, amount, result2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, SmoothStep)
{
	Vector3 value1(1.0f, 2.0f, 3.0f);
	Vector3 value2(1.5f, 2.5f, 3.5f);
	float amount = 0.5f;

	Vector3 result = Vector3::SmoothStep(value1, value2, amount);

	ASSERT_EQ(result.X, 1.25f);
	ASSERT_EQ(result.Y, 2.25f);
	ASSERT_EQ(result.Z, 3.25f);
}

TEST(Vector3Tests, SmoothStepByRef)
{
	Vector3 value1(1.0f, 2.0f, 3.0f);
	Vector3 value2(1.5f, 2.5f, 3.5f);
	float amount = 0.5f;

	Vector3 result;
	Vector3::SmoothStep(value1, value2, amount, result);

	ASSERT_EQ(result.X, 1.25f);
	ASSERT_EQ(result.Y, 2.25f);
	ASSERT_EQ(result.Z, 3.25f);
}

TEST(Vector3Tests, Distance)
{
	Vector3 value1(1.0f, 2.0f, 3.0f);
	Vector3 value2(1.75f, 2.75f, 3.75f);

	float result = Vector3::Distance(value1, value2);

	ASSERT_EQ(result, 1.299038f);
}

TEST(Vector3Tests, DistanceSquared)
{
	Vector3 value1(1.0f, 2.0f, 3.0f);
	Vector3 value2(1.75f, 2.75f, 3.75f);

	float result = Vector3::DistanceSquared(value1, value2);

	ASSERT_EQ(result, 1.6875f);
}

TEST(Vector3Tests, Dot)
{
	Vector3 value1(1.0f, 2.0f, 3.0f);
	Vector3 value2(1.75f, 2.75f, 3.75f);

	float result1 = D3DXVec3Dot(reinterpret_cast<D3DXVECTOR3*>(&value1), reinterpret_cast<D3DXVECTOR3*>(&value2));
	float result2 = Vector3::Dot(value1, value2);

	ASSERT_EQ(result1, result2);
}

TEST(Vector3Tests, Cross)
{
	Vector3 value1(1.0f, 2.0f, 3.0f);
	Vector3 value2(1.75f, 2.75f, 3.75f);

	D3DXVECTOR3 result1;
	D3DXVec3Cross(&result1, reinterpret_cast<D3DXVECTOR3*>(&value1), reinterpret_cast<D3DXVECTOR3*>(&value2));

	Vector3 result2 = Vector3::Cross(value1, value2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, CrossByRef)
{
	Vector3 value1(1.0f, 2.0f, 3.0f);
	Vector3 value2(1.75f, 2.75f, 3.75f);

	D3DXVECTOR3 result1;
	D3DXVec3Cross(&result1, reinterpret_cast<D3DXVECTOR3*>(&value1), reinterpret_cast<D3DXVECTOR3*>(&value2));

	Vector3 result2;
	Vector3::Cross(value1, value2, result2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, Reflect)
{
	Vector3 value1(1.0f, 2.0f, 3.0f);
	Vector3 value2(1.75f, 2.75f, 3.75f);

	Vector3 result = Vector3::Reflect(value1, value2);

	ASSERT_EQ(result.X, -63.75f);
	ASSERT_EQ(result.Y, -99.75f);
	ASSERT_EQ(result.Z, -135.75f);
}

TEST(Vector3Tests, ReflectByRef)
{
	Vector3 value1(1.0f, 2.0f, 3.0f);
	Vector3 value2(1.75f, 2.75f, 3.75f);

	Vector3 result;
	Vector3::Reflect(value1, value2, result);

	ASSERT_EQ(result.X, -63.75f);
	ASSERT_EQ(result.Y, -99.75f);
	ASSERT_EQ(result.Z, -135.75f);
}

TEST(Vector3Tests, TransformByQuat)
{
	Vector3 vector(1.0f, 2.0f, 3.0f);
	Quaternion quat(0.5f, 1.5f, 2.5f, 3.5f);

	Vector3 result = Vector3::Transform(vector, quat);

	ASSERT_EQ(result.X, -9.0f);		// values otained from XNA GS math lib
	ASSERT_EQ(result.Y, 7.0f);
	ASSERT_EQ(result.Z, 2.0f);
}

TEST(Vector3Tests, TransformByQuatByRef)
{
	Vector3 vector(1.0f, 2.0f, 3.0f);
	Quaternion quat(0.5f, 1.5f, 2.5f, 3.5f);

	Vector3 result;
	Vector3::Transform(vector, quat, result);

	ASSERT_EQ(result.X, -9.0f);		// values otained from XNA GS math lib
	ASSERT_EQ(result.Y, 7.0f);
	ASSERT_EQ(result.Z, 2.0f);
}

TEST(Vector3Tests, TransformByMatrix)
{
	Vector3 vector(1.0f, 2.0f, 3.0f);
	Matrix matrix = CreateWorldMatrix();

	D3DXVECTOR4 result1;
	D3DXVec3Transform(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector), reinterpret_cast<D3DXMATRIX*>(&matrix));

	Vector4 result2 = Vector3::Transform(vector, matrix);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, TransformByMatrixByRef)
{
	Vector3 vector(1.0f, 2.0f, 3.0f);
	Matrix matrix = CreateWorldMatrix();

	D3DXVECTOR4 result1;
	D3DXVec3Transform(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector), reinterpret_cast<D3DXMATRIX*>(&matrix));

	Vector4 result2;
	Vector3::Transform(vector, matrix, result2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, TransformCoordinate)
{
	Vector3 vector(1.0f, 2.0f, 3.0f);
	Matrix matrix = CreateWorldMatrix();

	D3DXVECTOR3 result1;
	D3DXVec3TransformCoord(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector), reinterpret_cast<D3DXMATRIX*>(&matrix));

	Vector3 result2 = Vector3::TransformCoordinate(vector, matrix);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, TransformCoordinateByRef)
{
	Vector3 vector(1.0f, 2.0f, 3.0f);
	Matrix matrix = CreateWorldMatrix();

	D3DXVECTOR3 result1;
	D3DXVec3TransformCoord(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector), reinterpret_cast<D3DXMATRIX*>(&matrix));

	Vector3 result2;
	Vector3::TransformCoordinate(vector, matrix, result2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, TransformNormal)
{
	Vector3 vector(1.0f, 2.0f, 3.0f);
	Matrix matrix = CreateWorldMatrix();

	D3DXVECTOR3 result1;
	D3DXVec3TransformNormal(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector), reinterpret_cast<D3DXMATRIX*>(&matrix));

	Vector3 result2 = Vector3::TransformNormal(vector, matrix);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, TransformNormalByRef)
{
	Vector3 vector(1.0f, 2.0f, 3.0f);
	Matrix matrix = CreateWorldMatrix();

	D3DXVECTOR3 result1;
	D3DXVec3TransformNormal(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector), reinterpret_cast<D3DXMATRIX*>(&matrix));

	Vector3 result2;
	Vector3::TransformNormal(vector, matrix, result2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, Project)
{
	Vector3 vector(1.0f, 2.0f, 3.0f);
	float x = 10.0f;
	float y = 20.0f;
	float width = 100.0f;
	float height = 200.0f;
	float minZ = 0.5f;
	float maxZ = 100.0f;
	Matrix matrix1 = CreateProjectionMatrix();
	Matrix matrix2 = CreateViewMatrix();
	Matrix matrix3 = CreateWorldMatrix();

	D3DVIEWPORT9 viewport;
	viewport.X = (DWORD)x;
	viewport.Y = (DWORD)y;
	viewport.Width = (DWORD)width;
	viewport.Height = (DWORD)height;
	viewport.MinZ = minZ;
	viewport.MaxZ = maxZ;

	D3DXVECTOR3 result1;
	D3DXVec3Project(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector), &viewport, reinterpret_cast<D3DXMATRIX*>(&matrix1), reinterpret_cast<D3DXMATRIX*>(&matrix2), reinterpret_cast<D3DXMATRIX*>(&matrix3));

	Vector3 result2 = Vector3::Project(vector, x, y, width, height, minZ, maxZ, matrix3 * matrix2 * matrix1);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, ProjectByRef)
{
	Vector3 vector(1.0f, 2.0f, 3.0f);
	float x = 10.0f;
	float y = 20.0f;
	float width = 100.0f;
	float height = 200.0f;
	float minZ = 0.5f;
	float maxZ = 100.0f;
	Matrix matrix1 = CreateProjectionMatrix();
	Matrix matrix2 = CreateViewMatrix();
	Matrix matrix3 = CreateWorldMatrix();

	D3DVIEWPORT9 viewport;
	viewport.X = (DWORD)x;
	viewport.Y = (DWORD)y;
	viewport.Width = (DWORD)width;
	viewport.Height = (DWORD)height;
	viewport.MinZ = minZ;
	viewport.MaxZ = maxZ;

	D3DXVECTOR3 result1;
	D3DXVec3Project(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector), &viewport, reinterpret_cast<D3DXMATRIX*>(&matrix1), reinterpret_cast<D3DXMATRIX*>(&matrix2), reinterpret_cast<D3DXMATRIX*>(&matrix3));

	Vector3 result2;
	Vector3::Project(vector, x, y, width, height, minZ, maxZ, matrix3 * matrix2 * matrix1, result2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, Unproject)
{
	Vector3 vector(1.0f, 2.0f, 3.0f);
	float x = 10.0f;
	float y = 20.0f;
	float width = 100.0f;
	float height = 200.0f;
	float minZ = 0.5f;
	float maxZ = 100.0f;
	Matrix matrix1 = CreateProjectionMatrix();
	Matrix matrix2 = CreateViewMatrix();
	Matrix matrix3 = CreateWorldMatrix();

	D3DVIEWPORT9 viewport;
	viewport.X = (DWORD)x;
	viewport.Y = (DWORD)y;
	viewport.Width = (DWORD)width;
	viewport.Height = (DWORD)height;
	viewport.MinZ = minZ;
	viewport.MaxZ = maxZ;

	D3DXVECTOR3 result1;
	D3DXVec3Unproject(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector), &viewport, reinterpret_cast<D3DXMATRIX*>(&matrix1), reinterpret_cast<D3DXMATRIX*>(&matrix2), reinterpret_cast<D3DXMATRIX*>(&matrix3));

	Vector3 result2 = Vector3::Unproject(vector, x, y, width, height, minZ, maxZ, matrix3 * matrix2 * matrix1);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, UnprojectByRef)
{
	Vector3 vector(1.0f, 2.0f, 3.0f);
	float x = 10.0f;
	float y = 20.0f;
	float width = 100.0f;
	float height = 200.0f;
	float minZ = 0.5f;
	float maxZ = 100.0f;
	Matrix matrix1 = CreateProjectionMatrix();
	Matrix matrix2 = CreateViewMatrix();
	Matrix matrix3 = CreateWorldMatrix();

	D3DVIEWPORT9 viewport;
	viewport.X = (DWORD)x;
	viewport.Y = (DWORD)y;
	viewport.Width = (DWORD)width;
	viewport.Height = (DWORD)height;
	viewport.MinZ = minZ;
	viewport.MaxZ = maxZ;

	D3DXVECTOR3 result1;
	D3DXVec3Unproject(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector), &viewport, reinterpret_cast<D3DXMATRIX*>(&matrix1), reinterpret_cast<D3DXMATRIX*>(&matrix2), reinterpret_cast<D3DXMATRIX*>(&matrix3));

	Vector3 result2;
	Vector3::Unproject(vector, x, y, width, height, minZ, maxZ, matrix3 * matrix2 * matrix1, result2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, Min)
{
	Vector3 vector1(0.0f, 2.0f, 1.5f);
	Vector3 vector2(1.0f, 2.0f, 3.0f);

	D3DXVECTOR3 result1;
	D3DXVec3Minimize(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector1), reinterpret_cast<D3DXVECTOR3*>(&vector2));

	Vector3 result2 = Vector3::Min(vector1, vector2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, MinByRef)
{
	Vector3 vector1(0.0f, 2.0f, 1.5f);
	Vector3 vector2(1.0f, 2.0f, 3.0f);

	D3DXVECTOR3 result1;
	D3DXVec3Minimize(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector1), reinterpret_cast<D3DXVECTOR3*>(&vector2));

	Vector3 result2;
	Vector3::Min(vector1, vector2, result2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, Max)
{
	Vector3 vector1(0.0f, 2.0f, 1.5f);
	Vector3 vector2(1.0f, 2.0f, 3.0f);

	D3DXVECTOR3 result1;
	D3DXVec3Maximize(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector1), reinterpret_cast<D3DXVECTOR3*>(&vector2));

	Vector3 result2 = Vector3::Max(vector1, vector2);

	AssertEq(result1, result2);
}

TEST(Vector3Tests, MaxByRef)
{
	Vector3 vector1(0.0f, 2.0f, 1.5f);
	Vector3 vector2(1.0f, 2.0f, 3.0f);

	D3DXVECTOR3 result1;
	D3DXVec3Maximize(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector1), reinterpret_cast<D3DXVECTOR3*>(&vector2));

	Vector3 result2;
	Vector3::Max(vector1, vector2, result2);

	AssertEq(result1, result2);
}

// ----- OPERATOR TESTS ----- //

TEST(Vector3Tests, AddOperator)
{
	Vector3 vector1 = Vector3(1.0f, 2.0f, 3.0f);
	Vector3 vector2 = Vector3(5.0f, 6.0f, 7.0f);

	D3DXVECTOR3 result1;
	D3DXVec3Add(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector1), reinterpret_cast<D3DXVECTOR3*>(&vector2));

	Vector3 result2 = vector1 + vector2;

	AssertEq(result1, result2);
}

TEST(Vector3Tests, SubtractOperator)
{
	Vector3 vector1 = Vector3(1.0f, 2.0f, 3.0f);
	Vector3 vector2 = Vector3(5.0f, 6.0f, 7.0f);

	D3DXVECTOR3 result1;
	D3DXVec3Subtract(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector1), reinterpret_cast<D3DXVECTOR3*>(&vector2));

	Vector3 result2 = vector1 - vector2;

	AssertEq(result1, result2);
}

TEST(Vector3Tests, MultiplyOperatorScalarOnLeft)
{
	Vector3 vector1 = Vector3(1.0f, 2.0f, 3.0f);
	float amount = 2.5f;

	D3DXVECTOR3 result1;
	D3DXVec3Scale(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector1), amount);

	Vector3 result2 = amount * vector1;

	AssertEq(result1, result2);
}

TEST(Vector3Tests, MultiplyOperatorScalarOnRight)
{
	Vector3 vector1 = Vector3(1.0f, 2.0f, 3.0f);
	float amount = 2.5f;

	D3DXVECTOR3 result1;
	D3DXVec3Scale(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector1), amount);

	Vector3 result2 = vector1 * amount;

	AssertEq(result1, result2);
}

TEST(Vector3Tests, DivideOperator)
{
	Vector3 vector1 = Vector3(1.0f, 2.0f, 3.0f);
	float amount = 2.5f;

	D3DXVECTOR3 result1;
	D3DXVec3Scale(&result1, reinterpret_cast<D3DXVECTOR3*>(&vector1), 1.0f / amount);

	Vector3 result2 = vector1 / amount;

	AssertEq(result1, result2);
}

TEST(Vector3Tests, NegateOperator)
{
	Vector3 vector = Vector3(1.0f, -2.0f, 3.0f);
	Vector3 result = -vector;

	ASSERT_EQ(result.X, -1.0f);
	ASSERT_EQ(result.Y, 2.0f);
	ASSERT_EQ(result.Z, -3.0f);
}

TEST(Vector3Tests, EqualityOperator)
{
	Vector3 vector1(1.0f, 2.0f, 3.0f);
	Vector3 vector2(1.0f, 2.0f, 3.0f);
	Vector3 vector3(2.0f, 2.0f, 2.0f);

	ASSERT_TRUE(vector1 == vector2);
	ASSERT_TRUE(vector2 == vector1);
	ASSERT_FALSE(vector3 == vector1);
}

TEST(Vector3Tests, InequalityOperator)
{
	Vector3 vector1(1.0f, 2.0f, 3.0f);
	Vector3 vector2(1.0f, 2.0f, 3.0f);
	Vector3 vector3(2.0f, 2.0f, 2.0f);

	ASSERT_FALSE(vector1 != vector2);
	ASSERT_FALSE(vector2 != vector1);
	ASSERT_TRUE(vector3 != vector1);
}

// ----- EQUALS TESTS ----- //

TEST(Vector3Tests, Equals)
{
	Vector3 vector1(1.0f, 2.0f, 3.0f);
	Vector3 vector2(1.0f, 2.0f, 3.0f);
	Vector3 vector3(2.0f, 2.0f, 2.0f);

	ASSERT_TRUE(vector1.Equals(vector2));
	ASSERT_TRUE(vector2.Equals(vector1));
	ASSERT_FALSE(vector3.Equals(vector1));
}

TEST(Vector3Tests, EqualsObject)
{
	Vector3 vector1(1.0f, 2.0f, 3.0f);
	Vector3 vector2(1.0f, 2.0f, 3.0f);
	Vector3 vector3(2.0f, 2.0f, 2.0f);

	ASSERT_TRUE(vector1.Equals(safe_cast<Object^>(vector2)));
	ASSERT_TRUE(vector2.Equals(safe_cast<Object^>(vector1)));
	ASSERT_FALSE(vector3.Equals(safe_cast<Object^>(vector1)));
}

TEST(Vector3Tests, GetHashCode)
{
	Vector3 vector1(1.0f, 2.0f, 3.0f);
	Vector3 vector2(1.0f, 2.0f, 3.0f);

	ASSERT_EQ(vector1.GetHashCode(), vector2.GetHashCode());
}