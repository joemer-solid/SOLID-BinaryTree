using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree.Strategy
{
    public sealed class StringComparer : ComparerBase<string>
    {

        #region IComparer implementation

        public override int Compare(string x, string y)
        {
            CompareResult compareResult = CompareResult.Unknown;


            if (x[0] == y[0])
            {
                compareResult = CompareResult.Equal;
            }
            else if (x[0] > y[0])
            {
                compareResult = CompareResult.GreaterThan;
            }
            else if (x[0] < y[0])
            {
                compareResult = CompareResult.LessThan;
            }


            return (int)compareResult;
        }

        public override bool SwapValues(string x, string y)
        {
            throw new NotImplementedException();
        }

        #endregion



    }
}
