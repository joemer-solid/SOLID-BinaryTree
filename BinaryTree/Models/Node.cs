using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree.Models
{
    public sealed class Node<T> : NodeBase<T>, IDisplayableNode
    {
        private int _displayPosition;

        int IDisplayableNode.DisplayPosition
        {
            get
            {
                return _displayPosition;
            }

            set
            {
                _displayPosition = value;
            }

           
        }
    
           
    }
}
