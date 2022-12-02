using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TreePactice
{
    public class ArbolConf
    {
        public Nullable <int>[] OrdLista = new Nullable <int>[15];
        public int gu = 1;
        public int guT = 0;
        public String [] tamaño = new String [10];
        public String[] linea = new String[10];
        public int ar = 0;
        public bool iz;
        public bool de;

       
        public int[] NodosG = new int [1];
        public bool ValorU = false;

        public Nullable<int>[] ILis = new Nullable<int>[16];
        public List<Nullable<int>[]> ILT = new List<Nullable<int>[]>();
        public int depness = 0;
        public bool x = false;
        public int diagonalLineSpaces = 0;
        public int arrayPosition = 0;
    }
    
    internal class Node
    {
        public Nullable <int> data = null;
        public Node elementLeft = null;
        public Node elementRight = null;
        int depnessX;
        private int save;

        
        public Node(int nodeData)
        {
            listOfNodes.ValorU = true;
            for (int i = 0; i < listOfNodes.NodosG.Length; i++)
            {
                if (nodeData == listOfNodes.NodosG[i])
                {
                    listOfNodes.ValorU = false;
                    break;
                }
            }
            if (listOfNodes.ValorU == true)
            {
                data = nodeData;
            }
            else
            {
                Console.WriteLine("You cannot add a non-unique value");
            }
            
        }
        ArbolConf listOfNodes = new ArbolConf();

        
        public void met(Node newNode) { 
            if (newNode != null)
            {
                if (elementLeft == null)
                {
                    elementLeft = newNode;
                }
            }
        
        }
        public void met(Node newNode, string direction)
        {
            if (newNode.data != null)
            {
                if (direction == "iz")
                {
                    if (elementLeft == null)
                    {
                        elementLeft = newNode;
                    }

                }
                else if (direction == "de")
                {
                    if (elementRight == null)
                    {
                        elementRight = newNode;
                    }

                }
            }
            else
            {
                Console.WriteLine("You cannot add an invalid node.");            }
        }
        public void quita()
        {

            if (elementLeft != null) 
            {
                elementLeft.quita();
                elementLeft = null;
            }
            if (elementRight != null)
            {
                elementRight.quita();
                elementRight = null;
            }
            data = null;
            
        }

       
        public void QuitF(Node node)
        {
            QuitD(node);
            if (node == this.elementLeft)
            {
                Console.WriteLine("xdd");
                elementLeft = null;
            }
            else if (node == this.elementRight)
            {
                Console.WriteLine("xdd");
                elementRight = null;
            }
        }
        public void QuitD(Node node)
        {
            if (node.elementLeft != null)
            {
                node.elementLeft.QuitD(node.elementLeft);
                node.elementLeft = null;
            }
            if (node.elementRight != null)
            {
                node.elementRight.QuitD(node.elementRight);
                node.elementRight = null;
            }

            node.data = null;
        }
        
        public void buscar(int nodeNumber)
        {
            Console.WriteLine();
            if (1 == buscar(this, nodeNumber))
            {
                Console.WriteLine("buscar result: Yes, there is the node number " + nodeNumber + ".");
            }
            else 
            {
                Console.WriteLine("buscar result: Jajajaja there isn't the node number " + nodeNumber + ".");
            }
            
        }
        public Nullable<int> buscar(Node node, int nodeNumber)
        {
            if (node.data == null)
            {
                return null;
            }
            for (int i = 1; i < 4; i++)
            {
                if (i == 1)
                {
                    if (node.elementLeft != null)
                    {
                        if (1 == buscar(node.elementLeft, nodeNumber))
                        {
                            return 1;
                        }
                    }

                }
                else if (i == 2)
                {
                    if (nodeNumber == node.data)
                    {
                        return 1;
                    }
                }
                else if (i == 3)
                {
                    if (node.elementRight != null)
                    {
                        if (1 == buscar(node.elementRight, nodeNumber))
                        {
                            return 1;
                        }
                    }

                }
            }
            return null;
        }
        public bool BuscR(int nodeNumber)
        {
            Console.WriteLine();
            if (1 == buscar(this, nodeNumber))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public Node BuscCret(int nodeNumber)
        {
            Node node = BuscCret(this, nodeNumber);
            
            return node;
        }
        public Node BuscCret(Node node, int nodeNumber)
        {
            if (node.data == null)
            {
                return null;
            }
            if (node.data == nodeNumber)
            {
                Node find = node;
                return find;
            }

            if (node.elementLeft != null)
            {
                if (null != BuscCret(node.elementLeft, nodeNumber))
                {
                    Node find = BuscCret(node.elementLeft, nodeNumber);
                    return find;
                }
            }

            if (node.elementRight != null)
            {
                if (null != BuscCret(node.elementRight, nodeNumber))
                {
                    Node find = BuscCret(node.elementRight, nodeNumber);
                    return find;
                }
            }
 
            return null;
        }
        public void TransversalU(string type)
        {
            
            TransversalU(this, type);

            Console.WriteLine();
            Console.Write("Transversed tree: (");
            for(int i=0;i < listOfNodes.OrdLista.Length;i++)
            {
                if (listOfNodes.OrdLista[i] != null)
                {
                    if (i == 0)
                    {
                        Console.Write(listOfNodes.OrdLista[i]);
                    }
                    else
                    {
                        Console.Write(", " + listOfNodes.OrdLista[i]);
                    }
                }
            }
            Console.Write(")");
            Console.WriteLine();
        }
        public int?[] TransversalOr(string type)
        {
           
            for(int i = 0; i < listOfNodes.OrdLista.Length;i++)
            {
                listOfNodes.OrdLista[i] = null;
            }
            TransversalU(this, type);
            return listOfNodes.OrdLista;

        }
        public void TransversalU(Node node,string type)
        {
            if (node.data == null)
            {
                return;
            }
         
            if (type == "inorder")
            {
                for (int i = 1; i < 4; i++)
                {
                    if (i == 1)
                    {
                        if (node.elementLeft != null)
                        {
                            TransversalU(node.elementLeft, "inorder");
                        }

                    }
                    else if (i == 2)
                    {
                        for (int k = 0; k < listOfNodes.OrdLista.Length; k++)
                        {
                            if (listOfNodes.OrdLista[k] == null)
                            {
                                listOfNodes.OrdLista[k] = node.data;
                                break;
                            }
                        }
                    }
                    else if (i == 3)
                    {
                        if (node.elementRight != null)
                        {
                            TransversalU(node.elementRight,"inorder");
                        }

                    }

                }
            }
        
            else if(type == "preorder")
            {
                for (int i = 1; i < 4;i++)
                {
                    if (i==1)
                    {
                        for (int k = 0; k < listOfNodes.OrdLista.Length; k++)
                        {
                            if (listOfNodes.OrdLista[k] == null)
                            {
                                listOfNodes.OrdLista[k] = node.data;
                                break;
                            }
                        }
                    } 
                    else if (i == 2)
                    {
                        if (node.elementLeft != null)
                        {
                            TransversalU(node.elementLeft, "preorder");
                        }
                        
                    }
                    else if(i == 3)
                    {
                        if(node.elementRight != null)
                        {
                            TransversalU(node.elementRight, "preorder");
                        }
                    }
                }
            } 
            
            else if(type == "postorder")
            {
                for (int i = 1; i < 4;i++)
                {
                    if (i == 1)
                    {
                        if (node.elementLeft != null)
                        {
                            TransversalU(node.elementLeft, "postorder");
                        }
                    }
                    else if(i == 2)
                    {
                        if (node.elementRight != null)
                        {
                            TransversalU(node.elementRight, "postorder");
                        }
                    }
                    else if (i == 3)
                    {
                        for (int k = 0; k < listOfNodes.OrdLista.Length; k++)
                        {
                            if (listOfNodes.OrdLista[k] == null)
                            {
                                listOfNodes.OrdLista[k] = node.data;
                                break;
                            }
                        }
                    }
                }
            }
        }
        public void Al()
        {
            Al(this);
            Console.WriteLine();
            Console.WriteLine("Your tree have "+ listOfNodes.guT + " tamaño.");
        }
        public int AlR()
        {
            Al(this);
            return listOfNodes.guT;
        }
        public void Al(Node node)
        {
            for (int i = 2; i < 4; i++)
            {
                if (i == 2)
                {
                    if (node.elementLeft != null)
                    {
                        listOfNodes.gu = listOfNodes.gu + 1;
                        if (listOfNodes.gu > listOfNodes.guT)
                        {
                            listOfNodes.guT = listOfNodes.gu;
                        }
                        Al(node.elementLeft);
                        listOfNodes.gu = listOfNodes.gu - 1;
                    }

                }
                else if (i == 3)
                {
                    if (node.elementRight != null)
                    {
                        listOfNodes.gu = listOfNodes.gu + 1;
                        if (listOfNodes.gu > listOfNodes.guT)
                        {
                            listOfNodes.guT = listOfNodes.gu;
                        }
                        Al(node.elementRight);
                        listOfNodes.gu = listOfNodes.gu - 1;
                    }
                }
            }
        }
        public void MArbol()
        {
            Console.WriteLine("      "+this.data+"       ");
            Console.Write("     ");
            if (this.elementLeft.data != null)
            {
                Console.Write("/");
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write(" ");
            if (this.elementRight.data != null)
            {
                Console.Write("\\");
            }


            Console.WriteLine("");
            Console.Write("    ");
            if (elementLeft.data != null)
            {
                Console.Write(elementLeft.data);
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write("   ");
            if (elementRight.data != null)
            {
                Console.Write(elementRight.data);
            }

            Console.WriteLine("");
            Console.Write("   ");
            if(elementLeft.elementLeft.data != null)
            {
                Console.Write("/");
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write(" ");
            if(this.elementLeft.elementRight.data != null)
            {
                Console.Write("\\");
            }
            Console.Write(" ");
            if (elementRight.elementLeft.data != null)
            {
                Console.Write("/");
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write(" ");
            if (elementRight.elementRight.data != null)
            {
                Console.Write("\\");
            }

            Console.WriteLine();
            Console.Write("  ");
            if(elementLeft.elementLeft.data != null)
            {
                Console.Write(elementLeft.elementLeft.data);
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write("  ");
            if(elementLeft.elementRight.data != null)
            {
                Console.Write(elementLeft.elementRight.data);
            }
            if(elementRight.elementLeft.data != null)
            {
                Console.Write(elementRight.elementLeft.data);
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write("   ");
            if(elementRight.elementRight.data != null)
            {
                Console.Write(elementRight.elementRight.data);
            }

            Console.WriteLine();
            Console.Write(" ");
            if(elementLeft.elementLeft.elementLeft.data != null)
            {
                Console.Write("/");
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write(" ");
            if(elementLeft.elementLeft.elementRight.data != null)
            {
                Console.Write("\\");
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write("     ");
            if (elementRight.elementRight.elementLeft.data != null)
            {
                Console.Write("/");
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write(" ");
            if (elementRight.elementRight.elementRight.data != null)
            {
                Console.Write("\\");
            }

            Console.WriteLine("");
            if(elementLeft.elementLeft.elementLeft.data != null)
            {
                Console.Write(elementLeft.elementLeft.elementLeft.data);
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write("   ");
            if (elementLeft.elementLeft.elementRight.data != null)
            {
                Console.Write(elementLeft.elementLeft.elementRight.data);
            }
            Console.Write("   ");
            if(elementRight.elementRight.elementLeft.data != null)
            {
                Console.Write(elementRight.elementRight.elementLeft.data);
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write("  ");
            if (elementRight.elementRight.elementRight.data != null)
            {
                Console.Write(elementRight.elementRight.elementRight.data);
            }
            
        }
        public void MArbol2()
        {
       
            MArbol2(this);

            
            depnessX = -1;

           
            for (int i = 0; i < listOfNodes.tamaño.Length; i++)
            {
                
               
                for (int k = 0; k< AlR()+depnessX;k++)
                {
                    Console.Write("  ");
                }
                

                
                if (listOfNodes.tamaño[i] != null)
                {
                    for (int k = 0; k< listOfNodes.tamaño[i].Length;k++)
                    {
                        Console.Write(listOfNodes.tamaño[i][k]+" ");
                    }
                }
                Console.WriteLine();

                
                for (int l = 0; l < AlR()+ depnessX; l++)
                {
                    if (l == AlR()+depnessX-1)
                    {
                        for (int k = 0; k < listOfNodes.tamaño[l].Length; k++)
                        {
                            if(Char.ToString(listOfNodes.tamaño[l][k]) != " ")
                            {
                               
                                
                            }
                            
                        }
                        
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                depnessX = depnessX - 1;
               
                Console.WriteLine();
            }
        }
        public void MArbol2(Node node)
        {
            if (listOfNodes.iz==true)
            {
                listOfNodes.tamaño[listOfNodes.ar] = listOfNodes.tamaño[listOfNodes.ar] + " ";
            } else if (listOfNodes.de == true){
                listOfNodes.tamaño[listOfNodes.ar] = listOfNodes.tamaño[listOfNodes.ar] + " ";
            }
            listOfNodes.tamaño[listOfNodes.ar] = listOfNodes.tamaño[listOfNodes.ar] + node.data;
            listOfNodes.iz = false;
            listOfNodes.de = false;
            node.AlR();
            if (node.elementLeft != null)
            {
                listOfNodes.ar = listOfNodes.ar + 1;
                MArbol2(node.elementLeft);
            }
            else
            {
                listOfNodes.iz = true;
            }
            if (node.elementRight != null)
            {
                listOfNodes.ar = listOfNodes.ar + 1;
                MArbol2(node.elementRight);
            }
            else
            {
                listOfNodes.de = true;
            }
            listOfNodes.ar = listOfNodes.ar - 1;
        }
        public void MArbD()
        {
            for (int i = 0; i < AlR()+1;i++)
            {
                Nullable<int>[] intList2 = new Nullable<int>[15];
                listOfNodes.ILT.Add(intList2);

            }

            MArbD(this);

            bool exchange = false;
            for (int level = 0; level < AlR(); level++)
            {
                
                for (int k = 0; k < AlR() - listOfNodes.diagonalLineSpaces + 1; k++)
                {
                    Console.Write("  ");
                }
                while (listOfNodes.ILT[level][listOfNodes.arrayPosition] != null)
                {
                    if (exchange == false)
                    {
                        Console.Write("(");
                        Console.Write(listOfNodes.ILT[level][listOfNodes.arrayPosition] + ", ");
                        exchange = true;
                    }
                    else
                    {
                        Console.Write(listOfNodes.ILT[level][listOfNodes.arrayPosition]+") ");
                        exchange = false;
                    }
                    
                    listOfNodes.arrayPosition++;
                }
                Console.WriteLine();
                Console.WriteLine();
                listOfNodes.arrayPosition = 0;
                listOfNodes.diagonalLineSpaces = listOfNodes.diagonalLineSpaces + 1;
            }
            }

        public void printDiagonals(Node node)
        {
            Console.WriteLine(node.AlR());
            for (int i = 0; i < node.AlR();i++)
            {

            }
        }
        public bool Reg(Node node, string side)
        {
            if (side == "de")
            {
                if (node.elementRight != null)
                {
                    return true;
                }
            }
            if (side == "iz")
            {
                if (node.elementLeft != null)
                {
                    return true;
                }
            }
            return false;
        }
        public void MArbD(Node node)
        {
            if (node.elementLeft != null)
            {
                listOfNodes.depness = listOfNodes.depness + 1;
                MArbD(node.elementLeft);
                listOfNodes.depness = listOfNodes.depness - 1;
            }
            else
            {
                listOfNodes.depness = listOfNodes.depness + 1;

                int h = 0;
                while (listOfNodes.x == false)
                {
                    if (listOfNodes.ILT[listOfNodes.depness][h] == null)
                    {
                        listOfNodes.ILT[listOfNodes.depness][h] = 0;
                        listOfNodes.x = true;
                    }
                    h = h + 1;
                }
                listOfNodes.x = false;

                listOfNodes.depness = listOfNodes.depness - 1;
            }
            
            
            if (node.elementRight != null)
            {
                listOfNodes.depness = listOfNodes.depness + 1;
                MArbD(node.elementRight);
                listOfNodes.depness = listOfNodes.depness - 1;
            }
            else
            {
                listOfNodes.depness = listOfNodes.depness + 1;

                int h = 0;
                while (listOfNodes.x == false)
                {
                    if (listOfNodes.ILT[listOfNodes.depness][h] == null)
                    {
                        listOfNodes.ILT[listOfNodes.depness][h] = 0;
                        listOfNodes.x = true;
                    }
                    h = h + 1;
                }
                listOfNodes.x = false;

                listOfNodes.depness = listOfNodes.depness - 1;
            }

            int p = 0;
            while (listOfNodes.x == false)
            {
                if (listOfNodes.ILT[listOfNodes.depness][p] == null)
                {
                    listOfNodes.ILT[listOfNodes.depness][p] = node.data;
                    listOfNodes.x = true;
                }
                p = p + 1;

            }
            listOfNodes.x = false;
            
        }
    }
}
