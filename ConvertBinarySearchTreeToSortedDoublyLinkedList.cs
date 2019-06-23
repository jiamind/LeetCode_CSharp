using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertBinarySearchTreeToSortedDoublyLinkedList_NS;

namespace ConvertBinarySearchTreeToSortedDoublyLinkedList_NS
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;

        public Node() { }
        public Node(int _val, Node _left, Node _right)
        {
            val = _val;
            left = _left;
            right = _right;
        }
    }
}

namespace LeetCode_CSharp
{
    /// <summary>
    /// 426. Convert Binary Search Tree to Sorted Doubly Linked List
    /// Convert a BST to a sorted circular doubly-linked list in-place. Think of the left and right pointers as synonymous to the previous and next pointers in a doubly-linked list.
    /// Let's take the following BST as an example, it may help you understand the problem better:
    /// We want to transform this BST into a circular doubly linked list.Each node in a doubly linked list has a predecessor and successor.For a circular doubly linked list, the predecessor of the first element is the last element, and the successor of the last element is the first element.
    /// The figure below shows the circular doubly linked list for the BST above.The "head" symbol means the node it points to is the smallest element of the linked list.
    /// Specifically, we want to do the transformation in place.After the transformation, the left pointer of the tree node should point to its predecessor, and the right pointer should point to its successor.We should return the pointer to the first element of the linked list.
    /// The figure below shows the transformed BST.The solid line indicates the successor relationship, while the dashed line means the predecessor relationship.
    /// </summary>
    public class ConvertBinarySearchTreeToSortedDoublyLinkedList
    {
        private Node firstNode;

        private Node prevNode;

        public Node TreeToDoublyList(Node root)
        {
            this.Helper(root);

            if (firstNode != null && prevNode != null)
            {
                firstNode.left = prevNode;
                prevNode.right = firstNode;
            }

            return firstNode;
        }

        private void Helper(Node node)
        {
            if (node == null)
            {
                return;
            }

            Helper(node.left);

            if (firstNode == null)
            {
                firstNode = node;
            }

            if (prevNode != null)
            {
                prevNode.right = node;
                node.left = prevNode;
            }

            prevNode = node;

            Helper(node.right);
        }
    }
}
