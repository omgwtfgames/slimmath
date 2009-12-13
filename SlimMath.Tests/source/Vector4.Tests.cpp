/*
* Copyright (c) 2007-2009 SlimDX Group
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

using namespace testing;
using namespace System;
using namespace SlimMath;

Matrix CreateTestMatrix()
{
	Matrix matrix;
	matrix.M11 = 0.25f;
	matrix.M12 = 0.5f;
	matrix.M13 = 0.75f;
	matrix.M14 = 1.0f;
	matrix.M21 = 0.25f;
	matrix.M22 = 0.5f;
	matrix.M23 = 0.75f;
	matrix.M24 = 1.0f;
	matrix.M31 = 0.25f;
	matrix.M32 = 0.5f;
	matrix.M33 = 0.75f;
	matrix.M34 = 1.0f;
	matrix.M41 = 0.25f;
	matrix.M42 = 0.5f;
	matrix.M43 = 0.75f;
	matrix.M44 = 1.0f;

	return matrix;
}

void AssertEq(D3DXVECTOR4 result1, Vector4 result2)
{
	ASSERT_EQ(result1.x, result2.X);
	ASSERT_EQ(result1.y, result2.Y);
	ASSERT_EQ(result1.z, result2.Z);
	ASSERT_EQ(result1.w, result2.W);
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

TEST(Vector4Tests, TransformByMatrix)
{
	Vector4 vector(1.0f, 2.0f, 3.0f, 4.0f);
	Matrix matrix = CreateTestMatrix();

	D3DXVECTOR4 result1;
	D3DXVec4Transform(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector), reinterpret_cast<D3DXMATRIX*>(&matrix));

	Vector4 result2 = Vector4::Transform(vector, matrix);

	AssertEq(result1, result2);
}

TEST(Vector4Tests, TransformByMatrixByRef)
{
	Vector4 vector(1.0f, 2.0f, 3.0f, 4.0f);
	Matrix matrix = CreateTestMatrix();

	D3DXVECTOR4 result1;
	D3DXVec4Transform(&result1, reinterpret_cast<D3DXVECTOR4*>(&vector), reinterpret_cast<D3DXMATRIX*>(&matrix));

	Vector4 result2;
	Vector4::Transform(vector, matrix, result2);

	AssertEq(result1, result2);
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