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
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
