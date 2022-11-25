using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_119
{
    
    class Node
    {
        /*creates Nodes for the circular nexted list*/
        public int roll119;
        public string MF;
        public Node next;
        public Node prev;
    }
    class CircularList
    {
        Node LAST;

        public CircularList()
        {
            LAST = null;
        }
        public void addNode()
        {
            int nim;
            string nm;
            Console.WriteLine("\nEnter the roll number of the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student: ");
            nm = Console.ReadLine();
            Node newNode = new Node();
            newNode.roll119 = nim;
            newNode.MF = nm;

            //check if the list empty
            if (LAST == null || nim <= LAST.roll119)
            {
                if ((LAST != null) && (nim == LAST.roll119))
                {
                    Console.WriteLine("\nDuplicate number not allowed");
                    return;
                }
                newNode.next = LAST;
                if (LAST != null)
                    LAST.prev = newNode;
                newNode.next = null;
                LAST = newNode;
                return;
            }
            /*if the node is to be inserted at beetwen two Node*/
            Node previous, current;
            for (current = previous = LAST;
                current != null && nim >= current.roll119;
                previous = current, current = current.next)
            {
                if (nim == current.roll119)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
            }
            /*On the execution of the above for loop, prev and
            * current will point to those nodes
            * between which the new node is to be inserted*/
            newNode.next = current;
            newNode.prev = previous;

            //if the node is to be inserted at the end of the list
            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }

        public bool Search(int rollNo, ref Node previous, ref Node current)
        /*search for the specified node*/
        {
            for (previous = current = LAST.next; current != LAST; previous =
                current, current = current.next)
            {
                if (rollNo == current.roll119)
                    return (true);/*returns true if the node is found*/
            }
            if (rollNo == LAST.roll119)/*if the Node is present at the end*/
                return true;
            else
                return (false);/*return false if the node is not found*/
        }
        public bool dellNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            // the begining of data
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            //Node between two nodes in the list
            if (current == LAST)
            {
                LAST = LAST.next;
                if (LAST != null)
                    LAST.prev = null;
                return true;
            }

            /*if the to be deleted is in between the list then the following lines of is exetuted. */
            previous.next = current.next;
            current.next.prev = previous;
            return true;
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
                    Console.Write(currentNode.roll119 + "        " +
                        currentNode.MF + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.roll119 + "      " + LAST.MF + "\n");
            }
        }
        public void firstNode()
        {
            if (ListEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is:\n\n " +
                    LAST.next.roll119 + "    " + LAST.next. MF);
            Node currentNode;
            for (currentNode = LAST; currentNode != null; currentNode = currentNode.next)
                Console.Write(currentNode.roll119 + currentNode.MF + "\n");
        }
        public void SecondNode()
        {
            if (ListEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecord in the Descending order of" + "Roll number are:\n");
                Node currentNode;
                //membawa currentNode ke node paling belakang
                currentNode = LAST;
                while (currentNode.next != null)
                {
                    currentNode = currentNode.next;
                }

                //membaca data dari last node ke first node
                while (currentNode != null)
                {
                    Console.Write(currentNode.roll119 + "  " + currentNode.MF + "\n");
                    currentNode = currentNode.prev;
                }
            }
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
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.traverse();
                            }
                            break;
                        case '2':
                            {
                                if (obj.ListEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " +
                                        curr.roll119);
                                    Console.WriteLine("\nName: " + curr.MF);
                                }
                            }
                            break;
                        case '3':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
