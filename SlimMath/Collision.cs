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
using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace SlimMath
{
    /*
     * This class is organized so that the least complex objects come first so that the least
     * complex objects will have the most methods in most cases. Note that not all shapes exist
     * at this time and not all shapes have a corresponding struct. Only the objects that have
     * a corresponding struct should come first in naming and in parameter order. The order of
     * complexity is as follows:
     * 
     * 1. Point
     * 2. Ray
     * 3. Segment
     * 4. Plane
     * 5. Triangle
     * 6. Box
     * 7. Sphere
     * 8. Ellipsoid
     * 9. Cone
     * 10. Cylinder
     * 11. Frustum
    */

    /// <summary>
    /// Contains static methods to help in determining intersections, containment, etc.
    /// </summary>
    public static class Collision
    {
        /// <summary>
        /// Determines whether there is an intersection between a <see cref="SlimMath.Ray"/> and a <see cref="SlimMath.Plane"/>.
        /// </summary>
        /// <param name="ray">The ray to test.</param>
        /// <param name="plane">The plane to test.</param>
        /// <param name="distance">When the method completes, contains the distance of the intersection,
        /// or 0 if there was no intersection.</param>
        /// <returns>Whether the two objects intersect.</returns>
        public static bool RayIntersectsPlane(ref Ray ray, ref Plane plane, out float distance)
        {
            float direction;
            Vector3.Dot(ref plane.Normal, ref ray.Direction, out direction);

            if (Math.Abs(direction) < Utilities.ZeroTolerance)
            {
                distance = 0f;
                return false;
            }

            float position;
            Vector3.Dot(ref plane.Normal, ref ray.Position, out position);
            distance = (plane.D - position) / direction;

            if (distance < 0f)
            {
                if (distance < -Utilities.ZeroTolerance)
                {
                    distance = 0;
                    return false;
                }

                distance = 0f;
            }

            return true;
        }

        /// <summary>
        /// Determines whether there is an intersection between a <see cref="SlimMath.Ray"/> and a <see cref="SlimMath.Plane"/>.
        /// </summary>
        /// <param name="ray">The ray to test.</param>
        /// <param name="plane">The plane to test</param>
        /// <param name="point">When the method completes, contains the point of intersection,
        /// or <see cref="SlimMath.Vector3.Zero"/> if there was no intersection.</param>
        /// <returns>Whether the two objects intersected.</returns>
        public static bool RayIntersectsPlane(ref Ray ray, ref Plane plane, out Vector3 point)
        {
            float distance;
            if (!RayIntersectsPlane(ref ray, ref plane, out distance))
            {
                point = Vector3.Zero;
                return false;
            }

            point = ray.Position + (ray.Direction * distance);
            return true;
        }

        /// <summary>
        /// Determines whether there is an intersection between a <see cref="SlimMath.Ray"/> and a triangle.
        /// </summary>
        /// <param name="ray">The ray to test.</param>
        /// <param name="vertex1">The first vertex of the triangle to test.</param>
        /// <param name="vertex2">The second vertex of the triagnle to test.</param>
        /// <param name="vertex3">The third vertex of the triangle to test.</param>
        /// <param name="distance">When the method completes, contains the distance of the intersection,
        /// or 0 if there was no intersection.</param>
        /// <returns>Whether the two objects intersected.</returns>
        public static bool RayIntersectsTriangle(ref Ray ray, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3, out float distance)
        {
            //Compute vectors along two edges of the triangle.
            Vector3 edge1, edge2;

            edge1.X = vertex2.X - vertex1.X;
            edge1.Y = vertex2.Y - vertex1.Y;
            edge1.Z = vertex2.Z - vertex1.Z;

            edge2.X = vertex3.X - vertex1.X;
            edge2.Y = vertex3.Y - vertex1.Y;
            edge2.Z = vertex3.Z - vertex1.Z;

            Vector3 directioncrossedge2;
            directioncrossedge2.X = (ray.Direction.Y * edge2.Z) - (ray.Direction.Z * edge2.Y);
            directioncrossedge2.Y = (ray.Direction.Z * edge2.X) - (ray.Direction.X * edge2.Z);
            directioncrossedge2.Z = (ray.Direction.X * edge2.Y) - (ray.Direction.Y * edge2.X);

            //Compute the determinant.
            float determinant;
            determinant = (edge1.X * directioncrossedge2.X) + (edge1.Y * directioncrossedge2.Y) + (edge1.Z * directioncrossedge2.Z);

            //If the ray is parallel to the triangle plane, there is no collision.
            if (determinant > Utilities.ZeroTolerance && determinant < Utilities.ZeroTolerance)
            {
                distance = 0f;
                return false;
            }

            float inversedeterminant = 1.0f / determinant;

            //Calculate the U parameter of the intersection point.
            Vector3 distanceVector;
            distanceVector.X = ray.Position.X - vertex1.X;
            distanceVector.Y = ray.Position.Y - vertex1.Y;
            distanceVector.Z = ray.Position.Z - vertex1.Z;

            float triangleU;
            triangleU = (distanceVector.X * directioncrossedge2.X) + (distanceVector.Y * directioncrossedge2.Y) + (distanceVector.Z * directioncrossedge2.Z);
            triangleU *= inversedeterminant;

            //Make sure it is inside the triangle.
            if (triangleU < 0f || triangleU > 1f)
            {
                distance = 0f;
                return false;
            }

            //Calculate the V parameter of the intersection point.
            Vector3 distancecrossedge1;
            distancecrossedge1.X = (distanceVector.Y * edge1.Z) - (distanceVector.Z * edge1.Y);
            distancecrossedge1.Y = (distanceVector.Z * edge1.X) - (distanceVector.X * edge1.Z);
            distancecrossedge1.Z = (distanceVector.X * edge1.Y) - (distanceVector.Y * edge1.X);

            float triangleV;
            triangleV = ((ray.Direction.X * distancecrossedge1.X) + (ray.Direction.Y * distancecrossedge1.Y)) + (ray.Direction.Z * distancecrossedge1.Z);
            triangleV *= inversedeterminant;

            //Make sure it is inside the triangle.
            if (triangleV < 0f || triangleU + triangleV > 1f)
            {
                distance = 0f;
                return false;
            }

            //Compute the distance along the ray to the triangle.
            float raydistance;
            raydistance = (edge2.X * distancecrossedge1.X) + (edge2.Y * distancecrossedge1.Y) + (edge2.Z * distancecrossedge1.Z);
            raydistance *= inversedeterminant;

            //Is the triangle behind the ray origin?
            if (raydistance < 0f)
            {
                distance = 0f;
                return false;
            }

            distance = raydistance;
            return true;
        }

        /// <summary>
        /// Determines whether there is an intersection between a <see cref="SlimMath.Ray"/> and a triangle.
        /// </summary>
        /// <param name="ray">The ray to test.</param>
        /// <param name="vertex1">The first vertex of the triangle to test.</param>
        /// <param name="vertex2">The second vertex of the triagnle to test.</param>
        /// <param name="vertex3">The third vertex of the triangle to test.</param>
        /// <param name="point">When the method completes, contains the point of intersection,
        /// or <see cref="SlimMath.Vector3.Zero"/> if there was no intersection.</param>
        /// <returns>Whether the two objects intersected.</returns>
        public static bool RayIntersectsTriangle(ref Ray ray, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3, out Vector3 point)
        {
            float distance;
            if (!RayIntersectsTriangle(ref ray, ref vertex1, ref vertex2, ref vertex3, out distance))
            {
                point = Vector3.Zero;
                return false;
            }

            point = ray.Position + (ray.Direction * distance);
            return true;
        }

        /// <summary>
        /// Determines whether there is an intersection between a <see cref="SlimMath.Ray"/> and a <see cref="SlimMath.BoundingBox"/>.
        /// </summary>
        /// <param name="ray">The ray to test.</param>
        /// <param name="box">The box to test.</param>
        /// <param name="distance">When the method completes, contains the distance of the intersection,
        /// or 0 if there was no intersection.</param>
        /// <returns>Whether the two objects intersected.</returns>
        public static bool RayIntersectsBox(ref Ray ray, ref BoundingBox box, out float distance)
        {
            distance = 0f;
            float tmax = float.MaxValue;

            if (Math.Abs(ray.Direction.X) < Utilities.ZeroTolerance)
            {
                if (ray.Position.X < box.Minimum.X || ray.Position.X > box.Maximum.X)
                {
                    distance = 0f;
                    return false;
                }
            }
            else
            {
                float inverse = 1.0f / ray.Direction.X;
                float t1 = (box.Minimum.X - ray.Position.X) * inverse;
                float t2 = (box.Maximum.X - ray.Position.X) * inverse;

                if (t1 > t2)
                {
                    float temp = t1;
                    t1 = t2;
                    t2 = temp;
                }

                distance = Math.Max(t1, distance);
                tmax = Math.Min(t2, tmax);

                if (distance > tmax)
                {
                    distance = 0f;
                    return false;
                }
            }

            if (Math.Abs(ray.Direction.Y) < Utilities.ZeroTolerance)
            {
                if (ray.Position.Y < box.Minimum.Y || ray.Position.Y > box.Maximum.Y)
                {
                    distance = 0f;
                    return false;
                }
            }
            else
            {
                float inverse = 1.0f / ray.Direction.Y;
                float t1 = (box.Minimum.Y - ray.Position.Y) * inverse;
                float t2 = (box.Maximum.Y - ray.Position.Y) * inverse;

                if (t1 > t2)
                {
                    float temp = t1;
                    t1 = t2;
                    t2 = temp;
                }

                distance = Math.Max(t1, distance);
                tmax = Math.Min(t2, tmax);

                if (distance > tmax)
                {
                    distance = 0f;
                    return false;
                }
            }

            if (Math.Abs(ray.Direction.Z) < Utilities.ZeroTolerance)
            {
                if (ray.Position.Z < box.Minimum.Z || ray.Position.Z > box.Maximum.Z)
                {
                    distance = 0f;
                    return false;
                }
            }
            else
            {
                float inverse = 1.0f / ray.Direction.Z;
                float t1 = (box.Minimum.Z - ray.Position.Z) * inverse;
                float t2 = (box.Maximum.Z - ray.Position.Z) * inverse;

                if (t1 > t2)
                {
                    float temp = t1;
                    t1 = t2;
                    t2 = temp;
                }

                distance = Math.Max(t1, distance);
                tmax = Math.Min(t2, tmax);

                if (distance > tmax)
                {
                    distance = 0f;
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether there is an intersection between a <see cref="SlimMath.Ray"/> and a <see cref="SlimMath.Plane"/>.
        /// </summary>
        /// <param name="ray">The ray to test.</param>
        /// <param name="box">The box to test.</param>
        /// <param name="point">When the method completes, contains the point of intersection,
        /// or <see cref="SlimMath.Vector3.Zero"/> if there was no intersection.</param>
        /// <returns>Whether the two objects intersected.</returns>
        public static bool RayIntersectsBox(ref Ray ray, ref BoundingBox box, out Vector3 point)
        {
            float distance;
            if (!RayIntersectsBox(ref ray, ref box, out distance))
            {
                point = Vector3.Zero;
                return false;
            }

            point = ray.Position + (ray.Direction * distance);
            return true;
        }

        /// <summary>
        /// Determines whether there is an intersection between a <see cref="SlimMath.Ray"/> and a <see cref="SlimMath.BoundingSphere"/>.
        /// </summary>
        /// <param name="ray">The ray to test.</param>
        /// <param name="sphere">The sphere to test.</param>
        /// <param name="distance">When the method completes, contains the distance of the intersection,
        /// or 0 if there was no intersection.</param>
        /// <returns>Whether the two objects intersected.</returns>
        public static bool RayIntersectsSphere(ref Ray ray, ref BoundingSphere sphere, out float distance)
        {
            Vector3 m;
            Vector3.Subtract(ref ray.Position, ref sphere.Center, out m);

            float b = Vector3.Dot(m, ray.Direction);
            float c = Vector3.Dot(m, m) - (sphere.Radius * sphere.Radius);

            if (c > 0f && b > 0f)
            {
                distance = 0f;
                return false;
            }

            float discriminant = b * b - c;

            if (discriminant < 0f)
            {
                distance = 0f;
                return false;
            }

            distance = -b - (float)Math.Sqrt(discriminant);

            if (distance < 0f)
                distance = 0f;

            return true;
        }

        /// <summary>
        /// Determines whether there is an intersection between a <see cref="SlimMath.Ray"/> and a <see cref="SlimMath.BoundingSphere"/>. 
        /// </summary>
        /// <param name="ray">The ray to test.</param>
        /// <param name="sphere">The sphere to test.</param>
        /// <param name="point">When the method completes, contains the point of intersection,
        /// or <see cref="SlimMath.Vector3.Zero"/> if there was no intersection.</param>
        /// <returns>Whether the two objects intersected.</returns>
        public static bool RayIntersectsSphere(ref Ray ray, ref BoundingSphere sphere, out Vector3 point)
        {
            float distance;
            if (!RayIntersectsSphere(ref ray, ref sphere, out distance))
            {
                point = Vector3.Zero;
                return false;
            }

            point = ray.Position + (ray.Direction * distance);
            return true;
        }

        /// <summary>
        /// Determines whether there is an intersection between a <see cref="SlimMath.Plane"/> and a <see cref="SlimMath.Plane"/>.
        /// </summary>
        /// <param name="plane1">The first plane to test.</param>
        /// <param name="plane2">The second plane to test.</param>
        /// <returns>Whether the two objects intersected.</returns>
        public static bool PlaneIntersectsPlane(ref Plane plane1, ref Plane plane2)
        {
            Vector3 direction;
            Vector3.Cross(ref plane1.Normal, ref plane2.Normal, out direction);

            //If direction is the zero vector, the planes are parallel and possibly
            //coincident. It is not an intersection. The dot product will tell us.
            float denominator;
            Vector3.Dot(ref direction, ref direction, out denominator);

            if (Math.Abs(denominator) < Utilities.ZeroTolerance)
                return false;

            return true;
        }

        /// <summary>
        /// Determines whether there is an intersection between a <see cref="SlimMath.Plane"/> and a <see cref="SlimMath.Plane"/>.
        /// </summary>
        /// <param name="plane1">The first plane to test.</param>
        /// <param name="plane2">The second plane to test.</param>
        /// <param name="line">When the method completes, contains the line of intersection
        /// as a <see cref="SlimMath.Ray"/>, or a zero ray if there was no intersection.</param>
        /// <returns>Whether the two objects intersected.</returns>
        public static bool PlaneIntersectsPlane(ref Plane plane1, ref Plane plane2, out Ray line)
        {
            Vector3 direction;
            Vector3.Cross(ref plane1.Normal, ref plane2.Normal, out direction);

            //If direction is the zero vector, the planes are parallel and possibly
            //coincident. It is not an intersection. The dot product will tell us.
            float denominator;
            Vector3.Dot(ref direction, ref direction, out denominator);

            //We assume the planes are normalized, therefore the denominator
            //only serves as a parallel and coincident check. Otherwise we need
            //to deivide the point by the denominator.
            if (Math.Abs(denominator) < Utilities.ZeroTolerance)
            {
                line = new Ray();
                return false;
            }

            Vector3 point;
            Vector3 temp = plane1.D * plane2.Normal - plane2.D * plane1.Normal;
            Vector3.Cross(ref temp, ref direction, out point);

            line.Position = point;
            line.Direction = direction;
            line.Direction.Normalize();

            return true;
        }

        /// <summary>
        /// Determines whether there is an intersection between a <see cref="SlimMath.Plane"/> and a <see cref="SlimMath.BoundingBox"/>.
        /// </summary>
        /// <param name="plane">The plane to test.</param>
        /// <param name="box">The box to test.</param>
        /// <returns>Whether the two objects intersected.</returns>
        public static PlaneIntersectionType PlaneIntersectsBox(ref Plane plane, ref BoundingBox box)
        {
            Vector3 min;
            Vector3 max;

            max.X = (plane.Normal.X >= 0.0f) ? box.Minimum.X : box.Maximum.X;
            max.Y = (plane.Normal.Y >= 0.0f) ? box.Minimum.Y : box.Maximum.Y;
            max.Z = (plane.Normal.Z >= 0.0f) ? box.Minimum.Z : box.Maximum.Z;
            min.X = (plane.Normal.X >= 0.0f) ? box.Maximum.X : box.Minimum.X;
            min.Y = (plane.Normal.Y >= 0.0f) ? box.Maximum.Y : box.Minimum.Y;
            min.Z = (plane.Normal.Z >= 0.0f) ? box.Maximum.Z : box.Minimum.Z;

            float distance;
            Vector3.Dot(ref plane.Normal, ref max, out distance);

            if (distance + plane.D > 0.0f)
                return PlaneIntersectionType.Front;

            distance = Vector3.Dot(plane.Normal, min);

            if (distance + plane.D < 0.0f)
                return PlaneIntersectionType.Back;

            return PlaneIntersectionType.Intersecting;
        }

        /// <summary>
        /// Determines whether there is an intersection between a <see cref="SlimMath.Plane"/> and a <see cref="SlimMath.BoundingSphere"/>.
        /// </summary>
        /// <param name="plane">The plane to test.</param>
        /// <param name="sphere">The sphere to test.</param>
        /// <returns>Whether the two objects intersected.</returns>
        public static PlaneIntersectionType PlaneIntersectsSphere(ref Plane plane, ref BoundingSphere sphere)
        {
            float distance;
            Vector3.Dot(ref plane.Normal, ref sphere.Center, out distance);
            distance += plane.D;

            if (distance > sphere.Radius)
                return PlaneIntersectionType.Front;

            if (distance < -sphere.Radius)
                return PlaneIntersectionType.Back;

            return PlaneIntersectionType.Intersecting;
        }

        /// <summary>
        /// Determines whether there is an intersection between a <see cref="SlimMath.BoundingBox"/> and a <see cref="SlimMath.BoundingBox"/>.
        /// </summary>
        /// <param name="box1">The first box to test.</param>
        /// <param name="box2">The second box to test.</param>
        /// <returns>Whether the two objects intersected.</returns>
        public static bool BoxIntersectsBox(ref BoundingBox box1, ref BoundingBox box2)
        {
            if (box1.Minimum.X > box2.Maximum.X || box2.Minimum.X > box1.Maximum.X)
                return false;

            if (box1.Minimum.Y > box2.Maximum.Y || box2.Minimum.Y > box1.Maximum.Y)
                return false;

            if (box1.Minimum.Z > box2.Maximum.Z || box2.Minimum.Z > box1.Maximum.Z)
                return false;

            return true;
        }

        /// <summary>
        /// Determines whether there is an intersection between a <see cref="SlimMath.BoundingBox"/> and a <see cref="SlimMath.BoundingSphere"/>.
        /// </summary>
        /// <param name="box">The box to test.</param>
        /// <param name="sphere">The sphere to test.</param>
        /// <returns>Whether the two objects intersected.</returns>
        public static bool BoxIntersectsSphere(ref BoundingBox box, ref BoundingSphere sphere)
        {
            Vector3 vector;
            Vector3.Clamp(ref sphere.Center, ref box.Minimum, ref box.Maximum, out vector);
            float distance = Vector3.DistanceSquared(sphere.Center, vector);

            return distance <= sphere.Radius * sphere.Radius;
        }

        /// <summary>
        /// Determines whether there is an intersection between a <see cref="SlimMath.BoundingSphere"/> and a <see cref="SlimMath.BoundingSphere"/>.
        /// </summary>
        /// <param name="sphere1">First sphere to test.</param>
        /// <param name="sphere2">Second sphere to test.</param>
        /// <returns>Whether the two objects intersected.</returns>
        public static bool SphereIntersectsSphere(ref BoundingSphere sphere1, ref BoundingSphere sphere2)
        {
            float radiisum = sphere1.Radius + sphere2.Radius;
            return Vector3.DistanceSquared(sphere1.Center, sphere2.Center) <= radiisum * radiisum;
        }

        /// <summary>
        /// Determines whether a <see cref="SlimMath.BoundingBox"/> contains a point.
        /// </summary>
        /// <param name="box">The box to test.</param>
        /// <param name="point">The point to test.</param>
        /// <returns>The type of containment the two objects have.</returns>
        public static ContainmentType BoxContainsPoint(ref BoundingBox box, ref Vector3 point)
        {
            if (box.Minimum.X <= point.X && box.Maximum.X >= point.X &&
                box.Minimum.Y <= point.Y && box.Maximum.Y >= point.Y &&
                box.Minimum.Z <= point.Z && box.Maximum.Z >= point.Z)
            {
                return ContainmentType.Contains;
            }

            return ContainmentType.Disjoint;
        }

        /// <summary>
        /// Determines whether a <see cref="SlimMath.BoundingBox"/> contains a triangle.
        /// </summary>
        /// <param name="box">The box to test.</param>
        /// <param name="vertex1">The first vertex of the triangle to test.</param>
        /// <param name="vertex2">The second vertex of the triagnle to test.</param>
        /// <param name="vertex3">The third vertex of the triangle to test.</param>
        /// <returns>The type of containment the two objects have.</returns>
        public static ContainmentType BoxContainsTriangle(ref BoundingBox box, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3)
        {
            ContainmentType test1 = BoxContainsPoint(ref box, ref vertex1);
            ContainmentType test2 = BoxContainsPoint(ref box, ref vertex2);
            ContainmentType test3 = BoxContainsPoint(ref box, ref vertex3);

            if (test1 == ContainmentType.Contains && test2 == ContainmentType.Contains && test3 == ContainmentType.Contains)
                return ContainmentType.Contains;

            if (test1 == ContainmentType.Contains || test2 == ContainmentType.Contains || test3 == ContainmentType.Contains)
                return ContainmentType.Intersects;

            return ContainmentType.Disjoint;
        }

        /// <summary>
        /// Determines whether a <see cref="SlimMath.BoundingBox"/> contains a <see cref="SlimMath.BoundingBox"/>.
        /// </summary>
        /// <param name="box1">The first box to test.</param>
        /// <param name="box2">The second box to test.</param>
        /// <returns>The type of containment the two objects have.</returns>
        public static ContainmentType BoxContainsBox(ref BoundingBox box1, ref BoundingBox box2)
        {
            if (box1.Maximum.X < box2.Minimum.X || box1.Minimum.X > box2.Maximum.X)
                return ContainmentType.Disjoint;

            if (box1.Maximum.Y < box2.Minimum.Y || box1.Minimum.Y > box2.Maximum.Y)
                return ContainmentType.Disjoint;

            if (box1.Maximum.Z < box2.Minimum.Z || box1.Minimum.Z > box2.Maximum.Z)
                return ContainmentType.Disjoint;

            if (box1.Minimum.X <= box2.Minimum.X && (box2.Maximum.X <= box1.Maximum.X &&
                box1.Minimum.Y <= box2.Minimum.Y && box2.Maximum.Y <= box1.Maximum.Y) &&
                box1.Minimum.Z <= box2.Minimum.Z && box2.Maximum.Z <= box1.Maximum.Z)
            {
                return ContainmentType.Contains;
            }

            return ContainmentType.Intersects;
        }

        /// <summary>
        /// Determines whether a <see cref="SlimMath.BoundingBox"/> contains a <see cref="SlimMath.BoundingSphere"/>.
        /// </summary>
        /// <param name="box">The box to test.</param>
        /// <param name="sphere">The sphere to test.</param>
        /// <returns>The type of containment the two objects have.</returns>
        public static ContainmentType BoxContainsSphere(ref BoundingBox box, ref BoundingSphere sphere)
        {
            Vector3 vector;
            Vector3.Clamp(ref sphere.Center, ref box.Minimum, ref box.Maximum, out vector);
            float distance = Vector3.DistanceSquared(sphere.Center, vector);

            if (distance > sphere.Radius * sphere.Radius)
                return ContainmentType.Disjoint;

            if ((((box.Minimum.X + sphere.Radius <= sphere.Center.X) && (sphere.Center.X <= box.Maximum.X - sphere.Radius)) && ((box.Maximum.X - box.Minimum.X > sphere.Radius) &&
                (box.Minimum.Y + sphere.Radius <= sphere.Center.Y))) && (((sphere.Center.Y <= box.Maximum.Y - sphere.Radius) && (box.Maximum.Y - box.Minimum.Y > sphere.Radius)) &&
                (((box.Minimum.Z + sphere.Radius <= sphere.Center.Z) && (sphere.Center.Z <= box.Maximum.Z - sphere.Radius)) && (box.Maximum.X - box.Minimum.X > sphere.Radius))))
            {
                return ContainmentType.Contains;
            }

            return ContainmentType.Intersects;
        }

        /// <summary>
        /// Determines whether a <see cref="SlimMath.BoundingSphere"/> contains a point.
        /// </summary>
        /// <param name="sphere">The sphere to test.</param>
        /// <param name="point">The point to test.</param>
        /// <returns>The type of containment the two objects have.</returns>
        public static ContainmentType SphereContainsPoint(ref BoundingSphere sphere, ref Vector3 point)
        {
            if (Vector3.DistanceSquared(point, sphere.Center) <= sphere.Radius * sphere.Radius)
                return ContainmentType.Contains;

            return ContainmentType.Disjoint;
        }

        /// <summary>
        /// Determines whether a <see cref="SlimMath.BoundingSphere"/> contains a triangle.
        /// </summary>
        /// <param name="sphere">The sphere to test.</param>
        /// <param name="vertex1">The first vertex of the triangle to test.</param>
        /// <param name="vertex2">The second vertex of the triagnle to test.</param>
        /// <param name="vertex3">The third vertex of the triangle to test.</param>
        /// <returns>The type of containment the two objects have.</returns>
        public static ContainmentType SphereContainsTriangle(ref BoundingSphere sphere, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3)
        {
            ContainmentType test1 = SphereContainsPoint(ref sphere, ref vertex1);
            ContainmentType test2 = SphereContainsPoint(ref sphere, ref vertex2);
            ContainmentType test3 = SphereContainsPoint(ref sphere, ref vertex3);

            if (test1 == ContainmentType.Contains && test2 == ContainmentType.Contains && test3 == ContainmentType.Contains)
                return ContainmentType.Contains;

            if (test1 == ContainmentType.Contains || test2 == ContainmentType.Contains || test3 == ContainmentType.Contains)
                return ContainmentType.Intersects;

            return ContainmentType.Disjoint;
        }

        /// <summary>
        /// Determines whether a <see cref="SlimMath.BoundingSphere"/> contains a <see cref="SlimMath.BoundingBox"/>.
        /// </summary>
        /// <param name="sphere">The sphere to test.</param>
        /// <param name="box">The box to test.</param>
        /// <returns>The type of containment the two objects have.</returns>
        public static ContainmentType SphereContainsBox(ref BoundingSphere sphere, ref BoundingBox box)
        {
            Vector3 vector;

            if (!BoxIntersectsSphere(ref box, ref sphere))
                return ContainmentType.Disjoint;

            float radiussquared = sphere.Radius * sphere.Radius;
            vector.X = sphere.Center.X - box.Minimum.X;
            vector.Y = sphere.Center.Y - box.Maximum.Y;
            vector.Z = sphere.Center.Z - box.Maximum.Z;

            if (vector.LengthSquared() > radiussquared)
                return ContainmentType.Intersects;

            vector.X = sphere.Center.X - box.Maximum.X;
            vector.Y = sphere.Center.Y - box.Maximum.Y;
            vector.Z = sphere.Center.Z - box.Maximum.Z;

            if (vector.LengthSquared() > radiussquared)
                return ContainmentType.Intersects;

            vector.X = sphere.Center.X - box.Maximum.X;
            vector.Y = sphere.Center.Y - box.Minimum.Y;
            vector.Z = sphere.Center.Z - box.Maximum.Z;

            if (vector.LengthSquared() > radiussquared)
                return ContainmentType.Intersects;

            vector.X = sphere.Center.X - box.Minimum.X;
            vector.Y = sphere.Center.Y - box.Minimum.Y;
            vector.Z = sphere.Center.Z - box.Maximum.Z;

            if (vector.LengthSquared() > radiussquared)
                return ContainmentType.Intersects;

            vector.X = sphere.Center.X - box.Minimum.X;
            vector.Y = sphere.Center.Y - box.Maximum.Y;
            vector.Z = sphere.Center.Z - box.Minimum.Z;

            if (vector.LengthSquared() > radiussquared)
                return ContainmentType.Intersects;

            vector.X = sphere.Center.X - box.Maximum.X;
            vector.Y = sphere.Center.Y - box.Maximum.Y;
            vector.Z = sphere.Center.Z - box.Minimum.Z;

            if (vector.LengthSquared() > radiussquared)
                return ContainmentType.Intersects;

            vector.X = sphere.Center.X - box.Maximum.X;
            vector.Y = sphere.Center.Y - box.Minimum.Y;
            vector.Z = sphere.Center.Z - box.Minimum.Z;

            if (vector.LengthSquared() > radiussquared)
                return ContainmentType.Intersects;

            vector.X = sphere.Center.X - box.Minimum.X;
            vector.Y = sphere.Center.Y - box.Minimum.Y;
            vector.Z = sphere.Center.Z - box.Minimum.Z;

            if (vector.LengthSquared() > radiussquared)
                return ContainmentType.Intersects;

            return ContainmentType.Contains;
        }

        /// <summary>
        /// Determines whether a <see cref="SlimMath.BoundingSphere"/> contains a <see cref="SlimMath.BoundingSphere"/>.
        /// </summary>
        /// <param name="sphere1">The first sphere to test.</param>
        /// <param name="sphere2">The second sphere to test.</param>
        /// <returns>The type of containment the two objects have.</returns>
        public static ContainmentType SphereContainsSphere(ref BoundingSphere sphere1, ref BoundingSphere sphere2)
        {
            float distance = Vector3.Distance(sphere1.Center, sphere2.Center);

            if (sphere1.Radius + sphere2.Radius < distance)
                return ContainmentType.Disjoint;

            if (sphere1.Radius - sphere2.Radius < distance)
                return ContainmentType.Intersects;

            return ContainmentType.Contains;
        }
    }
}
