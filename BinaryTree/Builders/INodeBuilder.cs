using BinaryTree.Models;

namespace BinaryTree.Builders
{
    public sealed class NodeBuilderParams<T>
    {
        public int Id { get; set; }

        public T Value { get; set; }

        public bool IsRootNode { get; set; }

        public NodeToParentType NodeTypeToParent { get; set; }

        public Node<string> ParentRef { get; set; }
    }

    public interface INodeBuilder<T>
    {
        NodeBase<T> Build(NodeBuilderParams<T> t);
    }

}
