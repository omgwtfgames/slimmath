using SlimMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SlimMathManagedTests
{
    [TestClass()]
    public class GjkTest
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod()]
        public void GjkRealTest()
        {
            Gjk gjk = new Gjk();

            BoundingSphere shape1 = new BoundingSphere(new Vector3(30, 52, 119), 91);
            BoundingSphere shape2 = new BoundingSphere(new Vector3(139, 13, 35), 49);

            float expected = Collision.DistanceSphereSphere(ref shape1, ref shape2);

            //BoundingSphere shape1 = new BoundingSphere(new Vector3(-10.01f, 99f, 2.7f), 0.0001f);
            //BoundingSphere shape2 = new BoundingSphere(new Vector3(12.7f, 2f, -120.07f), 0.0001f);

            //BoundingSphere shape1 = new BoundingSphere(new Vector3(0, 15, 0), 1);
            //BoundingBox shape1 = new BoundingBox(new Vector3(0, 0, 0), new Vector3(1, 1, 1));
            //BoundingBox shape2 = new BoundingBox(new Vector3(0, 2, 0), new Vector3(3, 3, 3));

            float distance = gjk.GetMinimumDistance(v =>
                {
                    Vector3 a = shape1.SupportMapping(v);
                    Vector3 b = shape2.SupportMapping(-v);

                    return a - b;
                }, maxIterations: 50);
        }

        [TestMethod()]
        public void GjkBatteryTest()
        {
            Gjk gjk = new Gjk();

            const int iterations = 10000;

            //Point to point test
            for (int i = 0; i < iterations; ++i)
            {
                gjk.Reset();

                Vector3 point1 = Utilities.GenerateVector3();
                Vector3 point2 = Utilities.GenerateVector3();
                float expected = Vector3.Distance(point1, point2);

                float actual = gjk.GetMinimumDistance(v =>
                    {
                        return point1 - point2;
                    });

                Utilities.AreEqual(expected, actual);
            }

            //Sphere to sphere test
            for (int i = 0; i < iterations; ++i)
            {
                gjk.Reset();

                BoundingSphere shape1 = new BoundingSphere(Utilities.GenerateVector3(), Utilities.GenerateFloat());
                BoundingSphere shape2 = new BoundingSphere(Utilities.GenerateVector3(), Utilities.GenerateFloat());
                float expected = Collision.DistanceSphereSphere(ref shape1, ref shape2);

                if (Collision.SphereIntersectsSphere(ref shape1, ref shape2))
                {
                    i--;
                    continue;
                }

                float actual = gjk.GetMinimumDistance(v =>
                {
                    Vector3 a = shape1.SupportMapping(v);
                    Vector3 b = shape2.SupportMapping(-v);

                    return a - b;
                });

                Utilities.AreEqual(expected, actual);
            }

            //Box to box test
            for (int i = 0; i < iterations; ++i)
            {
                gjk.Reset();

                BoundingBox shape1 = new BoundingBox(Utilities.GenerateVector3(), Utilities.GenerateVector3());
                BoundingBox shape2 = new BoundingBox(Utilities.GenerateVector3(), Utilities.GenerateVector3());
                float expected = Collision.DistanceBoxBox(ref shape1, ref shape2);

                if (Collision.BoxIntersectsBox(ref shape1, ref shape2))
                {
                    i--;
                    continue;
                }

                float actual = gjk.GetMinimumDistance(v =>
                {
                    Vector3 a = shape1.SupportMapping(v);
                    Vector3 b = shape2.SupportMapping(-v);

                    return a - b;
                });

                Utilities.AreEqual(expected, actual);
            }
        }
    }
}
