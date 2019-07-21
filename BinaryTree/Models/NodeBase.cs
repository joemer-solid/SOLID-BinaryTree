using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree.Models
{
    public abstract class NodeBase<T>
    {
        public int Id { get; set; }  

        public T Value { get; set; }

        public NodeBase<T> LeftChild { get; set; }

        public NodeBase<T> RightChild { get; set; }
    }


}
