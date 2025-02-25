﻿using System;
using System.Collections.Generic;
using System.Text;
class Node
{
    public int Data;
    public Node Left, Right;

    // Constructor 
    public Node(int data)
    {
        Data = data;
        Left = Right = null;
    }
}
class BinaryTree
{
    Node root;

    // Prints the left border, except for leaf buttons
    private void PrintLeftBoundary(Node node, List<int> result)
    {
        if (node == null) return;
        if (node.Left != null)
        {
            result.Add(node.Data);  // Save the current node
            PrintLeftBoundary(node.Left, result);
        }
        else if (node.Right != null)
        {
            result.Add(node.Data);
            PrintLeftBoundary(node.Right, result);
        }
    }

    // Print leaf buttons
    private void PrintLeaves(Node node, List<int> result)
    {
        if (node == null) return;
        PrintLeaves(node.Left, result);

        // Check if it is leaves
        if (node.Left == null && node.Right == null)
            result.Add(node.Data);
        PrintLeaves(node.Right, result);
    }

    // Print right border, except leaf nodes (in order from bottom to top)
    private void PrintRightBoundary(Node node, List<int> result)
    {
        if (node == null) return;
        if (node.Right != null)
        {
            PrintRightBoundary(node.Right, result);
            result.Add(node.Data); // Save the current node after recursion 
        }
        else if (node.Left != null)
        {
            PrintRightBoundary(node.Left, result);
            result.Add(node.Data);
        }
    }

    // Determine the boundary
    public List<int> BoundaryTraversal()
    {
        List<int> result = new List<int>();
        if (root == null) return result;

        result.Add(root.Data); // The tree stump is always on the border

        // Print left border
        PrintLeftBoundary(root.Left, result);

        // Print leaf buttons
        PrintLeaves(root.Left, result);
        PrintLeaves(root.Right, result);

        // Print right border 
        PrintRightBoundary(root.Right, result);

        return result;
    }

    // Utility function to add data to the tree (demo)
    public void AddRoot(int data) => root = new Node(data);
    public Node AddLeft(Node parent, int data) => parent.Left = new Node(data);
    public Node AddRight(Node parent, int data) => parent.Right = new Node(data);

    // Main
    public static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();

        /*
                1
              /   \
             2     3
            / \   / \
           4   5 6   7

        */

        // Create binary tree
        tree.AddRoot(1);
        var left = tree.AddLeft(tree.root, 2);
        var right = tree.AddRight(tree.root, 3);
        tree.AddLeft(left, 4);
        tree.AddRight(left, 5);
        tree.AddLeft(right, 6);
        tree.AddRight(right, 7);

        List<int> boundary = tree.BoundaryTraversal();
        Console.WriteLine("Boundary Traversal: " + string.Join(", ", boundary));
        Console.WriteLine("Final project of 2024");
    }
}

