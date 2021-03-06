﻿namespace SortingAlgorithm
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class representing array sorting
    /// </summary>
    public class ArraySorter
    {
        #region public
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

        public static int[][] BubbleSort(int[][] array, IComparer<int[]> comparer)
        {
            return BubbleSort(array, comparer.Compare);
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

        private static void Swap<T>(ref T x, ref T y)
        {
            var temp = x;
            x = y;
            y = temp;
        }
        #endregion private
    }
}