namespace SortingAlgorithm.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class ArraySorterTest
    {
        private const int CountRepeat = 15;

        [TestCase(null)]
        public void BubbleSortTest_ArrayIsNull_ThrowsArgumentNullException(int[][] array)
        {
            var comparator = ComparatorFactory.GetAmountComparer(true);
            Assert.Throws<ArgumentNullException>(() => ArraySorter.BubbleSort(array, comparator));
        }

        [TestCase]
        public void IncreaseAmountBubbleSortTests()
        {
            for (int j = 0; j < CountRepeat; j++)
            {
                var array = SorterTestsHelper.GenerateArray(Guid.NewGuid().GetHashCode());

                ArraySorter.BubbleSort(array, ComparatorFactory.GetAmountComparer(true));

                Assert.IsTrue(SorterTestsHelper.IsTrustOrder(array, arr => arr.Sum(), (a, b) => a > b));
            }
        }

        [TestCase]
        public void IncreaseAmountBubbleSortIComparerTests()
        {
            for (int j = 0; j < CountRepeat; j++)
            {
                var array = SorterTestsHelper.GenerateArray(Guid.NewGuid().GetHashCode());

                ArraySorter.BubbleSort(array, ComparatorFactory.GetAmountComparisonDelegate(true));

                Assert.IsTrue(SorterTestsHelper.IsTrustOrder(array, arr => arr.Sum(), (a, b) => a > b));
            }
        }

        [TestCase]
        public void DecreaseAmountBubbleSortTests()
        {
            for (int j = 0; j < CountRepeat; j++)
            {
                var array = SorterTestsHelper.GenerateArray(Guid.NewGuid().GetHashCode());

                ArraySorter.BubbleSort(array, ComparatorFactory.GetAmountComparer(false));

                Assert.IsTrue(SorterTestsHelper.IsTrustOrder(array, arr => arr.Sum(), (a, b) => a < b));
            }
        }

        [TestCase]
        public void DecreaseAmountBubbleSortIComparerTests()
        {
            for (int j = 0; j < CountRepeat; j++)
            {
                var array = SorterTestsHelper.GenerateArray(Guid.NewGuid().GetHashCode());

                ArraySorter.BubbleSort(array, ComparatorFactory.GetAmountComparisonDelegate(false));

                Assert.IsTrue(SorterTestsHelper.IsTrustOrder(array, arr => arr.Sum(), (a, b) => a < b));
            }
        }

        [TestCase]
        public void IncreaseMaxItemBubbleSortTests()
        {
            for (int j = 0; j < CountRepeat; j++)
            {
                var array = SorterTestsHelper.GenerateArray(Guid.NewGuid().GetHashCode());

                ArraySorter.BubbleSort(array, ComparatorFactory.GetMaxItemComparer(true));

                Assert.IsTrue(SorterTestsHelper.IsTrustOrder(array, arr => arr.Max(), (a, b) => a > b));
            }
        }

        [TestCase]
        public void IncreaseMaxItemBubbleIComparerSortTests()
        {
            for (int j = 0; j < CountRepeat; j++)
            {
                var array = SorterTestsHelper.GenerateArray(Guid.NewGuid().GetHashCode());

                ArraySorter.BubbleSort(array, ComparatorFactory.GetMaxItemComparisonDelegate(true));

                Assert.IsTrue(SorterTestsHelper.IsTrustOrder(array, arr => arr.Max(), (a, b) => a > b));
            }
        }

        [TestCase]
        public void DecreaseMaxItemBubbleSortTests()
        {
            for (int j = 0; j < CountRepeat; j++)
            {
                var array = SorterTestsHelper.GenerateArray(Guid.NewGuid().GetHashCode());

                ArraySorter.BubbleSort(array, ComparatorFactory.GetMaxItemComparer(false));

                Assert.IsTrue(SorterTestsHelper.IsTrustOrder(array, arr => arr.Max(), (a, b) => a < b));
            }
        }

        [TestCase]
        public void DecreaseMaxItemBubbleSortIComparerTests()
        {
            for (int j = 0; j < CountRepeat; j++)
            {
                var array = SorterTestsHelper.GenerateArray(Guid.NewGuid().GetHashCode());

                ArraySorter.BubbleSort(array, ComparatorFactory.GetMaxItemComparisonDelegate(false));

                Assert.IsTrue(SorterTestsHelper.IsTrustOrder(array, arr => arr.Max(), (a, b) => a < b));
            }
        }

        [TestCase]
        public void IncreaseMinItemBubbleSortTests()
        {
            for (int j = 0; j < CountRepeat; j++)
            {
                var array = SorterTestsHelper.GenerateArray(Guid.NewGuid().GetHashCode());

                ArraySorter.BubbleSort(array, ComparatorFactory.GetMinItemComparer(true));

                Assert.IsTrue(SorterTestsHelper.IsTrustOrder(array, arr => arr.Min(), (a, b) => a > b));
            }
        }

        [TestCase]
        public void IncreaseMinItemBubbleIComparerSortTests()
        {
            for (int j = 0; j < CountRepeat; j++)
            {
                var array = SorterTestsHelper.GenerateArray(Guid.NewGuid().GetHashCode());

                ArraySorter.BubbleSort(array, ComparatorFactory.GetMinItemComparisonDelegate(true));

                Assert.IsTrue(SorterTestsHelper.IsTrustOrder(array, arr => arr.Min(), (a, b) => a > b));
            }
        }

        [TestCase]
        public void DecreaseMinItemBubbleSortTests()
        {
            for (int j = 0; j < CountRepeat; j++)
            {
                var array = SorterTestsHelper.GenerateArray(Guid.NewGuid().GetHashCode());

                ArraySorter.BubbleSort(array, ComparatorFactory.GetMinItemComparer(false));

                Assert.IsTrue(SorterTestsHelper.IsTrustOrder(array, arr => arr.Min(), (a, b) => a < b));
            }
        }

        [TestCase]
        public void DecreaseMinItemBubbleIComparerSortTests()
        {
            for (int j = 0; j < CountRepeat; j++)
            {
                var array = SorterTestsHelper.GenerateArray(Guid.NewGuid().GetHashCode());

                ArraySorter.BubbleSort(array, ComparatorFactory.GetMinItemComparisonDelegate(false));

                Assert.IsTrue(SorterTestsHelper.IsTrustOrder(array, arr => arr.Min(), (a, b) => a < b));
            }
        }
    }
}
