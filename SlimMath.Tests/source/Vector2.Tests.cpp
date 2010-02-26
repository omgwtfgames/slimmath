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

TEST(Vector2Tests, ConstructDefault)
{
	Vector2 vector = Vector2();

	ASSERT_EQ(0.0f, vector.X);
	ASSERT_EQ(0.0f, vector.Y);
}

TEST(Vector2Tests, ConstructWithX)
{
	Vector2 vector = Vector2(0.75f);

	ASSERT_EQ(0.75f, vector.X);
	ASSERT_EQ(0.75f, vector.Y);
}

TEST(Vector2Tests, ConstructWithXY)
{
	Vector2 vector = Vector2(0.75f, 1.25f);

	ASSERT_EQ(0.75f, vector.X);
	ASSERT_EQ(1.25f, vector.Y);
}

// ----- PROPERTY TESTS ----- //

TEST(Vector2Tests, SizeInBytes)
{
	ASSERT_EQ(Vector2::SizeInBytes, 8);
}

TEST(Vector2Tests, ZeroVector)
{
	Vector2 vector = Vector2::Zero;

	ASSERT_EQ(vector.X, 0.0f);
	ASSERT_EQ(vector.Y, 0.0f);
}

TEST(Vector2Tests, UnitXVector)
{
	Vector2 vector = Vector2::UnitX;

	ASSERT_EQ(vector.X, 1.0f);
	ASSERT_EQ(vector.Y, 0.0f);
}

TEST(Vector2Tests, UnitYVector)
{
	Vector2 vector = Vector2::UnitY;

	ASSERT_EQ(vector.X, 0.0f);
	ASSERT_EQ(vector.Y, 1.0f);
}

TEST(Vector2Tests, IndexerGet)
{
	float x, y;
	Vector2 vector(1.0f, 2.0f);

	ASSERT_NO_THROW(x = vector[0]);
	ASSERT_NO_THROW(y = vector[1]);

	ASSERT_EQ(x, 1.0f);
	ASSERT_EQ(y, 2.0f);
}

