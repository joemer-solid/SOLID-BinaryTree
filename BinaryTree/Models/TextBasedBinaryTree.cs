using System;
using System.Collections.Generic;
using System.Text;
using BinaryTree.Builders;
using BinaryTree.Strategy;
using St = BinaryTree.Strategy;

namespace BinaryTree.Models
{
    public sealed class TextBasedBinaryTree : BinaryTree<string>
    {

        /// <summary>Initializes a new instance of the <see cref="TextBasedBinaryTree"/> class.</summary>
        /// <param name="rootNodeValue">The root node value.</param>
        public TextBasedBinaryTree(string rootNodeValue) : base(rootNodeValue)
        {
            // do nothing
        }

        #region Properties

        public override NodeBase<string> RootNode { get; protected set; }

        public override NodeBase<string> CurrentNode { get; protected set; }

        protected override INodeBuilder<string> NodeBuilder { get; set; }

        #endregion



        public override void AddNode(string nodeValue)
        {
            AddNode(RootNode, nodeValue);
        }

        protected override void AddNode(NodeBase<string> currentNode, string addNodeValue)
        {
            ITextBasedNodeAddEvaluator textBasedNodeEvaluator = new TextBasedNodeAddEvaluator(
                new St.StringComparer(), NodeBuilder);

            textBasedNodeEvaluator.Execute(new Tuple<NodeBase<string>, string, int>(
                RootNode, addNodeValue, GetNewNodeId()));          
          
        }

        protected override void Initialize(string rootNodeValue)
        {
            // Initializes the Binary Tree by creating a root node
            NodeBuilder = new TextValueNodeBuilder();

            RootNode = BuildNode(rootNodeValue, true);

            CurrentNode = RootNode;
                 
        }


        private NodeBase<string> BuildNode(string nodeValue, bool isRootNode)
        {
            return NodeBuilder.Build(new NodeBuilderParams<string>
            {
                Id = GetNewNodeId(),
                Value = nodeValue,
                IsRootNode = isRootNode
            });
        }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            bool moreNodes = true;
            int treeDepth = 0;

            builder.AppendLine("TextBasedBinaryTree");

            NodeBase<string> currentNode = RootNode;

            builder.AppendLine(getFormattedNodeIdAndValue(RootNode));

            while (moreNodes)
            {
               
                if (currentNode.LeftChild != null)
                {
                    builder.AppendLine(getFormattedNodeIdAndValue(currentNode));

                    if(treeDepth > 0)
                    {
                        currentNode = currentNode.RightChild;
                    }
                   
                }

                if(currentNode.RightChild != null)
                {
                    builder.AppendLine(getFormattedNodeIdAndValue(currentNode));

                    if(treeDepth > 0)
                    {
                       
                    }
                }

                treeDepth++;

                moreNodes = currentNode.LeftChild != null;


                currentNode = currentNode.LeftChild;



            }


            return builder.ToString();
        }



        private string getFormattedNodeIdAndValue(NodeBase<string> node)
        {
            return string.Format("Id: {0} Value: {1}", node.Id.ToString(), node.Value);
        }
    }
}
