using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GraphPractice
{
	internal class Graph
	{
	

		public List<Node> lisN = new List<Node>();
		public List<Edge> ListAris = new List<Edge>();

		public int assignNodeData=1;

		public int shortest = 0;

		public List<Node> CCNodos = new List<Node>();

        public List<Edge> CCamS = new List<Edge>();
		public bool Pri = true;
		public bool Seg = true;

		public int[] CaminoCor = new int[10];

		public int[] CaminoLar = new int[10];

		
		public void MetNodo(Node node)
		{
		
			foreach (Node nodes in lisN)
            {
				if(node == nodes)
                {
					Console.WriteLine("No se puede insertar el mismo nodo más de dos veces");
					return;
                }
            }
			lisN.Add(node);
		}
		public void ElimiNodo(Node node)
		{
			for (int i = 0; i < lisN.Count; i++)
			{
				for (int k = 0; k < lisN[i].hijo.Count; k++)
				{
					if (lisN[i].hijo[k] == node)
					{
						lisN[i].hijo.RemoveAt(k);
					}
				}
			}
			
			for (int i = 0; i < lisN.Count; i++)
            {
				
				if (lisN[i] == node)
                {
					for (int k = 0; k > node.hijo.Count; k++)
					{
						lisN[i].hijo.RemoveAt(k);
                    }
					for (int k = 0; k<ListAris.Count ;k++)
					{
						if (ListAris[k].INodo == node || ListAris[k].finalNode == node )
						{
							ListAris.RemoveAt(k);
						}
					}
					lisN.RemoveAt(i);
					return;
                }
            }
			Console.WriteLine("El nodo no puede ser borrado porque ya fue eliminado");
		}
		public void MArista(Edge edge)
		{
			
			ListAris.Add(edge);
		}
		public void EliminarAri(Edge edge)
        {
			for (int i = 0; i < lisN.Count; i++)
			{
				if (edge.INodo == lisN[i])
				{
					for (int k = 0; k<lisN[i].hijo.Count;k++)
					{
						if (edge.finalNode == lisN[i].hijo[k])
						{
							lisN[i].hijo.RemoveAt(k);
						}
					}
				}
			}
               
                for (int i = 0; i<ListAris.Count;i++)
            {
                if (ListAris[i]==edge)
                {
					ListAris.RemoveAt(i);
					return;
				}
			}
			Console.WriteLine("La arista no puede ser borrado porque ya fue borrada");
        }
		public void ConGrafo()
		{
			int zeroCounter = 0;

		
			Console.WriteLine("Conexiones:\n");
			Console.Write("   ");
			foreach (Node node in lisN)
			{
				Console.Write(node.data + "  ");
			}
			Console.WriteLine();
			Console.Write("  ");
			foreach (Node node in lisN)
			{
				Console.Write("---");
			}
			Console.WriteLine();

		
			for (int i = 0; i < lisN.Count;i++)
			{
				Console.Write(lisN[i].data + "| ");

				
				for(int j = 0; j < lisN.Count; j++)
				{
					foreach(Edge edge in ListAris)
					{
						if (edge.INodo.data==lisN[i].data && edge.finalNode.data == lisN[j].data)
						{
							Console.Write(1 + "  ");
							zeroCounter = zeroCounter + 1;
						}
					}
                    if (zeroCounter <= 0)
                    {
						Console.Write(0 + "  ");
					}
                    else
                    {
						zeroCounter=zeroCounter-1;
                    }
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
		public void PesoAri()
		{
			int zeroCounter = 0;

			
			Console.WriteLine("Peso:\n");
			Console.Write("   ");
			foreach (Node node in lisN)
			{
				Console.Write(node.data + "  ");
			}
			Console.WriteLine();
			Console.Write("  ");
			foreach (Node node in lisN)
			{
				Console.Write("---");
			}
			Console.WriteLine();

			
			for (int i = 0; i < lisN.Count; i++)
			{
				Console.Write(lisN[i].data + "| ");
				for (int j = 0; j < lisN.Count; j++)
				{
					foreach (Edge edge in ListAris)
					{
						if (edge.INodo.data == lisN[i].data&& edge.finalNode.data == lisN[j].data)
						{
							Console.Write(edge.weight+"  ");
							zeroCounter = zeroCounter + 1;	
						}
					}
					if (zeroCounter <= 0)
					{
						Console.Write(0 + "  ");
					}
					else
					{
						zeroCounter = zeroCounter - 1;
					}
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
		public void transversalBFS(Node node)
		{
			int[] values = new int[lisN.Count];

			values[0] = node.data;

			foreach (Node nodes in node.hijo)
			{
				transversalBFS(nodes,values);
			}
            Console.Write("\n" + "Transversal BFS: (");
            for (int i = 0; i < values.Length; i++)
			{
				if (values.Length-1==i)
				{
					Console.Write(values[i]+")");
                }
				else
				{
					Console.Write(values[i] + ", ");
                }
				
			}
		}
		public int[] transversalBFS2(Node node)
		{
			int[] values = new int[lisN.Count];

			for (int i = 0; i < values.Length; i++)
			{
				values[i] = 0;
			}

			values[0] = node.data;

			foreach (Node nodes in node.hijo)
			{
				transversalBFS(nodes, values);
			}
			Console.Write("\n" + "Transversal BFS: (");
			return values;

		}
		public void transversalBFS(Node node, int[] values)
		{
			if (!values.Contains(node.data))
				{
                for (int i = 1; i < values.Length; i++)
                {
                    if (values[i] == 0)
                    {
                        values[i] = node.data;
                        break;
                    }
                }
            }

			foreach (Node nodes in node.hijo)
			{
				transversalBFS(nodes,values);
			}
		}
		public void transversalDFS(Node node)
		{
            int[] values = new int[lisN.Count];

            foreach (Node nodes in node.hijo)
			{
				transversalDFS(nodes,values);
			}

            if (!values.Contains(node.data))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] == 0)
                    {
                        values[i] = node.data;
                        break;
                    }
                }
            }

            Console.Write("\n" + "Transversal DFS: (");
            for (int i = 0; i < values.Length; i++)
            {
                if (values.Length - 1 == i)
                {
                    Console.Write(values[i] + ")");
                }
                else
                {
                    Console.Write(values[i] + ", ");
                }

            }
        }
		public int[] transversalDFS2(Node node)
		{
			int[] values = new int[lisN.Count];

			for(int i = 0; i < values.Length; i++)
            {
				values[i] = 0;
            }

			foreach (Node nodes in node.hijo)
			{
				transversalDFS(nodes, values);
			}

			if (!values.Contains(node.data))
			{
				for (int i = 0; i < values.Length; i++)
				{
					if (values[i] == 0)
					{
						values[i] = node.data;
						break;
					}
				}
			}
			return values;
			Console.Write("\n" + "Transversal DFS: (");
			for (int i = 0; i < values.Length; i++)
			{
				if (values.Length - 1 == i)
				{
					Console.Write(values[i] + ")");
				}
				else
				{
					Console.Write(values[i] + ", ");
				}

			}
		}
		public void transversalDFS(Node node, int[] values)
		{
            foreach (Node nodes in node.hijo)
            {
                transversalDFS(nodes, values);
            }

            if (!values.Contains(node.data))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] == 0)
                    {
                        values[i] = node.data;
                        break;
                    }
                }
            }
        }
		public void CorAl(Node initialNode, Node goal)
		{
			int maxNumb = 30000000;
			Edge edgeIn = new Edge();
			if (initialNode == goal)
			{
				Console.WriteLine("Nodo encontrado.");
				return;
			}
			foreach (Edge edges in ListAris)
			{
				if (edges.INodo == initialNode)
				{

                    if (maxNumb > edges.weight)
                    {
                        maxNumb = edges.weight;
						edgeIn = edges;
                    }

                }
            }

			CCNodos.Add(edgeIn.INodo);
			CCNodos.Add(edgeIn.finalNode);
			CorAl(edgeIn, goal);

			Console.Write("\n"+"Camino corto: (");
			int i = 0;
			foreach (Node nodes in CCNodos)
			{
				if (CCNodos.Count - 1 <= i)
				{
                    Console.Write(nodes.data+")");
                }
				else
				{
                    Console.Write(nodes.data+", ");
                }
				
				i++;
			}
		}
		public void CorAl(Edge edgeIn, Node goal)
		{
			int maxNumb = 30000;
			if (edgeIn.finalNode == goal)
			{
				return;
			}
            foreach (Edge edges in ListAris)
            {
                if (edges.INodo == edgeIn.finalNode)
                {
                    
                        if (maxNumb > edges.weight)
                        {
                            maxNumb = edges.weight;
                            edgeIn = edges;
                        }
                    
                }
            }

            CCNodos.Add(edgeIn.finalNode);

            CorAl(edgeIn, goal);
        }
		public void CorDef(Node initialNode, Node goal)
		{
			List <Edge> pathOfEdges = new List<Edge>();
			
			foreach (Edge edges in ListAris)
			{
				if (edges.INodo == initialNode)
				{
					pathOfEdges.Add(edges);

					foreach(Node nodeChildren in initialNode.hijo)
					{
						if (nodeChildren == edges.finalNode)
						{
                            CorDef(nodeChildren, goal, pathOfEdges);
                        }
					}
					pathOfEdges.Remove(edges);

				}
			}
            Console.Write("\n"+"\n"+"Camino corto: (");
            for (int i = 0; i< CaminoCor.Length; i++)
			{
				if (i == CaminoCor.Length - 1)
				{
					Console.Write(CaminoCor[i] + ")");
				}
				else
				{
					Console.Write(CaminoCor[i] + ", ");
				}
                
            }
			
		}
		public int[] CorDef2(Node initialNode, Node goal)
		{
			List<Edge> pathOfEdges = new List<Edge>();

			

			foreach (Edge edges in ListAris)
			{
				if (edges.INodo == initialNode)
				{
					pathOfEdges.Add(edges);

					foreach (Node nodeChildren in initialNode.hijo)
					{
						if (nodeChildren == edges.finalNode)
						{
							CorDef(nodeChildren, goal, pathOfEdges);
						}
					}
					pathOfEdges.Remove(edges);

				}
			}
            Pri = true;
            return CaminoCor;

		}
		public void CorDef(Node nodeChildren, Node goal, List<Edge> pathOfEdges)
		{
			if (nodeChildren == goal)
			{
				if (Pri == true)
				{
					foreach (Edge edge in pathOfEdges)
					{
						for (int i = 0; i < CaminoCor.Length; i++)
						{
							if (CaminoCor[i] == 0)
							{
								CaminoCor[i] = edge.weight;
								break;
							}
						}
					}
			
					Pri = false;
				}
				else if(CamS(CaminoCor) > CamS(pathOfEdges))
				{
					for (int j = 0; j < CaminoCor.Length; j++)
					{
						if (CaminoCor[j] != 0)
						{
							CaminoCor[j] = 0;
						}

					}
                    foreach (Edge edge in pathOfEdges)
                    {
                        for (int i = 0; i < CaminoCor.Length; i++)
                        {
                            if (CaminoCor[i] == 0)
                            {
                                CaminoCor[i] = edge.weight;
                                break;
                            }
                        }
                    }
                 
				}
				return;
			}

            foreach (Edge edges in ListAris)
            {
                if (edges.INodo == nodeChildren)
                {
                    pathOfEdges.Add(edges);

                    foreach (Node nodeChildrens in nodeChildren.hijo)
                    {
                        if (nodeChildrens == edges.finalNode)
                        {
                            CorDef(nodeChildrens, goal, pathOfEdges);
                        }
                    }
                    pathOfEdges.Remove(edges);

                }
            }
        }
		public int[] larDef2(Node initialNode, Node goal)
		{
			List<Edge> pathOfEdges2 = new List<Edge>();

			foreach (Edge edges in ListAris)
			{
				if (edges.INodo == initialNode)
				{
					pathOfEdges2.Add(edges);

					foreach (Node nodeChildren in initialNode.hijo)
					{
						if (nodeChildren == edges.finalNode)
						{
							larDef(nodeChildren, goal, pathOfEdges2);
						}
					}
					pathOfEdges2.Remove(edges);

				}
			}
			Seg = true;
			return CaminoLar;

		}
		public void larDef(Node nodeChildren, Node goal, List<Edge> pathOfEdges)
		{
			if (nodeChildren == goal)
			{
				if (Seg == true)
				{
					foreach (Edge edge in pathOfEdges)
					{
						for (int i = 0; i < CaminoLar.Length; i++)
						{
							if (CaminoLar[i] == 0)
							{
								CaminoLar[i] = edge.weight;
								break;
							}
						}
					}
					
					Seg = false;
				}
				else if (CamS(CaminoLar) < CamS(pathOfEdges))
				{
					for (int j = 0; j < CaminoLar.Length; j++)
					{
						if (CaminoLar[j] != 0)
						{
							CaminoLar[j] = 0;
						}

					}
					foreach (Edge edge in pathOfEdges)
					{
						for (int i = 0; i < CaminoLar.Length; i++)
						{
							if (CaminoLar[i] == 0)
							{
								CaminoLar[i] = edge.weight;
								break;
							}
						}
					}
				
				}
				return;
			}

			foreach (Edge edges in ListAris)
			{
				if (edges.INodo == nodeChildren)
				{
					pathOfEdges.Add(edges);

					foreach (Node nodeChildrens in nodeChildren.hijo)
					{
						if (nodeChildrens == edges.finalNode)
						{
							larDef(nodeChildrens, goal, pathOfEdges);
						}
					}
					pathOfEdges.Remove(edges);

				}
			}
		}

		public int CamS(List<Edge> path)
		{
			int pathResult = 0;
			foreach (Edge edge in path)
			{
				pathResult = edge.weight + pathResult;
			}
			return pathResult;
		}
        public int CamS(int[] path)
        {
            int pathResult = 0;
            for (int i = 0; i < path.Length;i++)
            {
                pathResult = path[i] + pathResult;
            }
            return pathResult;
        }
        public void CorIni(Edge edgeIn, Node goal,int maxNumb)
        {
            if (edgeIn.finalNode == goal)
            {
                Console.WriteLine("Proceso terminado");
                return;
            }
            
            foreach (Edge edges in ListAris)
            {
                if (edges.INodo == edgeIn.INodo)
                {
                    foreach (Node nodesChildren in edgeIn.INodo.hijo)
                    {
                        if (maxNumb > edges.weight)
                        {
                            maxNumb = edges.weight;
                            edgeIn = edges;
                            
                        }
                    }
                }
            }
            Console.WriteLine(maxNumb);
            CorAl(edgeIn, goal);
        }
    }
}