TEST(Vector2Tests, IndexerGetOutOfRange)
{
	float x;
	Vector2 vector(1.0f, 2.0f);

	ASSERT_MANAGED_THROW(x = vector[-1], ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW(x = vector[2], ArgumentOutOfRangeException);
}

TEST(Vector2Tests, IndexerSet)
{
	Vector2 vector(1.0f, 2.0f);

	ASSERT_NO_THROW(vector[0] = 1.5f);
	ASSERT_NO_THROW(vector[1] = 2.5f);

	ASSERT_EQ(vector.X, 1.5f);
	ASSERT_EQ(vector.Y, 2.5f);
}

TEST(Vector2Tests, IndexerSetOutOfRange)
{
	Vector2 vector(1.0f, 2.0f);

	ASSERT_MANAGED_THROW(vector[-1] = 5.0f, ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW(vector[2] = 5.0f, ArgumentOutOfRangeException);
}

// ----- METHOD TESTS ----- //

TEST(Vector2Tests, Length)
{
	Vector2 value(1.5f, 2.5f);

	float length1 = D3DXVec2Length(reinterpret_cast<D3DXVECTOR2*>(&value));
	float length2 = value.Length();

	ASSERT_EQ(length1, length2);
}

TEST(Vector2Tests, LengthSquared)
{
	Vector2 value(1.5f, 2.5f);

	float length1 = D3DXVec2LengthSq(reinterpret_cast<D3DXVECTOR2*>(&value));
	float length2 = value.LengthSquared();

	ASSERT_EQ(length1, length2);
}

TEST(Vector2Tests, Normalize)
{
	Vector2 value(1.5f, 2.5f);
	value.Normalize();

	D3DXVECTOR2 result1;
	D3DXVec2Normalize(&result1, reinterpret_cast<D3DXVECTOR2*>(&value));

	AssertEq(result1, value);
}

TEST(Vector2Tests, NormalizeZeroVector)
{
	Vector2 vector = Vector2(0.0f);
	vector.Normalize();

	ASSERT_EQ(0.0f, vector.X);
	ASSERT_EQ(0.0f, vector.Y);
}

TEST(Vector2Tests, NormalizeStatic)
{
	Vector2 value(1.5f, 2.5f);

	D3DXVECTOR2 result1;
	D3DXVec2Normalize(&result1, reinterpret_cast<D3DXVECTOR2*>(&value));

	Vector2 result2 = Vector2::Normalize(value);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, NormalizeStaticByRef)
{
	Vector2 value(1.5f, 2.5f);

	D3DXVECTOR2 result1;
	D3DXVec2Normalize(&result1, reinterpret_cast<D3DXVECTOR2*>(&value));

	Vector2 result2;
	Vector2::Normalize(value, result2);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, Add)
{
	Vector2 vector1 = Vector2(1.0f, 2.0f);
	Vector2 vector2 = Vector2(5.0f, 6.0f);

	D3DXVECTOR2 result1;
	D3DXVec2Add(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector1), reinterpret_cast<D3DXVECTOR2*>(&vector2));

	Vector2 result2 = Vector2::Add(vector1, vector2);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, AddByRef)
{
	Vector2 vector1 = Vector2(1.0f, 2.0f);
	Vector2 vector2 = Vector2(5.0f, 6.0f);

	D3DXVECTOR2 result1;
	D3DXVec2Add(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector1), reinterpret_cast<D3DXVECTOR2*>(&vector2));

	Vector2 result2;
	Vector2::Add(vector1, vector2, result2);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, Subtract)
{
	Vector2 vector1 = Vector2(1.0f, 2.0f);
	Vector2 vector2 = Vector2(5.0f, 6.0f);

	D3DXVECTOR2 result1;
	D3DXVec2Subtract(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector1), reinterpret_cast<D3DXVECTOR2*>(&vector2));

	Vector2 result2 = Vector2::Subtract(vector1, vector2);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, SubtractByRef)
{
	Vector2 vector1 = Vector2(1.0f, 2.0f);
	Vector2 vector2 = Vector2(5.0f, 6.0f);

	D3DXVECTOR2 result1;
	D3DXVec2Subtract(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector1), reinterpret_cast<D3DXVECTOR2*>(&vector2));

	Vector2 result2;
	Vector2::Subtract(vector1, vector2, result2);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, Multiply)
{
	Vector2 vector1 = Vector2(1.0f, 2.0f);
	float amount = 2.5f;

	D3DXVECTOR2 result1;
	D3DXVec2Scale(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector1), amount);

	Vector2 result2 = Vector2::Multiply(vector1, amount);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, MultiplyByRef)
{
	Vector2 vector1 = Vector2(1.0f, 2.0f);
	float amount = 2.5f;

	D3DXVECTOR2 result1;
	D3DXVec2Scale(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector1), amount);

	Vector2 result2;
	Vector2::Multiply(vector1, amount, result2);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, Modulate)
{
	Vector2 vector1 = Vector2(2.0f, 3.0f);
	Vector2 vector2 = Vector2(4.0f, 5.0f);
	Vector2 result = Vector2::Modulate(vector1, vector2);

	ASSERT_EQ(8.0f, result.X);
	ASSERT_EQ(15.0f, result.Y);
}

TEST(Vector2Tests, ModulateByRef)
{
	Vector2 vector1 = Vector2(2.0f, 3.0f);
	Vector2 vector2 = Vector2(4.0f, 5.0f);
	Vector2 result;
	Vector2::Modulate(vector1, vector2, result);

	ASSERT_EQ(8.0f, result.X);
	ASSERT_EQ(15.0f, result.Y);
}

TEST(Vector2Tests, Divide)
{
	Vector2 vector1 = Vector2(1.0f, 2.0f);
	float amount = 2.5f;

	D3DXVECTOR2 result1;
	D3DXVec2Scale(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector1), 1.0f / amount);

	Vector2 result2 = Vector2::Divide(vector1, amount);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, DivideByRef)
{
	Vector2 vector1 = Vector2(1.0f, 2.0f);
	float amount = 2.5f;

	D3DXVECTOR2 result1;
	D3DXVec2Scale(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector1), 1.0f / amount);

	Vector2 result2;
	Vector2::Divide(vector1, amount, result2);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, Negate)
{
	Vector2 vector = Vector2(1.0f, -2.0f);
	Vector2 result = Vector2::Negate(vector);

	ASSERT_EQ(result.X, -1.0f);
	ASSERT_EQ(result.Y, 2.0f);
}

