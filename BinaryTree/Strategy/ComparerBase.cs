using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree.Strategy
{
    public abstract class ComparerBase<T> : IComparer<T>
    {
        public abstract int Compare(T x, T y);

        public abstract bool SwapValues(T x, T y);
    }


    public enum CompareResult
    {
        Equal = 0,
        LessThan = -1,
        GreaterThan = 1,
        Unknown = 10

    }
}
