namespace SortingAlgorithm.Test
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class ArraySorterTest
    {
        private const int CountRepeat = 15;

        [TestCase(null)]
        public void BubbleSortTest_ArrayIsNull_ThrowsArgumentNullException(int[][] array)
        {
            var comparator = ArraySorter.IncreaseAmount;
            Assert.Throws<ArgumentNullException>(() => ArraySorter.BubbleSort(array, comparator));
        }

        [TestCase]
        public void BubbleSortTest_ComparatorIsNull_ThrowsArgumentNullException()
        {
            var array = new int[][] { };
            Assert.Throws<ArgumentNullException>(() => ArraySorter.BubbleSort(array, null));
        }

        [Test]
        public void AscendingSumSortTests()
        {
            for (int j = 0; j < CountRepeat; j++)
            {
                var array = SorterTestsHelper.GenerateArray(Guid.NewGuid().GetHashCode());

                ArraySorter.BubbleSort(array, ArraySorter.IncreaseAmount);

                Assert.IsTrue(SorterTestsHelper.IsTrustOrder(array, arr => arr.Sum(), (a, b) => a > b));
            }
        }

        [Test]
        public void DescendingSumSortTests()
        {
            for (int j = 0; j < CountRepeat; j++)
            {
                var array = SorterTestsHelper.GenerateArray(Guid.NewGuid().GetHashCode());

                ArraySorter.BubbleSort(array, ArraySorter.DecreaseAmount);

                Assert.IsTrue(SorterTestsHelper.IsTrustOrder(array, arr => arr.Sum(), (a, b) => a < b));
            }
        }

        [Test]
        public void AscendingMaxElementSortTests()
        {
            for (int j = 0; j < CountRepeat; j++)
            {
                var array = SorterTestsHelper.GenerateArray(Guid.NewGuid().GetHashCode());

                ArraySorter.BubbleSort(array, ArraySorter.IncreaseMaxItem);

                Assert.IsTrue(SorterTestsHelper.IsTrustOrder(array, arr => arr.Max(), (a, b) => a > b));
            }
        }

        [Test]
        public void DescendingMaxElementSortTests()
        {
            for (int j = 0; j < CountRepeat; j++)
            {
                var array = SorterTestsHelper.GenerateArray(Guid.NewGuid().GetHashCode());

                ArraySorter.BubbleSort(array, ArraySorter.DecreaseMaxItem);

                Assert.IsTrue(SorterTestsHelper.IsTrustOrder(array, arr => arr.Max(), (a, b) => a < b));
            }
        }

        [Test]
        public void AscendingMinElementSortTests()
        {
            for (int j = 0; j < CountRepeat; j++)
            {
                var array = SorterTestsHelper.GenerateArray(Guid.NewGuid().GetHashCode());

                ArraySorter.BubbleSort(array, ArraySorter.IncreaseMinItem);

                Assert.IsTrue(SorterTestsHelper.IsTrustOrder(array, arr => arr.Min(), (a, b) => a > b));
            }
        }

        [Test]
        public void DescendingMinElementSortTests()
        {
            for (int j = 0; j < CountRepeat; j++)
            {
                var array = SorterTestsHelper.GenerateArray(Guid.NewGuid().GetHashCode());

                ArraySorter.BubbleSort(array, ArraySorter.DecreaseMinItem);

                Assert.IsTrue(SorterTestsHelper.IsTrustOrder(array, arr => arr.Min(), (a, b) => a < b));
            }
        }
    }
}
