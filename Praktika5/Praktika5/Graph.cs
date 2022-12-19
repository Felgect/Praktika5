using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika5
{
    public class Node
    {
        private int id;
        private int weight;
        private Node link;
        public int Id { get; set; }
        public int Weight { get; set; }
        public Node Link;
        public Node() { }
        public Node(int id, int weight)
        {
            Id = id;
            Weight = weight;
        }
    }

    public class Graph
    {
        private int size;
        private bool[,] adjacency;
        public bool[] vector;

        public int Size { get; set; }
        public bool[,] Adjacency { get; set; }
        public bool[] Vector { get; set; }

        public Graph(int size, bool[,] G)
        {
            Adjacency = new bool[size, size];
            Adjacency = G;
            Vector = new bool[size];
            for (int i = 0; i < size; i++)
                Vector[i] = false;
            Size = size;
        }

        public void Depth(int i)
        {
            Vector[i] = true;
            Console.Write("{0}" + ' ', i);
            for (int k = 0; k < Size; k++)
                if (Adjacency[i, k] && !(Vector[k]))
                    Depth(k);
        }
    }
}
