namespace SortingAlgorithm
{
    using System;
    using System.Linq;

    /// <summary>
    /// Class representing array sorting
    /// </summary>
    public class ArraySorter
    {
        #region public

        /// <summary>
        /// Delegate for sorting by increasing the sum of matrix elements
        /// </summary>
        public static Comparison<int[]> IncreaseAmount
        {
            get
            {
                return GetComparison(true, (int[] funcValue) => { return funcValue.Sum(); });
            }
        }

        /// <summary>
        /// Delegate for sorting by descending the sum of matrix elements
        /// </summary>
        public static Comparison<int[]> DecreaseAmount
        {
            get
            {
                return GetComparison(false, (int[] funcValue) => { return funcValue.Sum(); });
            }
        }

        /// <summary>
        /// Delegate for sorting by increasing the maximum elements of the matrix
        /// </summary>
        public static Comparison<int[]> IncreaseMaxItem
        {
            get
            {
                return GetComparison(true, (int[] funcValue) => { return funcValue.Max(); });
            }
        }

        /// <summary>
        /// Delegate for sorting by descending the maximum elements of the matrix
        /// </summary>
        public static Comparison<int[]> DecreaseMaxItem
        {
            get
            {
                return GetComparison(false, (int[] funcValue) => { return funcValue.Max(); });
            }
        }

        /// <summary>
        /// Delegate for sorting by increasing the minimum elements of the matrix
        /// </summary>
        public static Comparison<int[]> IncreaseMinItem
        {
            get
            {
                return GetComparison(true, (int[] funcValue) => { return funcValue.Min(); });
            }
        }

        /// <summary>
        /// Delegate for sorting by descending the minimum elements of the matrix
        /// </summary>
        public static Comparison<int[]> DecreaseMinItem
        {
            get
            {
                return GetComparison(false, (int[] funcValue) => { return funcValue.Min(); });
            }
        }

        /// <summary>
        /// Sorts the array using the passed comparator.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        /// <param name="comparator">The comparator used in sorting.</param>
        /// <returns></returns>
        public static int[][] BubbleSort(int[][] array, Comparison<int[]> comparator)
        {
            VerifySortInput(array, comparator);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparator(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

            return array;
        }
        #endregion public 

        #region private
        private static void VerifySortInput(int[][] array, Comparison<int[]> comparison)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }
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

        private static void Swap<T>(ref T x, ref T y)
        {
            var temp = x;
            x = y;
            y = temp;
        }

        private static Comparison<int[]> GetComparison(bool increment, Func<int[], int> func)
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

                if (!increment)
                {
                    result = -result;
                }

                return result;
            };
        }
        #endregion private
    }
}