TEST(Vector2Tests, NegateByRef)
{
	Vector2 vector = Vector2(1.0f, -2.0f);
	Vector2 result;
	Vector2::Negate(vector, result);

	ASSERT_EQ(result.X, -1.0f);
	ASSERT_EQ(result.Y, 2.0f);
}

TEST(Vector2Tests, Barycentric)
{
	Vector2 value1(1.0f, 2.0f);
	Vector2 value2(1.5f, 2.5f);
	Vector2 value3(1.75f, 2.75f);
	float amount1 = 2.0f;
	float amount2 = 3.0f;

	D3DXVECTOR2 result1;
	D3DXVec2BaryCentric(&result1, reinterpret_cast<D3DXVECTOR2*>(&value1), reinterpret_cast<D3DXVECTOR2*>(&value2), reinterpret_cast<D3DXVECTOR2*>(&value3), amount1, amount2);

	Vector2 result2 = Vector2::Barycentric(value1, value2, value3, amount1, amount2);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, BarycentricByRef)
{
	Vector2 value1(1.0f, 2.0f);
	Vector2 value2(1.5f, 2.5f);
	Vector2 value3(1.75f, 2.75f);
	float amount1 = 2.0f;
	float amount2 = 3.0f;

	D3DXVECTOR2 result1;
	D3DXVec2BaryCentric(&result1, reinterpret_cast<D3DXVECTOR2*>(&value1), reinterpret_cast<D3DXVECTOR2*>(&value2), reinterpret_cast<D3DXVECTOR2*>(&value3), amount1, amount2);

	Vector2 result2;
	Vector2::Barycentric(value1, value2, value3, amount1, amount2, result2);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, CatmullRom)
{
	Vector2 value1(1.0f, 2.0f);
	Vector2 value2(1.5f, 2.5f);
	Vector2 value3(1.75f, 2.75f);
	Vector2 value4(1.25f, 2.25f);
	float amount = 2.5f;

	D3DXVECTOR2 result1;
	D3DXVec2CatmullRom(&result1, reinterpret_cast<D3DXVECTOR2*>(&value1), reinterpret_cast<D3DXVECTOR2*>(&value2), reinterpret_cast<D3DXVECTOR2*>(&value3), reinterpret_cast<D3DXVECTOR2*>(&value4), amount);

	Vector2 result2 = Vector2::CatmullRom(value1, value2, value3, value4, amount);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, CatmullRomByRef)
{
	Vector2 value1(1.0f, 2.0f);
	Vector2 value2(1.5f, 2.5f);
	Vector2 value3(1.75f, 2.75f);
	Vector2 value4(1.25f, 2.25f);
	float amount = 2.5f;

	D3DXVECTOR2 result1;
	D3DXVec2CatmullRom(&result1, reinterpret_cast<D3DXVECTOR2*>(&value1), reinterpret_cast<D3DXVECTOR2*>(&value2), reinterpret_cast<D3DXVECTOR2*>(&value3), reinterpret_cast<D3DXVECTOR2*>(&value4), amount);

	Vector2 result2;
	Vector2::CatmullRom(value1, value2, value3, value4, amount, result2);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, Clamp)
{
	Vector2 value(2.0f, 2.0f);
	Vector2 minimum(1.0f, 2.5f);
	Vector2 maximum(2.75f, 2.75f);

	Vector2 result = Vector2::Clamp(value, minimum, maximum);

	ASSERT_EQ(result.X, 2.0f);
	ASSERT_EQ(result.Y, 2.5f);
}

TEST(Vector2Tests, ClampByRef)
{
	Vector2 value(2.0f, 2.0f);
	Vector2 minimum(1.0f, 2.5f);
	Vector2 maximum(2.75f, 2.75f);

	Vector2 result;
	Vector2::Clamp(value, minimum, maximum, result);

	ASSERT_EQ(result.X, 2.0f);
	ASSERT_EQ(result.Y, 2.5f);
}

