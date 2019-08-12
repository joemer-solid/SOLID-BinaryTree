using BinaryTree.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree.Strategy
{
    public struct TextBasedNodeDisplayerParams<T>
    {
        public Node<T> NodeToDisplay { get; set; }
    }


    public sealed class TextBasedNodeDisplayer : INodeDisplayer<TextBasedNodeDisplayerParams<string>>
    {
        private int _centerLeftPadForRoot;
        private int _currentDisplayLine;
        private int _childNodeOffset;

        public TextBasedNodeDisplayer(int centerLeftPadForRoot, int childNodeOffset)
        {
            _centerLeftPadForRoot = centerLeftPadForRoot;
            _currentDisplayLine = 1;
            _childNodeOffset = childNodeOffset;
        }

        void INodeDisplayer<TextBasedNodeDisplayerParams<string>>.DisplayNode()
        {
            throw new NotImplementedException();
        }


        void INodeDisplayer<TextBasedNodeDisplayerParams<string>>.SetNodePrintPosition(TextBasedNodeDisplayerParams<string> t)
        {
            ((IDisplayableNode)t.NodeToDisplay).DisplayPosition = getNodeLeftPadValue(t.NodeToDisplay);
        }


        private int getNodeLeftPadValue(Node<string> nodeToDisplay)
        {
            int result = 0;

            if(nodeToDisplay.ParentNode == null)
            {
                result = _centerLeftPadForRoot;
            }
            else
            {
                if(nodeToDisplay.NodeToParentType == NodeToParentType.LeftChild)
                {
                    result = ((IDisplayableNode)nodeToDisplay.ParentNode).DisplayPosition - _childNodeOffset;
                }
                else if(nodeToDisplay.NodeToParentType == NodeToParentType.RightChild)
                {
                    result = ((IDisplayableNode)nodeToDisplay.ParentNode).DisplayPosition + _childNodeOffset;
                }
            }

            return result;
        }

    }
}
