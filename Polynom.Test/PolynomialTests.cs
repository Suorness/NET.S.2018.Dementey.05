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
        [TestCase(new double[] { 0 }, new double[] { 0 }, ExpectedResult = new double[] { })]
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
        [TestCase(new double[] { 0 }, new double[] { 0 }, ExpectedResult = new double[] { })]
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

        [TestCase(new double[] { 1 }, new double[] { 1 }, ExpectedResult = new double[] { })]
        [TestCase(new double[] { 2, 1 }, new double[] { 1 }, ExpectedResult = new double[] { 1, 1 })]
        [TestCase(new double[] { 0 }, new double[] { 0 }, ExpectedResult = new double[] { })]
        [TestCase(new double[] { 1, 2, 0, 0, 0, 8 }, new double[] { 0, 0, 0, 0, 0, 8 }, ExpectedResult = new double[] { 1, 2 })]
        [TestCase(new double[] { 1, 2, 0, 0, 0, 8 }, new double[] { 0, 0, 0, 0, 0, 0 }, ExpectedResult = new double[] { 1, 2, 0, 0, 0, 8 })]
        public double[] Subtract(double[] firstCoefficients, double[] secondCoefficients)
        {
            var firstPolynim = new Polynomial(firstCoefficients);
            var secondPolynom = new Polynomial(secondCoefficients);

            var result = Polynomial.Subtract(firstPolynim, secondPolynom);

            return result.Coefficients;
        }

        [TestCase(new double[] { 1 }, new double[] { 1 }, ExpectedResult = new double[] { })]
        [TestCase(new double[] { 2, 1 }, new double[] { 1 }, ExpectedResult = new double[] { 1, 1 })]
        [TestCase(new double[] { 0 }, new double[] { 0 }, ExpectedResult = new double[] { })]
        [TestCase(new double[] { 1, 2, 0, 0, 0, 8 }, new double[] { 0, 0, 0, 0, 0, 8 }, ExpectedResult = new double[] { 1, 2 })]
        [TestCase(new double[] { 1, 2, 0, 0, 0, 8 }, new double[] { 0, 0, 0, 0, 0, 0 }, ExpectedResult = new double[] { 1, 2, 0, 0, 0, 8 })]
        public double[] OperatorSubtractTest(double[] firstCoefficients, double[] secondCoefficients)
        {
            var firstPolynim = new Polynomial(firstCoefficients);
            var secondPolynom = new Polynomial(secondCoefficients);

            var result = firstPolynim - secondPolynom;

            return result.Coefficients;
        }

        [TestCase(new double[] { 1 }, new double[] { 1 }, ExpectedResult = new double[] { 1 })]
        [TestCase(new double[] { 0 }, new double[] { 1 }, ExpectedResult = new double[] { })]
        [TestCase(new double[] { 8 }, new double[] { 8 }, ExpectedResult = new double[] { 64 })]
        [TestCase(new double[] { 8 }, new double[] { 8, 1 }, ExpectedResult = new double[] { 64, 8 })]
        [TestCase(new double[] { 8 }, new double[] { 8, 1, 2 }, ExpectedResult = new double[] { 64, 8, 16 })]
        [TestCase(new double[] { 8, 16 }, new double[] { 8, 1, 2 }, ExpectedResult = new double[] { 64, 136, 32, 32 })]
        [TestCase(new double[] { 8, 16 }, new double[] { 8, 0, 2 }, ExpectedResult = new double[] { 64, 128, 16, 32 })]
        public double[] MultiplyTest(double[] firstCoefficients, double[] secondCoefficients)
        {
            var firstPolynim = new Polynomial(firstCoefficients);
            var secondPolynom = new Polynomial(secondCoefficients);

            var result = Polynomial.Multiply(firstPolynim, secondPolynom);

            return result.Coefficients;
        }

        [TestCase(new double[] { 1 }, new double[] { 1 }, ExpectedResult = new double[] { 1 })]
        [TestCase(new double[] { 0 }, new double[] { 1 }, ExpectedResult = new double[] { })]
        [TestCase(new double[] { 8 }, new double[] { 8 }, ExpectedResult = new double[] { 64 })]
        [TestCase(new double[] { 8 }, new double[] { 8, 1 }, ExpectedResult = new double[] { 64, 8 })]
        [TestCase(new double[] { 8 }, new double[] { 8, 1, 2 }, ExpectedResult = new double[] { 64, 8, 16 })]
        [TestCase(new double[] { 8, 16 }, new double[] { 8, 1, 2 }, ExpectedResult = new double[] { 64, 136, 32, 32 })]
        [TestCase(new double[] { 8, 16 }, new double[] { 8, 0, 2 }, ExpectedResult = new double[] { 64, 128, 16, 32 })]
        public double[] OperatorMultiplyTest(double[] firstCoefficients, double[] secondCoefficients)
        {
            var firstPolynim = new Polynomial(firstCoefficients);
            var secondPolynom = new Polynomial(secondCoefficients);

            var result = firstPolynim * secondPolynom;

            return result.Coefficients;
        }

        [TestCase(new double[] { 1 }, ExpectedResult = "1*x^0")]
        [TestCase(new double[] { 1, 2, 0, 5 }, ExpectedResult = "1*x^0 + 2*x^1 + 0*x^2 + 5*x^3")]
        public string ToStringTest(double[] coefficients)
        {
            var polynom = new Polynomial(coefficients);
            return polynom.ToString();
        }

        [TestCase(new double[] { 8, 16 }, new double[] { 8, 16 }, ExpectedResult = true)]
        [TestCase(new double[] { 8, 16 }, new double[] { 8, 1 }, ExpectedResult = false)]
        [TestCase(new double[] { 8, 16 }, new double[] { 8 }, ExpectedResult = false)]
        public bool EqualsTest(double[] firstCoefficients, double[] secondCoefficients)
        {
            var firstPolynim = new Polynomial(firstCoefficients);
            var secondPolynom = new Polynomial(secondCoefficients);

            return firstPolynim.Equals(secondPolynom);
        }

        [TestCase]
        public void EqualsTest_ObjIsNull()
        {
            var coefficients = new double[] { 8, 16 };
            var firstPolynim = new Polynomial(coefficients);

            Assert.IsFalse(firstPolynim.Equals(null));
        }

        [TestCase(new double[] { 8, 16 }, new double[] { 8, 16 }, ExpectedResult = true)]
        [TestCase(new double[] { 8, 16 }, new double[] { 8, 1 }, ExpectedResult = false)]
        [TestCase(new double[] { 8, 16 }, new double[] { 8 }, ExpectedResult = false)]
        public bool OperatorEquality(double[] firstCoefficients, double[] secondCoefficients)
        {
            var firstPolynim = new Polynomial(firstCoefficients);
            var secondPolynom = new Polynomial(secondCoefficients);

            return firstPolynim == secondPolynom;
        }

        [TestCase(new double[] { 8, 16 }, new double[] { 8, 16 }, ExpectedResult = false)]
        [TestCase(new double[] { 8, 16 }, new double[] { 8, 1 }, ExpectedResult = true)]
        [TestCase(new double[] { 8, 16 }, new double[] { 8 }, ExpectedResult = true)]
        public bool OperatorInequality(double[] firstCoefficients, double[] secondCoefficients)
        {
            var firstPolynim = new Polynomial(firstCoefficients);
            var secondPolynom = new Polynomial(secondCoefficients);

            return firstPolynim != secondPolynom;
        }
    }
}
