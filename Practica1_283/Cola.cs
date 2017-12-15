using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Practica1_283
{
    public class Cola
    {
        private NodoCola front;
        private NodoCola final;
        private int size;

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

        #region Encolar
        public void enqueue(int date, int col, int row)
        {
            NodoCola news = new NodoCola(date, col, row);

            if (isEmptyQ())
            {
                front = news;
                final = news;
                size++;
            }
            else
            {
                final.next = news;
                final = news;
                size++;
            }
        }
        #endregion

        public void dequeue()
        {
            NodoCola aux = front;
            if (isEmptyQ())
            {
                MessageBox.Show(null, "Cola Vacia", "Pila Vacia");
            }
            else
            {
                if (aux == final)
                {
                    front = null;
                    final = null;
                }
                else
                {
                    front = front.next;
                }
            }
        }
    }
}
