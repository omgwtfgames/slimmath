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
#include "Asserts.h"

void AssertEq(D3DXVECTOR2 result1, SlimMath::Vector2 result2)
{
	ASSERT_LE(abs(result1.x - result2.X), 0.000001f);
	ASSERT_LE(abs(result1.y - result2.Y), 0.000001f);
}

void AssertEq(D3DXVECTOR3 result1, SlimMath::Vector3 result2)
{
	ASSERT_LE(abs(result1.x - result2.X), 0.000001f);
	ASSERT_LE(abs(result1.y - result2.Y), 0.000001f);
	ASSERT_LE(abs(result1.z - result2.Z), 0.000001f);
}

void AssertEq(D3DXVECTOR4 result1, SlimMath::Vector4 result2)
{
	ASSERT_LE(abs(result1.x - result2.X), 0.000001f);
	ASSERT_LE(abs(result1.y - result2.Y), 0.000001f);
	ASSERT_LE(abs(result1.z - result2.Z), 0.000001f);
	ASSERT_LE(abs(result1.w - result2.W), 0.000001f);
}