using BinaryTree.Models;
using BinaryTree.Strategy;
using System;
using System.Collections.Generic;
using System.Text;
using BinaryTree.Adapters;

namespace BinaryTree.PortServices
{
   
    public sealed class TextBasedBinaryTreeService 
    {
        

        public TextBasedBinaryTree CreateTextBasedBinaryTree(string[] values)
        {                       

            TextBasedBinaryTree textBasedBinaryTree = initializeTextBasedBTreeWithRootNode(values[0]);

            TextBasedNodeDisplayer.Instance.SetNodePrintPosition(
                new TextBasedNodeDisplayerParams<string> { NodeToDisplay = textBasedBinaryTree.RootNode });           

            for (int i = 1; i < values.Length; i++)
            {
                textBasedBinaryTree.AddNode(values[i]);
            }

            return textBasedBinaryTree;

        }


        private TextBasedBinaryTree initializeTextBasedBTreeWithRootNode(string rootNodeValue)
        {
            // The initial value will be the root node
            return new TextBasedBinaryTree(rootNodeValue);
        }

    }
}
