namespace SortingAlgorithm.Test
{
    using System;

    public class SorterTestsHelper
    {
        private const int LeftBorder = 1;
        private const int RightBorder = 10;

        public static int[][] GenerateArray(int seed)
        {
            var random = new Random(seed);
            int rowCount = random.Next(LeftBorder, RightBorder);

            var array = new int[rowCount][];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = GetRandomArray(seed + Guid.NewGuid().GetHashCode());
            }

            return array;
        }

        public static bool IsTrustOrder(int[][] array, Func<int[], int> operation, Func<int, int, bool> comparator)
        {
            int[] resultArray = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                resultArray[i] = operation(array[i]);
            }

            for (int i = 0; i < resultArray.Length - 1; i++)
            {
                if (comparator(resultArray[i], resultArray[i + 1]))
                {
                    return false;
                }
            }

            return true;
        }

        private static int[] GetRandomArray(int seed)
        {
            var random = new Random(seed);
            int length = random.Next(LeftBorder, RightBorder);

            var array = new int[length];
            FillArrayRandom(array, seed + Guid.NewGuid().GetHashCode());

            return array;
        }

        private static void FillArrayRandom(int[] array, int seed)
        {
            var random = new Random(seed);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(LeftBorder, RightBorder);
            }
        }
    }
}
