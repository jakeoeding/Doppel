using NUnit.Framework;
using Doppel;
using System;

namespace Doppel.Tests
{
    [TestFixture]
    public class VectorTests
    {
        const double DELTA = 0.0001;

        readonly int[] VectorA = { 1, 2, 3, 4, 5 };
        readonly int[] VectorB = { -1, -2, -3, -4, -5 };
        readonly int[] VectorC = { 1, 0 };
        readonly int[] VectorD = { 0, 1 };
        readonly int[] VectorE = { 3, 4 };

        #region DotProduct tests

        [Test]
        public void DotProductWithVectorAndItself()
        {
            int actual = Vector.DotProduct(VectorA, VectorA);
            Assert.AreEqual(55, actual);
        }

        [Test]
        public void DotProductWithOppositeVectors()
        {
            int actual = Vector.DotProduct(VectorA, VectorB);
            Assert.AreEqual(-55, actual);
        }

        [Test]
        public void DotProductWithOrthogonalVectors()
        {
            int actual = Vector.DotProduct(VectorC, VectorD);
            Assert.AreEqual(0, actual);
        }

        [Test]
        public void DotProductWithVectorsOfDifferingDimensions()
        {
            Assert.Throws<InvalidOperationException>(() => Vector.DotProduct(VectorA, VectorC));
        }

        #endregion

        #region Magnitude tests

        [Test]
        public void MagnitudeWithVectorOfAllPositiveComponents()
        {
            double actual = Vector.Magnitude(VectorA);
            Assert.AreEqual(7.4162, actual, DELTA);
        }

        [Test]
        public void MagnitudeWithVectorOfAllNegativeComponents()
        {
            double actual = Vector.Magnitude(VectorB);
            Assert.AreEqual(7.4162, actual, DELTA);
        }

        [Test]
        public void MagnitudeWithUnitBasisVector()
        {
            double actual = Vector.Magnitude(VectorC);
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void MagnitudeWithRightTriangle()
        {
            double actual = Vector.Magnitude(VectorE);
            Assert.AreEqual(5, actual);
        }

        #endregion

        #region AngleBetween tests

        [Test]
        public void AngleBetweenWithVectorAndItself()
        {
            double actual = Vector.AngleBetween(VectorA, VectorA);
            Assert.AreEqual(0, actual);
        }

        [Test]
        public void AngleBetweenWithOppositeVectors()
        {
            double actual = Vector.AngleBetween(VectorA, VectorB);
            Assert.AreEqual(Math.PI, actual, DELTA);
        }

        [Test]
        public void AngleBetweenWithOrthogonalVectors()
        {
            double actual = Vector.AngleBetween(VectorC, VectorD);
            Assert.AreEqual(Math.PI / 2, actual, DELTA);
        }

        #endregion
    }
}