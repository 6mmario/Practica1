using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_283
{
    public class NodoCola
    {
        public int date;
        public NodoCola next;

        public NodoCola(int date)
        {
            this.date = date;
            this.next = null;
        }
    }
}
