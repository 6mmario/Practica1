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
        public int col;
        public int row;
        public NodoCola next;


        public NodoCola(int date, int col, int row)
        {
            this.date = date;
            this.col = col;
            this.row = row;
            this.next = null;
        }
    }
}
