using Avalonia.Controls;
using System;
using System.Collections.Generic;
using TreePactice;

namespace PracticaInt.Views
{
    public partial class ArbolV : Window
    {
        List<Node> ArbolNodos = new List<Node>();
        public ArbolV()
        {
            InitializeComponent();
            ArbolNodos.Add(new Node(1));
            Console.WriteLine("teste");
        }
        void VolverArB (object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Principal x = new Principal();
            x.Show();
            this.Close();
        }
        void Nododeo(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            bool check = true;
            
            if (NodoPa.Text == null || NodoPa.Text == "")
            {
                Mostrar2.Content = "Debe seleccionar un nodo padre para añadir un nuevo nodo.";
                return;
            }
            if (ANodoN.Text == null || ANodoN.Text == "")
            {
                Mostrar2.Content = "Si desea crear un nuevo nodo, debe insertarlo en el cuadro de texto.";
                return;
            }

            Node node = new Node(Int16.Parse(ANodoN.Text));
            
            foreach (Node node2 in ArbolNodos)
            {
                if(Int16.Parse(ANodoN.Text) == node2.data)
                {
                    Mostrar2.Content = "El nodo ya existe.";
                    return;
                }
                
            }
            foreach (Node node2 in ArbolNodos)
            {
                if (Int16.Parse(NodoPa.Text) == node2.data)
                {
                    if (0 == LadoArb.SelectedIndex)
                    {
                        if(node2.elementLeft != null)
                        {
                            Mostrar2.Content = "El elemento izquierdo de padre ya tiene un nodo.";
                            return;
                        }
                    }
                    else
                    {
                        if (node2.elementRight != null)
                        {
                            Mostrar2.Content = "El elemento derecho del padre ya tiene un nodo.";
                            return;
                        }
                    }
                }

            }

            foreach (Node node2 in ArbolNodos)
            {
                if (node2.data == Int16.Parse(NodoPa.Text))
                {
                    
                    if (0 == LadoArb.SelectedIndex)
                    {
                        
                        ArbolNodos.Add(node);
                        node2.met(node);
                        Mostrar2.Content = "Nodo "+ ANodoN.Text + " añadido con éxito a la izquierda de " + NodoPa.Text;
                        break;
                    }
                    else
                    {
                        ArbolNodos.Add(node);
                        node2.met(node, "a la derecha");

                        Mostrar2.Content = "Nodo "+ ANodoN.Text + " añadido con éxito a la derecha de " + NodoPa.Text;
                        break;
                    }
                    
                }
            }

        }
        void ArEliminarB(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if(1 == Int16.Parse(ArNodoEl.Text))
            {
                Mostrar2.Content = "No se puede eliminar el nodo principal.";
                return;
            }
            foreach(Node node in ArbolNodos)
            {
                if(node.data == Int16.Parse(ArNodoEl.Text))
                {
                    ArbolNodos[0].QuitF(node);
                    ArbolNodos.Remove(node);
                    Mostrar2.Content = "Nodo eliminado con éxito.";
                    return;
                }
            }
            Mostrar2.Content = "Nodo que ha intentado borrar no encontrado.";

        }
        void AltoB(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            AlNodo.Content = ArbolNodos[0].AlR();
            if("0" == AlNodo.Content.ToString())
            {
                AlNodo.Content = "1";
            }
        }
        void TransversalAr(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            int?[] list1 = new int?[15];
            for(int i = 0; i < list1.Length; i++)
            {
                list1[i] = 0;
            }
            String save = "Árbol transversal: (";

            if (TransversalOrden.SelectedIndex == 0)
            {
                list1 = ArbolNodos[0].TransversalOr("inorder");

            } 
            else if (TransversalOrden.SelectedIndex == 1)
            {
                list1 = ArbolNodos[0].TransversalOr("preorder");
            }
            else
            {
                list1 = ArbolNodos[0].TransversalOr("postorder");
            }

            for (int i = 0; i < list1.Length; i++)
            {
                if (list1[i] != null)
                {
                    if (i == 0)
                    {
                        save = save + list1[i];
                    }
                    else
                    {
                        save = save + ", " + list1[i];
                    }
                }
            }
            save = save + ")";
            Mostrar2.Content = save;
        }
        void ArBuscar(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (ArbolNodos[0].BuscR(Int16.Parse(NodoBus.Text)) == true)
            {
                Mostrar2.Content = "El nodo " + NodoBus.Text + " SI esta en el árbol.";
            }
            else
            {
                Mostrar2.Content = "El nodo " + NodoBus.Text + " NO esta en el árbol.";
            }
        }
    }
}
