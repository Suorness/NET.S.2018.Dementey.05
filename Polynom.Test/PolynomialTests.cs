namespace Polynom.Test
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Class for testing Polymomiac.
    /// </summary>
    public class PolymomiacTests
    {
        [TestCase(new double[] { 8, 16 })]
        public void PolynomialCtorTest(double[] coefficients)
        {
            Assert.IsNotNull(new Polynomial(coefficients));
        }

        [TestCase]
        public void PolynomialCtor_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Polynomial(null));
        }

        [TestCase]
        public void Add_firstPolynomIsNull_ThrowsArgumentNullException()
        {
            Polynomial firstPolynim = new Polynomial(new double[] { 1 });
            Polynomial secondPolynom = null;
            Assert.Throws<ArgumentNullException>(() => Polynomial.Add(firstPolynim, secondPolynom));
        }

        [TestCase]
        public void Add_secondPolynomIsNull_ThrowsArgumentNullException()
        {
            Polynomial firstPolynim = null;
            Polynomial secondPolynom = new Polynomial(new double[] { 1 });
            Assert.Throws<ArgumentNullException>(() => Polynomial.Add(firstPolynim, secondPolynom));
        }

        [TestCase(new double[] { 1 }, new double[] { 1 }, ExpectedResult = new double[] { 2 })]
        [TestCase(new double[] { 0 }, new double[] { 1 }, ExpectedResult = new double[] { 1 })]
        [TestCase(new double[] { 0 }, new double[] { 0 }, ExpectedResult = new double[] { 0 })]
        [TestCase(new double[] { 1 }, new double[] { 0 }, ExpectedResult = new double[] { 1 })]
        [TestCase(new double[] { 1, 2 }, new double[] { 1 }, ExpectedResult = new double[] { 2, 2 })]
        [TestCase(new double[] { 1, 2, 0, 0, 0, 8 }, new double[] { 1 }, ExpectedResult = new double[] { 2, 2, 0, 0, 0, 8 })]
        [TestCase(new double[] { 1, 2, 0, 0, 0, 8 }, new double[] { 1, 2, 0, 8 }, ExpectedResult = new double[] { 2, 4, 0, 8, 0, 8 })]
        public double[] AddTest(double[] firstCoefficients, double[] secondCoefficients)
        {
            var firstPolynim = new Polynomial(firstCoefficients);
            var secondPolynom = new Polynomial(secondCoefficients);

            var result = Polynomial.Add(firstPolynim, secondPolynom);

            return result.Coefficients;
        }

        [TestCase(new double[] { 1 }, new double[] { 1 }, ExpectedResult = new double[] { 2 })]
        [TestCase(new double[] { 0 }, new double[] { 1 }, ExpectedResult = new double[] { 1 })]
        [TestCase(new double[] { 0 }, new double[] { 0 }, ExpectedResult = new double[] { 0 })]
        [TestCase(new double[] { 1 }, new double[] { 0 }, ExpectedResult = new double[] { 1 })]
        [TestCase(new double[] { 1, 2 }, new double[] { 1 }, ExpectedResult = new double[] { 2, 2 })]
        [TestCase(new double[] { 1, 2, 0, 0, 0, 8 }, new double[] { 1 }, ExpectedResult = new double[] { 2, 2, 0, 0, 0, 8 })]
        [TestCase(new double[] { 1, 2, 0, 0, 0, 8 }, new double[] { 1, 2, 0, 8 }, ExpectedResult = new double[] { 2, 4, 0, 8, 0, 8 })]
        public double[] OperatorPlusTest(double[] firstCoefficients, double[] secondCoefficients)
        {
            var firstPolynim = new Polynomial(firstCoefficients);
            var secondPolynom = new Polynomial(secondCoefficients);

            var result = firstPolynim + secondPolynom;

            return result.Coefficients;
        }

        [TestCase(new double[] { 1 }, new double[] { 1 }, ExpectedResult = new double[] { 0 })]
        [TestCase(new double[] { 2, 1 }, new double[] { 1 }, ExpectedResult = new double[] { 1, 1 })]
        [TestCase(new double[] { 0 }, new double[] { 0 }, ExpectedResult = new double[] { 0 })]
        [TestCase(new double[] { 1, 2, 0, 0, 0, 8 }, new double[] { 0, 0, 0, 0, 0, 8 }, ExpectedResult = new double[] { 1, 2, 0, 0, 0, 0 })]
        [TestCase(new double[] { 1, 2, 0, 0, 0, 8 }, new double[] { 0, 0, 0, 0, 0, 0 }, ExpectedResult = new double[] { 1, 2, 0, 0, 0, 8 })]
        [TestCase(new double[] { 0 }, new double[] { 0 }, ExpectedResult = new double[] { 0 })]
        public double[] Subtract(double[] firstCoefficients, double[] secondCoefficients)
        {
            var firstPolynim = new Polynomial(firstCoefficients);
            var secondPolynom = new Polynomial(secondCoefficients);

            var result = Polynomial.Subtract(firstPolynim, secondPolynom);

            return result.Coefficients;
        }

        [TestCase(new double[] { 1 }, new double[] { 1 }, ExpectedResult = new double[] { 0 })]
        [TestCase(new double[] { 2, 1 }, new double[] { 1 }, ExpectedResult = new double[] { 1, 1 })]
        [TestCase(new double[] { 0 }, new double[] { 0 }, ExpectedResult = new double[] { 0 })]
        [TestCase(new double[] { 1, 2, 0, 0, 0, 8 }, new double[] { 0, 0, 0, 0, 0, 8 }, ExpectedResult = new double[] { 1, 2, 0, 0, 0, 0 })]
        [TestCase(new double[] { 1, 2, 0, 0, 0, 8 }, new double[] { 0, 0, 0, 0, 0, 0 }, ExpectedResult = new double[] { 1, 2, 0, 0, 0, 8 })]
        [TestCase(new double[] { 0 }, new double[] { 0 }, ExpectedResult = new double[] { 0 })]
        public double[] OperatorSubtractTest(double[] firstCoefficients, double[] secondCoefficients)
        {
            var firstPolynim = new Polynomial(firstCoefficients);
            var secondPolynom = new Polynomial(secondCoefficients);

            var result = firstPolynim - secondPolynom;

            return result.Coefficients;
        }
    }
}
