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
#include "TestValues.h"

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

Matrix CreateTestMatrix(int index)
{
	Matrix matrix;
	matrix.M11 = index * 0.5f;
	matrix.M12 = index * 0.5f;
	matrix.M13 = index * 0.5f;
	matrix.M14 = 1.0f;
	matrix.M21 = index;
	matrix.M22 = index;
	matrix.M23 = index;
	matrix.M24 = 0.5f;
	matrix.M31 = index * 3.0f;
	matrix.M32 = index * 2.0f;
	matrix.M33 = index * 2.0f;
	matrix.M34 = 1.0f;
	matrix.M41 = index * 2.0f;
	matrix.M42 = index * 3.0f;
	matrix.M43 = index * 3.0f;
	matrix.M44 = 2.5f;

	return matrix;
}