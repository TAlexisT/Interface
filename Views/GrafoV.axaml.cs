using Avalonia.Controls;
using GraphPractice;
using System;
using System.Collections.Generic;

namespace PracticaInt.Views
{
    public partial class GrafoV : Window
    {
        Graph graph = new Graph();
        List<Node> NodosT = new List<Node>();
        public GrafoV()
        {
            InitializeComponent();
        }
        void EspacioB(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Principal x = new Principal();
            x.Show();
            this.Close();

        }
        void NNodoB(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Node node = new Node(graph);
            graph.MetNodo(node);
            Muestra.Content = "Nodo " + node.data + " añadido exitosamente";
        }
        void NAristaB(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (InicioN.Text == "" || FinalN.Text == "" || PesoN.Text == "" || InicioN.Text == null || FinalN.Text == null || PesoN.Text == null)
            {
                Muestra.Content = "Para añadir una arista, complete todos los espacios en blanco.";
                return;
            }

            if (Int16.Parse(InicioN.Text) == Int16.Parse(FinalN.Text))
            {
                Muestra.Content = "No se puede conectar un nodo entre sí.";
                return;
            }
            foreach (Edge edge in graph.ListAris)
            {
                if (Int16.Parse(InicioN.Text) == edge.INodo.data && Int16.Parse(FinalN.Text) == edge.finalNode.data)
                {
                    Muestra.Content = "No se pueden añadir dos aristas con el mismo inicio y final.";
                    return;
                }
            }
            foreach (Node node in graph.lisN)
            {
                if(node.data == Int16.Parse(InicioN.Text))
                {
                    foreach (Node node2 in graph.lisN) 
                    {
                        if(node2.data == Int16.Parse(FinalN.Text))
                        {
                            Edge edge = new Edge(node,node2, Int16.Parse(PesoN.Text));
                            graph.MArista(edge);
                            Muestra.Content = "Arista "+node.data+ " to "+ node2.data + " añadida correctamente";
                            return;
                        }
                    }
                    Muestra.Content = "Nodo final no encontrado";
                    return;
                }
            }
            Muestra.Content = "Nodo de inicio no encontrado";
        }
        void EliminarB(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if(EliminarN.Text == null)
            {
                Muestra.Content = "Inserte un nodo que desee eliminar.";
                return;
            }
            foreach(Node node in graph.lisN)
            {
                if(node.data == Int16.Parse(EliminarN.Text))
                {
                    Muestra.Content = "Nodo "+node.data+" eliminado correctamente.";
                    graph.ElimiNodo(node);
                    return;
                }
            }
            Muestra.Content = "Nodo que se quiere eliminar no encontrado.";
        }
        void EliminarAB(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if(EliminarAF.Text == null || EliminarAI.Text == null)
            {
                Muestra.Content = "Rellenar todos los espacios para eliminar una arista.";
                return;
            }
            foreach(Edge edge in graph.ListAris)
            {
                if (Int16.Parse(EliminarAI.Text) == edge.INodo.data && Int16.Parse(EliminarAF.Text) == edge.finalNode.data)
                {
                    graph.EliminarAri(edge);
                    Muestra.Content = "Arista"+ EliminarAI.Text +" a "+ EliminarAF.Text + " eliminada correctamente.";
                    return;
                }
            }
            Muestra.Content = "Arista no encontrada.";
        }
        void Corto(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if(DestinoC.Text == null)
            {
                Muestra.Content = "Inserte el nodo que desea ir.";
                return;
            }
            int[] CCor = new int[10];
            String message= "Camino más corto = ";

            for (int i = 0; i < graph.CaminoCor.Length; i++)
            {
                graph.CaminoCor[i] = 0;
            }
            
            for (int i = 0; i < graph.CaminoCor.Length; i++)
            {
                graph.CaminoCor[i] = 0;
            }

            foreach (Node node in graph.lisN)
            {
                if(Int16.Parse(DestinoC.Text) == node.data)
                {
                    CCor = graph.CorDef2(graph.lisN[0], node);
                    break;
                }
            }
            for(int i = 0; i < CCor.Length; i++)
            {
                if (CCor[i] != 0)
                {
                    message = message + CCor[i] + " ";
                }
                
            }
            Muestra.Content = message;
        }
        void TransversalB(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            int[] tv = new int[graph.lisN.Count];
            String savis = "Transversal por ";
            if (ele.SelectedIndex == 0)
            {
                tv = graph.transversalBFS2(graph.lisN[0]);
                savis = savis + "BFS: ";
            }
            else
            {
                tv = graph.transversalDFS2(graph.lisN[0]);
                savis = savis + "DFS: ";
            }

            for(int i = 0; i < tv.Length; i++)
            {
                if(tv[i] != 0)
                {
                    savis = savis + tv[i] + " ";
                }
                
            }

            Muestra.Content = savis;
        }
        void LargoB(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (Destino2.Text == null)
            {
                Muestra.Content = "Insertar nodo al que se quiere ir.";
                return;
            }
            int[] longPath = new int[10];
            String message1 = "Camino mas largo = ";
            for (int i = 0; i < graph.CaminoLar.Length; i++)
            {
                graph.CaminoLar[i] = 0;
            }

            for (int i = 0; i < graph.CaminoLar.Length; i++)
            {
                graph.CaminoLar[i] = 0;
            }
            foreach (Node node in graph.lisN)
            {
                if (Int16.Parse(Destino2.Text) == node.data)
                {
                    longPath = graph.larDef2(graph.lisN[0], node);
                    break;
                }
            }
            for (int i = 0; i < longPath.Length; i++)
            {
                if (longPath[i] != 0)
                {
                    message1 = message1 + longPath[i] + " ";
                }
            }
            Muestra.Content = message1;
        }


    }
}
