namespace SortingAlgorithm
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class representing array sorting
    /// </summary>
    public class ArraySorterWithAdapter
    {
        #region public
        /// <summary>
        /// Sorts the array using the passed comparator.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        /// <param name="comparator">The comparator used in sorting.</param>
        /// <returns>
        /// Sorted array.
        /// </returns>
        public static int[][] BubbleSort(int[][] array, IComparer<int[]> comparator)
        {
            VerifySortInput(array, comparator);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparator.Compare(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

            return array;
        }

        /// <summary>
        /// Sorts the array using the passed comparator.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        /// <param name="comparator">The comparator used in sorting.</param>
        /// <returns>
        /// Sorted array.
        /// </returns>
        public static int[][] BubbleSort(int[][] array, Comparison<int[]> comparer)
        {
            return BubbleSort(array, new AdapterToIComparer(comparer));
        }
        #endregion public 

        #region private
        private static void VerifySortInput(int[][] array, IComparer<int[]> comparison)
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
        
        private static void Swap<T>(ref T x, ref T y)
        {
            var temp = x;
            x = y;
            y = temp;
        }
        #endregion private
    }
}