TEST(Vector2Tests, Hermite)
{
	Vector2 value1(1.0f, 2.0f);
	Vector2 value2(1.5f, 2.5f);
	Vector2 value3(1.75f, 2.75f);
	Vector2 value4(1.25f, 2.25f);
	float amount = 2.5f;

	D3DXVECTOR2 result1;
	D3DXVec2Hermite(&result1, reinterpret_cast<D3DXVECTOR2*>(&value1), reinterpret_cast<D3DXVECTOR2*>(&value2), reinterpret_cast<D3DXVECTOR2*>(&value3), reinterpret_cast<D3DXVECTOR2*>(&value4), amount);

	Vector2 result2 = Vector2::Hermite(value1, value2, value3, value4, amount);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, HermiteByRef)
{
	Vector2 value1(1.0f, 2.0f);
	Vector2 value2(1.5f, 2.5f);
	Vector2 value3(1.75f, 2.75f);
	Vector2 value4(1.25f, 2.25f);
	float amount = 2.5f;

	D3DXVECTOR2 result1;
	D3DXVec2Hermite(&result1, reinterpret_cast<D3DXVECTOR2*>(&value1), reinterpret_cast<D3DXVECTOR2*>(&value2), reinterpret_cast<D3DXVECTOR2*>(&value3), reinterpret_cast<D3DXVECTOR2*>(&value4), amount);

	Vector2 result2;
	Vector2::Hermite(value1, value2, value3, value4, amount, result2);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, Lerp)
{
	Vector2 value1(1.0f, 2.0f);
	Vector2 value2(1.5f, 2.5f);
	float amount = 0.5f;

	D3DXVECTOR2 result1;
	D3DXVec2Lerp(&result1, reinterpret_cast<D3DXVECTOR2*>(&value1), reinterpret_cast<D3DXVECTOR2*>(&value2), amount);

	Vector2 result2 = Vector2::Lerp(value1, value2, amount);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, LerpByRef)
{
	Vector2 value1(1.0f, 2.0f);
	Vector2 value2(1.5f, 2.5f);
	float amount = 0.5f;

	D3DXVECTOR2 result1;
	D3DXVec2Lerp(&result1, reinterpret_cast<D3DXVECTOR2*>(&value1), reinterpret_cast<D3DXVECTOR2*>(&value2), amount);

	Vector2 result2;
	Vector2::Lerp(value1, value2, amount, result2);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, SmoothStep)
{
	Vector2 value1(1.0f, 2.0f);
	Vector2 value2(1.5f, 2.5f);
	float amount = 0.5f;

	Vector2 result = Vector2::SmoothStep(value1, value2, amount);

	ASSERT_EQ(result.X, 1.25f);
	ASSERT_EQ(result.Y, 2.25f);
}

TEST(Vector2Tests, SmoothStepByRef)
{
	Vector2 value1(1.0f, 2.0f);
	Vector2 value2(1.5f, 2.5f);
	float amount = 0.5f;

	Vector2 result;
	Vector2::SmoothStep(value1, value2, amount, result);

	ASSERT_EQ(result.X, 1.25f);
	ASSERT_EQ(result.Y, 2.25f);
}

TEST(Vector2Tests, Distance)
{
	Vector2 value1(1.0f, 2.0f);
	Vector2 value2(1.75f, 2.75f);

	float result = Vector2::Distance(value1, value2);

	ASSERT_LE(abs(result - 1.06066), 0.000001f);
}

TEST(Vector2Tests, DistanceSquared)
{
	Vector2 value1(1.0f, 2.0f);
	Vector2 value2(1.75f, 2.75f);

	float result = Vector2::DistanceSquared(value1, value2);

	ASSERT_EQ(result, 1.125f);
}

TEST(Vector2Tests, Dot)
{
	Vector2 value1(1.0f, 2.0f);
	Vector2 value2(1.75f, 2.75f);

	float result1 = D3DXVec2Dot(reinterpret_cast<D3DXVECTOR2*>(&value1), reinterpret_cast<D3DXVECTOR2*>(&value2));
	float result2 = Vector2::Dot(value1, value2);

	ASSERT_EQ(result1, result2);
}

TEST(Vector2Tests, TransformByQuat)
{
	Vector2 vector(1.0f, 2.0f);
	Quaternion quat(0.5f, 1.5f, 2.5f, 3.5f);

	Vector2 result = Vector2::Transform(vector, quat);

	ASSERT_EQ(result.X, -48.0f);		// values otained from XNA GS math lib
	ASSERT_EQ(result.Y, -5.0f);
}

