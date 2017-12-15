using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_283
{
    public class Matriz
    {

        listaEncabezados eFilas = new listaEncabezados();
        listaEncabezados eColumnas = new listaEncabezados();


        public void add(int fila, int columna, int dato)
        {
            NodoM news = new NodoM(fila, columna, dato);

            //insersersion filas
            NodoE eFila = eFilas.getEncabezado(fila);
            if (eFila == null) //Si no existe encabezado se crea.
            {
                eFila = new NodoE(fila);
                eFilas.insertar(eFila);
                eFila.acceso = news;
            }
            else
            {
                if (news.columna < eFila.acceso.columna)//inserto al inicio
                {
                    news.derecha = eFila.acceso;
                    eFila.acceso.izquierda = news;
                    eFila.acceso = news;
                }
                else
                {
                    NodoM actual = eFila.acceso;
                    while (actual.derecha != null)
                    {
                        if (news.columna < actual.derecha.columna)// insertar enmedio
                        {
                            news.derecha = actual.derecha;
                            actual.derecha.izquierda = news;
                            news.izquierda = actual;
                            actual.derecha = news;
                            break;
                        }
                        actual = actual.derecha;
                    }

                    if (actual.derecha == null)//inserto al final
                    {
                        actual.derecha = news;
                        news.izquierda = actual;
                    }
                }
            }

            //fin de las filas

            //insercion COlumans
            NodoE eColumna = eColumnas.getEncabezado(columna);
            if (eColumna == null)
            {
                eColumna = new NodoE(columna);
                eColumnas.insertar(eColumna);
                eColumna.acceso = news;
            }
            else
            {
                if (news.fila < eColumna.acceso.fila)//inserto al inicio
                {
                    news.abajo = eColumna.acceso;
                    eColumna.acceso.arriba = news;
                    eColumna.acceso = news;
                }
                else
                {
                    NodoM actual = eColumna.acceso;
                    while (actual.abajo != null)
                    {
                        if (news.fila < actual.abajo.fila)//insertar al medio
                        {
                            news.abajo = actual.abajo;
                            actual.abajo.arriba = news;
                            news.arriba = actual;
                            actual.abajo = news;
                            break;
                        }
                        actual = actual.abajo;
                    }

                    if (actual.abajo == null)//inserto al fial
                    {
                        actual.abajo = news;
                        news.arriba = actual;
                    }
                }
            }
            //fin de las columnas
        }

        public void recorrerFilas()
        {
            NodoE eFila = eFilas.primero;
            Console.WriteLine("Recorrido por Filas: ");

            while (eFila != null)
            {
                NodoM actual = eFila.acceso;
                while (actual != null)
                {
                    Console.Write(actual.valor);

                    if (eFila.siguiente != null || actual.derecha != null)
                    {
                        Console.Write("->");
                    }

                    actual = actual.derecha;
                }
                eFila = eFila.siguiente;
            }
            Console.WriteLine(Environment.NewLine + "Fin");
        }

        public void recorrerColumnas()
        {
            NodoE eColumna = eColumnas.primero;
            Console.WriteLine("Recorrido por Columnas: ");
            while (eColumna != null)
            {
                NodoM actual = eColumna.acceso;
                while (actual !=null)
                {
                    Console.Write(actual.valor);
                    if (eColumna.siguiente != null || actual.abajo != null)
                    {
                        Console.Write("->");
                    }
                    actual = actual.abajo;
                }
                eColumna = eColumna.siguiente;
            }
            Console.WriteLine(Environment.NewLine + "fin");
        }

    }
}