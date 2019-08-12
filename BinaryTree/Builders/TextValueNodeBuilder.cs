using BinaryTree.Models;

namespace BinaryTree.Builders
{

    public interface ITextValueNodeBuilder : INodeBuilder<string> { }

    public sealed class TextValueNodeBuilder : ITextValueNodeBuilder
    {      
        NodeBase<string> INodeBuilder<string>.Build(NodeBuilderParams<string> t)
        {
            return new Node<string>()
            {
                Id = t.Id,
                Value = t.Value,
                IsRootNode = t.IsRootNode,
                NodeToParentType = t.NodeTypeToParent
            };
        }

    }
}
