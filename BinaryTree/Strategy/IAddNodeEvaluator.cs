using BinaryTree.Builders;
using BinaryTree.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree.Strategy
{
    public interface IAddNodeEvaluator<in T>
    {
        void Execute(T t);
    }


    public interface ITextBasedNodeAddEvaluator : IAddNodeEvaluator<Tuple<NodeBase<string>, string, int>> { }

}
