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

        Cola cola;

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

        #region VacioQ
        private bool isEmptyQ()
        {
            if (front == null)
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
            Nodo aux2 = last;
            Nodo aux3 = first;
            Nodo aux4 = first;

            text = "";

            if (isEmpty())
            {
                text = "\"Lista de Usuarios Vacia\"";
            }
            else
            {
                if (size == 1)
                {
                    int inc = 1;
                    text = "ci " + "[label =\"" + aux.user + " \\n " + aux.pass + "\"]" + Environment.NewLine;

                    if (aux3.acces != null)
                    {
                        text = text + "subgraph cluster_0 {" + Environment.NewLine;
                        text = text + "ci" + inc + " [label =\"" + aux3.acces.col + " \\n " + aux3.acces.row + "\"]" + Environment.NewLine;
                        text = text + "ci" + "->" + "ci" + inc + Environment.NewLine;
                        do
                        {
                            inc++;
                            text = text + "ci" + inc + " [ label=\"" + aux3.acces.next.col + " \\n " + aux3.acces.next.row + "\"]" + Environment.NewLine;
                            text = text + "ci" + (inc - 1) + "->" + "ci" + inc + Environment.NewLine;
                            aux3.acces = aux3.acces.next;
                        } while (aux3.acces.next != null);
                        text = text + "label = \"cola del Usuario: " + aux.user + "\"";
                        text = text + "}";
                    }

                }
                else
                {
                    do
                    {
                        text = text + "\"" + aux.user + " \\n " + aux.pass + "\"" + "->" + "\"" + aux.next.user + " \\n " + aux.next.pass + "\"" + Environment.NewLine;
                        aux = aux.next;
                    } while (aux != first);

                    do
                    {
                        text = text + "\"" + aux2.user + " \\n " + aux2.pass + "\"" + "->" + "\"" + aux2.prev.user + " \\n " + aux2.prev.pass + "\"" + Environment.NewLine;
                        aux2 = aux2.prev;
                    } while (aux2 != last);

                    int co = 1;
                    int inc = 1;
                    do
                    {

                        if (aux4.acces != null)
                        {
                            text = text + "cola" + co + "[ label = \"" + aux4.acces.col + "\\n" + aux4.acces.row + "\"]" + Environment.NewLine;
                            text = text + "\"" + aux4.user + " \\n " + aux4.pass + "\"" + "->" + "cola" + co + " [constraint = false]" + Environment.NewLine;
                            co++;
                            text = text + "subgraph cluster_" + inc + "{" + Environment.NewLine;

                            do
                            {
                                text = text + "cola" + co + "[ label = \"" + aux4.acces.next.col + "\\n" + aux4.acces.next.row + "\"]" + Environment.NewLine;
                                text = text + "cola" + (co - 1) + "-> cola" + co + Environment.NewLine;
                                co++;
                                aux4.acces = aux4.acces.next;
                            } while (aux4.acces.next != null);
                            text = text + "color=blue" + Environment.NewLine;
                            text = text + "label = \"cola del Usuario: " + aux4.user + "\"" + Environment.NewLine;
                            text = text + "}" + Environment.NewLine;
                            inc++;
                        }

                        aux4 = aux4.next;
                    } while (aux4 != first);
                }
            }


            createDOT();
        }
        #endregion

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
