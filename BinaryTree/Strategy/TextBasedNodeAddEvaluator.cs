﻿using System;
using System.Collections.Generic;
using System.Text;
using BinaryTree.Adapters;
using BinaryTree.Builders;
using BinaryTree.Models;
using BinaryTree.PortServices;

namespace BinaryTree.Strategy
{
    public sealed class TextBasedNodeAddEvaluator : ITextBasedNodeAddEvaluator
    {
        private IComparer<string> _stringComparer;
        private INodeBuilder<string> _textBasedNodeBuilder;

        public TextBasedNodeAddEvaluator(IComparer<string> stringComparer, INodeBuilder<string> nodeBuilder)
        {
            _stringComparer = stringComparer;
            _textBasedNodeBuilder = nodeBuilder;
        }

        void IAddNodeEvaluator<Tuple<NodeBase<string>, string, int>>.Execute(Tuple<NodeBase<string>, string, int> t)
        {
            AddNode(t.Item1, t.Item2, t.Item3);
        }



        private void AddNode(NodeBase<string> currentNode, string addNodeValue, int newNodeId)
        {

            CompareResult valueCompareResult = CompareNodeValues(addNodeValue, currentNode.Value);

            if (valueCompareResult == CompareResult.GreaterThan)
            {
                // right child
                // If no right child exists, build it
                if (currentNode.RightChild == null)
                {
                    currentNode.RightChild = BuildNode(addNodeValue, newNodeId, NodeToParentType.RightChild, (Node<string>)currentNode);

                    return;
                }
                else
                {
                    currentNode = currentNode.RightChild;

                    AddNode(currentNode, addNodeValue, newNodeId);
                }
            }
            else if (valueCompareResult == CompareResult.LessThan)
            {
                if (currentNode.LeftChild == null)
                {
                    currentNode.LeftChild = BuildNode(addNodeValue,newNodeId, NodeToParentType.LeftChild, (Node<string>)currentNode);
                    return;
                }
                else
                {
                    currentNode = currentNode.LeftChild;

                    AddNode(currentNode, addNodeValue,newNodeId);
                }
            }
        }

        private CompareResult CompareNodeValues(string a, string b)
        {
            int compareResult = _stringComparer.Compare(a, b);

            return (CompareResult)compareResult;
        }


        private NodeBase<string> BuildNode(string nodeValue, int newNodeId, NodeToParentType nodeTypeToParent, Node<string> parentRef)
        {
            return _textBasedNodeBuilder.Build(new NodeBuilderParams<string>
            {
                Id = newNodeId,
                Value = nodeValue,
                NodeTypeToParent = nodeTypeToParent,
                ParentRef = parentRef
            });
        }

        private void SetNodeDisplayPosition(NodeBase<string> node)
        {
            TextBasedNodeDisplayer.Instance.SetNodePrintPosition(new TextBasedNodeDisplayerParams<string> { NodeToDisplay = node });
        }
    }
}
