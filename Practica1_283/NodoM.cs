using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_283
{
    public class NodoM
    {
        public int fila;
        public int columna;
        public int valor;
        public NodoM derecha;
        public NodoM izquierda;
        public NodoM arriba;
        public NodoM abajo;

        public NodoM(int fila, int columna, int valor)
        {
            this.fila = fila;
            this.columna = columna;
            this.valor = valor;
            this.derecha = null;
            this.izquierda = null;
            this.arriba = null;
            this.arriba = null;
        }
    }

    public class NodoE
    {
        public int id;
        public NodoE siguiente;
        public NodoE anterior;
        public NodoM acceso;
        public NodoE(int id)
        {
            this.id = id;
            this.siguiente = null;
            this.anterior = null;
            this.acceso = null;
        }
    }

    public class listaEncabezados
    {
        public NodoE primero;

        public void insertar(NodoE nuevo)
        {
            if (primero == null)
            {
                primero = nuevo;
            }
            else
            {
                if (nuevo.id < primero.id)//inserto al inicio
                {
                    nuevo.siguiente = primero;
                    primero.anterior = nuevo;
                    primero = nuevo;
                }
                else
                {
                    NodoE actual = primero;

                    while (actual.siguiente != null)
                    {
                        if (nuevo.id < actual.siguiente.id)//insertar al medio
                        {
                            nuevo.siguiente = actual.siguiente;
                            actual.siguiente.anterior = nuevo;
                            nuevo.anterior = actual;
                            actual.siguiente = nuevo;
                            break;
                        }
                        actual = actual.siguiente;
                    }

                    if (actual.siguiente == null) // insertar al final
                    {
                        actual.siguiente = nuevo;
                        nuevo.anterior = actual;
                    }
                }
                
            }
        }

        public NodoE getEncabezado(int val)
        {
            NodoE actual = primero;

            while (actual != null)
            {
                if (actual.id.Equals(val))
                {
                    return actual;
                }
                actual = actual.siguiente;
            }
            return null;
        }

    }


}
