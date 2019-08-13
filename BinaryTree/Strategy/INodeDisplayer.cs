namespace BinaryTree.Strategy
{
    public interface INodeDisplayer<T>
    {
        void SetNodePrintPosition(T t);

        void DisplayAllNodes(T t);
    }
}
