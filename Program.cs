﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_119
{
    class Node
    {
        /*creates Nodes for the circular nexted list*/
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;

        public CircularList()
        {
            LAST = null;
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)
        /*search for the specified node*/
        {
            for (previous = current = LAST.next; current != LAST; previous =
                current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true);/*returns true if the node is found*/
            }
            if (rollNo == LAST.rollNumber)/*if the Node is present at the end*/
                return true;
            else
                return (false);/*return false if the node is not found*/
        }
        public bool ListEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void traverse()/*Traverses all the nodes of the list*/
        {
            if (ListEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecords in the list are:\n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + "        " +
                        currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + "      " + LAST.name + "\n");
            }
        }
        public void firstNode()
        {
            if (ListEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is:\n\n " +
                    LAST.next.rollNumber + "    " + LAST.next.name);
        }
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. View all the records in the list");
                    Console.WriteLine("2. Search for the records in the list");
                    Console.WriteLine("3. Display the first record in the list");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nEnter your choice (1-4):  ");
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
