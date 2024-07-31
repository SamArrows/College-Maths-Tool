using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class Node
    {
        private int data;
        private Node left;
        private Node right;
        //each node has data as well as two child nodes: the one directly to its left and the one directly to its right.
        //the node class contains methods for getting and setting these attributes, which are utilised by the tree class.
        public int GetData()
        {
            return data;
        }
        public Node GetLeftNode()
        {
            return left;
        }
        public Node GetRightNode()
        {
            return right;
        }
        public void SetRightNode(Node node)
        {
            right = node;
        }
        public void SetLeftNode(Node node)
        {
            left = node;
        }
        public void SetData(int val)
        {
            data = val;
        }
    }
    class Tree
    {
        public Node InsertNode(Node root, int v)
        {
            /*
            * The InsertNode algorithm is recursive and keeps cycling through nodes in the tree until it finds one with the left or right child of it empty.
             * At this point, the node is assigned to be the located node's child, using setters and getters to access node attributes and modify them.
             */
            if (root == null)
            {
                /*
                 * The constructor for node doesn't need any parameters as these are assigned when new nodes are made and added to the tree.
                 * The left and right attributes need to be left null in order for the algorithm to easily locate available positions in the tree.
                */
                root = new Node();
                root.SetData(v);
            }
            else if (v < root.GetData())
            {
                root.SetLeftNode(InsertNode(root.GetLeftNode(), v));
            }
            else
            {
                root.SetRightNode(InsertNode(root.GetRightNode(), v));
            }
            return root;
        }
    }
}
