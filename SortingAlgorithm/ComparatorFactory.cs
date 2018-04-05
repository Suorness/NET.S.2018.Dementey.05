namespace SortingAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ComparatorFactory
    {
        /// <summary>
        /// Get delegate for sorting by increasing the sum of matrix elements.
        /// </summary>
        /// <param name="isIncrement">
        ///  A value indicating whether sort order.
        /// </param>
        /// <returns>
        /// Delegate for sorting.
        /// </returns>
        public static Comparison<int[]> GetAmountComparisonDelegate(bool isIncrement)
        {
            return GetComparison(funcValue => funcValue.Sum(), isIncrement);
        }

        /// Get Interface variable for sorting by increasing the sum of matrix elements.
        /// </summary>
        /// <param name="isIncrement">
        ///  A value indicating whether sort order.
        /// </param>
        /// <returns>
        /// Interface variable for sorting.
        /// </returns>
        public static IComparer<int[]> GetAmountComparer(bool isIncrement)
        {
            return new AdapterToIComparer(GetAmountComparisonDelegate(isIncrement));
        }

        /// <summary>
        /// Get delegate for sorting by increasing the maximum elements of the matrix.
        /// </summary>
        /// <param name="isIncrement">
        ///  A value indicating whether sort order.
        /// </param>
        /// <returns>
        /// Delegate for sorting.
        /// </returns>
        public static Comparison<int[]> GetMaxItemComparisonDelegate(bool isIncrement)
        {
            return GetComparison(funcValue => funcValue.Max(), isIncrement);
        }

        /// Get Interface variable for sorting by increasing the maximum elements of the matrix.
        /// </summary>
        /// <param name="isIncrement">
        ///  A value indicating whether sort order.
        /// </param>
        /// <returns>
        /// Interface variable for sorting.
        /// </returns>
        public static IComparer<int[]> GetMaxItemComparer(bool isIncrement)
        {
            return new AdapterToIComparer(GetMaxItemComparisonDelegate(isIncrement));
        }

        /// <summary>
        /// Get delegate for sorting by increasing the minimum elements of the matrix.
        /// </summary>
        /// <param name="isIncrement">
        ///  A value indicating whether sort order.
        /// </param>
        /// <returns>
        /// Delegate for sorting.
        /// </returns>
        public static Comparison<int[]> GetMinItemComparisonDelegate(bool isIncrement)
        {
            return GetComparison(funcValue => funcValue.Min(), isIncrement);
        }

        /// Get Interface variable for sorting by increasing the minimum elements of the matrix.
        /// </summary>
        /// <param name="isIncrement">
        ///  A value indicating whether sort order.
        /// </param>
        /// <returns>
        /// Interface variable for sorting.
        /// </returns>
        public static IComparer<int[]> GetMinItemComparer(bool isIncrement)
        {
            return new AdapterToIComparer(GetMinItemComparisonDelegate(isIncrement));
        }

        private static Comparison<int[]> GetComparison(Func<int[], int> func, bool isIncrement)
        {
            return (int[] x, int[] y) =>
            {
                int result = VerifyCoparisonInput(x, y);

                if (result == int.MaxValue)
                {
                    int funcValueX = func(x);
                    int funcValueY = func(y);

                    result = funcValueX.CompareTo(funcValueY);
                }

                if (!isIncrement)
                {
                    result = -result;
                }

                return result;
            };
        }

        private static int VerifyCoparisonInput(int[] x, int[] y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null)
            {
                return -1;
            }

            if (y == null)
            {
                return -1;
            }

            if (x.Length.Equals(0) && y.Length.Equals(0))
            {
                return 0;
            }

            if (x.Length.Equals(0))
            {
                return -1;
            }

            if (y.Length.Equals(0))
            {
                return -1;
            }

            return int.MaxValue;
        }
    }
}
