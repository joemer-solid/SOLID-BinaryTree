using BinaryTree.Builders;
using System;
using BinaryTree.Models;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildBinaryTree(new string[] { "m", "a", "n", "b", "o", "c" , "p"});
        }


        private static void BuildBinaryTree(string[] values)
        {
            // The initial value will be the root node
            BinaryTree<string> binaryTree = new TextBasedBinaryTree(values[0]);

            for(int i = 1; i < values.Length; i++)
            {
                binaryTree.AddNode(values[i]);
            }

            System.Diagnostics.Debug.WriteLine("stop");


        }
    }
}
