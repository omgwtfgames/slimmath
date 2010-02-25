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
	Matrix testFailure = CreateTestMatrix();

	ASSERT_TRUE(testSuccess.IsIdentity);
	ASSERT_FALSE(testFailure.IsIdentity);
}

TEST(MatrixTests, SingleIndexerGet)
{
	Matrix matrix = CreateTestMatrix();
	float v;
	
	for (int i = 0; i < 16; i++)
	{
		ASSERT_NO_THROW(v = matrix[i]);
		ASSERT_EQ(v, i);
	}
}

TEST(MatrixTests, SingleIndexerGetOutOfRange)
{
	Matrix matrix = CreateTestMatrix();
	float v;

	ASSERT_MANAGED_THROW(v = matrix[-1], ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW(v = matrix[16], ArgumentOutOfRangeException);
}

TEST(MatrixTests, SingleIndexerSet)
{
	Matrix matrix = CreateTestMatrix();
	
	for (int i = 0; i < 16; i++)
	{
		ASSERT_NO_THROW(matrix[i] = 1.5f);
		ASSERT_EQ(1.5f, matrix[i]);
	}
}

TEST(MatrixTests, SingleIndexerSetOutOfRange)
{
	Matrix matrix = CreateTestMatrix();

	ASSERT_MANAGED_THROW(matrix[-1] = 5.0f, ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW(matrix[16] = 5.0f, ArgumentOutOfRangeException);
}

TEST(MatrixTests, DoubleIndexerGet)
{
	Matrix matrix = CreateTestMatrix();
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
	Matrix matrix = CreateTestMatrix();
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
	Matrix matrix = CreateTestMatrix();

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
	Matrix matrix = CreateTestMatrix();

	ASSERT_MANAGED_THROW((matrix[-1, 0] = 5.0f), ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW((matrix[4, 0] = 5.0f), ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW((matrix[0, -1] = 5.0f), ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW((matrix[0, 4] = 5.0f), ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW((matrix[-1, -1] = 5.0f), ArgumentOutOfRangeException);
	ASSERT_MANAGED_THROW((matrix[4, 4] = 5.0f), ArgumentOutOfRangeException);
}

// ----- METHOD TESTS ----- //

TEST(MatrixTests, Invert)
{
	Matrix test = Matrix::RotationX(1.0f) * Matrix::Translation(1.0f, 2.0f, 3.0f);

	D3DXMATRIX expected;
	D3DXMatrixInverse(&expected, NULL, reinterpret_cast<D3DXMATRIX*>(&test));

	Matrix actual = Matrix::Invert(test);
	AssertEq(expected, actual);
}

// ----- OPERATOR TESTS ----- //

TEST(MatrixTests, EqualityOperator)
{
	Matrix matrix1 = CreateTestMatrix(1);
	Matrix matrix2 = CreateTestMatrix(1);
	Matrix matrix3 = CreateTestMatrix(2);

	ASSERT_TRUE(matrix1 == matrix2);
	ASSERT_TRUE(matrix2 == matrix1);
	ASSERT_FALSE(matrix3 == matrix1);
}

TEST(MatrixTests, InequalityOperator)
{
	Matrix matrix1 = CreateTestMatrix(1);
	Matrix matrix2 = CreateTestMatrix(1);
	Matrix matrix3 = CreateTestMatrix(2);

	ASSERT_FALSE(matrix1 != matrix2);
	ASSERT_FALSE(matrix2 != matrix1);
	ASSERT_TRUE(matrix3 != matrix1);
}

// ----- EQUALS TESTS ----- //

TEST(MatrixTests, Equals)
{
	Matrix matrix1 = CreateTestMatrix(1);
	Matrix matrix2 = CreateTestMatrix(1);
	Matrix matrix3 = CreateTestMatrix(2);

	ASSERT_TRUE(matrix1.Equals(matrix2));
	ASSERT_TRUE(matrix2.Equals(matrix1));
	ASSERT_FALSE(matrix3.Equals(matrix1));
}

TEST(MatrixTests, EqualsObject)
{
	Matrix matrix1 = CreateTestMatrix(1);
	Matrix matrix2 = CreateTestMatrix(1);
	Matrix matrix3 = CreateTestMatrix(2);

	ASSERT_TRUE(matrix1.Equals(safe_cast<Object^>(matrix2)));
	ASSERT_TRUE(matrix2.Equals(safe_cast<Object^>(matrix1)));
	ASSERT_FALSE(matrix3.Equals(safe_cast<Object^>(matrix1)));
}

TEST(MatrixTests, GetHashCode)
{
	Matrix matrix1 = CreateTestMatrix(1);
	Matrix matrix2 = CreateTestMatrix(1);

	ASSERT_EQ(matrix1.GetHashCode(), matrix2.GetHashCode());
}