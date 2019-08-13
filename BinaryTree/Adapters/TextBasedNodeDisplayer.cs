using BinaryTree.Models;
using BinaryTree.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree.Adapters
{
    public struct TextBasedNodeDisplayerParams<T>
    {
        public NodeBase<T> NodeToDisplay { get; set; }
    }

    public sealed class TextBasedNodeDisplayer : INodeDisplayer<TextBasedNodeDisplayerParams<string>>
    {
        private int _centerLeftPadForRoot;
        private int _currentDisplayLine;
        private int _childNodeOffset;
        private static INodeDisplayer<TextBasedNodeDisplayerParams<string>> _instance;
    


        private TextBasedNodeDisplayer(int centerLeftPadForRoot, int childNodeOffset)
        {
            _centerLeftPadForRoot = centerLeftPadForRoot;
            _currentDisplayLine = 1;
            _childNodeOffset = childNodeOffset;
        }


        public static INodeDisplayer<TextBasedNodeDisplayerParams<string>> Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new TextBasedNodeDisplayer(45, 5);
                }

                return _instance;
            }
        }

        void INodeDisplayer<TextBasedNodeDisplayerParams<string>>.DisplayAllNodes(TextBasedNodeDisplayerParams<string> t)
        {
            NodeBase<string> currentNode = t.NodeToDisplay;
            IList<Node<string>> nodesToDisplayOnSingleLine = new List<Node<string>>();

            //TODO Implement

            //while(currentNode != null)
            //{
            //    if(currentNode.ParentNode == null)
            //    {
            //        Console.WriteLine(currentNode.Value.PadLeft(((IDisplayableNode)currentNode).DisplayPosition));
                    
            //        if(currentNode.LeftChild != null)
            //        {  
            //            nodesToDisplayOnSingleLine.Add((Node<string>)currentNode);
            //        }

            //        if(currentNode.RightChild != null)
            //        {
                      
            //            nodesToDisplayOnSingleLine.Add((Node<string>)currentNode);
            //        }

            //        Console.WriteLine(getFormattedNodeValuesDisplayLine(nodesToDisplayOnSingleLine));

            //        currentNode = currentNode.LeftChild ?? currentNode.RightChild;

            //    }   
            //    else
            //    {
            //        if (currentNode.LeftChild != null)
            //        {
            //            nodesToDisplayOnSingleLine.Add((Node<string>)currentNode);
            //        }

            //        if (currentNode.RightChild != null)
            //        {

            //            nodesToDisplayOnSingleLine.Add((Node<string>)currentNode);
            //        }

            //        if(currentNode.ParentNode != null)
            //        {

            //        }
            //    }
            //}
            //throw new NotImplementedException();
            ////Print root node on line 1

            //// left child line 2

            //// right child line 2

            //// 
        }


        void INodeDisplayer<TextBasedNodeDisplayerParams<string>>.SetNodePrintPosition(TextBasedNodeDisplayerParams<string> t)
        {
            ((IDisplayableNode)t.NodeToDisplay).DisplayPosition = getNodeLeftPadValue(t.NodeToDisplay);
        }


        private int getNodeLeftPadValue(NodeBase<string> nodeToDisplay)
        {
            int result = 0;

            if (nodeToDisplay.ParentNode == null)
            {
                result = _centerLeftPadForRoot;
            }
            else
            {
                if (nodeToDisplay.NodeToParentType == NodeToParentType.LeftChild)
                {
                    result = ((IDisplayableNode)nodeToDisplay.ParentNode).DisplayPosition - _childNodeOffset;
                }
                else if (nodeToDisplay.NodeToParentType == NodeToParentType.RightChild)
                {
                    result = ((IDisplayableNode)nodeToDisplay.ParentNode).DisplayPosition + _childNodeOffset;
                }
            }

            return result;
        }


        private string getFormattedNodeValuesDisplayLine(IList<Node<string>> nodesToDisplayOnSingleLine)
        {
            StringBuilder builder = new StringBuilder();

            foreach(Node<string> node in nodesToDisplayOnSingleLine)
            {
                builder.Append(node.Value.PadLeft(((IDisplayableNode)node).DisplayPosition));
            }

            return builder.ToString();

        }
    }
}
