using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_283
{
    class ListaCircular
    {

        private Nodo first;
        private Nodo last;
        private int size;
        private string text = "";

        public ListaCircular()
        {
            this.first = null;
            this.last = null;
            this.size = 0;
        }

        public bool isEmpty()
        {
            if (first == null)
            {
                return true;
            }

            return false;
        }

        public void add(string user, string pass)
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

        public Nodo search(string user, string pass)
        {
            Nodo aux = first;

            if (!isEmpty())
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


            return null;
        }

        public int Size()
        {
            return size;
        }


        public void print()
        {
            Nodo aux = first;
            Nodo aux2 = last;

            if (size == 1)
            {
                Console.WriteLine("<->" + aux.user);
                text = "\"" + aux.user + " /n " + aux.pass + "\"";
            }
            else
            {
                do
                {
                    Console.Write("<->" + aux.user);
                    text = text + "\"" + aux.user + " \\n " + aux.pass + "\"" + "->" + "\"" + aux.next.user + " \\n " + aux.next.pass + "\"" + Environment.NewLine;
                    aux = aux.next;
                } while (aux != first);

                do
                {
                    Console.Write("<->" + aux2.user);
                    text = text + "\"" + aux2.user + " \\n " + aux2.pass + "\"" + "->" + "\"" + aux2.prev.user + " \\n " + aux2.prev.pass + "\"" + Environment.NewLine;
                    aux2 = aux2.prev;
                } while (aux2 != last);

            }
            createDOT();
        }

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
            File.AppendAllText(path, "size = \"60\" " + Environment.NewLine);
            File.AppendAllText(path, "nodesep = 0.6" + Environment.NewLine);
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
    }

}