TEST(Vector2Tests, TransformByQuatByRef)
{
	Vector2 vector(1.0f, 2.0f);
	Quaternion quat(0.5f, 1.5f, 2.5f, 3.5f);

	Vector2 result;
	Vector2::Transform(vector, quat, result);

	ASSERT_EQ(result.X, -48.0f);		// values otained from XNA GS math lib
	ASSERT_EQ(result.Y, -5.0f);
}

TEST(Vector2Tests, TransformByMatrix)
{
	Vector2 vector(1.0f, 2.0f);
	Matrix matrix = CreateWorldMatrix();

	D3DXVECTOR4 result1;
	D3DXVec2Transform(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector), reinterpret_cast<D3DXMATRIX*>(&matrix));

	Vector4 result2 = Vector2::Transform(vector, matrix);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, TransformByMatrixByRef)
{
	Vector2 vector(1.0f, 2.0f);
	Matrix matrix = CreateWorldMatrix();

	D3DXVECTOR4 result1;
	D3DXVec2Transform(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector), reinterpret_cast<D3DXMATRIX*>(&matrix));

	Vector4 result2;
	Vector2::Transform(vector, matrix, result2);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, TransformCoordinate)
{
	Vector2 vector(1.0f, 2.0f);
	Matrix matrix = CreateWorldMatrix();

	D3DXVECTOR2 result1;
	D3DXVec2TransformCoord(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector), reinterpret_cast<D3DXMATRIX*>(&matrix));

	Vector2 result2 = Vector2::TransformCoordinate(vector, matrix);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, TransformCoordinateByRef)
{
	Vector2 vector(1.0f, 2.0f);
	Matrix matrix = CreateWorldMatrix();

	D3DXVECTOR2 result1;
	D3DXVec2TransformCoord(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector), reinterpret_cast<D3DXMATRIX*>(&matrix));

	Vector2 result2;
	Vector2::TransformCoordinate(vector, matrix, result2);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, TransformNormal)
{
	Vector2 vector(1.0f, 2.0f);
	Matrix matrix = CreateWorldMatrix();

	D3DXVECTOR2 result1;
	D3DXVec2TransformNormal(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector), reinterpret_cast<D3DXMATRIX*>(&matrix));

	Vector2 result2 = Vector2::TransformNormal(vector, matrix);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, TransformNormalByRef)
{
	Vector2 vector(1.0f, 2.0f);
	Matrix matrix = CreateWorldMatrix();

	D3DXVECTOR2 result1;
	D3DXVec2TransformNormal(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector), reinterpret_cast<D3DXMATRIX*>(&matrix));

	Vector2 result2;
	Vector2::TransformNormal(vector, matrix, result2);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, Min)
{
	Vector2 vector1(0.0f, 2.0f);
	Vector2 vector2(1.0f, 2.0f);

	D3DXVECTOR2 result1;
	D3DXVec2Minimize(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector1), reinterpret_cast<D3DXVECTOR2*>(&vector2));

	Vector2 result2 = Vector2::Min(vector1, vector2);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, MineByRef)
{
	Vector2 vector1(0.0f, 2.0f);
	Vector2 vector2(1.0f, 2.0f);

	D3DXVECTOR2 result1;
	D3DXVec2Minimize(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector1), reinterpret_cast<D3DXVECTOR2*>(&vector2));

	Vector2 result2;
	Vector2::Min(vector1, vector2, result2);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, Max)
{
	Vector2 vector1(0.0f, 2.0f);
	Vector2 vector2(1.0f, 2.0f);

	D3DXVECTOR2 result1;
	D3DXVec2Maximize(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector1), reinterpret_cast<D3DXVECTOR2*>(&vector2));

	Vector2 result2 = Vector2::Max(vector1, vector2);

	AssertEq(result1, result2);
}

TEST(Vector2Tests, MaxByRef)
{
	Vector2 vector1(0.0f, 2.0f);
	Vector2 vector2(1.0f, 2.0f);

	D3DXVECTOR2 result1;
	D3DXVec2Maximize(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector1), reinterpret_cast<D3DXVECTOR2*>(&vector2));

	Vector2 result2;
	Vector2::Max(vector1, vector2, result2);

	AssertEq(result1, result2);
}

// ----- OPERATOR TESTS ----- //

