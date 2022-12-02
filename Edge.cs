using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice
{
    internal class Edge
    {
       
        public Node INodo;
        public Node finalNode;
        public int weight;
        public Edge(Node initialNode, Node finalNode, int weight)
        {
            if (initialNode.data == finalNode.data)
            {
                Console.WriteLine("Conectar un nodo consigo mismo está prohibido.");
                return;
            }
            
            this.INodo = initialNode;
            this.finalNode = finalNode;
            this.weight = weight;

            this.INodo.hijo.Add(finalNode);
            this.finalNode.padre.Add(initialNode);
        }
        public Edge()
        {

        }
    }
}
