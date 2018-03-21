namespace Polynom
{
    using System;
    using System.Text;

    /// <summary>
    /// This class describes a polynomial with certain methods of addition, subtraction and multiplication.
    /// </summary>
    public class Polynomial
    {
        #region private fields
        private const char DefaultChar = 'x';
        private const double DefaultAccuracy = 0.001D;

        private char designationVariablePolynomial;
        private double[] coefficients;

        #endregion private fields

        #region public 
        public Polynomial(double[] coefficients)
        {
            this.coefficients = coefficients ?? throw new ArgumentNullException(nameof(coefficients));
            DesignationVariablePolynomial = DefaultChar;
        }

        public double[] Coefficients
        {
            get
            {
                return (double[])coefficients.Clone();
            }

            private set
            {
                coefficients = value;
            }
        }

        public char DesignationVariablePolynomial
        {
            get
            {
                return designationVariablePolynomial;
            }

            set
            {
                if (char.IsLetter(value))
                {
                    designationVariablePolynomial = value;
                }
            }
        }

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

            return new Polynomial(RemoveZeroes(resultPolynom));
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

            return new Polynomial(RemoveZeroes(resultPolynom));
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

        /// <summary>
        /// This method multiplies two polynomials.
        /// </summary>
        /// <param name="firstPolynom">The first term. <see cref="Polynomial"/></param>
        /// <param name="secondPolynom">The second term. <see cref="Polynomial"/></param>
        /// <returns>The result of multiplies of two polynomials in the form of a new object. <see cref="Polynomial"/></returns>
        public static Polynomial Multiply(Polynomial firstPolynom, Polynomial secondPolynom)
        {
            if (firstPolynom == null)
            {
                throw new ArgumentNullException(nameof(firstPolynom));
            }

            if (secondPolynom == null)
            {
                throw new ArgumentNullException(nameof(secondPolynom));
            }

            int lengthResultPolynom = firstPolynom.Coefficients.Length + secondPolynom.Coefficients.Length - 1;

            var resultPolynom = new double[lengthResultPolynom];

            for (int i = 0; i < firstPolynom.Coefficients.Length; i++)
            {
                for (int j = 0; j < secondPolynom.Coefficients.Length; j++)
                {
                    resultPolynom[i + j] += firstPolynom.Coefficients[i] * secondPolynom.Coefficients[j];
                }
            }

            return new Polynomial(RemoveZeroes(resultPolynom));
        }

        /// <summary>
        /// This method multiplies two polynomials.
        /// </summary>
        /// <param name="firstPolynom">The first term. <see cref="Polynomial"/></param>
        /// <param name="secondPolynom">The second term. <see cref="Polynomial"/></param>
        /// <returns>The result of multiplies of two polynomials in the form of a new object. <see cref="Polynomial"/></returns>
        public static Polynomial operator *(Polynomial firstPolynom, Polynomial secondPolynom)
        {
            return Multiply(firstPolynom, secondPolynom);
        }

        /// <summary>
        /// Comparison of the equality of two polynomials.
        /// </summary>
        /// <param name="firstPolynom">The first term. <see cref="Polynomial"/></param>
        /// <param name="secondPolynom">The second term. <see cref="Polynomial"/></param>
        /// <returns>
        /// <c>true</c> if the objects are equal, <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(Polynomial firstPolynom, Polynomial secondPolynom)
        {
            return ComparisonOfPolynomials(firstPolynom, secondPolynom);
        }

        /// <summary>
        /// Comparison of the inequality of two polynomials.
        /// </summary>
        /// <param name="firstPolynom">The first term. <see cref="Polynomial"/></param>
        /// <param name="secondPolynom">The second term. <see cref="Polynomial"/></param>
        /// <returns>
        /// <c>false</c> if the objects are equal, <c>true</c> otherwise.
        /// </returns>
        public static bool operator !=(Polynomial firstPolynom, Polynomial secondPolynom)
        {
            return !ComparisonOfPolynomials(firstPolynom, secondPolynom);
        }

        /// <summary>
        /// Overridden standard hash function
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode() => ToString().GetHashCode();

        public override string ToString()
        {
            var strBilder = new StringBuilder();
            for (int i = 0; i < Coefficients.Length; i++)
            {
                strBilder.Append($"{Coefficients[i]}*{DesignationVariablePolynomial}^{i}");

                if (i + 1 != Coefficients.Length)
                {
                    strBilder.Append(" + ");
                }
            }

            return strBilder.ToString();
        }

        /// <summary>
        /// Comparison of the equality of two polynomials.
        /// </summary>
        /// <param name="obj"> The object to compare with the current object.</param>
        /// <returns>
        /// <c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            bool result = false;
            if (obj is Polynomial polynom)
            {
                var firstCoefficients = RemoveZeroes(Coefficients);
                var secondCoefficients = RemoveZeroes(polynom.Coefficients);

                result = firstCoefficients.Length == secondCoefficients.Length;
                int i = 0;
                while (result && i < firstCoefficients.Length)
                {
                    result = Math.Abs(firstCoefficients[i] - secondCoefficients[i]) < DefaultAccuracy;
                    i++;
                }
            }

            return result;
        }

        #endregion public

        #region private method
        private static bool ComparisonOfPolynomials(Polynomial firstPolynom, Polynomial secondPolynom)
        {
            bool result = firstPolynom is null && secondPolynom is null;

            if (!result)
            {
                result = (firstPolynom is null) ? secondPolynom.Equals(firstPolynom) : firstPolynom.Equals(secondPolynom);
            }

            return result;
        }

        private static double[] RemoveZeroes(double[] coefficients)
        {
            if (coefficients == null)
            {
                throw new ArgumentNullException(nameof(coefficients));
            }

            if (coefficients.Length == 0)
            {
                return new double[] { };
            }

            int newBorder = coefficients.Length - 1;
            while ((newBorder >= 0) && (coefficients[newBorder] == 0.0))
            {
                newBorder--;
            }

            int newLength = newBorder + 1;

            double[] newCoefficients = new double[newLength];

            Array.Copy(coefficients, 0, newCoefficients, 0, newLength);

            return newCoefficients;
        }
        #endregion private method
    }
}
