using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace Practica1_283
{
    public partial class Form1 : Form
    {
        ListaCircular lista = new ListaCircular();
        Matriz matriz = new Matriz();
        string Usuario;
        string Pasword;

        public Form1()
        {
            InitializeComponent();
            //tab.SelectTab(0);
            tabPage1.Parent = null;
            tabPage2.Parent = null;
            radioButton1.Checked = true;
            //txtNContrasena.Enabled = false;
            //txtNUsuario.Enabled = false;
            //btnRegistrar.Enabled = false;
            lista.add("a", "a");
            lista.add("b", "b");
            lista.add("c", "c");
            lista.add("d", "d");
            lista.add("e", "e");
            lista.add("f", "f");
            lista.add("g", "g");
            matriz.add(1, 2, 3);
            matriz.add(2, 1, 2);
            matriz.add(2, 3, 5);
            matriz.add(3, 2, 9);
            matriz.add(3, 4, 10);
            matriz.add(2, 4, 1);
            matriz.add(2, 2, 19);
            matriz.recorrerFilas();
            matriz.recorrerColumnas();

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

                if (user.Equals("abc") && pass.Equals("123"))
                {
                    tabPage2.Parent = tab;
                    login.Parent = null;
                }
                else if (en == null)
                {
                    MessageBox.Show(null, "El Usuario No Existe", "No Existe Usuario");
                }
                else
                {

                    tabPage1.Parent = tab;
                    Usuario = user;
                    Pasword = pass;
                    login.Parent = null;
                }
            }

            txtUsuario.Clear();
            txtContrasena.Clear();
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
            lista.delete(Usuario, Pasword);
            tabPage1.Parent = null;
            login.Parent = tab;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtNContrasena.Enabled = true;
            txtNUsuario.Enabled = true;
            btnRegistrar.Enabled = true;

            txtUsuario.Enabled = false;
            txtContrasena.Enabled = false;
            btnIngresar.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtNContrasena.Enabled = false;
            txtNUsuario.Enabled = false;
            btnRegistrar.Enabled = false;

            txtUsuario.Enabled = true;
            txtContrasena.Enabled = true;
            btnIngresar.Enabled = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            tabPage1.Parent = null;
            login.Parent = tab;
            Usuario = "";
            Pasword = "";
        }

        private void graficaCircularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista.createDOT();
            // Img i = new Img();
            // i.ShowDialog(this);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "JSON (*.json)|*.json";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                string readText = File.ReadAllText(path);
                JObject googleSearch = JObject.Parse(readText);
                try
                {
                    IList<JToken> results = googleSearch["archivo"]["cola"]["matrices"]["matriz"].Children().ToList();
                    IList<SearchResult> searchResults = new List<SearchResult>();
                    foreach (JToken result in results)
                    {
                        SearchResult searchResult = JsonConvert.DeserializeObject<SearchResult>(result.ToString());
                        searchResults.Add(searchResult);
                    }
                    foreach (SearchResult item in searchResults)
                    {
                        lista.enqueue(Usuario, Pasword, 0, item.size_x, item.size_y);
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

                try
                {
                    IList<JToken> results1 = googleSearch["archivo"]["pila"]["matrices"]["matriz"].Children().ToList();
                    IList<SearchResult> searchResults1 = new List<SearchResult>();
                    foreach (JToken result in results1)
                    {
                        SearchResult searchResult = JsonConvert.DeserializeObject<SearchResult>(result.ToString());
                        searchResults1.Add(searchResult);
                    }
                    foreach (SearchResult item in searchResults1)
                    {
                        lista.push(Usuario, Pasword, 0, item.size_x, item.size_y);
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }


    }
    public class SearchResult
    {
        public string Pila { get; set; }
        public string Cola { get; set; }
        public string Matrices { get; set; }
        public string Matriz { get; set; }
        public int size_x { get; set; }
        public int size_y { get; set; }
    }
}
