using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice
{
    internal class Node
    {
      
        public int data;
        public List<Node> hijo = new List<Node>();
        public List<Node> padre = new List<Node>();
        public Node(Graph graph)
        {
            data = graph.assignNodeData;
            graph.assignNodeData++;
        }
    }
}
