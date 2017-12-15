using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_283
{
    public class Nodo
    {
        public string user;
        public string pass;
        public Nodo next;
        public Nodo prev;
        public NodoCola acces;
        public NodoPila acces1;

        public Nodo(string user, string pass)
        {
            this.user = user;
            this.pass = pass;
            this.next = null;
            this.prev = null;
            this.acces = null;
            this.acces1 = null;
            
        }

    }
}
