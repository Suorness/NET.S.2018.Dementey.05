namespace Polynom
{
    using System;

    /// <summary>
    /// This class describes a polynomial with certain methods of addition, subtraction and multiplication.
    /// </summary>
    public class Polynomial
    {
        #region constructor
        public Polynomial(double[] coefficients)
        {
            Coefficients = coefficients ?? throw new ArgumentNullException(nameof(coefficients));
        }
        #endregion constructor

        public double[] Coefficients { get; private set; }

        #region public method

        /// <summary>
        /// This method adds two polynomials.
        /// </summary>
        /// <param name="firstPolynom">The first term. <see cref="Polynomial"/></param>
        /// <param name="secondPolynom">The second term. <see cref="Polynomial"/></param>
        /// <returns>The result of addition of two polynomials in the form of a new object. <see cref="Polynomial"/></returns>
        public static Polynomial Add(Polynomial firstPolynom, Polynomial secondPolynom)
        {
            if (firstPolynom == null)
            {
                throw new ArgumentNullException(nameof(firstPolynom));
            }

            if (secondPolynom == null)
            {
                throw new ArgumentNullException(nameof(secondPolynom));
            }

            int lengthResultPolynom = Math.Max(firstPolynom.Coefficients.Length, secondPolynom.Coefficients.Length);

            var resultPolynom = new double[lengthResultPolynom];
            var firstCoefficients = new double[lengthResultPolynom];
            var secondCoefficients = new double[lengthResultPolynom];

            Array.Copy(firstPolynom.Coefficients, firstCoefficients, firstPolynom.Coefficients.Length);
            Array.Copy(secondPolynom.Coefficients, secondCoefficients, secondPolynom.Coefficients.Length);

            for (int i = 0; i < lengthResultPolynom; i++)
            {
                resultPolynom[i] = firstCoefficients[i] + secondCoefficients[i];
            }

            return new Polynomial(resultPolynom);
        }

        /// <summary>
        /// This method adds two polynomials.
        /// </summary>
        /// <param name="firstPolynom">The first term. <see cref="Polynomial"/></param>
        /// <param name="secondPolynom">The second term. <see cref="Polynomial"/></param>
        /// <returns>The result of addition of two polynomials in the form of a new object. <see cref="Polynomial"/></returns>
        public static Polynomial operator +(Polynomial firstPolynom, Polynomial secondPolynom)
        {
            return Add(firstPolynom, secondPolynom);
        }

        /// <summary>
        /// This method subtracts two polynomials.
        /// </summary>
        /// <param name="firstPolynom">The first term. <see cref="Polynomial"/></param>
        /// <param name="secondPolynom">The second term. <see cref="Polynomial"/></param>
        /// <returns>The result of subtracts of two polynomials in the form of a new object. <see cref="Polynomial"/></returns>
        public static Polynomial Subtract(Polynomial firstPolynom, Polynomial secondPolynom)
        {
            if (firstPolynom == null)
            {
                throw new ArgumentNullException(nameof(firstPolynom));
            }

            if (secondPolynom == null)
            {
                throw new ArgumentNullException(nameof(secondPolynom));
            }

            int lengthResultPolynom = Math.Max(firstPolynom.Coefficients.Length, secondPolynom.Coefficients.Length);

            var resultPolynom = new double[lengthResultPolynom];
            var firstCoefficients = new double[lengthResultPolynom];
            var secondCoefficients = new double[lengthResultPolynom];

            Array.Copy(firstPolynom.Coefficients, firstCoefficients, firstPolynom.Coefficients.Length);
            Array.Copy(secondPolynom.Coefficients, secondCoefficients, secondPolynom.Coefficients.Length);

            for (int i = 0; i < lengthResultPolynom; i++)
            {
                resultPolynom[i] = firstCoefficients[i] - secondCoefficients[i];
            }

            return new Polynomial(resultPolynom);
        }

        /// <summary>
        /// This method subtracts two polynomials.
        /// </summary>
        /// <param name="firstPolynom">The first term. <see cref="Polynomial"/></param>
        /// <param name="secondPolynom">The second term. <see cref="Polynomial"/></param>
        /// <returns>The result of subtracts of two polynomials in the form of a new object. <see cref="Polynomial"/></returns>
        public static Polynomial operator -(Polynomial firstPolynom, Polynomial secondPolynom)
        {
            return Subtract(firstPolynom, secondPolynom);
        }

        #endregion public method

        #region private method
        #endregion private method
    }
}
