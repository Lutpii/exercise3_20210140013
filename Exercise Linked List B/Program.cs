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

    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
