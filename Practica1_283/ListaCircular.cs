using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1_283
{
    class ListaCircular
    {

        private Nodo first;
        private Nodo last;
        private NodoCola front;
        private NodoCola final;
        private NodoPila top;
        

        private int size;
        private string text = "";

        public ListaCircular()
        {
            this.first = null;
            this.last = null;
            this.size = 0;
        }

        #region Vacio
        public bool isEmpty()
        {
            if (first == null)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region Agregar
        public void add(string user, string pass)
        {
            Nodo en = search(user, pass);

            if (en == null)
            {
                Nodo news = new Nodo(user, pass);

                if (isEmpty())
                {
                    first = news;
                    last = news;
                    first.prev = last;
                    last.next = first;
                    size++;
                }
                else
                {
                    news.prev = last;
                    last.next = news;
                    last = news;
                    last.next = first;
                    first.prev = last;
                    size++;
                }
            }
            else
            {
                MessageBox.Show(null,
                    "Usuario Ya registrado",
                    "Usuario no Ingresado");
            }
        }
        #endregion

        #region Encolar
        public void enqueue(string user, string pass, int date, int col, int row)
        {
            NodoCola news = new NodoCola(date, col, row);
            Nodo encontrado = search(user, pass);

            if (encontrado.acces == null)
            {
                front = news;
                final = news;
                encontrado.acces = front;
                encontrado.acces = final;
                
                //size++;
            }
            else
            {
                final.next = news;
                final = news;
                //size++;
            }
        }
        #endregion

        #region PUSH
        public void push(string user, string pass, int date, int col, int row)
        {
            NodoPila news = new NodoPila(date, col, row);
            Nodo Encontrado = search(user, pass);

            if (Encontrado.acces1 == null)
            {
                top = news;
                Encontrado.acces1 = top;
            }
            else
            {
                news.next = top;
                top = news;
                Encontrado.acces1 = top;
            }

        }
        #endregion

        #region Buscar
        public Nodo search(string user, string pass)
        {
            Nodo aux = first;

            if (isEmpty())
            {
                Console.WriteLine("La lista esta Vacia");
            }
            else
            {

                if (size == 1)
                {
                    if (first.user.Equals(user) && first.pass.Equals(pass))
                    {
                        return aux;
                    }
                    return null;
                }
                else
                {
                    do
                    {
                        if (aux.user.Equals(user) && aux.pass.Equals(pass))
                        {
                            return aux;
                        }

                        aux = aux.next;
                    } while (aux != first);

                }

            }
            return null;
        }
        #region Eliminar
        public void delete(string user, string pass)
        {
            Nodo aux = first;

            if (isEmpty())
            {
                Console.WriteLine("La lista esta Vacia");
            }
            else
            {

                if (size == 1)
                {
                    if (first.user.Equals(user) && first.pass.Equals(pass))
                    {
                        first = null;
                        last = null;
                    }
                }
                else
                {
                    do
                    {
                        if (aux.user.Equals(user) && aux.pass.Equals(pass))
                        {
                            if (aux == first)
                            {
                                first = aux.next;
                                first.prev = last;
                                last.next = first;
                                size--;
                            }
                            else if (aux == last)
                            {
                                last = aux.prev;
                                last.next = first;
                                first.prev = last;
                                size--;
                            }
                            else
                            {
                                aux.prev.next = aux.next;
                                aux.next.prev = aux.prev;
                                size--;
                            }
                        }

                        aux = aux.next;
                    } while (aux != first);

                }

            }
        }
        #endregion
        #endregion

        #region tama;o
        public int Size()
        {
            return size;
        }
        #endregion

        #region Imprimir
        public void print()
        {
            Nodo aux = first;
            text = "";

            if (isEmpty())
            {
                text = "\"Lista de Usuarios Vacia\"";
            }
            else
            {
                //Grafica de la lista Circular
                text = text + "subgraph cluster_lc {" + Environment.NewLine;
                text = text + "node [margin=0 fontname=Marvel fontsize=14 width=0.5 shape=rectangle ]" + Environment.NewLine;
                do
                {
                    text = text + "\"" + aux.user + " \\n " + aux.pass + "\"" + "->" + "\"" + aux.next.user + " \\n " + aux.next.pass + "\" [dir = \"both\"]" + Environment.NewLine;
                    aux = aux.next;
                } while (aux != first);
                text = text + "color=green" + Environment.NewLine;
                text = text + "label = \"Lista Circular de Usuario\"" + Environment.NewLine;
                text = text + "}" + Environment.NewLine;

                printCola();
                printPila();
            }
            //createDOT();
        }
        #endregion

        public void printCola()
        {
            Nodo aux = first;

            int co = 1;
            int inc = 1;
            do
            {
                if (aux.acces != null)
                {
                    text = text + "cola" + co + "[ label = \"" + aux.acces.col + "\\n" + aux.acces.row + "\"]" + Environment.NewLine;
                    text = text + "\"" + aux.user + " \\n " + aux.pass + "\"" + "->" + "cola" + co + " [constraint = false]" + Environment.NewLine;
                    co++;
                    text = text + "subgraph cluster_c" + inc + "{" + Environment.NewLine;
                    do
                    {
                        text = text + "cola" + co + "[ label = \"" + aux.acces.next.col + "\\n" + aux.acces.next.row + "\"]" + Environment.NewLine;
                        text = text + "cola" + (co - 1) + "-> cola" + co + Environment.NewLine;
                        co++;
                        aux.acces = aux.acces.next;
                    } while (aux.acces.next != null);
                    text = text + "color=blue" + Environment.NewLine;
                    text = text + "label = \"cola del Usuario: " + aux.user + "\"" + Environment.NewLine;
                    text = text + "}" + Environment.NewLine;
                    inc++;
                }
                aux = aux.next;
            } while (aux != first);
        }


        public void printPila()
        {
            Nodo aux = first;

            int inc = 1;
            int pi = 1;
            do
            {
                if (aux.acces1 != null)
                {
                    text = text + "pila" + pi + "[ label = \"" + aux.acces1.col + "\\n" + aux.acces1.row + "\"]" + Environment.NewLine;
                    text = text + "\"" + aux.user + " \\n " + aux.pass + "\"" + "->" + "pila" + pi + " [constraint = false]" + Environment.NewLine;
                    pi++;
                    text = text + "subgraph cluster_p" + inc + "{" + Environment.NewLine;
                    do
                    {
                        text = text + "pila" + pi + "[ label = \"" + aux.acces1.next.col + "\\n" + aux.acces1.next.row + "\"]" + Environment.NewLine;
                        text = text + "pila" + (pi - 1) + "-> pila" + pi + " [constraint = false]" + Environment.NewLine;
                        pi++;
                        aux.acces1 = aux.acces1.next;
                    } while (aux.acces1.next != null);
                    text = text + "color=red" + Environment.NewLine;
                    text = text + "label = \"pila del Usuario: " + aux.user + "\"" + Environment.NewLine;
                    text = text + "}" + Environment.NewLine;
                    inc++;
                }
            } while (aux != first);
        }

        #region CrearDOT
        public void createDOT()
        {
            string path = @"../../img/ListaCircular.dot";

            //This text is added only once to the file.
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.AppendAllText(path, "digraph listaUsuarios {" + Environment.NewLine);
            File.AppendAllText(path, "rankdir = LR" + Environment.NewLine);
            File.AppendAllText(path, "size = \"100,100\" " + Environment.NewLine);
            File.AppendAllText(path, "nodesep = 0.6" + Environment.NewLine);
            File.AppendAllText(path, "splines=ortho" + Environment.NewLine);
            File.AppendAllText(path, "fontname = Marvel" + Environment.NewLine);
            print();
            File.AppendAllText(path, text + Environment.NewLine);
            File.AppendAllText(path, "}");

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            string executable = @"dot.exe";
            // Stop the process from opening a new window
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            // Setup executable and parameters
            process.StartInfo.FileName = executable;
            process.StartInfo.Arguments = string.Format(@"{0} -Tjpg -O", path);

            // Go
            process.Start();
            // and wait dot.exe to complete and exit
            process.WaitForExit();
            //// Open the file to read from.
            //string readText = File.ReadAllText(path);
            //Console.WriteLine(readText);
        }
        #endregion
    }

}
