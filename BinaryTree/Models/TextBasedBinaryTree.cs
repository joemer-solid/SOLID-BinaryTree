using BinaryTree.Builders;
using BinaryTree.Strategy;
using System;
using System.Text;
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

            RootNode = BuildNode(rootNodeValue);

            CurrentNode = RootNode;                 
        }


        private NodeBase<string> BuildNode(string nodeValue)
        {
            return NodeBuilder.Build(new NodeBuilderParams<string>
            {
                Id = GetNewNodeId(),
                Value = nodeValue,                
                NodeTypeToParent = NodeToParentType.None,
                ParentRef = null
            });
        }   



        private string getFormattedNodeIdAndValue(NodeBase<string> node)
        {
            return string.Format("Id: {0} Value: {1}", node.Id.ToString(), node.Value);
        }
    }
}