TEST(Vector2Tests, AddOperator)
{
	Vector2 vector1 = Vector2(1.0f, 2.0f);
	Vector2 vector2 = Vector2(5.0f, 6.0f);

	D3DXVECTOR2 result1;
	D3DXVec2Add(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector1), reinterpret_cast<D3DXVECTOR2*>(&vector2));

	Vector2 result2 = vector1 + vector2;

	AssertEq(result1, result2);
}

TEST(Vector2Tests, SubtractOperator)
{
	Vector2 vector1 = Vector2(1.0f, 2.0f);
	Vector2 vector2 = Vector2(5.0f, 6.0f);

	D3DXVECTOR2 result1;
	D3DXVec2Subtract(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector1), reinterpret_cast<D3DXVECTOR2*>(&vector2));

	Vector2 result2 = vector1 - vector2;

	AssertEq(result1, result2);
}

TEST(Vector2Tests, MultiplyOperatorScalarOnLeft)
{
	Vector2 vector1 = Vector2(1.0f, 2.0f);
	float amount = 2.5f;

	D3DXVECTOR2 result1;
	D3DXVec2Scale(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector1), amount);

	Vector2 result2 = amount * vector1;

	AssertEq(result1, result2);
}

TEST(Vector2Tests, MultiplyOperatorScalarOnRight)
{
	Vector2 vector1 = Vector2(1.0f, 2.0f);
	float amount = 2.5f;

	D3DXVECTOR2 result1;
	D3DXVec2Scale(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector1), amount);

	Vector2 result2 = vector1 * amount;

	AssertEq(result1, result2);
}

TEST(Vector2Tests, DivideOperator)
{
	Vector2 vector1 = Vector2(1.0f, 2.0f);
	float amount = 2.5f;

	D3DXVECTOR2 result1;
	D3DXVec2Scale(&result1, reinterpret_cast<D3DXVECTOR2*>(&vector1), 1.0f / amount);

	Vector2 result2 = vector1 / amount;

	AssertEq(result1, result2);
}

TEST(Vector2Tests, NegateOperator)
{
	Vector2 vector = Vector2(1.0f, -2.0f);
	Vector2 result = -vector;

	ASSERT_EQ(result.X, -1.0f);
	ASSERT_EQ(result.Y, 2.0f);
}

TEST(Vector2Tests, EqualityOperator)
{
	Vector2 vector1(1.0f, 2.0f);
	Vector2 vector2(1.0f, 2.0f);
	Vector2 vector3(2.0f, 2.0f);

	ASSERT_TRUE(vector1 == vector2);
	ASSERT_TRUE(vector2 == vector1);
	ASSERT_FALSE(vector3 == vector1);
}

TEST(Vector2Tests, InequalityOperator)
{
	Vector2 vector1(1.0f, 2.0f);
	Vector2 vector2(1.0f, 2.0f);
	Vector2 vector3(2.0f, 2.0f);

	ASSERT_FALSE(vector1 != vector2);
	ASSERT_FALSE(vector2 != vector1);
	ASSERT_TRUE(vector3 != vector1);
}

// ----- EQUALS TESTS ----- //

TEST(Vector2Tests, Equals)
{
	Vector2 vector1(1.0f, 2.0f);
	Vector2 vector2(1.0f, 2.0f);
	Vector2 vector3(2.0f, 2.0f);

	ASSERT_TRUE(vector1.Equals(vector2));
	ASSERT_TRUE(vector2.Equals(vector1));
	ASSERT_FALSE(vector3.Equals(vector1));
}

TEST(Vector2Tests, EqualsObject)
{
	Vector2 vector1(1.0f, 2.0f);
	Vector2 vector2(1.0f, 2.0f);
	Vector2 vector3(2.0f, 2.0f);

	ASSERT_TRUE(vector1.Equals(safe_cast<Object^>(vector2)));
	ASSERT_TRUE(vector2.Equals(safe_cast<Object^>(vector1)));
	ASSERT_FALSE(vector3.Equals(safe_cast<Object^>(vector1)));
}

TEST(Vector2Tests, GetHashCode)
{
	Vector2 vector1(1.0f, 2.0f);
	Vector2 vector2(1.0f, 2.0f);

	ASSERT_EQ(vector1.GetHashCode(), vector2.GetHashCode());
}