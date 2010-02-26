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

TEST(MatrixTests, ConstructDefault)
{
	Matrix matrix = Matrix();
	for (int i = 0; i < 16; i++)
		ASSERT_EQ(0.0f, matrix[i]);
}

TEST(MatrixTests, ConstructWithValues)
{
	array<float>^ testValues = gcnew array<float>(16);
	for (int i = 0; i < 16; i++)
		testValues[i] = static_cast<float>(i);

	Matrix matrix(testValues);
	for (int i = 0; i < 16; i++)
		ASSERT_EQ(i, matrix[i]);
}

// ----- PROPERTY TESTS ----- //

TEST(MatrixTests, SizeInBytes)
{
	ASSERT_EQ(Matrix::SizeInBytes, 16 * 4);
}

TEST(MatrixTests, MatrixZero)
{
	Matrix matrix = Matrix::Zero;
	for (int i = 0; i < 16; i++)
		ASSERT_EQ(0.0f, matrix[i]);
}

TEST(MatrixTests, Identity)
{
	D3DXMATRIX expected;
	D3DXMatrixIdentity(&expected);

	AssertEq(expected, Matrix::Identity);
}

TEST(MatrixTests, IsIdentity)
{
	Matrix testSuccess = Matrix::Identity;
	Matrix testFailure = CreateCountedMatrix();

	ASSERT_TRUE(testSuccess.IsIdentity);
	ASSERT_FALSE(testFailure.IsIdentity);
}

TEST(MatrixTests, SingleIndexerGet)
{
	Matrix matrix = CreateCountedMatrix();
	float v;
	
	for (int i = 0; i < 16; i++)
	{
		ASSERT_NO_THROW(v = matrix[i]);
		ASSERT_EQ(v, i);
	}
}

