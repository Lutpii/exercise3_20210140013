using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_Linked_List_B
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

        /*Method untuk menge-check apakah Node yang dimaksud ada didalam list*/
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            previous = LAST;
            current = LAST;
            while ((current != null) && (rollNo != current.rollNumber))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }

        /*class list empty dan mendeklarasikan*/
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }

        /*Method Traverse mengunjungi dan membaca semua isi list*/
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty. \n");
            else
            {
                Console.WriteLine("\nRecords in the list are: \n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != null)
                {
                    Console.Write(currentNode.rollNumber + " " + currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + " " + LAST.name + "\n");
            }
        }

        /*Method first node untuk menampilkan record pertama di list*/
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is:\n\n" + LAST.next.rollNumber + "     " + LAST.next.name);
        }

        /*Method untuk menambahkan sebuah Node kedalam list*/
        public void addNode()
        {
            int rollNo;
            string nm;
            Console.Write("\nEnter student number: ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the Student's name: ");
            nm = Console.ReadLine();
            Node NodeBaru = new Node();
            NodeBaru.rollNumber = rollNo;
            NodeBaru.name = nm;
            if (LAST == null || rollNo <= LAST.rollNumber) /*Node ditambahkan sebagai Nodebaru*/
            {
                if ((LAST != null) && (rollNo == LAST.rollNumber))
                {
                    Console.WriteLine("\nSame student number is not allowed\n");
                    return;
                }
                NodeBaru.next = LAST;
                LAST = NodeBaru;
                return;
            }
            /*Menemukan lokasi Node baru didalam list*/
            Node previous, current;
            previous = LAST;
            current = LAST;
            while ((current != null) && (rollNo >= current.rollNumber))
            {
                if (rollNo == current.rollNumber)
                {
                    Console.WriteLine("\nSame student number is not allowed\n");
                    return;
                }
                previous = current;
                current = current.next;
            }
            /*Node baru akan ditempatkan diantara previous dan current*/
            NodeBaru.next = current;
            previous.next = NodeBaru;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
