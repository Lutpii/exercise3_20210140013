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

        /*Method untuk menghapus Node tertentu didalam list*/
        public bool delNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            /*check apakah Node yang dimaksud ada didalam list atau tidak*/
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == LAST)
                LAST = LAST.next;
            return true;
        }

    }

    /*Method untuk menampilkan menu*/
    class Program
    {
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. View all the records in the list");
                    Console.WriteLine("2. Search for a record in the list");
                    Console.WriteLine("3. Display the first record in the list");
                    Console.WriteLine("4. Add student names and numbers in the list");
                    Console.WriteLine("5. Delete student names and numbers in the list");
                    Console.WriteLine("6. Exit");
                    Console.Write("\nEnter Your Choice (1-6): ");
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
                                if (obj.listEmpty() == true)
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
                                    Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                            }
                            break;
                        case '3':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '4'://new case add
                            {
                                obj.addNode();
                            }
                            break;
                        case '5'://new case delete
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("\nEnter the roll number of the student which will be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("\nRecord not found.");
                                else
                                    Console.WriteLine("Data with student numbers " + rollNo + " deleted ");
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid choice");
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
