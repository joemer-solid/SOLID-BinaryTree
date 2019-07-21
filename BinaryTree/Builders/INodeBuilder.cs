using BinaryTree.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree.Builders
{
    public class NodeBuilderParams<T>
    {
        public int Id { get; set; }

        public T Value { get; set; }
    }

    public interface INodeBuilder<T>
    {
        NodeBase<T> Build(NodeBuilderParams<T> t);
    }

}
