using BinaryTree.Models;
using BinaryTree.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree.PortServices
{
    public sealed class TextBasedBinaryTreeService
    {

        public TextBasedBinaryTree CreateTextBasedBinaryTree(string[] values)
        {
            const int centerForRootPadLeft = 40;
            INodeDisplayer<TextBasedNodeDisplayerParams<string>> 
                nodeDisplayer = new TextBasedNodeDisplayer(centerForRootPadLeft);

            TextBasedBinaryTree textBasedBinaryTree = initializeTextBasedBTreeWithRootNode(values[0]);



        }


        private TextBasedBinaryTree initializeTextBasedBTreeWithRootNode(string rootNodeValue)
        {
            // The initial value will be the root node
            return new TextBasedBinaryTree(rootNodeValue);
        }

        private void setNodeDisplayPosition(Node<string> node, INodeDisplayer<TextBasedNodeDisplayerParams<string>> nodeDisplayer)
        {
            no
        }
    }
}
