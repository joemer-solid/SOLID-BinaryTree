using BinaryTree.Builders;
using System;
using BinaryTree.Models;
using BinaryTree.PortServices;

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
            TextBasedBinaryTreeService textBasedBinaryTreeService = new TextBasedBinaryTreeService();

            TextBasedBinaryTree textBasedBinaryTree = textBasedBinaryTreeService.CreateTextBasedBinaryTree(values);

          
            System.Diagnostics.Debug.WriteLine("stop");


        }
    }
}
