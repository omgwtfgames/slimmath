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
#include "TestValues.h"

using namespace SlimMath;

Matrix CreateCountedMatrix()
{
	Matrix matrix;
	for (int i = 0; i < 16; i++)
		matrix[i] = static_cast<float>(i);

	return matrix;
}

Matrix CreateWorldMatrix()
{
	return Matrix::RotationX(1.0f) * Matrix::Translation(1.0f, 2.0f, 3.0f) * Matrix::Scaling(2.0f, 0.5f, 1.0f);
}

Matrix CreateViewMatrix()
{
	return Matrix::LookAtLH(Vector3::UnitX, Vector3::Zero, Vector3::UnitY);
}

Matrix CreateProjectionMatrix()
{
	return Matrix::PerspectiveFovLH(1.0f, 1.333f, 1.0f, 100.0f);
}