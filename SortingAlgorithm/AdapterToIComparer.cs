namespace SortingAlgorithm
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class AdapterToIComparer:IComparer<int[]>
    {
        private readonly Comparison<int[]> _comparer;

        public AdapterToIComparer(Comparison<int[]> comparer)
        {
            _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        }

        public int Compare(int[] x, int[] y)
        {
            return _comparer(x, y);
        }
    }
}
