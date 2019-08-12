using System;
using System.Collections.Generic;
using System.Text;
using BinaryTree.Builders;
using BinaryTree.Strategy;

namespace BinaryTree.Models
{
    public abstract class BinaryTree<T>
    {
        private int _newNodeId;

        #region Constructors

        public BinaryTree(T rootNodeValue)
        {
            Initialize(rootNodeValue);
        }

        #endregion

        #region Properties

        protected abstract INodeBuilder<T> NodeBuilder { get; set; }

        public abstract NodeBase<T> RootNode { get; protected set; }

        public abstract NodeBase<T> CurrentNode { get; protected set; }

        #endregion

        #region Abstract Methods

        public abstract void AddNode(T nodeValue);

        protected abstract void AddNode(NodeBase<string> currentNode, string addNodeValue);

        protected abstract void Initialize(T rootNodeValue);

        #endregion


        protected int GetNewNodeId()
        {
            _newNodeId = _newNodeId += 1;
            return _newNodeId;
        }
       
    }
}
