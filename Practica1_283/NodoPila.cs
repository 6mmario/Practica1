using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_283
{
    public class NodoPila
    {
        public int date;
        public int col;
        public int row;
        public NodoPila next;

        public Matriz ma;

        public NodoPila(int date, int col, int row)
        {
            this.date = date;
            this.col = col;
            this.row = row;
            this.next = null;
            this.ma = null;
        }
    }
}
