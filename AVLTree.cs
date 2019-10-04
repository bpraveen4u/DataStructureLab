using System;
using System.Collections.Generic;
using System.Text;

namespace DataStuctureLab
{
    class AVL
    {
        public class Node
        {
            public int Data;
            public Node Left;
            public Node Right;

            public Node(int data)
            {
                this.Data = data;
            }
        }

        Node root;
        public AVL()
        {
        }

        public static void Run()
        {
            Console.WriteLine("AVL Tree");
            AVL tree = new AVL();
            tree.Add(15);
            tree.Add(12);
            tree.Add(13);
            tree.Add(11);
            tree.Add(10);
            tree.Add(9);
            //tree.Display();
            tree.Add(7);
            //tree.Display();
            tree.Add(5);
            //tree.Display();
            tree.Add(3);
            tree.Add(1);
            tree.Add(0);
            //tree.Display();
            //tree.Delete(7);
            //tree.DisplayTree();
            tree.Display();
            tree.Delete(5);
            tree.Display();

            tree.Add(20);
            tree.Add(30);
            //tree.Add(40);
            tree.Display();
        }

        public void Add(int data)
        {
            Node addItem = new Node(data);
            if (this.root == null)
            {
                root = addItem;
            }
            else
            {
                root = RecursiveInsert(root, addItem);
            }
        }

        private Node RecursiveInsert(Node current, Node n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.Data < current.Data)
            {
                current.Left = RecursiveInsert(current.Left, n);
                current = BalanceTree(current);
            }
            else if (n.Data > current.Data)
            {
                current.Right = RecursiveInsert(current.Right, n);
                current = BalanceTree(current);
            }

            return current;
        }

        private Node BalanceTree(Node current)
        {
            int balanceFactor = this.BalanceFactor(current);

            if (balanceFactor > 1)
            {
                if (this.BalanceFactor(current.Left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (balanceFactor < -1)
            {
                if (this.BalanceFactor(current.Right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }

            return current;
        }

        private int BalanceFactor(Node current)
        {
            int l = GetHeight(current.Left);
            int r = GetHeight(current.Right);
            int b_factor = l - r;
            return b_factor;
        }

        private int Max(int left, int right)
        {
            return left > right ? left : right;
        }

        private int GetHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int left = GetHeight(current.Left);
                int right = GetHeight(current.Right);
                int m = Max(left, right);
                height = m + 1;
            }
            return height;
        }
        private Node RotateRR(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }
        private Node RotateLL(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private Node RotateLR(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }

        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            InOrderDisplayTree(root);
            Console.WriteLine();
        }
        private void InOrderDisplayTree(Node current)
        {
            if (current != null)
            {
                InOrderDisplayTree(current.Left);
                Console.Write("({0}) ", current.Data);
                InOrderDisplayTree(current.Right);
            }
        }

        public void Display()
        {
            PrintNode("", root, false);
            Console.WriteLine("\n");
        }

        private void PrintNode(string prefix, Node n, bool isLeft)
        {
            if (n != null)
            {
                PrintNode(prefix + "     ", n.Right, false);
                Console.WriteLine(prefix + ("|-- ") + n.Data);
                PrintNode(prefix + "     ", n.Left, true);
            }
        }

        public void Find(int key)
        {
            if (Find(key, root).Data == key)
            {
                Console.WriteLine("{0} was found!", key);
            }
            else
            {
                Console.WriteLine("Nothing found!");
            }
        }
        private Node Find(int target, Node current)
        {

            if (target < current.Data)
            {
                if (target == current.Data)
                {
                    return current;
                }
                else
                    return Find(target, current.Left);
            }
            else
            {
                if (target == current.Data)
                {
                    return current;
                }
                else
                    return Find(target, current.Right);
            }

        }

        public void Delete(int target)
        {//and here
            root = Delete(root, target);
        }
        private Node Delete(Node current, int target)
        {
            Node parent;
            if (current == null)
            { return null; }
            else
            {
                //left subtree
                if (target < current.Data)
                {
                    current.Left = Delete(current.Left, target);
                    if (BalanceFactor(current) == -2)//here
                    {
                        if (BalanceFactor(current.Right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }
                //right subtree
                else if (target > current.Data)
                {
                    current.Right = Delete(current.Right, target);
                    if (BalanceFactor(current) == 2)
                    {
                        if (BalanceFactor(current.Left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                //if target is found
                else
                {
                    if (current.Right != null)
                    {
                        //delete its inorder successor
                        parent = current.Right;
                        while (parent.Left != null)
                        {
                            parent = parent.Left;
                        }
                        current.Data = parent.Data;
                        current.Right = Delete(current.Right, parent.Data);
                        if (BalanceFactor(current) == 2)//rebalancing
                        {
                            if (BalanceFactor(current.Left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else { current = RotateLR(current); }
                        }
                    }
                    else
                    {   //if current.left != null
                        return current.Left;
                    }
                }
            }
            return current;
        }
    }
}