TEST(MatrixTests, SingleIndexerGetOutOfRange)
{
	Matrix matrix = CreateCountedMatrix();
	float v;

	ASSERT_MANAGED_THROW(v = matrix[-1], ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW(v = matrix[16], ArgumentOutOfRangeException);
}

TEST(MatrixTests, SingleIndexerSet)
{
	Matrix matrix = CreateCountedMatrix();
	
	for (int i = 0; i < 16; i++)
	{
		ASSERT_NO_THROW(matrix[i] = 1.5f);
		ASSERT_EQ(1.5f, matrix[i]);
	}
}

TEST(MatrixTests, SingleIndexerSetOutOfRange)
{
	Matrix matrix = CreateCountedMatrix();

	ASSERT_MANAGED_THROW(matrix[-1] = 5.0f, ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW(matrix[16] = 5.0f, ArgumentOutOfRangeException);
}

TEST(MatrixTests, DoubleIndexerGet)
{
	Matrix matrix = CreateCountedMatrix();
	float v;

	for (int row = 0; row < 4; row++)
	{
		for (int col = 0; col < 4; col++)
		{
			ASSERT_NO_THROW((v = matrix[row, col]));
			ASSERT_EQ(v, (row * 4) + col);
		}
	}
}

TEST(MatrixTests, DoubleIndexerGetOutOfRange)
{
	Matrix matrix = CreateCountedMatrix();
	float v;

	ASSERT_MANAGED_THROW((v = matrix[-1, 0]), ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW((v = matrix[4, 0]), ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW((v = matrix[0, -1]), ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW((v = matrix[0, 4]), ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW((v = matrix[-1, -1]), ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW((v = matrix[4, 4]), ArgumentOutOfRangeException);
}

TEST(MatrixTests, DoubleIndexerSet)
{
	Matrix matrix = CreateCountedMatrix();

	for (int row = 0; row < 4; row++)
	{
		for (int col = 0; col < 4; col++)
		{
			ASSERT_NO_THROW((matrix[row, col] = 1.5f));
			ASSERT_EQ(1.5f, (matrix[row, col]));
		}
	}
}

TEST(MatrixTests, DoubleIndexerSetOutOfRange)
{
	Matrix matrix = CreateCountedMatrix();

	ASSERT_MANAGED_THROW((matrix[-1, 0] = 5.0f), ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW((matrix[4, 0] = 5.0f), ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW((matrix[0, -1] = 5.0f), ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW((matrix[0, 4] = 5.0f), ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW((matrix[-1, -1] = 5.0f), ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW((matrix[4, 4] = 5.0f), ArgumentOutOfRangeException);
}

// ----- METHOD TESTS ----- //

TEST(MatrixTests, Determinant)
{
	Matrix test = Matrix::RotationX(1.0f) * Matrix::Translation(1.0f, 2.0f, 3.0f);

	ASSERT_FLOAT_EQ(D3DXMatrixDeterminant(reinterpret_cast<D3DXMATRIX*>(&test)), test.Determinant());
}

TEST(MatrixTests, InvertInstance)
{
	Matrix test = Matrix::RotationX(1.0f) * Matrix::Translation(1.0f, 2.0f, 3.0f);

	D3DXMATRIX expected;
	D3DXMatrixInverse(&expected, NULL, reinterpret_cast<D3DXMATRIX*>(&test));

	test.Invert();
	AssertEq(expected, test);
}

TEST(MatrixTests, ToArray)
{
	Matrix test = CreateCountedMatrix();
	array<float>^ values = test.ToArray();

	for (int i = 0; i < 16; i++)
		ASSERT_FLOAT_EQ(static_cast<float>(i), values[i]);
}

TEST(MatrixTests, Multiply)
{
	Matrix left = CreateWorldMatrix();
	Matrix right = CreateViewMatrix();

	D3DXMATRIX expected;
	D3DXMatrixMultiply(&expected, reinterpret_cast<D3DXMATRIX*>(&left), reinterpret_cast<D3DXMATRIX*>(&right));

	Matrix actual = Matrix::Multiply(left, right);

	AssertEq(expected, actual);
}

TEST(MatrixTests, MultiplyByRef)
{
	Matrix left = CreateWorldMatrix();
	Matrix right = CreateViewMatrix();

	D3DXMATRIX expected;
	D3DXMatrixMultiply(&expected, reinterpret_cast<D3DXMATRIX*>(&left), reinterpret_cast<D3DXMATRIX*>(&right));

	Matrix actual;
	Matrix::Multiply(left, right, actual);

	AssertEq(expected, actual);
}

TEST(MatrixTests, Invert)
{
	Matrix test = CreateWorldMatrix();

	D3DXMATRIX expected;
	D3DXMatrixInverse(&expected, NULL, reinterpret_cast<D3DXMATRIX*>(&test));

	Matrix actual = Matrix::Invert(test);

	AssertEq(expected, actual);
}

TEST(MatrixTests, InvertByRef)
{
	Matrix test = CreateWorldMatrix();

	D3DXMATRIX expected;
	D3DXMatrixInverse(&expected, NULL, reinterpret_cast<D3DXMATRIX*>(&test));

	Matrix actual;
	Matrix::Invert(test, actual);

	AssertEq(expected, actual);
}

TEST(MatrixTests, RotationX)
{
	Matrix actual = Matrix::RotationX(1.5f);

	D3DXMATRIX expected;
	D3DXMatrixRotationX(&expected, 1.5f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, RotationXByRef)
{
	Matrix actual;
	Matrix::RotationX(1.5f, actual);

	D3DXMATRIX expected;
	D3DXMatrixRotationX(&expected, 1.5f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, RotationY)
{
	Matrix actual = Matrix::RotationY(1.5f);

	D3DXMATRIX expected;
	D3DXMatrixRotationY(&expected, 1.5f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, RotationYByRef)
{
	Matrix actual;
	Matrix::RotationY(1.5f, actual);

	D3DXMATRIX expected;
	D3DXMatrixRotationY(&expected, 1.5f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, RotationZ)
{
	Matrix actual = Matrix::RotationZ(1.5f);

	D3DXMATRIX expected;
	D3DXMatrixRotationZ(&expected, 1.5f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, RotationZByRef)
{
	Matrix actual;
	Matrix::RotationZ(1.5f, actual);

	D3DXMATRIX expected;
	D3DXMatrixRotationZ(&expected, 1.5f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, RotationAxis)
{
	Vector3 axis(1.5f, 2.0f, 3.0f);
	Matrix actual = Matrix::RotationAxis(axis, 1.5f);

	D3DXMATRIX expected;
	D3DXMatrixRotationAxis(&expected, reinterpret_cast<D3DXVECTOR3*>(&axis), 1.5f);

	AssertEq(expected, actual, 1e-6f);
}

TEST(MatrixTests, RotationAxisByRef)
{
	Vector3 axis(1.5f, 2.0f, 3.0f);
	Matrix actual;
	Matrix::RotationAxis(axis, 1.5f, actual);

	D3DXMATRIX expected;
	D3DXMatrixRotationAxis(&expected, reinterpret_cast<D3DXVECTOR3*>(&axis), 1.5f);

	AssertEq(expected, actual, 1e-6f);
}

TEST(MatrixTests, RotationQuaternion)
{
	Quaternion rotation(1.5f, 2.0f, 3.0f, 4.0f);
	Matrix actual = Matrix::RotationQuaternion(rotation);

	D3DXMATRIX expected;
	D3DXMatrixRotationQuaternion(&expected, reinterpret_cast<D3DXQUATERNION*>(&rotation));

	AssertEq(expected, actual);
}

TEST(MatrixTests, RotationQuaternionByRef)
{
	Quaternion rotation(1.5f, 2.0f, 3.0f, 4.0f);
	Matrix actual;
	Matrix::RotationQuaternion(rotation, actual);

	D3DXMATRIX expected;
	D3DXMatrixRotationQuaternion(&expected, reinterpret_cast<D3DXQUATERNION*>(&rotation));

	AssertEq(expected, actual);
}

TEST(MatrixTests, RotationYawPitchRoll)
{
	Matrix actual = Matrix::RotationYawPitchRoll(1.5f, 2.0f, 3.0f);

	D3DXMATRIX expected;
	D3DXMatrixRotationYawPitchRoll(&expected, 1.5f, 2.0f, 3.0f);

	AssertEq(expected, actual, 1e-6f);
}

TEST(MatrixTests, RotationYawPitchRollByRef)
{
	Matrix actual;
	Matrix::RotationYawPitchRoll(1.5f, 2.0f, 3.0f, actual);

	D3DXMATRIX expected;
	D3DXMatrixRotationYawPitchRoll(&expected, 1.5f, 2.0f, 3.0f);

	AssertEq(expected, actual, 1e-6f);
}

TEST(MatrixTests, LookAtLH)
{
	Vector3 target(1.0f, 2.0f, 3.0f);
	Vector3 eye(1.5, 2.5f, 3.5f);
	Vector3 up(0.0f, 1.0f, 0.0f);

	Matrix actual = Matrix::LookAtLH(eye, target, up);

	D3DXMATRIX expected;
	D3DXMatrixLookAtLH(&expected, reinterpret_cast<D3DXVECTOR3*>(&eye), reinterpret_cast<D3DXVECTOR3*>(&target), reinterpret_cast<D3DXVECTOR3*>(&up));

	AssertEq(expected, actual);
}

TEST(MatrixTests, LookAtLHByRef)
{
	Vector3 target(1.0f, 2.0f, 3.0f);
	Vector3 eye(1.5, 2.5f, 3.5f);
	Vector3 up(0.0f, 1.0f, 0.0f);

	Matrix actual;
	Matrix::LookAtLH(eye, target, up, actual);

	D3DXMATRIX expected;
	D3DXMatrixLookAtLH(&expected, reinterpret_cast<D3DXVECTOR3*>(&eye), reinterpret_cast<D3DXVECTOR3*>(&target), reinterpret_cast<D3DXVECTOR3*>(&up));

	AssertEq(expected, actual);
}

TEST(MatrixTests, LookAtRH)
{
	Vector3 target(1.0f, 2.0f, 3.0f);
	Vector3 eye(1.5, 2.5f, 3.5f);
	Vector3 up(0.0f, 1.0f, 0.0f);

	Matrix actual = Matrix::LookAtRH(eye, target, up);

	D3DXMATRIX expected;
	D3DXMatrixLookAtRH(&expected, reinterpret_cast<D3DXVECTOR3*>(&eye), reinterpret_cast<D3DXVECTOR3*>(&target), reinterpret_cast<D3DXVECTOR3*>(&up));

	AssertEq(expected, actual);
}

TEST(MatrixTests, LookAtRHByRef)
{
	Vector3 target(1.0f, 2.0f, 3.0f);
	Vector3 eye(1.5, 2.5f, 3.5f);
	Vector3 up(0.0f, 1.0f, 0.0f);

	Matrix actual;
	Matrix::LookAtRH(eye, target, up, actual);

	D3DXMATRIX expected;
	D3DXMatrixLookAtRH(&expected, reinterpret_cast<D3DXVECTOR3*>(&eye), reinterpret_cast<D3DXVECTOR3*>(&target), reinterpret_cast<D3DXVECTOR3*>(&up));

	AssertEq(expected, actual);
}

TEST(MatrixTests, OrthoLH)
{
	Matrix actual = Matrix::OrthoLH(10.0f, 2.0f, 1.5f, 100.0f);

	D3DXMATRIX expected;
	D3DXMatrixOrthoLH(&expected, 10.0f, 2.0f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, OrthoLHByRef)
{
	Matrix actual;
	Matrix::OrthoLH(10.0f, 2.0f, 1.5f, 100.0f, actual);

	D3DXMATRIX expected;
	D3DXMatrixOrthoLH(&expected, 10.0f, 2.0f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, OrthoRH)
{
	Matrix actual = Matrix::OrthoRH(10.0f, 2.0f, 1.5f, 100.0f);

	D3DXMATRIX expected;
	D3DXMatrixOrthoRH(&expected, 10.0f, 2.0f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, OrthoRHByRef)
{
	Matrix actual;
	Matrix::OrthoRH(10.0f, 2.0f, 1.5f, 100.0f, actual);

	D3DXMATRIX expected;
	D3DXMatrixOrthoRH(&expected, 10.0f, 2.0f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, OrthoOffCenterLH)
{
	Matrix actual = Matrix::OrthoOffCenterLH(-10.0f, 2.0f, -1.0f, 10.0f, 1.5f, 100.0f);

	D3DXMATRIX expected;
	D3DXMatrixOrthoOffCenterLH(&expected, -10.0f, 2.0f, -1.0f, 10.0f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, OrthoOffCenterLHByRef)
{
	Matrix actual;
	Matrix::OrthoOffCenterLH(-10.0f, 2.0f, -1.0f, 10.0f, 1.5f, 100.0f, actual);

	D3DXMATRIX expected;
	D3DXMatrixOrthoOffCenterLH(&expected, -10.0f, 2.0f, -1.0f, 10.0f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, OrthoOffCenterRH)
{
	Matrix actual = Matrix::OrthoOffCenterRH(-10.0f, 2.0f, -1.0f, 10.0f, 1.5f, 100.0f);

	D3DXMATRIX expected;
	D3DXMatrixOrthoOffCenterRH(&expected, -10.0f, 2.0f, -1.0f, 10.0f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, OrthoOffCenterRHByRef)
{
	Matrix actual;
	Matrix::OrthoOffCenterRH(-10.0f, 2.0f, -1.0f, 10.0f, 1.5f, 100.0f, actual);

	D3DXMATRIX expected;
	D3DXMatrixOrthoOffCenterRH(&expected, -10.0f, 2.0f, -1.0f, 10.0f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, PerspectiveLH)
{
	Matrix actual = Matrix::PerspectiveLH(10.0f, 2.0f, 1.5f, 100.0f);

	D3DXMATRIX expected;
	D3DXMatrixPerspectiveLH(&expected, 10.0f, 2.0f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, PerspectiveLHByRef)
{
	Matrix actual;
	Matrix::PerspectiveLH(10.0f, 2.0f, 1.5f, 100.0f, actual);

	D3DXMATRIX expected;
	D3DXMatrixPerspectiveLH(&expected, 10.0f, 2.0f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, PerspectiveRH)
{
	Matrix actual = Matrix::PerspectiveRH(10.0f, 2.0f, 1.5f, 100.0f);

	D3DXMATRIX expected;
	D3DXMatrixPerspectiveRH(&expected, 10.0f, 2.0f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, PerspectiveRHByRef)
{
	Matrix actual;
	Matrix::PerspectiveRH(10.0f, 2.0f, 1.5f, 100.0f, actual);

	D3DXMATRIX expected;
	D3DXMatrixPerspectiveRH(&expected, 10.0f, 2.0f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, PerspectiveOffCenterLH)
{
	Matrix actual = Matrix::PerspectiveOffCenterLH(-10.0f, 2.0f, -1.0f, 10.0f, 1.5f, 100.0f);

	D3DXMATRIX expected;
	D3DXMatrixPerspectiveOffCenterLH(&expected, -10.0f, 2.0f, -1.0f, 10.0f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, PerspectiveOffCenterLHByRef)
{
	Matrix actual;
	Matrix::PerspectiveOffCenterLH(-10.0f, 2.0f, -1.0f, 10.0f, 1.5f, 100.0f, actual);

	D3DXMATRIX expected;
	D3DXMatrixPerspectiveOffCenterLH(&expected, -10.0f, 2.0f, -1.0f, 10.0f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, PerspectiveOffCenterRH)
{
	Matrix actual = Matrix::PerspectiveOffCenterRH(-10.0f, 2.0f, -1.0f, 10.0f, 1.5f, 100.0f);

	D3DXMATRIX expected;
	D3DXMatrixPerspectiveOffCenterRH(&expected, -10.0f, 2.0f, -1.0f, 10.0f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, PerspectiveOffCenterRHByRef)
{
	Matrix actual;
	Matrix::PerspectiveOffCenterRH(-10.0f, 2.0f, -1.0f, 10.0f, 1.5f, 100.0f, actual);

	D3DXMATRIX expected;
	D3DXMatrixPerspectiveOffCenterRH(&expected, -10.0f, 2.0f, -1.0f, 10.0f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, PerspectiveFovLH)
{
	Matrix actual = Matrix::PerspectiveFovLH(2.0f, 1.333f, 1.5f, 100.0f);

	D3DXMATRIX expected;
	D3DXMatrixPerspectiveFovLH(&expected, 2.0f, 1.333f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, PerspectiveFovLHByRef)
{
	Matrix actual;
	Matrix::PerspectiveFovLH(2.0f, 1.333f, 1.5f, 100.0f, actual);

	D3DXMATRIX expected;
	D3DXMatrixPerspectiveFovLH(&expected, 2.0f, 1.333f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, PerspectiveFovRH)
{
	Matrix actual = Matrix::PerspectiveFovRH(2.0f, 1.333f, 1.5f, 100.0f);

	D3DXMATRIX expected;
	D3DXMatrixPerspectiveFovRH(&expected, 2.0f, 1.333f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

TEST(MatrixTests, PerspectiveFovRHByRef)
{
	Matrix actual;
	Matrix::PerspectiveFovRH(2.0f, 1.333f, 1.5f, 100.0f, actual);

	D3DXMATRIX expected;
	D3DXMatrixPerspectiveFovRH(&expected, 2.0f, 1.333f, 1.5f, 100.0f);

	AssertEq(expected, actual);
}

// ----- OPERATOR TESTS ----- //

TEST(MatrixTests, EqualityOperator)
{
	Matrix matrix1 = CreateCountedMatrix();
	Matrix matrix2 = CreateCountedMatrix();
	Matrix matrix3 = CreateWorldMatrix();

	ASSERT_TRUE(matrix1 == matrix2);
	ASSERT_TRUE(matrix2 == matrix1);
	ASSERT_FALSE(matrix3 == matrix1);
}

TEST(MatrixTests, InequalityOperator)
{
	Matrix matrix1 = CreateCountedMatrix();
	Matrix matrix2 = CreateCountedMatrix();
	Matrix matrix3 = CreateWorldMatrix();

	ASSERT_FALSE(matrix1 != matrix2);
	ASSERT_FALSE(matrix2 != matrix1);
	ASSERT_TRUE(matrix3 != matrix1);
}

// ----- EQUALS TESTS ----- //

TEST(MatrixTests, Equals)
{
	Matrix matrix1 = CreateCountedMatrix();
	Matrix matrix2 = CreateCountedMatrix();
	Matrix matrix3 = CreateWorldMatrix();

	ASSERT_TRUE(matrix1.Equals(matrix2));
	ASSERT_TRUE(matrix2.Equals(matrix1));
	ASSERT_FALSE(matrix3.Equals(matrix1));
}

TEST(MatrixTests, EqualsObject)
{
	Matrix matrix1 = CreateCountedMatrix();
	Matrix matrix2 = CreateCountedMatrix();
	Matrix matrix3 = CreateWorldMatrix();

	ASSERT_TRUE(matrix1.Equals(safe_cast<Object^>(matrix2)));
	ASSERT_TRUE(matrix2.Equals(safe_cast<Object^>(matrix1)));
	ASSERT_FALSE(matrix3.Equals(safe_cast<Object^>(matrix1)));
}

TEST(MatrixTests, GetHashCode)
{
	Matrix matrix1 = CreateCountedMatrix();
	Matrix matrix2 = CreateCountedMatrix();

	ASSERT_EQ(matrix1.GetHashCode(), matrix2.GetHashCode());
}