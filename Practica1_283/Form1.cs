using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1_283
{
    public partial class Form1 : Form
    {
        ListaCircular lista = new ListaCircular();
        string Usuario;
        string Pasword;
       
        public Form1()
        {
            InitializeComponent();
            tab.SelectTab(0);
            tabPage1.Parent = null;
            
            
        }

        #region Registrar
        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            string user = txtNUsuario.Text;
            string pass = txtNContrasena.Text;

            if (validar(2))
            {
                lista.add(user, pass);
            }

            txtNUsuario.Clear();
            txtNContrasena.Clear();
        }
        #endregion
        #region Ingresar
        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            string user = txtUsuario.Text;
            string pass = txtContrasena.Text;

            if (validar(1))
            {
                Nodo en = lista.search(user, pass);

                if (en == null)
                {
                    MessageBox.Show(null, "El Usuario No Existe", "No Existe Usuario");
                }
                else
                {
                    tabPage1.Parent =  tab;
                    Usuario = user;
                    Pasword = pass;
                    login.Parent = null;
                }
            }
        }
        #endregion
        #region Validar
        private bool validar(int op)
        {
            string Usuario = txtUsuario.Text;
            string Contrasena = txtContrasena.Text;
            string UsuarioN = txtNUsuario.Text;
            string ContrasenaN = txtNContrasena.Text;

            switch (op)
            {
                case 1:
                    if (Usuario.Equals("") || Contrasena.Equals(""))
                    {
                        MessageBox.Show(null, "Faltan datos para Logiar Usuario", "Error!!!");
                        return false;
                    }
                    return true;
                case 2:
                    if (UsuarioN.Equals("") || ContrasenaN.Equals(""))
                    {
                        MessageBox.Show(null, "Faltan Datos para Ingresar Nuevo Usuario", "Error!!!");
                        return false;
                    }
                    return true;

            }
            return false;
        }
        #endregion       

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(null, Usuario + "-" + Pasword, "Datos");
        }


    }
}
